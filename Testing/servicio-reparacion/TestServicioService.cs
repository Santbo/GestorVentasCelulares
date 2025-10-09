using FluentAssertions;
using GestionVentasCel.exceptions.servicio;
using GestionVentasCel.models.servicio;
using GestionVentasCel.repository.servicio;
using GestionVentasCel.service.servicio.impl;
using Moq;

namespace Testing.ServiciosReparaciones;
public class ServicioServiceTests
{
    private readonly Mock<IServicioRepository> _repoMock;
    private readonly ServicioServiceImpl _service;

    public ServicioServiceTests()
    {
        _repoMock = new Mock<IServicioRepository>();
        _service = new ServicioServiceImpl(_repoMock.Object);
    }

    [Fact]
    public void ToggleEstado_DeberiaCambiarEstadoDeActivo()
    {
        var servicio = new Servicio
        {
            Id = 1,
            Nombre = "Test",
            Precio = 100,
            Activo = true
        };

        _repoMock.Setup(r => r.GetById(servicio.Id)).Returns(servicio);
        _repoMock.Setup(r => r.Update(It.IsAny<Servicio>()));

        _service.ToggleEstado(servicio.Id);

        servicio.Activo.Should().BeFalse();
        _repoMock.Verify(r => r.Update(It.Is<Servicio>(s => s.Id == servicio.Id && s.Activo == false)), Times.Once);
    }

    [Fact]
    public void ToggleEstado_DeberiaActivarServicioInactivo()
    {
        var servicio = new Servicio
        {
            Id = 2,
            Nombre = "Otro Servicio",
            Precio = 200,
            Activo = false
        };

        _repoMock.Setup(r => r.GetById(servicio.Id)).Returns(servicio);
        _repoMock.Setup(r => r.Update(It.IsAny<Servicio>()));

        _service.ToggleEstado(servicio.Id);

        servicio.Activo.Should().BeTrue();
        _repoMock.Verify(r => r.Update(It.Is<Servicio>(s => s.Id == servicio.Id && s.Activo == true)), Times.Once);
    }

    [Fact]
    public void ToggleEstado_DeberiaLanzarExcepcionSiServicioNoExiste()
    {
        _repoMock.Setup(r => r.GetById(999)).Returns((Servicio?)null);

        Action act = () => _service.ToggleEstado(999);

        act.Should().Throw<ServicioNoEncontradoException>();
    }
}
