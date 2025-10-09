using FluentAssertions;
using GestionVentasCel.controller.articulo;
using GestionVentasCel.controller.reparaciones;
using GestionVentasCel.controller.servicio;
using GestionVentasCel.enumerations.reparacion;
using GestionVentasCel.exceptions.reparacion;
using GestionVentasCel.models.articulo;
using GestionVentasCel.models.reparacion;
using GestionVentasCel.models.servicio;
using GestionVentasCel.service.articulo;
using GestionVentasCel.service.reparacion;
using GestionVentasCel.service.servicio;
using Moq;

namespace Testing.ServiciosReparaciones;
public class ReparacionControllerTests
{
    private readonly Mock<IReparacionService> _reparacionServiceMock;
    private readonly Mock<IArticuloService> _articuloServiceMock;
    private readonly Mock<IServicioService> _servicioServiceMock;

    private readonly ArticuloController _articuloController;
    private readonly ServicioController _servicioController;
    private readonly ReparacionController _controller;

    public ReparacionControllerTests()
    {
        _reparacionServiceMock = new Mock<IReparacionService>();
        _articuloServiceMock = new Mock<IArticuloService>();
        _servicioServiceMock = new Mock<IServicioService>();

        _articuloController = new ArticuloController(_articuloServiceMock.Object);
        _servicioController = new ServicioController(_servicioServiceMock.Object);
        _controller = new ReparacionController(
            _reparacionServiceMock.Object,
            _articuloController,
            _servicioController
        );
    }

    [Fact]
    public void CambiarEstado_Entregado_DeberiaActualizarFechaEgreso()
    {
        var reparacion = new Reparacion { Id = 1 };
        _reparacionServiceMock.Setup(s => s.ObtenerPorId(1)).Returns(reparacion);

        _controller.CambiarEstado(1, EstadoReparacionEnum.Entregado);

        reparacion.FechaEgreso.Should().NotBe(null);
        _reparacionServiceMock.Verify(s => s.ActualizarReparacion(reparacion), Times.Once);
    }

    [Fact]
    public void CambiarEstado_Reparando_DeberiaLimpiarFechaVencimiento()
    {
        var reparacion = new Reparacion
        {
            Id = 1,
            FechaVencimiento = DateTime.Now.AddDays(5)
        };
        _reparacionServiceMock.Setup(s => s.ObtenerPorId(1)).Returns(reparacion);

        _controller.CambiarEstado(1, EstadoReparacionEnum.Reparando);

        reparacion.FechaVencimiento.Should().Be(null);
        _reparacionServiceMock.Verify(s => s.ActualizarReparacion(reparacion), Times.Once);
    }

    [Fact]
    public void RecalcularReparacion_DeberiaLanzarExcepcion_SiNoExiste()
    {
        _reparacionServiceMock.Setup(s => s.ObtenerPorId(99)).Returns((Reparacion)null);

        Action accion = () => _controller.RecalcularReparacion(99);
        accion.Should().Throw<ReparacionNoEncontradaException>();
    }

    [Fact]
    public void RecalcularReparacion_DeberiaRecalcularTotalYFechaVencimiento()
    {
        var servicio = new Servicio
        {
            Id = 1,
            Precio = 100m,
            ArticulosUsados = new List<ServicioArticulo>
            {
                new ServicioArticulo { ArticuloId = 10, Cantidad = 2 }
            }
        };

        var articulo = new Articulo { Id = 10, Precio = 25m };

        var reparacion = new Reparacion
        {
            Id = 1,
            ReparacionServicios = new List<ReparacionServicio>
            {
                new ReparacionServicio { Servicio = servicio }
            }
        };

        _reparacionServiceMock.Setup(s => s.ObtenerPorId(1)).Returns(reparacion);
        _servicioServiceMock.Setup(s => s.GetServicioConArticulos(1)).Returns(servicio);
        _articuloServiceMock.Setup(a => a.GetById(10)).Returns(articulo);

        _controller.RecalcularReparacion(1);

        reparacion.Total.Should().Be(150m);
        reparacion.FechaVencimiento.Should().NotBe(null);
        _reparacionServiceMock.Verify(s => s.ActualizarReparacion(reparacion), Times.Once);
    }

    [Fact]
    public void RecalcularReparacion_NoExistente_DeberiaLanzarExcepcion()
    {
        _reparacionServiceMock.Setup(s => s.ObtenerPorId(It.IsAny<int>()))
                              .Returns((Reparacion?)null);

        Action act = () => _controller.RecalcularReparacion(99);

        act.Should().Throw<ReparacionNoEncontradaException>();

        _reparacionServiceMock.Verify(s => s.ObtenerPorId(99), Times.Once);
        _reparacionServiceMock.Verify(s => s.ActualizarReparacion(It.IsAny<Reparacion>()), Times.Never);
    }
}
