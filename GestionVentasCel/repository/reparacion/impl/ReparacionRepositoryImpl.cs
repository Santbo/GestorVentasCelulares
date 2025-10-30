using GestionVentasCel.data;
using GestionVentasCel.enumerations.reparacion;
using GestionVentasCel.exceptions.reparacion;
using GestionVentasCel.models.articulo;
using GestionVentasCel.models.reparacion;
using GestionVentasCel.models.servicio;
using Microsoft.EntityFrameworkCore;

namespace GestionVentasCel.repository.reparacion.impl
{
    public class ReparacionRepositoryImpl : IReparacionRepository
    {
        private readonly AppDbContext _context;

        public ReparacionRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Reparacion reparacion)
        {

            _context.Reparaciones.Add(reparacion);
            _context.SaveChanges();

        }

        public void Update(Reparacion reparacion)
        {

            foreach (var rs in reparacion.ReparacionServicios)
            {
                if (rs.Id == 0)
                    _context.Entry(rs).State = EntityState.Added;
                else
                    _context.Entry(rs).State = EntityState.Modified;
            }

            _context.Reparaciones.Attach(reparacion);
            _context.Reparaciones.Update(reparacion);
            _context.SaveChanges();
        }

        public void Desactivar(int reparacionId)
        {
            var reparacion = _context.Reparaciones
                .Include(r => r.ReparacionServicios)
                .ThenInclude(rs => rs.Servicio)
                .ThenInclude(s => s.ArticulosUsados)
                .ThenInclude(au => au.Articulo)
                .FirstOrDefault(r => r.Id == reparacionId);

            if (reparacion == null)
            {
                throw new ReparacionNoEncontradaException("La reparación no existe.");
            }

            if (reparacion.Activo) { 
                // Está activa, entonces se la va a desactivar y se tiene que revertir el stock
                // únicamente si está reparando
                if (reparacion.Estado == EstadoReparacionEnum.Reparando)
                
                    foreach (ReparacionServicio rs in reparacion.ReparacionServicios)
                    {

                        if (rs.Servicio?.ArticulosUsados == null || !rs.Servicio.ArticulosUsados.Any())
                            continue;

                        foreach (ServicioArticulo sa in rs.Servicio.ArticulosUsados)
                        {
                            sa.Articulo.Stock += sa.Cantidad;
                        }
                    }
            }

            reparacion.Activo = false;

            _context.SaveChanges();
        }

        public IEnumerable<Reparacion> GetAll()
        {
            return _context.Reparaciones
                           .AsNoTracking()
                           .Include(r => r.Dispositivo)
                               .ThenInclude(d => d.Cliente)
                           .Include(r => r.ReparacionServicios)
                           .OrderByDescending(r => r.FechaIngreso)
                           .ToList();
        }

        public IEnumerable<Reparacion> ListarReparacionesTerminadasCliente(int idCliente)
        {
            return _context.Reparaciones
                .AsNoTracking()
                .Include(r => r.Dispositivo)
                    .ThenInclude(d => d.Cliente)
                .Where(r => r.Dispositivo.Cliente.Id == idCliente
                            && r.Estado == EstadoReparacionEnum.Terminado)
                .ToList();
        }

        public Reparacion? GetById(int id)
        {
            return _context.Reparaciones
                           .Include(r => r.Dispositivo)
                           .Include(r => r.ReparacionServicios)
                           .ThenInclude( rs => rs.Servicio)
                           .FirstOrDefault(r => r.Id == id)
                           ;
        }

        public Reparacion? GetWithClienteById(int id)
        {
            return _context.Reparaciones
                           .Include(r => r.Dispositivo)
                                .ThenInclude(d => d.Cliente)
                           .Include(r => r.ReparacionServicios)
                           .FirstOrDefault(r => r.Id == id)
                           ;
        }

        public bool Exist(int id)
        {
            return _context.Reparaciones.Any(r => r.Id == id);
        }

        public void CambiarEstado(int id, EstadoReparacionEnum nuevoEstado)
        {
            var reparacion = _context.Reparaciones
                .Include(r => r.ReparacionServicios)
                .ThenInclude(rs => rs.Servicio)
                .ThenInclude(s => s.ArticulosUsados)
                .ThenInclude(au => au.Articulo)
                .FirstOrDefault(r => r.Id == id);


            if (reparacion != null)
            {
                bool debeActualizarStock = reparacion.Estado == EstadoReparacionEnum.Ingresado && nuevoEstado == EstadoReparacionEnum.Reparando;
                if (debeActualizarStock)
                {
                    foreach (ReparacionServicio rs in reparacion.ReparacionServicios)
                    {

                        if (rs.Servicio?.ArticulosUsados == null || !rs.Servicio.ArticulosUsados.Any())
                            continue;

                        foreach (ServicioArticulo sa in rs.Servicio.ArticulosUsados)
                        {
                            sa.Articulo.Stock -= sa.Cantidad;
                        }
                    }
                }

                reparacion.Estado = nuevoEstado;


                _context.SaveChanges();
            }

        }

        public IEnumerable<Reparacion>? GetReparacionesDispositivo(Dispositivo dispositivo)
        {
            return _context.Reparaciones
                                .AsNoTracking()
                                .Where(r => r.DispositivoId == dispositivo.Id)
                                .ToList();
        }

        public IEnumerable<Dispositivo>? BuscarDispositivoPorCliente(int ClienteId)
        {
            return _context.Dispositivos
                             .AsNoTracking()
                             .Where(d => d.ClienteId == ClienteId)
                             .ToList();
        }

        public void AddDispositivo(Dispositivo dispositivo)
        {
            _context.Dispositivos.Add(dispositivo);
            _context.SaveChanges();
        }

        public void UpdateDispositivo(Dispositivo dispositivo)
        {
            _context.Dispositivos.Update(dispositivo);
            _context.SaveChanges();
        }

        public bool ExistDispositivo(int id)
        {
            return _context.Dispositivos.Any(d => d.Id == id);
        }

        public Dispositivo? GetDispositivoById(int dispositivoId)
        {
            return _context.Dispositivos.FirstOrDefault(d => d.Id == dispositivoId);
        }
    }
}
