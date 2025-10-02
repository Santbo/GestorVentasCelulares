using GestionVentasCel.enumerations.persona;
using GestionVentasCel.enumerations.ventas;
using GestionVentasCel.exceptions.caja;
using GestionVentasCel.models.ventas;
using GestionVentasCel.repository.facturas;
using GestionVentasCel.service.caja;

namespace GestionVentasCel.service.factura
{
    public class FacturaServiceImpl : IFacturaService
    {
        private readonly IFacturaRepository _facturaRepository;
        private readonly ICajaService _cajaService;

        public FacturaServiceImpl(IFacturaRepository facturaRepository, ICajaService cajaService)
        {
            _facturaRepository = facturaRepository;
            _cajaService = cajaService;
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
                NumeroFactura = "TEMPORAL", // Temporal hasta que pueda guardar la factura, y obtener la id
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
                    PorcentajeIVA = d.PorcentajeIva,
                    Subtotal = d.SubtotalConIva
                }).ToList()
            };

            var cajaId = _cajaService.ObtenerCajaActualAbierta();
            _cajaService.RegistrarVenta(cajaId, factura.Total, venta.TipoPago);

            _facturaRepository.Agregar(factura);

            return factura;
        }
    }

}
