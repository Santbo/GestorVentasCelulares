using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using GestionVentasCel.enumerations.persona;
using GestionVentasCel.enumerations.ventas;
using GestionVentasCel.models.articulo;
using GestionVentasCel.models.clientes;
using GestionVentasCel.models.ventas;
using GestionVentasCel.repository.facturas;
using GestionVentasCel.service.caja;
using GestionVentasCel.service.factura;
using Moq;

namespace Testing.ventas
{
    public class TestServiceFactura
    {
        private readonly Mock<IFacturaRepository> _facturaRepo;
        private readonly Mock<ICajaService> _cajaService;
        private readonly FacturaServiceImpl _facturaService;


        public TestServiceFactura()
        {
            _facturaRepo = new Mock<IFacturaRepository>();
            _cajaService = new Mock<ICajaService>();

            _facturaService = new FacturaServiceImpl(
                _facturaRepo.Object,
                _cajaService.Object
            );
        }
        [Fact]
        public void EmitirFactura_ClienteNulo_Falla()
        {
            // Se debería arrojar una excepción si no tiene cliente la factura, porque no
            // se puede saber a quién ni qué factura emitir.

            var venta = new Venta
            {
                Id = 1,
                EstadoVenta = EstadoVentaEnum.Confirmada,
                Detalles = new List<DetalleVenta>
                {
                    new DetalleVenta
                    {
                        Cantidad = 5,
                        PrecioUnitario = 100m,
                        PorcentajeIva = 0.21m,
                        Articulo = new Articulo
                        {
                            Id = 1,
                            Nombre = "prueba",
                            Marca = "prueba",
                            Precio = 100m,
                            Stock = 0,
                            Aviso_stock = 2,
                            CategoriaId = 1
                        },
                        ArticuloId = 1
                    }
                },
                Cliente = null,
            };

            Action accion = () => { _facturaService.EmitirFactura(venta); };

            accion.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void EmitirFactura_ClienteRI_EmiteFacA()
        {
            // Si el cliente es RI, se tiene que emitir factura A
            var venta = new Venta
            {
                Id = 1,
                EstadoVenta = EstadoVentaEnum.Confirmada,
                Detalles = new List<DetalleVenta>
                {
                    new DetalleVenta
                    {
                        Cantidad = 5,
                        PrecioUnitario = 100m,
                        PorcentajeIva = 0.21m,
                        Articulo = new Articulo
                        {
                            Id = 1,
                            Nombre = "prueba",
                            Marca = "prueba",
                            Precio = 100m,
                            Stock = 0,
                            Aviso_stock = 2,
                            CategoriaId = 1
                        },
                        ArticuloId = 1
                    }
                },
                Cliente = new Cliente
                {
                    Id = 1,
                    CondicionIVA = CondicionIVAEnum.ResponsableInscripto,
                    Nombre = "Responsable",
                    Apellido = "Inscripto",
                    TipoDocumento = TipoDocumentoEnum.CUIT,
                    Dni = "30-12345678-2",
                    Calle = "Calle falsa 123",
                    Ciudad = "Springfield"

                }
            };

            _cajaService.Setup(c => c.ObtenerCajaActualAbierta()).Returns(1);

            var factura = _facturaService.EmitirFactura(venta);

            factura.TipoComprobante.Should().Be(TipoFacturaEnum.FacturaA);

        }

        [Fact]
        public void EmitirFactura_ClienteMonotributista_EmiteFacA()
        {

            // Si el cliente es Monotributista, se tiene que emitir factura A
            var venta = new Venta
            {
                Id = 1,
                EstadoVenta = EstadoVentaEnum.Confirmada,
                Detalles = new List<DetalleVenta>
                {
                    new DetalleVenta
                    {
                        Cantidad = 5,
                        PrecioUnitario = 100m,
                        PorcentajeIva = 0.21m,
                        Articulo = new Articulo
                        {
                            Id = 1,
                            Nombre = "prueba",
                            Marca = "prueba",
                            Precio = 100m,
                            Stock = 0,
                            Aviso_stock = 2,
                            CategoriaId = 1
                        },
                        ArticuloId = 1
                    }
                },
                Cliente = new Cliente
                {
                    Id = 1,
                    CondicionIVA = CondicionIVAEnum.Monotributista,
                    Nombre = "Mono",
                    Apellido = "Tributista",
                    TipoDocumento = TipoDocumentoEnum.CUIT,
                    Dni = "30-12345678-2",
                    Calle = "Calle falsa 123",
                    Ciudad = "Springfield"

                }
            };

            _cajaService.Setup(c => c.ObtenerCajaActualAbierta()).Returns(1);

            var factura = _facturaService.EmitirFactura(venta);

            factura.TipoComprobante.Should().Be(TipoFacturaEnum.FacturaA);
        }

        [Fact]
        public void EmitirFactura_ClienteCF_EmiteFacB()
        {

            // Si el cliente es consumidor final, se tiene que emitir factura A
            var venta = new Venta
            {
                Id = 1,
                EstadoVenta = EstadoVentaEnum.Confirmada,
                Detalles = new List<DetalleVenta>
                {
                    new DetalleVenta
                    {
                        Cantidad = 5,
                        PrecioUnitario = 100m,
                        PorcentajeIva = 0.21m,
                        Articulo = new Articulo
                        {
                            Id = 1,
                            Nombre = "prueba",
                            Marca = "prueba",
                            Precio = 100m,
                            Stock = 0,
                            Aviso_stock = 2,
                            CategoriaId = 1
                        },
                        ArticuloId = 1
                    }
                },
                Cliente = new Cliente
                {
                    Id = 1,
                    CondicionIVA = CondicionIVAEnum.ConsumidorFinal,
                    Nombre = "Consumidor",
                    Apellido = "Final",
                    TipoDocumento = TipoDocumentoEnum.CUIT,
                    Dni = "30-12345678-2",
                    Calle = "Calle falsa 123",
                    Ciudad = "Springfield"

                }
            };

            _cajaService.Setup(c => c.ObtenerCajaActualAbierta()).Returns(1);

            var factura = _facturaService.EmitirFactura(venta);

            factura.TipoComprobante.Should().Be(TipoFacturaEnum.FacturaB);
        }

        [Fact]
        public void EmitirFactura_ClienteExento_EmiteFacB()
        {

            // Si el cliente es exento, se tiene que emitir factura A
            var venta = new Venta
            {
                Id = 1,
                EstadoVenta = EstadoVentaEnum.Confirmada,
                Detalles = new List<DetalleVenta>
                {
                    new DetalleVenta
                    {
                        Cantidad = 5,
                        PrecioUnitario = 100m,
                        PorcentajeIva = 0.21m,
                        Articulo = new Articulo
                        {
                            Id = 1,
                            Nombre = "prueba",
                            Marca = "prueba",
                            Precio = 100m,
                            Stock = 0,
                            Aviso_stock = 2,
                            CategoriaId = 1
                        },
                        ArticuloId = 1
                    }
                },
                Cliente = new Cliente
                {
                    Id = 1,
                    CondicionIVA = CondicionIVAEnum.Exento,
                    Nombre = "IVA",
                    Apellido = "Exento",
                    TipoDocumento = TipoDocumentoEnum.CUIT,
                    Dni = "30-12345678-2",
                    Calle = "Calle falsa 123",
                    Ciudad = "Springfield"

                }
            };

            _cajaService.Setup(c => c.ObtenerCajaActualAbierta()).Returns(1);

            var factura = _facturaService.EmitirFactura(venta);

            factura.TipoComprobante.Should().Be(TipoFacturaEnum.FacturaB);
        }

        [Fact]
        public void EmitirFactura_LlamaAAgregarMovimientoCaja()
        {
            //Siempre s etiene que agregar un movimiento en la caja cuando se factura una venta.
            // Lo que haga el service de movimientos no interesa, pero el service de factura
            // tiene la responsabilidad de llamarlo.
            // Si el cliente es exento, se tiene que emitir factura A
            var venta = new Venta
            {
                Id = 1,
                EstadoVenta = EstadoVentaEnum.Confirmada,
                Detalles = new List<DetalleVenta>
                {
                    new DetalleVenta
                    {
                        Cantidad = 5,
                        PrecioUnitario = 100m,
                        PorcentajeIva = 0.21m,
                        Articulo = new Articulo
                        {
                            Id = 1,
                            Nombre = "prueba",
                            Marca = "prueba",
                            Precio = 100m,
                            Stock = 0,
                            Aviso_stock = 2,
                            CategoriaId = 1
                        },
                        ArticuloId = 1
                    }
                },
                Cliente = new Cliente
                {
                    Id = 1,
                    CondicionIVA = CondicionIVAEnum.Exento,
                    Nombre = "IVA",
                    Apellido = "Exento",
                    TipoDocumento = TipoDocumentoEnum.CUIT,
                    Dni = "30-12345678-2",
                    Calle = "Calle falsa 123",
                    Ciudad = "Springfield"

                }
            };

            _cajaService.Setup(c => c.ObtenerCajaActualAbierta()).Returns(1);

            var factura = _facturaService.EmitirFactura(venta);

            _cajaService.Verify(
                c => c.RegistrarVenta(
                    1,
                    venta.TotalConIva,
                    venta.TipoPago),
                Times.Once
            );

        }

    }

}
