using GestionVentasCel.enumerations.persona;
using GestionVentasCel.enumerations.ventas;
using GestionVentasCel.models.ventas;
using GestionVentasCel.repository.facturas;

namespace GestionVentasCel.service.factura
{
    public class FacturaServiceImpl : IFacturaService
    {
        private readonly IFacturaRepository _facturaRepository;

        public FacturaServiceImpl(IFacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }

        public Factura? ObtenerPorId(int id)
        {
            return _facturaRepository.ObtenerPorId(id);
        }

        public IEnumerable<Factura> ObtenerTodas()
        {
            return _facturaRepository.ObtenerTodas();
        }

        public Factura EmitirFactura(Venta venta, TipoFacturaEnum? tipoFactura = null)
        {
            if (venta.Cliente == null)
            {
                throw new InvalidOperationException("No se puede emitir una factura sin cliente asociado.");
            }

            TipoFacturaEnum tipoFacturaFinal = tipoFactura ?? TipoFacturaEnum.FacturaA;

            if (tipoFactura == null)
            {
                // Setear el tipo correcto según el cliente.

                switch (venta.Cliente.CondicionIVA)
                {
                    case CondicionIVAEnum.ConsumidorFinal:
                    case CondicionIVAEnum.Exento:
                        tipoFacturaFinal = TipoFacturaEnum.FacturaB;
                        break;
                    case CondicionIVAEnum.Monotributista:
                    case CondicionIVAEnum.ResponsableInscripto:
                        tipoFacturaFinal = TipoFacturaEnum.FacturaA;
                        break;
                }
            }

            // Crear factura desde la venta
            var factura = new Factura
            {

                TipoComprobante = tipoFacturaFinal,
                NumeroFactura = GenerarNumeroFactura(),
                FechaEmision = DateTime.Now,

                // Datos cliente
                NombreCliente = venta.Cliente.Nombre,
                CUITCliente = venta.Cliente.Dni!,
                DomicilioCliente = $"{venta.Cliente.Calle}, {venta.Cliente.Ciudad}",
                CondicionIVACliente = venta.Cliente.CondicionIVA.ToString()!,

                // Relación con empresa y venta
                EmpresaId = 1,
                VentaId = venta.Id,

                // Totales
                Subtotal = venta.TotalSinIva,
                IVA = venta.IVATotal,
                Total = venta.TotalConIva,

                // Detalles
                Detalles = venta.Detalles.Select(d => new DetalleFactura
                {
                    Descripcion = d.EsArticulo
                        ? d.Articulo?.Nombre!
                        : $"Reparación #{d.ReparacionId}",
                    Cantidad = d.Cantidad,
                    PrecioUnitario = d.PrecioUnitario,
                    Subtotal = d.SubtotalConIva
                }).ToList()
            };

            _facturaRepository.Agregar(factura);
            return factura;
        }
        private string GenerarNumeroFactura()
        {
            // Esto debería venir de ARCA, pero bueno
            return $"0001-{DateTime.Now.Ticks % 1000000000:D8}";
        }
    }

}
