using FluentAssertions;
using GestionVentasCel.enumerations.ventas;
using GestionVentasCel.models.reportes;
using GestionVentasCel.repository.reportes;
using GestionVentasCel.service;
using Moq;

namespace Testing.reportes.services;

public class ReporteVentaServiceTests
{
    private readonly Mock<IReporteVentaRepository> _repositoryMock;
    private readonly ReporteVentaService _service;

    public ReporteVentaServiceTests()
    {
        _repositoryMock = new Mock<IReporteVentaRepository>();
        _service = new ReporteVentaService(_repositoryMock.Object);
    }

    [Fact]
    public void ObtenerVentasPorRangoFecha_DebeRetornarVentasDelRepositorio()
    {
        
        var fechaDesde = new DateTime(2025, 1, 1);
        var fechaHasta = new DateTime(2025, 1, 31);
        var ventasEsperadas = new List<ReporteVentaDTO>
        {
            new ReporteVentaDTO
            {
                Id = 1,
                Fecha = new DateTime(2025, 1, 15),
                NumeroComprobante = "V-001",
                Cliente = "Cliente Test",
                TipoPago = TipoPagoEnum.Efectivo,
                TipoPagoDescripcion = "Efectivo",
                Estado = EstadoVentaEnum.Confirmada,
                EstadoDescripcion = "Confirmada",
                MontoTotal = 1200.00m,
                MontoSinIva = 1000.00m,
                MontoIva = 200.00m
            },
            new ReporteVentaDTO
            {
                Id = 2,
                Fecha = new DateTime(2025, 1, 20),
                NumeroComprobante = "V-002",
                Cliente = "Otro Cliente",
                TipoPago = TipoPagoEnum.TarjetaCredito,
                TipoPagoDescripcion = "Tarjeta de Crédito",
                Estado = EstadoVentaEnum.Confirmada,
                EstadoDescripcion = "Confirmada",
                MontoTotal = 2400.00m,
                MontoSinIva = 2000.00m,
                MontoIva = 400.00m
            }
        };

        _repositoryMock.Setup(r => r.ObtenerVentasPorRangoFecha(fechaDesde, fechaHasta))
                      .Returns(ventasEsperadas);

        
        var resultado = _service.ObtenerVentasPorRangoFecha(fechaDesde, fechaHasta);

        
        resultado.Should().NotBeNull();
        resultado.Should().HaveCount(2);
        resultado.Should().BeEquivalentTo(ventasEsperadas);
        _repositoryMock.Verify(r => r.ObtenerVentasPorRangoFecha(fechaDesde, fechaHasta), Times.Once);
    }

    [Fact]
    public void ObtenerVentasPorRangoFecha_DebeRetornarListaVaciaCuandoNoHayVentas()
    {
        
        var fechaDesde = new DateTime(2025, 1, 1);
        var fechaHasta = new DateTime(2025, 1, 31);
        var ventasVacias = new List<ReporteVentaDTO>();

        _repositoryMock.Setup(r => r.ObtenerVentasPorRangoFecha(fechaDesde, fechaHasta))
                      .Returns(ventasVacias);

        
        var resultado = _service.ObtenerVentasPorRangoFecha(fechaDesde, fechaHasta);

        
        resultado.Should().NotBeNull();
        resultado.Should().BeEmpty();
        _repositoryMock.Verify(r => r.ObtenerVentasPorRangoFecha(fechaDesde, fechaHasta), Times.Once);
    }

