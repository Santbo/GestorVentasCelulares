using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionVentasCel.data;
using GestionVentasCel.models.articulo;
using GestionVentasCel.models.categoria;
using GestionVentasCel.repository.articulo.impl;
using Microsoft.EntityFrameworkCore;

namespace Testing.articulos
{
    public class TestArticuloRepository
    {
        private AppDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public void Add_DeberiaGuardarArticuloEnBaseDeDatos()
        {
            using var context = GetInMemoryDbContext();
            var repo = new ArticuloRepositoryImpl(context);

            var articulo = new Articulo
            {
                Nombre = "Pantalla AMOLED Samsung S21",
                Aviso_stock = 5,
                Precio = 85000m,
                Stock = 20,
                Marca = "Samsung",
                CategoriaId = 1,
                Descripcion = "Pantalla original con marco"
            };

            repo.Add(articulo);

            var guardado = context.Articulos.FirstOrDefault();
            Assert.NotNull(guardado);
            Assert.Equal("Pantalla AMOLED Samsung S21", guardado.Nombre);
            Assert.Equal(85000m, guardado.Precio);
        }

        [Fact]
        public void GetAll_DeberiaRetornarTodosLosArticulos()
        {
            using var context = GetInMemoryDbContext();

            context.Categorias.Add(
                new Categoria
                {
                    Id = 1,
                    Nombre = "Reparacion",
                    Descripcion = ""
                });

            context.Articulos.AddRange(
                new Articulo
                {
                    Nombre = "Batería iPhone 13",
                    Aviso_stock = 3,
                    Precio = 42000m,
                    Stock = 12,
                    Marca = "Apple",
                    CategoriaId = 1
                },
                new Articulo
                {
                    Nombre = "Pinzas de precisión",
                    Aviso_stock = 2,
                    Precio = 9000m,
                    Stock = 15,
                    Marca = "iFixit",
                    CategoriaId = 1
                }
            );
            context.SaveChanges();

            var repo = new ArticuloRepositoryImpl(context);

            var articulos = repo.GetAll();

            Assert.Equal(2, articulos.Count());
            Assert.Contains(articulos, a => a.Nombre == "Batería iPhone 13");
            Assert.Contains(articulos, a => a.Nombre == "Pinzas de precisión");
        }

        [Fact]
        public void Update_DeberiaActualizarArticuloExistente()
        {
            using var context = GetInMemoryDbContext();
            var articulo = new Articulo
            {
                Id = 1,
                Nombre = "Cargador USB-C 25W",
                Aviso_stock = 4,
                Precio = 15000m,
                Stock = 8,
                Marca = "Motorola",
                CategoriaId = 1
            };
            context.Articulos.Add(articulo);
            context.SaveChanges();

            var repo = new ArticuloRepositoryImpl(context);

            articulo.Precio = 17500m;
            articulo.Stock = 10;
            repo.Update(articulo);

            var actualizado = context.Articulos.Find(1);
            Assert.NotNull(actualizado);
            Assert.Equal(17500m, actualizado.Precio);
            Assert.Equal(10, actualizado.Stock);
        }
    }
}
