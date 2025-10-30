using GestionVentasCel.data;
using GestionVentasCel.enumerations.persona;
using GestionVentasCel.models.compra;
using GestionVentasCel.models.proveedor;
using GestionVentasCel.repository.reportes.impl;
using Microsoft.EntityFrameworkCore;

namespace Testing.reportes;

public class ReporteCompraRepositoryTests : IDisposable
{
    private readonly AppDbContext _context;
    private readonly ReporteCompraRepositoryImpl _repository;

    public ReporteCompraRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new AppDbContext(options);
        _repository = new ReporteCompraRepositoryImpl(_context);

        // Configurar datos de prueba base
        SeedTestData();
    }

    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }

    private void SeedTestData()
    {
        var proveedor = new Proveedor
        {
            Nombre = "Proveedor Test",
            Telefono = "987654321",
            CondicionIVA = CondicionIVAEnum.ResponsableInscripto
        };

        _context.Proveedores.Add(proveedor);
        _context.SaveChanges();
    }

    [Fact]
    public void ObtenerComprasPorRangoFecha_DebeRetornarComprasEnRango()
    {
        
        var fechaInicio = new DateTime(2025, 1, 1);
        var fechaFin = new DateTime(2025, 1, 31);

        var compra = CrearCompraConDetalles(new DateTime(2025, 1, 15));
        _context.Compras.Add(compra);
        _context.SaveChanges();

        
        var resultado = _repository.ObtenerComprasPorRangoFecha(fechaInicio, fechaFin);

        
        Assert.Single(resultado);
        Assert.Equal(compra.Id, resultado.First().Id);
    }

    [Fact]
    public void ObtenerComprasPorRangoFecha_DebeRetornarListaVaciaCuandoNoHayCompras()
    {
        
        var fechaInicio = new DateTime(2025, 2, 1);
        var fechaFin = new DateTime(2025, 2, 28);

        
        var resultado = _repository.ObtenerComprasPorRangoFecha(fechaInicio, fechaFin);

        
        Assert.Empty(resultado);
    }

    [Fact]
    public void ObtenerComprasPorRangoFecha_DebeIncluirInformacionDelProveedor()
    {
        
        var fecha = new DateTime(2025, 3, 1);
        var compra = CrearCompraConDetalles(fecha);
        _context.Compras.Add(compra);
        _context.SaveChanges();

        
        var resultado = _repository.ObtenerComprasPorRangoFecha(fecha, fecha);

        
        var reporteCompra = resultado.First();
        Assert.NotNull(reporteCompra.Proveedor);
        Assert.NotEmpty(reporteCompra.Proveedor);
        Assert.Equal("Proveedor Test", reporteCompra.Proveedor);
    }

    [Fact]
    public void ObtenerComprasPorRangoFecha_DebeCalcularMontoTotalCorrectamente()
    {
        
        var fecha = new DateTime(2025, 4, 1);
        var compra = CrearCompraConDetalles(fecha);
        _context.Compras.Add(compra);
        _context.SaveChanges();

        
        var resultado = _repository.ObtenerComprasPorRangoFecha(fecha, fecha);

        
        var reporteCompra = resultado.First();
        Assert.True(reporteCompra.MontoTotal > 0);
        Assert.Equal(compra.Total, reporteCompra.MontoTotal);
    }

    [Fact]
    public void ObtenerComprasPorRangoFecha_DebeGenerarNumeroComprobanteCorrectamente()
    {
        
        var fecha = new DateTime(2025, 5, 1);
        var compra = CrearCompraConDetalles(fecha);
        _context.Compras.Add(compra);
        _context.SaveChanges();

        
        var resultado = _repository.ObtenerComprasPorRangoFecha(fecha, fecha);

        
        var reporteCompra = resultado.First();
        Assert.NotNull(reporteCompra.NumeroComprobante);
        Assert.StartsWith("C-", reporteCompra.NumeroComprobante);
    }

    [Fact]
    public void ObtenerComprasPorRangoFecha_DebeOrdenarPorFechaDescendente()
    {
        
        var fecha1 = new DateTime(2025, 6, 1);
        var fecha2 = new DateTime(2025, 6, 15);
        var fecha3 = new DateTime(2025, 6, 30);

        var compra1 = CrearCompraConDetalles(fecha1);
        var compra2 = CrearCompraConDetalles(fecha2);
        var compra3 = CrearCompraConDetalles(fecha3);

        _context.Compras.AddRange(compra1, compra2, compra3);
        _context.SaveChanges();

        
        var resultado = _repository.ObtenerComprasPorRangoFecha(fecha1, fecha3).ToList();

        
        Assert.Equal(3, resultado.Count);
        Assert.True(resultado[0].Fecha >= resultado[1].Fecha);
        Assert.True(resultado[1].Fecha >= resultado[2].Fecha);
    }

    [Fact]
    public void ObtenerComprasPorRangoFecha_DebeIncluirVariasComprasEnRango()
    {
        
        var fechaInicio = new DateTime(2025, 7, 1);
        var fechaFin = new DateTime(2025, 7, 31);

        var compra1 = CrearCompraConDetalles(new DateTime(2025, 7, 5));
        var compra2 = CrearCompraConDetalles(new DateTime(2025, 7, 15));
        var compra3 = CrearCompraConDetalles(new DateTime(2025, 7, 25));

        _context.Compras.AddRange(compra1, compra2, compra3);
        _context.SaveChanges();

        
        var resultado = _repository.ObtenerComprasPorRangoFecha(fechaInicio, fechaFin);

        
        Assert.Equal(3, resultado.Count());
    }

    [Fact]
    public void ObtenerResumenCompras_DebeCalcularTotalGeneralCorrectamente()
    {
        
        var fecha = new DateTime(2025, 8, 1);
        var compra1 = CrearCompraConDetalles(fecha, 1000m);
        var compra2 = CrearCompraConDetalles(fecha.AddDays(1), 2000m);

        _context.Compras.AddRange(compra1, compra2);
        _context.SaveChanges();

        
        var resultado = _repository.ObtenerResumenCompras(fecha, fecha.AddDays(5));

        
        Assert.Equal(3000m, resultado.TotalGeneral);
        Assert.Equal(2, resultado.CantidadOperaciones);
    }

    [Fact]
    public void ObtenerResumenCompras_DebeCalcularPromedioCorrectamente()
    {
        
        var fecha = new DateTime(2025, 9, 1);
        var compra1 = CrearCompraConDetalles(fecha, 600m);
        var compra2 = CrearCompraConDetalles(fecha.AddDays(1), 400m);

        _context.Compras.AddRange(compra1, compra2);
        _context.SaveChanges();

        
        var resultado = _repository.ObtenerResumenCompras(fecha, fecha.AddDays(5));

        
        Assert.Equal(500m, resultado.PromedioOperacion);
    }

    [Fact]
    public void ObtenerResumenCompras_DebeRetornarCerosCuandoNoHayCompras()
    {
        
        var fecha = new DateTime(2025, 10, 1);

        
        var resultado = _repository.ObtenerResumenCompras(fecha, fecha.AddDays(30));

        
        Assert.Equal(0, resultado.TotalGeneral);
        Assert.Equal(0, resultado.CantidadOperaciones);
        Assert.Equal(0, resultado.PromedioOperacion);
    }

    // Métodos auxiliares
    private Compra CrearCompraConDetalles(DateTime fecha, decimal? totalOverride = null)
    {
        var proveedor = _context.Proveedores.First();
        var total = totalOverride ?? 500.00m;

        var compra = new Compra
        {
            Fecha = fecha,
            Total = total,
            ProveedorId = proveedor.Id,
            Proveedor = proveedor,
            Observaciones = "Compra de prueba",
            Detalles = new List<DetalleCompra>()
        };

        return compra;
    }
}
