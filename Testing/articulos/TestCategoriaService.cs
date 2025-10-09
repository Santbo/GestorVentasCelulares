using GestionVentasCel.exceptions.categoria;
using GestionVentasCel.models.categoria;
using GestionVentasCel.repository.categoria;
using GestionVentasCel.service.categoria.impl;
using Moq;

namespace Testing.articulos
{
    public class TestCategoriaService
    {
        private readonly Mock<ICategoriaRepository> _repoMock;
        private readonly CategoriaServiceImpl _service;

        public TestCategoriaService()
        {
            _repoMock = new Mock<ICategoriaRepository>();
            _service = new CategoriaServiceImpl(_repoMock.Object);
        }

        [Fact]
        public void AgregarCategoria_DeberiaAgregarSiNombreNoExiste()
        {

            _repoMock.Setup(r => r.NombreExist("Accesorios")).Returns(false);


            _service.AgregarCategoria("Accesorios", "Fundas y cargadores");


            _repoMock.Verify(r => r.Add(It.Is<Categoria>(c =>
                c.Nombre == "Accesorios" &&
                c.Descripcion == "Fundas y cargadores"
            )), Times.Once);
        }

        [Fact]
        public void AgregarCategoria_DeberiaLanzarExcepcionSiNombreExiste()
        {

            _repoMock.Setup(r => r.NombreExist("Accesorios")).Returns(true);


            Assert.Throws<CategoriaExistenteException>(() =>
                _service.AgregarCategoria("Accesorios", "Duplicada")
            );
        }

        [Fact]
        public void ToggleActivo_DeberiaCambiarEstadoActivoSiCategoriaExiste()
        {

            var categoria = new Categoria { Id = 1, Nombre = "Accesorios", Activo = true };
            _repoMock.Setup(r => r.GetById(1)).Returns(categoria);


            _service.ToggleActivo(1);


            Assert.False(categoria.Activo); // se invierte el estado
            _repoMock.Verify(r => r.Update(It.Is<Categoria>(c => c.Id == 1 && c.Activo == false)), Times.Once);
        }

        [Fact]
        public void ToggleActivo_DeberiaLanzarExcepcionSiCategoriaNoExiste()
        {

            _repoMock.Setup(r => r.GetById(1)).Returns((Categoria?)null);


            Assert.Throws<CategoriaNoEncontradaException>(() => _service.ToggleActivo(1));
        }

        [Fact]
        public void UpdateCategoria_DeberiaActualizarSiExiste()
        {

            var categoria = new Categoria { Id = 1, Nombre = "Pantallas" };
            _repoMock.Setup(r => r.Exist(1)).Returns(true);


            _service.UpdateCategoria(categoria);


            _repoMock.Verify(r => r.Update(It.Is<Categoria>(c => c.Id == 1 && c.Nombre == "Pantallas")), Times.Once);
        }

        [Fact]
        public void UpdateCategoria_DeberiaLanzarExcepcionSiNoExiste()
        {

            var categoria = new Categoria { Id = 99, Nombre = "NoExiste" };
            _repoMock.Setup(r => r.Exist(99)).Returns(false);


            Assert.Throws<CategoriaNoEncontradaException>(() => _service.UpdateCategoria(categoria));
        }
    }
}

