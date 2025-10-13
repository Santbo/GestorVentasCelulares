using GestionVentasCel.enumerations.caja;
using GestionVentasCel.enumerations.ventas;
using GestionVentasCel.exceptions.caja;
using GestionVentasCel.models.caja;
using GestionVentasCel.repository.caja;
using GestionVentasCel.service.caja.impl;
using Moq;

namespace Testing.caja
{
    public class TestCajaService
    {

        private readonly Mock<ICajaRepository> _repoMock;
        private readonly CajaServiceImpl _service;

        public TestCajaService()
        {
            _repoMock = new Mock<ICajaRepository>();
            _service = new CajaServiceImpl(_repoMock.Object);
        }

        [Fact]
        public void AbrirCaja_DeberiaLanzarExcepcion_SiYaExisteCajaAbierta()
        {
            _repoMock.Setup(r => r.GetAll()).Returns(new List<Caja>
            {
                new Caja { Id = 1, Estado = EstadoCajaEnum.Abierta }
            });

            Assert.Throws<CajaYaAbiertaException>(() => _service.AbrirCaja(10, 1000));
        }

        [Fact]
        public void CerrarCaja_DeberiaLanzarExcepcion_SiCajaNoExiste()
        {
            _repoMock.Setup(r => r.GetById(It.IsAny<int>())).Returns((Caja)null);

            Assert.Throws<CajaNoEncontradaException>(() => _service.CerrarCaja(99, 500));
        }

        [Fact]
        public void RegistrarVenta_DeberiaLanzarExcepcion_SiCajaEstaCerrada()
        {
            _repoMock.Setup(r => r.GetById(1)).Returns(new Caja { Id = 1, Estado = EstadoCajaEnum.Cerrada });

            Assert.Throws<CajaYaCerradaException>(() => _service.RegistrarVenta(1, 200, TipoPagoEnum.Efectivo));
        }

        [Fact]
        public void CerrarCaja_DeberiaActualizarEstadoYFecha()
        {
            var caja = new Caja { Id = 1, Estado = EstadoCajaEnum.Abierta };
            _repoMock.Setup(r => r.GetById(1)).Returns(caja);

            _service.CerrarCaja(1, 1500);

            _repoMock.Verify(r => r.Update(It.Is<Caja>(c =>
                c.Estado == EstadoCajaEnum.Cerrada &&
                c.MontoCierre == 1500 &&
                c.FechaCierre != null
            )), Times.Once);
        }

        [Fact]
        public void RegistrarVenta_DeberiaAgregarMovimientoCorrectamente()
        {
            var caja = new Caja { Id = 1, Estado = EstadoCajaEnum.Abierta };
            _repoMock.Setup(r => r.GetById(1)).Returns(caja);

            _service.RegistrarVenta(1, 300, TipoPagoEnum.Transferencia);

            _repoMock.Verify(r => r.AddMovimiento(It.Is<MovimientoCaja>(m =>
                m.CajaId == 1 &&
                m.Monto == 300 &&
                m.TipoMovimiento == TipoMovimientoEnum.Venta &&
                m.TipoPago == TipoPagoEnum.Transferencia
            )), Times.Once);
        }
    }
}

