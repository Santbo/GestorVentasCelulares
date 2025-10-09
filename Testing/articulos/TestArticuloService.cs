using GestionVentasCel.models.articulo;
using GestionVentasCel.repository.articulo;
using GestionVentasCel.service.articulo.impl;
using Moq;

namespace Testing.articulos
{
    public class TestArticuloService
    {

        [Fact]
        public void CrearArticulo_DeberiaAgregarArticuloCorrectamente()
        {
            var mockRepo = new Mock<IArticuloRepository>();
            var service = new ArticuloServiceImpl(mockRepo.Object);

            service.CrearArticulo(
                nombre: "Pantalla Samsung A52",
                aviso_stock: 3,
                precio: 45000m,
                stock: 10,
                marca: "Samsung",
                categoriaId: 1,
                descripcion: "Pantalla original AMOLED"
            );

            mockRepo.Verify(r => r.Add(It.Is<Articulo>(a =>
                a.Nombre == "Pantalla Samsung A52" &&
                a.Marca == "Samsung" &&
                a.Stock == 10 &&
                a.CategoriaId == 1
            )), Times.Once);
        }

        [Fact]
        public void ToggleActivo_DeberiaCambiarEstadoDelArticulo()
        {
            var mockRepo = new Mock<IArticuloRepository>();
            var articulo = new Articulo
            {
                Id = 1,
                Nombre = "Cargador USB-C",
                Activo = true,
                Marca = "Motorola",
                CategoriaId = 2
            };
            mockRepo.Setup(r => r.GetById(1)).Returns(articulo);
            var service = new ArticuloServiceImpl(mockRepo.Object);

            service.ToggleActivo(1);

            Assert.False(articulo.Activo);
            mockRepo.Verify(r => r.Update(It.Is<Articulo>(a => a.Id == 1 && a.Activo == false)), Times.Once);
        }

        [Fact]
        public void UpdateArticulo_DeberiaActualizarArticuloExistente()
        {
            var mockRepo = new Mock<IArticuloRepository>();
            var articulo = new Articulo
            {
                Id = 2,
                Nombre = "Batería iPhone 11",
                Marca = "Apple",
                Stock = 15,
                CategoriaId = 3
            };

            mockRepo.Setup(r => r.Exist(2)).Returns(true);
            var service = new ArticuloServiceImpl(mockRepo.Object);

            service.UpdateArticulo(articulo);

            mockRepo.Verify(r => r.Update(It.Is<Articulo>(a =>
                a.Id == 2 &&
                a.Nombre == "Batería iPhone 11" &&
                a.Marca == "Apple"
            )), Times.Once);
        }

        [Fact]
        public void UpdateArticulo_DeberiaLanzarExcepcion_SiNoExiste()
        {
            var mockRepo = new Mock<IArticuloRepository>();
            var articulo = new Articulo { Id = 99, Nombre = "Placa base Xiaomi", Marca = "Xiaomi", CategoriaId = 4 };
            mockRepo.Setup(r => r.Exist(99)).Returns(false);
            var service = new ArticuloServiceImpl(mockRepo.Object);

            Assert.Throws<ArticuloNoEncontradoException>(() => service.UpdateArticulo(articulo));
        }
    }
}
