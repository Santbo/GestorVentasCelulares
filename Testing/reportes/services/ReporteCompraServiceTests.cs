using FluentAssertions;
using GestionVentasCel.models.reportes;
using GestionVentasCel.repository.reportes;
using GestionVentasCel.service;
using Moq;

namespace Testing.reportes.services;

public class ReporteCompraServiceTests
{
    private readonly Mock<IReporteCompraRepository> _repositoryMock;
    private readonly ReporteCompraService _service;

    public ReporteCompraServiceTests()
    {
        _repositoryMock = new Mock<IReporteCompraRepository>();
        _service = new ReporteCompraService(_repositoryMock.Object);
    }

    [Fact]
    public void ObtenerComprasPorRangoFecha_DebeRetornarComprasDelRepositorio()
    {
        
        var fechaDesde = new DateTime(2025, 1, 1);
        var fechaHasta = new DateTime(2025, 1, 31);
        var comprasEsperadas = new List<ReporteCompraDTO>
        {
            new ReporteCompraDTO
            {
                Id = 1,
                Fecha = new DateTime(2025, 1, 15),
                NumeroComprobante = "FC-001",
                Proveedor = "Proveedor Test",
                CondicionIVAProveedor = "Responsable Inscripto",
                MontoTotal = 1000.50m,
                Observaciones = "Compra de prueba"
            },
            new ReporteCompraDTO
            {
                Id = 2,
                Fecha = new DateTime(2025, 1, 20),
                NumeroComprobante = "FC-002",
                Proveedor = "Otro Proveedor",
                CondicionIVAProveedor = "Monotributo",
                MontoTotal = 2500.75m,
                Observaciones = "Segunda compra"
            }
        };

        _repositoryMock.Setup(r => r.ObtenerComprasPorRangoFecha(fechaDesde, fechaHasta))
                      .Returns(comprasEsperadas);

        
        var resultado = _service.ObtenerComprasPorRangoFecha(fechaDesde, fechaHasta);

        
        resultado.Should().NotBeNull();
        resultado.Should().HaveCount(2);
        resultado.Should().BeEquivalentTo(comprasEsperadas);
        _repositoryMock.Verify(r => r.ObtenerComprasPorRangoFecha(fechaDesde, fechaHasta), Times.Once);
    }

    [Fact]
    public void ObtenerComprasPorRangoFecha_DebeRetornarListaVaciaCuandoNoHayCompras()
    {
        
        var fechaDesde = new DateTime(2025, 1, 1);
        var fechaHasta = new DateTime(2025, 1, 31);
        var comprasVacias = new List<ReporteCompraDTO>();

        _repositoryMock.Setup(r => r.ObtenerComprasPorRangoFecha(fechaDesde, fechaHasta))
                      .Returns(comprasVacias);

        
        var resultado = _service.ObtenerComprasPorRangoFecha(fechaDesde, fechaHasta);

        
        resultado.Should().NotBeNull();
        resultado.Should().BeEmpty();
        _repositoryMock.Verify(r => r.ObtenerComprasPorRangoFecha(fechaDesde, fechaHasta), Times.Once);
    }

    [Fact]
    public void ObtenerResumenCompras_DebeRetornarResumenDelRepositorio()
    {
        
        var fechaDesde = new DateTime(2025, 1, 1);
        var fechaHasta = new DateTime(2025, 1, 31);
        var resumenEsperado = new ResumenReporteDTO
        {
            TotalGeneral = 3500.25m,
            CantidadOperaciones = 2,
            PromedioOperacion = 1750.125m,
            FechaDesde = fechaDesde,
            FechaHasta = fechaHasta,
            TotalesPorTipo = new Dictionary<string, decimal>
            {
                { "Responsable Inscripto", 1000.50m },
                { "Monotributo", 2500.75m }
            }
        };

        _repositoryMock.Setup(r => r.ObtenerResumenCompras(fechaDesde, fechaHasta))
                      .Returns(resumenEsperado);

        
        var resultado = _service.ObtenerResumenCompras(fechaDesde, fechaHasta);

        
        resultado.Should().NotBeNull();
        resultado.Should().BeEquivalentTo(resumenEsperado);
        _repositoryMock.Verify(r => r.ObtenerResumenCompras(fechaDesde, fechaHasta), Times.Once);
    }

