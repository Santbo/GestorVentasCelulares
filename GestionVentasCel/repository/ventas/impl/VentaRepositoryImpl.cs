using GestionVentasCel.data;
using GestionVentasCel.enumerations.cuentaCorriente;
using GestionVentasCel.enumerations.reparacion;
using GestionVentasCel.enumerations.ventas;
using GestionVentasCel.exceptions.cliente;
using GestionVentasCel.exceptions.venta;
using GestionVentasCel.models.CuentaCorreinte;
using GestionVentasCel.models.ventas;
using Microsoft.EntityFrameworkCore;

namespace GestionVentasCel.repository.ventas.impl
{
    public class VentaRepositoryImpl : IVentaRepository
    {
        private readonly AppDbContext _context;

        public VentaRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public void Agregar(Venta venta)
        {
            _context.Ventas.Add(venta);
            _context.SaveChanges();
        }

        public void Actualizar(Venta ventaActualizada)
        {
            // Se tiene que:
            //  1. Traer la venta original de la DB
            //  2. Si la venta original estaba >= Confirmada:
            //      2.1 Revertir el stock de los articulos
            //      2.2 Revertir los estados de las reparaciones
            //      2.3 Poner FechaVenta en null
            //  3. Eliminar todos los detalles originales
            //  4. Agregar todos los detalles de la venta nueva
            //  5. Si la venta nueva está == Confirmada:
            //      5.1 Disminuir el stock de los artículos
            //      5.2 Poner estado entregado en las reparaciones

            //  6. Si la venta original se había pagado con cuenta corriente:
            //      6.1 Si la venta actualizada se pagó con cuenta corriente:
            //          6.1.1 Actualizar el monto del movimiento
            //      6.2 Si la venta actualizada se pagó con efectivo:
            //          6.2.1 Eliminar el movimiento
            //  7. Si la venta original se pagó con efectivo:
            //      7.1 Si la venta actualizada se pagó con cuenta corriente:
            //          7.1.2 Crear el movimiento, creando la cuenta corriente si es necesario
            //  8. Actualizar el tipo de pago.

            var strategy = _context.Database.CreateExecutionStrategy();

            strategy.Execute(() =>
            {
                using (var transaccion = _context.Database.BeginTransaction())
                {
                    try
                    {
                        Venta? ventaOriginal = this.ObtenerPorIdConDetalles(ventaActualizada.Id);
                        if (ventaOriginal == null)
                        {
                            throw new VentaNoEncontradaException("Se intentó actualizar una venta que no existe ne la DB");
                        }

                        // 2. si la venta está más que confirmada:
                        if (ventaOriginal!.EstadoVenta >= EstadoVentaEnum.Confirmada)
                        {
                            foreach (DetalleVenta det in ventaOriginal.Detalles)
                            {
                                // 2.1 Revertir el stock de los articulos
                                if (det.EsArticulo && det.Articulo != null)
                                {
                                    det.Articulo.Stock += det.Cantidad;
                                }
                                // 2.2 Revertir los estados de las reparaciones
                                if (det.EsReparacion && det.Reparacion != null)
                                {
                                    det.Reparacion.Estado = EstadoReparacionEnum.Terminado;
                                }
                            }

                            // 2.3 Poner fechaVenta en nulo
                            ventaOriginal.FechaVenta = null;
                        }

                        // 3. Eliminar todos los detalles originales, pero primero copiarlos a una lista nueva

                        var copia = new List<DetalleVenta>();
                        foreach (var nuevoDetalle in ventaActualizada.Detalles)
                        {
                            int? articuloId = nuevoDetalle.Articulo?.Id;
                            int? reparacionId = nuevoDetalle.Reparacion?.Id;
                            copia.Add(
                                new DetalleVenta
                                {
                                    Cantidad = nuevoDetalle.Cantidad,
                                    PrecioUnitario = nuevoDetalle.PrecioUnitario,
                                    PorcentajeIva = nuevoDetalle.PorcentajeIva,
                                    ArticuloId = articuloId,
                                    ReparacionId = reparacionId,
                                }
                            );
                        }
                        ventaOriginal.Detalles.Clear();


                        // 4. Agregar todos los detalles de la venta nueva
                        foreach (var nuevoDetalle in copia)
                        {

                            var detalle = new DetalleVenta
                            {
                                Cantidad = nuevoDetalle.Cantidad,
                                PrecioUnitario = nuevoDetalle.PrecioUnitario,
                                PorcentajeIva = nuevoDetalle.PorcentajeIva,
                                ArticuloId = nuevoDetalle.ArticuloId,
                                ReparacionId = nuevoDetalle.ReparacionId,
                            };

                            ventaOriginal.Detalles.Add(detalle);
                        }

                        // Guardar los cambios, una vez que se guardaron todos los detalles
                        _context.SaveChanges();


                        // Después de no se cuánto tiempo de problemas de tracking, la forma más fácil
                        // de hacer que esto funcione es guardando los cambios de la venta después de que se 
                        // guardaron los nuevos detalles, y volver a traer la venta de la base de datos para
                        // que EF core se arregle con instanciar los artículos y las reparaciones para que no de 
                        // errror de tracking. Es feo pero está en una transacción asi que no debería pasar nada

                        ventaOriginal = this.ObtenerPorIdConDetalles(ventaActualizada.Id);


                        // 5. Si la venta nueva está confirmada
                        if (ventaActualizada.EstadoVenta >= EstadoVentaEnum.Confirmada)
                        {
                            foreach (var detalle in ventaOriginal.Detalles)
                            {

                                if (detalle.EsArticulo && detalle.Articulo != null)
                                {
                                    detalle.Articulo.Stock -= detalle.Cantidad; // EF lo marcará como modificado
                                }

                                if (detalle.EsReparacion && detalle.Reparacion != null)
                                {
                                    detalle.Reparacion.FechaEgreso = DateTime.Now;
                                    detalle.Reparacion.Estado = EstadoReparacionEnum.Entregado; // EF lo marcará como modificado
                                }
                            }

                            ventaOriginal.FechaVenta = DateTime.Now;
                        }
                        ventaOriginal.EstadoVenta = ventaActualizada.EstadoVenta;

                        _context.Ventas.Update(ventaOriginal);
                        _context.SaveChanges();


                        // 6. Si la venta original se pagó con cuenta corriente:
                        if (ventaOriginal.TipoPago == TipoPagoEnum.CuentaCorriente )
                        //TODO: Esto se rompe cuando la venta está en borrador y se la quiere confirmar con cuenta corriente
                        {
                            MovimientoCuentaCorriente? movimiento = _context.MovimientosCuentasCorrientes
                                    .FirstOrDefault(m => m.VentaId == ventaOriginal.Id);
                            if (movimiento == null)
                            {
                                // Si la cuenta no existe, y la venta estaba en borrador, entonces hay que crear toda la cuenta corriente y eso
                                {
                                    // 7.1.1 Crear el movimiento, creando la cuenta corriente si es necesario
                                    CuentaCorriente? cuenta = _context.CuentasCorrientes
                                        .FirstOrDefault(cc => cc.ClienteId == ventaOriginal.ClienteId);
                                    if (cuenta == null)
                                    {
                                        cuenta = new CuentaCorriente
                                        {
                                            ClienteId = ventaOriginal.ClienteId,
                                        };
                                    }

                                    movimiento = new MovimientoCuentaCorriente
                                    {
                                        Tipo = TipoMovimiento.Aumento,
                                        Monto = ventaOriginal.TotalConIva,
                                        VentaId = ventaOriginal.Id,
                                        Fecha = (DateTime)ventaOriginal.FechaVenta!,
                                        Descripcion = $"Venta número {ventaOriginal.Id} del {ventaOriginal.FechaVenta}"
                                    };
                                    cuenta.Movimientos.Add(movimiento);
                                    _context.CuentasCorrientes.Add(cuenta);
                                    _context.SaveChanges();
                                }

                            }
                            // 6.1 Si la venta actualizada se pagó con cuenta corriente:
                            if (ventaActualizada.TipoPago == TipoPagoEnum.CuentaCorriente)
                            {
                                // 6.1.1 Actualizar el movimiento


                                movimiento.Monto = ventaOriginal.TotalConIva;
                                _context.MovimientosCuentasCorrientes.Update(movimiento);
                            }
                            // 6.2 Si la venta actualizada se pagó con efectivo:
                            else
                            {
                                // 6.2.1 Eliminar el movimiento
                                _context.MovimientosCuentasCorrientes.Remove(movimiento);
                            }
                        }
                        // 7. Si la venta original se pagó con efectivo
                        else
                        {
                            // 7.1 Si la venta actualizada se pagó con cuenta corriente
                            if (ventaActualizada.TipoPago == TipoPagoEnum.CuentaCorriente)
                            {
                                // 7.1.1 Crear el movimiento, creando la cuenta corriente si es necesario
                                CuentaCorriente? cuenta = _context.CuentasCorrientes
                                    .FirstOrDefault(cc => cc.ClienteId == ventaOriginal.ClienteId);
                                if (cuenta == null)
                                {
                                    cuenta = new CuentaCorriente
                                    {
                                        ClienteId = ventaOriginal.ClienteId,
                                    };
                                }
                                cuenta.Movimientos.Add(new MovimientoCuentaCorriente
                                {
                                    Tipo = TipoMovimiento.Aumento,
                                    Monto = ventaOriginal.TotalConIva,
                                    VentaId = ventaOriginal.Id,
                                    Fecha = (DateTime)ventaOriginal.FechaVenta!,
                                    Descripcion = $"Venta número {ventaOriginal.Id} del {ventaOriginal.FechaVenta}"
                                });
                            }
                        }

                        // 8. Actualizar el tipo de pago
                        ventaOriginal.TipoPago = ventaActualizada.TipoPago;
                        _context.SaveChanges();

                        transaccion.Commit();
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            });


        }


        public void ConfirmarVenta(int VentaId)
        {
            var venta = this.ObtenerPorIdConDetalles(VentaId);
            if (venta == null)
                throw new VentaNoEncontradaException("Se intentó confirmar una venta que no existe");

            if (venta.EstadoVenta == EstadoVentaEnum.Confirmada)
                throw new ConfirmacionVentaDupicadaException("Se intentó confirmar una venta que ya estaba confirmada");

            venta.EstadoVenta = EstadoVentaEnum.Confirmada;
            venta.FechaVenta = DateTime.Now;

            // Descontar stocks y marcar reparaciones como entregadas

            foreach (var detalle in venta.Detalles)
            {

                if (detalle.EsArticulo && detalle.Articulo != null)
                {
                    detalle.Articulo.Stock -= detalle.Cantidad;
                }

                if (detalle.EsReparacion && detalle.Reparacion != null)
                {
                    detalle.Reparacion.Estado = EstadoReparacionEnum.Entregado;
                    detalle.Reparacion.FechaEgreso = venta.FechaVenta;

                }
            }

            if (venta.TipoPago == TipoPagoEnum.CuentaCorriente)
            {
                CuentaCorriente? cuenta = _context.CuentasCorrientes
                                    .FirstOrDefault(cc => cc.ClienteId == venta.ClienteId);
                if (cuenta == null)
                {
                    cuenta = new CuentaCorriente
                    {
                        ClienteId = venta.ClienteId,
                    };

                    _context.CuentasCorrientes.Add(cuenta);
                }
                cuenta.Movimientos.Add(new MovimientoCuentaCorriente
                {
                    Tipo = TipoMovimiento.Aumento,
                    Monto = venta.TotalConIva,
                    VentaId = venta.Id,
                    Fecha = (DateTime)venta.FechaVenta!,
                    Descripcion = $"Venta número {venta.Id} del {venta.FechaVenta}"
                });
            }

            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var venta = _context.Ventas.Find(id);
            if (venta != null)
            {
                venta.EstadoVenta = EstadoVentaEnum.Anulada;
                _context.SaveChanges();
            }
        }

        public bool Existe(int id)
        {
            return _context.Ventas.Any(v => v.Id == id);
        }

        public IEnumerable<Venta> ObtenerTodas()
        {
            return _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Usuario)
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<Venta> ObtenerTodasConDetalles()
        {
            return _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Usuario)
                .Include(v => v.Detalles)
                    .ThenInclude(d => d.Articulo)
                .Include(v => v.Detalles)
                    .ThenInclude(d => d.Reparacion)
                .AsNoTracking()
                .ToList();
        }

        public Venta? ObtenerPorId(int id)
        {
            return _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Usuario)
                .FirstOrDefault(v => v.Id == id);
        }

        public Venta? ObtenerPorIdConDetalles(int id)
        {
            return _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Usuario)
                .Include(v => v.Detalles)
                    .ThenInclude(d => d.Articulo)
                .Include(v => v.Detalles)
                    .ThenInclude(d => d.Reparacion)
                .FirstOrDefault(v => v.Id == id);
        }

        public Venta? ObtenerPorIdConDetallesNoTracking(int id)
        {
            return _context.Ventas
                .AsNoTracking()
                .Include(v => v.Cliente)
                .Include(v => v.Usuario)
                .Include(v => v.Detalles)
                    .ThenInclude(d => d.Articulo)
                .Include(v => v.Detalles)
                    .ThenInclude(d => d.Reparacion)
                .FirstOrDefault(v => v.Id == id);
        }

        public Factura? ObtenerFacturaDeVenta(Venta venta)
        {
            return _context.Facturas
                .Include(f => f.Empresa)
                .Include(f => f.Detalles)
                .AsNoTracking()
                .FirstOrDefault(f => f.VentaId == venta.Id);
        }

    }

}