    [Fact]
    public void ObtenerResumenVentas_DebeRetornarResumenDelRepositorio()
    {
        
        var fechaDesde = new DateTime(2025, 1, 1);
        var fechaHasta = new DateTime(2025, 1, 31);
        var resumenEsperado = new ResumenReporteDTO
        {
            TotalGeneral = 3600.00m,
            CantidadOperaciones = 2,
            PromedioOperacion = 1800.00m,
            FechaDesde = fechaDesde,
            FechaHasta = fechaHasta,
            TotalesPorTipo = new Dictionary<string, decimal>
            {
                { "Efectivo", 1200.00m },
                { "Tarjeta de Crédito", 2400.00m }
            }
        };

        _repositoryMock.Setup(r => r.ObtenerResumenVentas(fechaDesde, fechaHasta))
                      .Returns(resumenEsperado);

        
        var resultado = _service.ObtenerResumenVentas(fechaDesde, fechaHasta);

        
        resultado.Should().NotBeNull();
        resultado.Should().BeEquivalentTo(resumenEsperado);
        _repositoryMock.Verify(r => r.ObtenerResumenVentas(fechaDesde, fechaHasta), Times.Once);
    }

    [Fact]
    public void ObtenerVentasDelMesActual_DebeCalcularFechasCorrectamente()
    {
        
        var hoy = DateTime.Today;
        var primerDiaDelMes = new DateTime(hoy.Year, hoy.Month, 1);
        var ultimoDiaDelMes = primerDiaDelMes.AddMonths(1).AddDays(-1);
        var ventasEsperadas = new List<ReporteVentaDTO>
        {
            new ReporteVentaDTO
            {
                Id = 1,
                Fecha = hoy.AddDays(-3),
                NumeroComprobante = "V-001",
                Cliente = "Cliente Actual",
                TipoPago = TipoPagoEnum.Efectivo,
                TipoPagoDescripcion = "Efectivo",
                Estado = EstadoVentaEnum.Confirmada,
                EstadoDescripcion = "Confirmada",
                MontoTotal = 1500.00m,
                MontoSinIva = 1250.00m,
                MontoIva = 250.00m
            }
        };

        _repositoryMock.Setup(r => r.ObtenerVentasPorRangoFecha(primerDiaDelMes, ultimoDiaDelMes))
                      .Returns(ventasEsperadas);

        
        var resultado = _service.ObtenerVentasDelMesActual();

        
        resultado.Should().NotBeNull();
        resultado.Should().HaveCount(1);
        resultado.Should().BeEquivalentTo(ventasEsperadas);
        _repositoryMock.Verify(r => r.ObtenerVentasPorRangoFecha(primerDiaDelMes, ultimoDiaDelMes), Times.Once);
    }

    [Fact]
    public void ObtenerResumenDelMesActual_DebeCalcularFechasCorrectamente()
    {
        
        var hoy = DateTime.Today;
        var primerDiaDelMes = new DateTime(hoy.Year, hoy.Month, 1);
        var ultimoDiaDelMes = primerDiaDelMes.AddMonths(1).AddDays(-1);
        var resumenEsperado = new ResumenReporteDTO
        {
            TotalGeneral = 7500.00m,
            CantidadOperaciones = 5,
            PromedioOperacion = 1500.00m,
            FechaDesde = primerDiaDelMes,
            FechaHasta = ultimoDiaDelMes,
            TotalesPorTipo = new Dictionary<string, decimal>
            {
                { "Efectivo", 3000.00m },
                { "Tarjeta de Crédito", 2500.00m },
                { "Transferencia", 2000.00m }
            }
        };

        _repositoryMock.Setup(r => r.ObtenerResumenVentas(primerDiaDelMes, ultimoDiaDelMes))
                      .Returns(resumenEsperado);

        
        var resultado = _service.ObtenerResumenDelMesActual();

        
        resultado.Should().NotBeNull();
        resultado.Should().BeEquivalentTo(resumenEsperado);
        _repositoryMock.Verify(r => r.ObtenerResumenVentas(primerDiaDelMes, ultimoDiaDelMes), Times.Once);
    }

