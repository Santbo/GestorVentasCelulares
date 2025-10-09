using GestionVentasCel.data;
using GestionVentasCel.enumerations.ventas;
using GestionVentasCel.models.ventas;
using Microsoft.EntityFrameworkCore;

namespace GestionVentasCel.repository.facturas.impl
{
    public class FacturaRepositoryImpl : IFacturaRepository
    {
        private readonly AppDbContext _context;

        public FacturaRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public Factura? ObtenerPorId(int id)
        {
            return _context.Facturas
                .Include(f => f.Empresa)
                .Include(f => f.Detalles)
                .AsNoTracking()
                .FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<Factura> ObtenerTodas()
        {
            return _context.Facturas
                .Include(f => f.Empresa)
                .Include(f => f.Detalles)
                .AsNoTracking()
                .ToList();
        }

        public void Agregar(Factura factura)
        {
            var venta = _context.Ventas.First(v => v.Id == factura.VentaId);
            venta.EstadoVenta = EstadoVentaEnum.Facturada;

            _context.Facturas.Add(factura);
            _context.SaveChanges();

            // Se necesita que esté la empresa porque si no no se puede mostrar la factura cuando el usuario
            // quiere verla inmediatamente después de agregar o editar una venta.
            //factura.Empresa = _context.Empresas.AsNoTracking().First(e => e.Id == factura.EmpresaId);


            this.GenerarNumeroFactura(factura.Id);
        }

        public bool Existe(int id)
        {
            return _context.Facturas.Any(f => f.Id == id);
        }

        public void GenerarNumeroFactura(int id)
        {
            Factura fac = _context.Facturas.First(f => f.Id == id);

            int numero = ((id - 1) % 99999999) + 1;
            int serie = ((id - 1) / 99999999) + 1;

            fac.NumeroFactura = $"{serie:D4}-{numero:D8}";

            _context.SaveChanges();
        }
    }

}
