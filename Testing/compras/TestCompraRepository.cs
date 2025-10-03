using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionVentasCel.data;
using GestionVentasCel.models.articulo;
using GestionVentasCel.models.compra;
using GestionVentasCel.models.proveedor;
using GestionVentasCel.repository.compra.impl;
using Microsoft.EntityFrameworkCore;

namespace Testing.compras
{
    public class TestCompraRepository
    {
        private AppDbContext GetDbContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: dbName) // DB aislada por test
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public void Add_CompraConDetalles_SeGuardaCorrectamente()
        {
            using var context = GetDbContext(nameof(Add_CompraConDetalles_SeGuardaCorrectamente));
            var compraRepo = new CompraRepositoryImpl(context);
            var detalleRepo = new DetalleCompraRepositoryImpl(context);

            var proveedor = new Proveedor { Nombre = "Proveedor Test", Activo = true };
            var articulo = new Articulo
            {
                Nombre = "Articulo Test",
                Aviso_stock = 5,
                Precio = 100,
                Stock = 10,
                Marca = "Marca X",
                CategoriaId = 1
            };

            context.Proveedores.Add(proveedor);
            context.Articulos.Add(articulo);
            context.SaveChanges();

            var compra = new Compra
            {
                Fecha = DateTime.Now,
                Total = 200,
                ProveedorId = proveedor.Id,
                Observaciones = "Compra inicial"
            };

            compraRepo.Add(compra);

            var detalles = new List<DetalleCompra>
        {
            new DetalleCompra
            {
                CompraId = compra.Id,
                ArticuloId = articulo.Id,
                Cantidad = 2,
                PrecioUnitario = 100,
                Subtotal = 200
            }
        };

            detalleRepo.AddRange(detalles);

            var compraGuardada = compraRepo.GetByIdWithDetails(compra.Id);

            Assert.NotNull(compraGuardada);
            Assert.Equal(1, compraGuardada.Detalles.Count);
            Assert.Equal(200, compraGuardada.Total);
        }

        [Fact]
        public void GetAllWithDetails_DevuelveComprasConDetalles()
        {
            using var context = GetDbContext(nameof(GetAllWithDetails_DevuelveComprasConDetalles));
            var compraRepo = new CompraRepositoryImpl(context);
            var detalleRepo = new DetalleCompraRepositoryImpl(context);

            var proveedor = new Proveedor { Nombre = "Proveedor 2", Activo = true };
            var articulo = new Articulo
            {
                Nombre = "Articulo Y",
                Aviso_stock = 3,
                Precio = 50,
                Stock = 5,
                Marca = "Marca Y",
                CategoriaId = 1
            };

            context.Proveedores.Add(proveedor);
            context.Articulos.Add(articulo);
            context.SaveChanges();

            var compra = new Compra
            {
                Fecha = DateTime.Now,
                Total = 100,
                ProveedorId = proveedor.Id
            };

            compraRepo.Add(compra);

            var detalle = new DetalleCompra
            {
                CompraId = compra.Id,
                ArticuloId = articulo.Id,
                Cantidad = 2,
                PrecioUnitario = 50,
                Subtotal = 100
            };

            detalleRepo.AddRange(new List<DetalleCompra> { detalle });

            var compras = compraRepo.GetAllWithDetails().ToList();

            Assert.Single(compras);
            Assert.Single(compras.First().Detalles);
        }

        [Fact]
        public void Delete_EliminaCompraYDetalles()
        {
            using var context = GetDbContext(nameof(Delete_EliminaCompraYDetalles));
            var compraRepo = new CompraRepositoryImpl(context);
            var detalleRepo = new DetalleCompraRepositoryImpl(context);

            var proveedor = new Proveedor { Nombre = "Proveedor 3", Activo = true };
            var articulo = new Articulo
            {
                Nombre = "Articulo Z",
                Aviso_stock = 2,
                Precio = 30,
                Stock = 3,
                Marca = "Marca Z",
                CategoriaId = 1
            };

            context.Proveedores.Add(proveedor);
            context.Articulos.Add(articulo);
            context.SaveChanges();

            var compra = new Compra
            {
                Fecha = DateTime.Now,
                Total = 60,
                ProveedorId = proveedor.Id
            };

            compraRepo.Add(compra);

            var detalle = new DetalleCompra
            {
                CompraId = compra.Id,
                ArticuloId = articulo.Id,
                Cantidad = 2,
                PrecioUnitario = 30,
                Subtotal = 60
            };

            detalleRepo.AddRange(new List<DetalleCompra> { detalle });

            // Act
            compraRepo.Delete(compra.Id);

            var compraEliminada = compraRepo.GetByIdWithDetails(compra.Id);
            var detallesEliminados = detalleRepo.GetByCompraId(compra.Id);

            Assert.Null(compraEliminada);
            Assert.Empty(detallesEliminados);
        }