    [Fact]
    public void ObtenerVentasDelMesActual_DebeCalcularFechasCorrectamenteParaDiferentesMeses()
    {
        
        var hoy = DateTime.Today;
        var primerDiaDelMes = new DateTime(hoy.Year, hoy.Month, 1);
        var ultimoDiaDelMes = primerDiaDelMes.AddMonths(1).AddDays(-1);
        
        var ventasEsperadas = new List<ReporteVentaDTO>();

        _repositoryMock.Setup(r => r.ObtenerVentasPorRangoFecha(primerDiaDelMes, ultimoDiaDelMes))
                      .Returns(ventasEsperadas);

        
        var resultado = _service.ObtenerVentasDelMesActual();

        
        resultado.Should().NotBeNull();
        _repositoryMock.Verify(r => r.ObtenerVentasPorRangoFecha(
            It.Is<DateTime>(f => f.Year == hoy.Year && f.Month == hoy.Month && f.Day == 1),
            It.Is<DateTime>(f => f.Year == hoy.Year && f.Month == hoy.Month && f.Day == ultimoDiaDelMes.Day)
        ), Times.Once);
    }

    [Fact]
    public void ObtenerVentasPorRangoFecha_DebeManejarDiferentesTiposDePago()
    {
        
        var fechaDesde = new DateTime(2025, 1, 1);
        var fechaHasta = new DateTime(2025, 1, 31);
        var ventasConDiferentesTiposPago = new List<ReporteVentaDTO>
        {
            new ReporteVentaDTO
            {
                Id = 1,
                Fecha = new DateTime(2025, 1, 10),
                NumeroComprobante = "V-001",
                Cliente = "Cliente 1",
                TipoPago = TipoPagoEnum.Efectivo,
                TipoPagoDescripcion = "Efectivo",
                Estado = EstadoVentaEnum.Confirmada,
                EstadoDescripcion = "Confirmada",
                MontoTotal = 1000.00m,
                MontoSinIva = 833.33m,
                MontoIva = 166.67m
            },
            new ReporteVentaDTO
            {
                Id = 2,
                Fecha = new DateTime(2025, 1, 15),
                NumeroComprobante = "V-002",
                Cliente = "Cliente 2",
                TipoPago = TipoPagoEnum.TarjetaCredito,
                TipoPagoDescripcion = "Tarjeta de Crédito",
                Estado = EstadoVentaEnum.Confirmada,
                EstadoDescripcion = "Confirmada",
                MontoTotal = 2000.00m,
                MontoSinIva = 1666.67m,
                MontoIva = 333.33m
            },
            new ReporteVentaDTO
            {
                Id = 3,
                Fecha = new DateTime(2025, 1, 20),
                NumeroComprobante = "V-003",
                Cliente = "Cliente 3",
                TipoPago = TipoPagoEnum.Transferencia,
                TipoPagoDescripcion = "Transferencia",
                Estado = EstadoVentaEnum.Confirmada,
                EstadoDescripcion = "Confirmada",
                MontoTotal = 1500.00m,
                MontoSinIva = 1250.00m,
                MontoIva = 250.00m
            }
        };

        _repositoryMock.Setup(r => r.ObtenerVentasPorRangoFecha(fechaDesde, fechaHasta))
                      .Returns(ventasConDiferentesTiposPago);

        
        var resultado = _service.ObtenerVentasPorRangoFecha(fechaDesde, fechaHasta);

        
        resultado.Should().NotBeNull();
        resultado.Should().HaveCount(3);
        resultado.Should().Contain(v => v.TipoPago == TipoPagoEnum.Efectivo);
        resultado.Should().Contain(v => v.TipoPago == TipoPagoEnum.TarjetaCredito);
        resultado.Should().Contain(v => v.TipoPago == TipoPagoEnum.Transferencia);
        _repositoryMock.Verify(r => r.ObtenerVentasPorRangoFecha(fechaDesde, fechaHasta), Times.Once);
    }