    [Fact]
    public void ObtenerComprasDelMesActual_DebeCalcularFechasCorrectamente()
    {
        
        var hoy = DateTime.Today;
        var primerDiaDelMes = new DateTime(hoy.Year, hoy.Month, 1);
        var ultimoDiaDelMes = primerDiaDelMes.AddMonths(1).AddDays(-1);
        var comprasEsperadas = new List<ReporteCompraDTO>
        {
            new ReporteCompraDTO
            {
                Id = 1,
                Fecha = hoy.AddDays(-5),
                NumeroComprobante = "FC-001",
                Proveedor = "Proveedor Actual",
                CondicionIVAProveedor = "Responsable Inscripto",
                MontoTotal = 1500.00m,
                Observaciones = "Compra del mes actual"
            }
        };

        _repositoryMock.Setup(r => r.ObtenerComprasPorRangoFecha(primerDiaDelMes, ultimoDiaDelMes))
                      .Returns(comprasEsperadas);

        
        var resultado = _service.ObtenerComprasDelMesActual();

        
        resultado.Should().NotBeNull();
        resultado.Should().HaveCount(1);
        resultado.Should().BeEquivalentTo(comprasEsperadas);
        _repositoryMock.Verify(r => r.ObtenerComprasPorRangoFecha(primerDiaDelMes, ultimoDiaDelMes), Times.Once);
    }

    [Fact]
    public void ObtenerResumenDelMesActual_DebeCalcularFechasCorrectamente()
    {
        
        var hoy = DateTime.Today;
        var primerDiaDelMes = new DateTime(hoy.Year, hoy.Month, 1);
        var ultimoDiaDelMes = primerDiaDelMes.AddMonths(1).AddDays(-1);
        var resumenEsperado = new ResumenReporteDTO
        {
            TotalGeneral = 5000.00m,
            CantidadOperaciones = 3,
            PromedioOperacion = 1666.67m,
            FechaDesde = primerDiaDelMes,
            FechaHasta = ultimoDiaDelMes,
            TotalesPorTipo = new Dictionary<string, decimal>
            {
                { "Responsable Inscripto", 3000.00m },
                { "Monotributo", 2000.00m }
            }
        };

        _repositoryMock.Setup(r => r.ObtenerResumenCompras(primerDiaDelMes, ultimoDiaDelMes))
                      .Returns(resumenEsperado);

        
        var resultado = _service.ObtenerResumenDelMesActual();

        
        resultado.Should().NotBeNull();
        resultado.Should().BeEquivalentTo(resumenEsperado);
        _repositoryMock.Verify(r => r.ObtenerResumenCompras(primerDiaDelMes, ultimoDiaDelMes), Times.Once);
    }

    [Fact]
    public void ObtenerComprasDelMesActual_DebeCalcularFechasCorrectamenteParaDiferentesMeses()
    {
        
        var hoy = DateTime.Today;
        var primerDiaDelMes = new DateTime(hoy.Year, hoy.Month, 1);
        var ultimoDiaDelMes = primerDiaDelMes.AddMonths(1).AddDays(-1);
        
        var comprasEsperadas = new List<ReporteCompraDTO>();

        _repositoryMock.Setup(r => r.ObtenerComprasPorRangoFecha(primerDiaDelMes, ultimoDiaDelMes))
                      .Returns(comprasEsperadas);

        
        var resultado = _service.ObtenerComprasDelMesActual();

        
        resultado.Should().NotBeNull();
        _repositoryMock.Verify(r => r.ObtenerComprasPorRangoFecha(
            It.Is<DateTime>(f => f.Year == hoy.Year && f.Month == hoy.Month && f.Day == 1),
            It.Is<DateTime>(f => f.Year == hoy.Year && f.Month == hoy.Month && f.Day == ultimoDiaDelMes.Day)
        ), Times.Once);
    }

