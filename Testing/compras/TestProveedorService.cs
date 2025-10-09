using GestionVentasCel.enumerations.persona;
using GestionVentasCel.exceptions.persona;
using GestionVentasCel.exceptions.proveedor;
using GestionVentasCel.models.proveedor;
using GestionVentasCel.repository.proveedor;
using GestionVentasCel.service.proveedor.impl;
using Moq;

namespace Testing.compras
{
    public class TestProveedorService
    {

        //Simula el repositorio:
        //Con Setup, configuramos que debe devolver el repo y
        //con Verify, si se llamo o no a un metodo
        private readonly Mock<IProveedorRepository> _repoMock;
        private readonly ProveedorServiceImpl _service;

        public TestProveedorService()
        {
            _repoMock = new Mock<IProveedorRepository>();
            _service = new ProveedorServiceImpl(_repoMock.Object);
        }


        /*
         Agregar proveedor con documento repetido lanza una excepcion
         */
        [Fact]
        public void AgregarProveedor_DocumentoDuplicado_LanzaExcepcion()
        {
            //Arrange
            var proveedor = new Proveedor
            {
                Id = 1,
                Dni = "12345678",
                TipoDocumento = TipoDocumentoEnum.CUIT
            };

            //Se configura el repo para que diga que el cuit que agregamos existe en la BD
            _repoMock.Setup(r => r.DocumentoExist(proveedor.Dni, proveedor.TipoDocumento.ToString(), null))
                .Returns(true);

            //Aca llamamos al service que va a llamar al repo creado por nosotros y debe lanzar la excepcion.
            Assert.Throws<DocumentoDuplicadoException>(() => _service.AgregarProveedor(proveedor));
        }

        /*
         Agregar proveedor valido llama a Add
         */

        [Fact]
        public void AgregarProveedor_ProveedorValido_LlamaAdd()
        {
            var proveedor = new Proveedor { Id = 1, Dni = "12345678", TipoDocumento = TipoDocumentoEnum.CUIT };

            //Decimos que el cuit no existe
            _repoMock.Setup(r => r.DocumentoExist(It.IsAny<string>(), It.IsAny<string>(), null))
                     .Returns(false);

            //Una vez que agregamos el Proveedor vemos si se añadio el proveedor en el repositorio.
            _service.AgregarProveedor(proveedor);

            _repoMock.Verify(r => r.Add(proveedor), Times.Once);
        }

        /*
         Actualizar proveedor que no existe lanza una excepcion
         */

        [Fact]
        public void ActualizarProveedor_NoExiste_LanzaExcepcion()
        {
            var proveedor = new Proveedor { Id = 1, Dni = "12345678", TipoDocumento = TipoDocumentoEnum.CUIT };
            _repoMock.Setup(r => r.Exist(proveedor.Id)).Returns(false);

            Assert.Throws<ProveedorNoEncontradoException>(() => _service.ActualizarProveedor(proveedor));
        }

        /*
        Actualizar con documento duplicado lanza excepción.
        */

        [Fact]
        public void ActualizarProveedor_DocumentoDuplicado_LanzaExcepcion()
        {
            var proveedor = new Proveedor { Id = 1, Dni = "12345678", TipoDocumento = TipoDocumentoEnum.CUIT };
            _repoMock.Setup(r => r.Exist(proveedor.Id)).Returns(true);
            _repoMock.Setup(r => r.DocumentoExist(proveedor.Dni, proveedor.TipoDocumento.ToString(), proveedor.Id))
                     .Returns(true);

            Assert.Throws<DocumentoDuplicadoException>(() => _service.ActualizarProveedor(proveedor));
        }


        /*
       Actualizar con documento valido llama a update.
       */

        [Fact]
        public void ActualizarProveedor_ProveedorValido_LlamaUpdate()
        {
            var proveedor = new Proveedor
            {
                Id = 1,
                Dni = "12345678",
                TipoDocumento = TipoDocumentoEnum.CUIT
            };

            _repoMock.Setup(r => r.Exist(proveedor.Id)).Returns(true);
            _repoMock.Setup(r => r.DocumentoExist(It.IsAny<String>(), It.IsAny<String>(), proveedor.Id))
                .Returns(false);

            _service.ActualizarProveedor(proveedor);

            _repoMock.Verify(r => r.Update(proveedor), Times.Once);
        }

        /*
         cambiar estado de un proveedor inexistente lanza excepción.
         */

        [Fact]
        public void CambiarEstadoProveedor_NoExiste_LanzaExcepcion()
        {
            _repoMock.Setup(r => r.Exist(1)).Returns(false);

            Assert.Throws<ProveedorNoEncontradoException>(() => _service.CambiarEstadoProveedor(1, true));
        }

        /*
         cambiar estado válido llama a "CambiarEstado"
         */

        [Fact]
        public void CambiarEstadoProveedor_Existe_LlamaCambiarEstado()
        {
            _repoMock.Setup(r => r.Exist(1)).Returns(true);

            _service.CambiarEstadoProveedor(1, false);

            _repoMock.Verify(r => r.CambiarEstado(1, false), Times.Once);
        }

        /*
         Que GetById devuelve lo que dice el repo.
        Revisamos que el proveedor que devuelve el servicio y el que devuelve el repo es el mismo
         */

        [Fact]
        public void GetById_DevuelveProveedorCorrecto()
        {
            var proveedor = new Proveedor { Id = 1, Nombre = "Samsung" };
            _repoMock.Setup(r => r.GetById(1)).Returns(proveedor);

            var result = _service.GetById(1);

            Assert.Equal("Samsung", result.Nombre);
            Assert.Equal(1, result.Id);
        }

        /*
        Que ListarProveedores devuelve la lista del repo.
        */

        [Fact]
        public void ListarProveedores_DevuelveLista()
        {
            var lista = new List<Proveedor>
            {
                new Proveedor { Id = 1, Nombre = "Proveedor 1" },
                new Proveedor { Id = 2, Nombre = "Proveedor 2" }
            };
            _repoMock.Setup(r => r.GetAll()).Returns(lista);

            var result = _service.ListarProveedores();

            Assert.Collection(result,
                p => Assert.Equal("Proveedor 1", p.Nombre),
                p => Assert.Equal("Proveedor 2", p.Nombre));
        }

    }
}