    [Fact]
    public void ObtenerVentasPorRangoFecha_DebeManejarDiferentesEstadosDeVenta()
    {
        
        var fechaDesde = new DateTime(2025, 1, 1);
        var fechaHasta = new DateTime(2025, 1, 31);
        var ventasConDiferentesEstados = new List<ReporteVentaDTO>
        {
            new ReporteVentaDTO
            {
                Id = 1,
                Fecha = new DateTime(2025, 1, 10),
                NumeroComprobante = "V-001",
                Cliente = "Cliente 1",
                TipoPago = TipoPagoEnum.Efectivo,
                TipoPagoDescripcion = "Efectivo",
                Estado = EstadoVentaEnum.Confirmada,
                EstadoDescripcion = "Confirmada",
                MontoTotal = 1000.00m,
                MontoSinIva = 833.33m,
                MontoIva = 166.67m
            },
            new ReporteVentaDTO
            {
                Id = 2,
                Fecha = new DateTime(2025, 1, 15),
                NumeroComprobante = "V-002",
                Cliente = "Cliente 2",
                TipoPago = TipoPagoEnum.TarjetaCredito,
                TipoPagoDescripcion = "Tarjeta de Crédito",
                Estado = EstadoVentaEnum.Borrador,
                EstadoDescripcion = "Borrador",
                MontoTotal = 2000.00m,
                MontoSinIva = 1666.67m,
                MontoIva = 333.33m
            },
            new ReporteVentaDTO
            {
                Id = 3,
                Fecha = new DateTime(2025, 1, 20),
                NumeroComprobante = "V-003",
                Cliente = "Cliente 3",
                TipoPago = TipoPagoEnum.Transferencia,
                TipoPagoDescripcion = "Transferencia",
                Estado = EstadoVentaEnum.Anulada,
                EstadoDescripcion = "Anulada",
                MontoTotal = 1500.00m,
                MontoSinIva = 1250.00m,
                MontoIva = 250.00m
            }
        };

        _repositoryMock.Setup(r => r.ObtenerVentasPorRangoFecha(fechaDesde, fechaHasta))
                      .Returns(ventasConDiferentesEstados);

        
        var resultado = _service.ObtenerVentasPorRangoFecha(fechaDesde, fechaHasta);

        
        resultado.Should().NotBeNull();
        resultado.Should().HaveCount(3);
        resultado.Should().Contain(v => v.Estado == EstadoVentaEnum.Confirmada);
        resultado.Should().Contain(v => v.Estado == EstadoVentaEnum.Borrador);
        resultado.Should().Contain(v => v.Estado == EstadoVentaEnum.Anulada);
        _repositoryMock.Verify(r => r.ObtenerVentasPorRangoFecha(fechaDesde, fechaHasta), Times.Once);
    }

    [Fact]
    public void ObtenerVentasPorRangoFecha_DebeManejarFechasInvalidas()
    {
        
        var fechaDesde = new DateTime(2025, 1, 31);
        var fechaHasta = new DateTime(2025, 1, 1); // Fecha hasta anterior a fecha desde
        var ventasVacias = new List<ReporteVentaDTO>();

        _repositoryMock.Setup(r => r.ObtenerVentasPorRangoFecha(fechaDesde, fechaHasta))
                      .Returns(ventasVacias);

        
        var resultado = _service.ObtenerVentasPorRangoFecha(fechaDesde, fechaHasta);

        
        resultado.Should().NotBeNull();
        resultado.Should().BeEmpty();
        _repositoryMock.Verify(r => r.ObtenerVentasPorRangoFecha(fechaDesde, fechaHasta), Times.Once);
    }

    [Fact]
    public void ObtenerResumenVentas_DebeManejarResumenConTotalesPorTipoVacio()
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

        _repositoryMock.Setup(r => r.ObtenerResumenVentas(fechaDesde, fechaHasta))
                      .Returns(resumenSinTotalesPorTipo);

        
        var resultado = _service.ObtenerResumenVentas(fechaDesde, fechaHasta);

        
        resultado.Should().NotBeNull();
        resultado.Should().BeEquivalentTo(resumenSinTotalesPorTipo);
        resultado.TotalesPorTipo.Should().BeEmpty();
        _repositoryMock.Verify(r => r.ObtenerResumenVentas(fechaDesde, fechaHasta), Times.Once);
    }
}