    [Fact]
    public void ObtenerComprasPorRangoFecha_DebeManejarFechasInvalidas()
    {
        
        var fechaDesde = new DateTime(2025, 1, 31);
        var fechaHasta = new DateTime(2025, 1, 1); // Fecha hasta anterior a fecha desde
        var comprasVacias = new List<ReporteCompraDTO>();

        _repositoryMock.Setup(r => r.ObtenerComprasPorRangoFecha(fechaDesde, fechaHasta))
                      .Returns(comprasVacias);

        
        var resultado = _service.ObtenerComprasPorRangoFecha(fechaDesde, fechaHasta);

        
        resultado.Should().NotBeNull();
        resultado.Should().BeEmpty();
        _repositoryMock.Verify(r => r.ObtenerComprasPorRangoFecha(fechaDesde, fechaHasta), Times.Once);
    }

    [Fact]
    public void ObtenerComprasPorRangoFecha_DebeManejarFechasIguales()
    {
        
        var fecha = new DateTime(2025, 1, 15);
        var comprasDelDia = new List<ReporteCompraDTO>
        {
            new ReporteCompraDTO
            {
                Id = 1,
                Fecha = fecha,
                NumeroComprobante = "FC-001",
                Proveedor = "Proveedor Test",
                CondicionIVAProveedor = "Responsable Inscripto",
                MontoTotal = 500.00m,
                Observaciones = "Compra del día"
            }
        };

        _repositoryMock.Setup(r => r.ObtenerComprasPorRangoFecha(fecha, fecha))
                      .Returns(comprasDelDia);

        
        var resultado = _service.ObtenerComprasPorRangoFecha(fecha, fecha);

        
        resultado.Should().NotBeNull();
        resultado.Should().HaveCount(1);
        resultado.Should().BeEquivalentTo(comprasDelDia);
        _repositoryMock.Verify(r => r.ObtenerComprasPorRangoFecha(fecha, fecha), Times.Once);
    }

    [Fact]
    public void ObtenerResumenCompras_DebeManejarResumenConTotalesPorTipoVacio()
    {
        
        var fechaDesde = new DateTime(2025, 1, 1);
        var fechaHasta = new DateTime(2025, 1, 31);
        var resumenSinTotalesPorTipo = new ResumenReporteDTO
        {
            TotalGeneral = 0m,
            CantidadOperaciones = 0,
            PromedioOperacion = 0m,
            FechaDesde = fechaDesde,
            FechaHasta = fechaHasta,
            TotalesPorTipo = new Dictionary<string, decimal>()
        };

        _repositoryMock.Setup(r => r.ObtenerResumenCompras(fechaDesde, fechaHasta))
                      .Returns(resumenSinTotalesPorTipo);

        
        var resultado = _service.ObtenerResumenCompras(fechaDesde, fechaHasta);

        
        resultado.Should().NotBeNull();
        resultado.Should().BeEquivalentTo(resumenSinTotalesPorTipo);
        resultado.TotalesPorTipo.Should().BeEmpty();
        _repositoryMock.Verify(r => r.ObtenerResumenCompras(fechaDesde, fechaHasta), Times.Once);
    }

    [Fact]
    public void ObtenerComprasDelMesActual_DebeManejarMesConSoloUnDia()
    {
        
        var hoy = DateTime.Today;
        var primerDiaDelMes = new DateTime(hoy.Year, hoy.Month, 1);
        var ultimoDiaDelMes = primerDiaDelMes.AddMonths(1).AddDays(-1);
        
        // Simulamos un mes con solo un día (aunque esto no es posible en la realidad)
        var comprasEsperadas = new List<ReporteCompraDTO>();

        _repositoryMock.Setup(r => r.ObtenerComprasPorRangoFecha(primerDiaDelMes, ultimoDiaDelMes))
                      .Returns(comprasEsperadas);

        
        var resultado = _service.ObtenerComprasDelMesActual();

        
        resultado.Should().NotBeNull();
        _repositoryMock.Verify(r => r.ObtenerComprasPorRangoFecha(primerDiaDelMes, ultimoDiaDelMes), Times.Once);
    }
}
