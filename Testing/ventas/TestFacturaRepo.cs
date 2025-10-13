using FluentAssertions;
using GestionVentasCel.data;
using GestionVentasCel.enumerations.persona;
using GestionVentasCel.enumerations.ventas;
using GestionVentasCel.models.articulo;
using GestionVentasCel.models.clientes;
using GestionVentasCel.models.ventas;
using GestionVentasCel.repository.facturas.impl;
using Microsoft.EntityFrameworkCore;

namespace Testing.ventas
{
    public class TestFacturaRepo
    {


        public TestFacturaRepo()
        {
        }

        [Fact]
        public void EmitirFactura_CambiaEstadoVenta()
        {
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

            var factura = new Factura
            {

                TipoComprobante = TipoFacturaEnum.FacturaB,
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

            var opciones = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "factura1")
                .Options;

            var context = new AppDbContext(opciones);

            // Se simula que ya existe una venta, despues su estado tiene que cambiar a Facturada
            context.Ventas.Add(venta);
            context.SaveChanges();

            var repoFactura = new FacturaRepositoryImpl(context);
            repoFactura.Agregar(factura);

            var ventaGuardada = context.Ventas.First(v => v.Id == 1);

            ventaGuardada.EstadoVenta.Should().Be(EstadoVentaEnum.Facturada);
        }

        [Fact]
        public void EmitirFactura_GeneraCodigoCorrecto()
        {
            // La factura debería terminar con un número correcto según su id.
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

            var factura = new Factura
            {

                TipoComprobante = TipoFacturaEnum.FacturaB,
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

            var opciones = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "factura2")
                .Options;

            var context = new AppDbContext(opciones);

            // Se simula que ya existe una venta, despues su estado tiene que cambiar a Facturada
            context.Ventas.Add(venta);
            context.SaveChanges();

            var repoFactura = new FacturaRepositoryImpl(context);
            repoFactura.Agregar(factura);

            factura.NumeroFactura.Should().Be("0001-00000001");

        }

        [Fact]
        public void EmitirFactura_GeneraCodigoCorrectoAumentaSerie()
        {
            // La factura debería terminar con un número correcto según su id, y la serie se 
            //debería aumentar cuando la id de la factura es mayor a 99999999
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

            var factura = new Factura
            {
                Id = 100000000, // Esta debería ser la primera factura de la serie 2
                TipoComprobante = TipoFacturaEnum.FacturaB,
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

            var opciones = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "factura3")
                .Options;

            var context = new AppDbContext(opciones);

            // Se simula que ya existe una venta, despues su estado tiene que cambiar a Facturada
            context.Ventas.Add(venta);
            context.SaveChanges();

            var repoFactura = new FacturaRepositoryImpl(context);
            repoFactura.Agregar(factura);

            factura.NumeroFactura.Should().Be("0002-00000001");

        }
    }
}