        [Fact]
        public void GetByProveedor_DevuelveSoloLasComprasDelProveedor()
        {
            using var context = GetDbContext(nameof(GetByProveedor_DevuelveSoloLasComprasDelProveedor));
            var compraRepo = new CompraRepositoryImpl(context);
            var detalleRepo = new DetalleCompraRepositoryImpl(context);

            var proveedor1 = new Proveedor { Nombre = "Proveedor A", Activo = true };
            var proveedor2 = new Proveedor { Nombre = "Proveedor B", Activo = true };

            var articulo = new Articulo
            {
                Nombre = "Articulo X",
                Aviso_stock = 1,
                Precio = 10,
                Stock = 5,
                Marca = "Marca X",
                CategoriaId = 1
            };

            context.Proveedores.AddRange(proveedor1, proveedor2);
            context.Articulos.Add(articulo);
            context.SaveChanges();

            var compra1 = new Compra
            {
                Fecha = DateTime.Now,
                Total = 100,
                ProveedorId = proveedor1.Id
            };
            var compra2 = new Compra
            {
                Fecha = DateTime.Now,
                Total = 200,
                ProveedorId = proveedor2.Id
            };

            compraRepo.Add(compra1);
            compraRepo.Add(compra2);

            detalleRepo.AddRange(new List<DetalleCompra>
            {
            new DetalleCompra { CompraId = compra1.Id, ArticuloId = articulo.Id, Cantidad = 10, PrecioUnitario = 10, Subtotal = 100 },
            new DetalleCompra { CompraId = compra2.Id, ArticuloId = articulo.Id, Cantidad = 20, PrecioUnitario = 10, Subtotal = 200 }
            });

            var comprasProveedor1 = compraRepo.GetByProveedor(proveedor1.Id).ToList();

            Assert.Single(comprasProveedor1);
            Assert.Equal(proveedor1.Id, comprasProveedor1.First().ProveedorId);
        }

        [Fact]
        public void Update_ModificaCompraYDetallesCorrectamente()
        {
            using var context = GetDbContext(nameof(Update_ModificaCompraYDetallesCorrectamente));
            var compraRepo = new CompraRepositoryImpl(context);
            var detalleRepo = new DetalleCompraRepositoryImpl(context);

            var proveedor = new Proveedor { Nombre = "Proveedor Update", Activo = true };
            var articulo = new Articulo
            {
                Nombre = "Articulo Update",
                Aviso_stock = 2,
                Precio = 50,
                Stock = 5,
                Marca = "Marca U",
                CategoriaId = 1
            };

            context.Proveedores.Add(proveedor);
            context.Articulos.Add(articulo);
            context.SaveChanges();

            var compra = new Compra
            {
                Fecha = DateTime.Now,
                Total = 100,
                ProveedorId = proveedor.Id,
                Observaciones = "Compra original"
            };
            compraRepo.Add(compra);

            var detalle = new DetalleCompra
            {
                CompraId = compra.Id,
                ArticuloId = articulo.Id,
                Cantidad = 2,
                PrecioUnitario = 50,
                Subtotal = 100
            };
            detalleRepo.AddRange(new List<DetalleCompra> { detalle });

            // Act → actualizar compra
            compra.Total = 200;
            compra.Observaciones = "Compra modificada";
            compraRepo.Update(compra);

            // Reemplazar detalles
            detalleRepo.DeleteByCompraId(compra.Id);
            detalleRepo.AddRange(new List<DetalleCompra>
            {
                new DetalleCompra
                {
                    CompraId = compra.Id,
                    ArticuloId = articulo.Id,
                    Cantidad = 4,
                    PrecioUnitario = 50,
                    Subtotal = 200
                }
            });

            var compraActualizada = compraRepo.GetByIdWithDetails(compra.Id);

            Assert.NotNull(compraActualizada);
            Assert.Equal(200, compraActualizada.Total);
            Assert.Equal("Compra modificada", compraActualizada.Observaciones);
            Assert.Single(compraActualizada.Detalles);
            Assert.Equal(200, compraActualizada.Detalles.First().Subtotal);
        }
    }
}
