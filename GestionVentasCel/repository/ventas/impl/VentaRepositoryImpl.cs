using GestionVentasCel.data;
using GestionVentasCel.enumerations.cuentaCorriente;
using GestionVentasCel.enumerations.reparacion;
using GestionVentasCel.enumerations.ventas;
using GestionVentasCel.exceptions.cliente;
using GestionVentasCel.exceptions.venta;
using GestionVentasCel.models.articulo;
using GestionVentasCel.models.CuentaCorreinte;
using GestionVentasCel.models.reparacion;
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

            // TODO: Implementar la capacidad de ver la venta del movimiento
            // TODO: Implementar el ver detalle de venta, que sea un editar nomas pero con todo desactivado
            // TODO: Sacar EstaVencida del listado de reparaciones
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
                                    detalle.Reparacion.Estado = EstadoReparacionEnum.Entregado; // EF lo marcará como modificado
                                }
                            }

                            ventaOriginal.FechaVenta = DateTime.Now;
                            ventaOriginal.EstadoVenta = ventaActualizada.EstadoVenta;
                        }

                        _context.Ventas.Update(ventaOriginal);
                        _context.SaveChanges();


                        // 6. Si la venta original se pagó con cuenta corriente:
                        if (ventaOriginal.TipoPago == TipoPagoEnum.CuentaCorriente)
                        {
                            MovimientoCuentaCorriente? movimiento = _context.MovimientosCuentasCorrientes
                                    .FirstOrDefault(m => m.VentaId == ventaOriginal.Id);
                            if (movimiento == null)
                            {
                                throw new MovimientoInexistenteException("Se intentó actualizar un movimiento de cuenta corriente que noe xiste.");
                            }
                            //TODO: Que no deje eliminar, editar o agregar movimientos de tipo Venta
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
                                //TODO: Hay que actualizar el usario que vendió, pero bloquear en el form que se pueda cmabiar el cliente
                                cuenta.Movimientos.Add(new MovimientoCuentaCorriente
                                {
                                    Tipo = TipoMovimiento.Aumento,
                                    Monto = ventaOriginal.TotalConIva,
                                    VentaId = ventaOriginal.Id,
                                    Fecha = (DateTime) ventaOriginal.FechaVenta!,
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

        /// <summary>
        /// Obtener las ventas que SÍ son presupuestos.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Venta> ObtenerPresupuestos()
        {
            return _context.Ventas
                .Include(v => v.Cliente)
                .Where(v => v.FechaVenta == null && v.EstadoVenta == EstadoVentaEnum.Presupuesto)
                .AsNoTracking()
                .ToList();
        }

        /// <summary>
        /// Obtener todas las ventas que NO sean prespuestos.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Venta> ObtenerVentas()
        {
            return _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Detalles)
                .Where(v => v.EstadoVenta != EstadoVentaEnum.Presupuesto)
                .AsNoTracking()
                .ToList();
        }

        public void AgregarDetalle(int ventaId, DetalleVenta detalle)
        {
            var venta = _context.Ventas
                .Include(v => v.Detalles)
                .FirstOrDefault(v => v.Id == ventaId);

            if (venta != null)
            {
                venta.Detalles.Add(detalle);
                _context.SaveChanges();
            }
        }

        public void EliminarDetalle(int detalleId)
        {
            var detalle = _context.DetallesVenta.Find(detalleId);
            if (detalle != null)
            {
                _context.DetallesVenta.Remove(detalle);
                _context.SaveChanges();
            }
        }

        public Venta? ObtenerPresupuestoPorId(int idVenta)
        {
            return _context.Ventas.FirstOrDefault(v => v.Id == idVenta && v.EstadoVenta == EstadoVentaEnum.Presupuesto);
        }
    }

}
