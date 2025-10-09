using GestionVentasCel.data;
using GestionVentasCel.models.categoria;
using GestionVentasCel.repository.categoria.impl;
using Microsoft.EntityFrameworkCore;

namespace Testing.articulos
{
    public class TestCategoriaRepository
    {
        private AppDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            return new AppDbContext(options);
        }

        [Fact]
        public void Add_Categoria_DeberiaAgregarCorrectamente()
        {

            var context = GetInMemoryDbContext();
            var repo = new CategoriaRepositoryImpl(context);
            var categoria = new Categoria { Nombre = "Telefono", Descripcion = "" };


            repo.Add(categoria);


            Assert.Single(context.Categorias);
            Assert.Equal("Telefono", context.Categorias.First().Nombre);
        }

        [Fact]
        public void NombreExist_DeberiaRetornarTrue_CuandoElNombreExiste()
        {

            var context = GetInMemoryDbContext();
            var repo = new CategoriaRepositoryImpl(context);
            context.Categorias.Add(new Categoria { Nombre = "Modulo", Descripcion = "" });
            context.SaveChanges();


            var result = repo.NombreExist("Modulo");


            Assert.True(result);
        }

        [Fact]
        public void Update_DeberiaModificarCategoriaCorrectamente()
        {

            var context = GetInMemoryDbContext();
            var repo = new CategoriaRepositoryImpl(context);
            var categoria = new Categoria { Nombre = "Herramienta", Descripcion = "Reparacion" };
            context.Categorias.Add(categoria);
            context.SaveChanges();


            categoria.Descripcion = "Reparacion Celulares";
            repo.Update(categoria);


            var updated = context.Categorias.First(c => c.Id == categoria.Id);
            Assert.Equal("Reparacion Celulares", updated.Descripcion);
        }
    }
}

