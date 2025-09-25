using GestionVentasCel.data;
using GestionVentasCel.enumerations.reparacion;
using GestionVentasCel.enumerations.ventas;
using GestionVentasCel.exceptions.venta;
using GestionVentasCel.models.articulo;
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

                        // 3. Eliminar todos los detalles originales
                        ventaOriginal.Detalles.Clear();
                        //this.Actualizar(ventaOriginal);

                        // 4. Agregar todos los detalles de la venta nueva
                        foreach (var nuevoDetalle in ventaActualizada.Detalles)
                        {

                            int? articuloId = nuevoDetalle.Articulo?.Id;
                            int? reparacionId = nuevoDetalle.Reparacion?.Id;

                            var detalle = new DetalleVenta
                            {
                                Cantidad = nuevoDetalle.Cantidad,
                                PrecioUnitario = nuevoDetalle.PrecioUnitario,
                                PorcentajeIva = nuevoDetalle.PorcentajeIva,
                                ArticuloId = articuloId,
                                ReparacionId = reparacionId,
                            };

                            ventaOriginal.Detalles.Add(detalle);
                        }


                        // 5. Si la venta nueva está confirmada
                        if (ventaActualizada.EstadoVenta >= EstadoVentaEnum.Confirmada)
                        {
                            foreach (var detalle in ventaOriginal.Detalles)
                            {

                                if (detalle.EsArticulo && detalle.ArticuloId.HasValue)
                                {
                                    var articulo = new Articulo { Id = detalle.ArticuloId.Value };
                                    _context.Articulos.Attach(articulo);

                                    articulo.Stock -= detalle.Cantidad; // EF lo marcará como modificado
                                }

                                if (detalle.EsReparacion && detalle.ReparacionId.HasValue)
                                {
                                    var reparacion = new Reparacion { Id = detalle.ReparacionId.Value };
                                    _context.Reparaciones.Attach(reparacion);

                                    reparacion.Estado = EstadoReparacionEnum.Entregado; // EF lo marcará como modificado
                                }
                            }

                            ventaOriginal.FechaVenta = DateTime.Now;
                            ventaOriginal.EstadoVenta = ventaActualizada.EstadoVenta;
                        }

                        _context.Ventas.Update(ventaOriginal);
                        _context.SaveChanges();
                        transaccion.Commit();

                        // Una vez guardadas las cosas, hay que recorrer los detalles y volver a agregar los artículos y reparaciones
                        // porque las uis los necesitan

                        foreach (var d in ventaActualizada.Detalles)
                        {

                            int? articuloId = d.Articulo?.Id;
                            int? reparacionId = d.Reparacion?.Id;

                            d.Articulo = _context.Articulos.AsNoTracking().FirstOrDefault(a => a.Id == articuloId);
                            d.Reparacion = _context.Reparaciones.AsNoTracking().FirstOrDefault(a => a.Id == reparacionId);
                        }

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
