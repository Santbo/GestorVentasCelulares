using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using GestionVentasCel.models.compra;
using GestionVentasCel.repository.compra;
using GestionVentasCel.service.articulo;
using GestionVentasCel.service.compra.impl;
using GestionVentasCel.service.configPrecios;
using GestionVentasCel.exceptions.configPrecios;
using GestionVentasCel.models.articulo;
using GestionVentasCel.models.configPrecios;
using GestionVentasCel.exceptions.compra;



namespace Testing.compras
{
    public class TestCompraService
    {
        private readonly Mock<ICompraRepository> _compraRepoMock;
        private readonly Mock<IDetalleCompraRepository> _detalleRepoMock;
        private readonly Mock<IArticuloService> _articuloServiceMock;
        private readonly Mock<IHistorialPrecioService> _historialPrecioMock;
        private readonly Mock<IConfiguracionPreciosService> _configuracionPreciosMock;
        private readonly CompraServiceImpl _service;

        public TestCompraService()
        {
            _compraRepoMock = new Mock<ICompraRepository>();
            _detalleRepoMock = new Mock<IDetalleCompraRepository>();
            _articuloServiceMock = new Mock<IArticuloService>();
            _historialPrecioMock = new Mock<IHistorialPrecioService>();
            _configuracionPreciosMock = new Mock<IConfiguracionPreciosService>();

            _service = new CompraServiceImpl(
                _compraRepoMock.Object,
                _detalleRepoMock.Object,
                _articuloServiceMock.Object,
                _historialPrecioMock.Object,
                _configuracionPreciosMock.Object
            );
        }

        private Compra CrearCompra()
        {
            return new Compra
            {
                Id = 1,
                Fecha = DateTime.Now,
                ProveedorId = 1,
                Total = 0
            };
        }

        private List<DetalleCompra> CrearDetalles()
        {
            return new List<DetalleCompra>
            {
                new DetalleCompra { ArticuloId = 1, Cantidad = 2, PrecioUnitario = 100 },
                new DetalleCompra { ArticuloId = 2, Cantidad = 1, PrecioUnitario = 200 }
            };
        }

        [Fact]
        public void AgregarCompraConDetalles_SinMargen_LanzaExcepcion()
        {
            var compra = CrearCompra();
            var detalles = CrearDetalles();

            _configuracionPreciosMock.Setup(c => c.MargenExist(1)).Returns(false);

            Assert.Throws<MargenNoAgregadoException>(() =>
                _service.AgregarCompraConDetalles(compra, detalles));
        }

        [Fact]
        public void AgregarCompraConDetalles_Valida_GuardaCompraYDetalles()
        {
            var compra = CrearCompra();
            var detalles = CrearDetalles();

            _configuracionPreciosMock.Setup(c => c.MargenExist(1)).Returns(true);
            _configuracionPreciosMock.Setup(c => c.GetById(1)).Returns(new ConfiguracionPrecios { Id = 1, MargenAumento = 1.2m });
            _articuloServiceMock.Setup(a => a.GetById(It.IsAny<int>()))
                .Returns(new Articulo { Id = 1, Precio = 0, Stock = 0 });

            _service.AgregarCompraConDetalles(compra, detalles);

            _compraRepoMock.Verify(r => r.Add(compra), Times.Once);
            _detalleRepoMock.Verify(r => r.AddRange(It.IsAny<List<DetalleCompra>>()), Times.Once);
            Assert.Equal(400, compra.Total); // 2*100 + 1*200
        }

        [Fact]
        public void ActualizarCompraConDetalles_NoExiste_LanzaExcepcion()
        {
            var compra = CrearCompra();
            var detalles = CrearDetalles();

            _compraRepoMock.Setup(r => r.Exist(compra.Id)).Returns(false);

            Assert.Throws<CompraNoEncontradaException>(() =>
                _service.ActualizarCompraConDetalles(compra, detalles));
        }

        [Fact]
        public void EliminarCompra_NoExiste_LanzaExcepcion()
        {
            _compraRepoMock.Setup(r => r.Exist(1)).Returns(false);

            Assert.Throws<CompraNoEncontradaException>(() =>
                _service.EliminarCompra(1));
        }

        [Fact]
        public void CalcularTotal_CalculaCorrecto()
        {
            var detalles = CrearDetalles();

            var total = _service.CalcularTotal(detalles);

            Assert.Equal(400, total);
        }
    }
}
