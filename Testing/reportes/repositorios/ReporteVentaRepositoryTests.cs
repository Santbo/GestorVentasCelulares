using GestionVentasCel.data;
using GestionVentasCel.enumerations.usuarios;
using GestionVentasCel.enumerations.ventas;
using GestionVentasCel.models.clientes;
using GestionVentasCel.models.usuario;
using GestionVentasCel.models.ventas;
using GestionVentasCel.repository.reportes.impl;
using Microsoft.EntityFrameworkCore;

namespace Testing.reportes;

public class ReporteVentaRepositoryTests : IDisposable
{
    private readonly AppDbContext _context;
    private readonly ReporteVentaRepositoryImpl _repository;

    public ReporteVentaRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new AppDbContext(options);
        _repository = new ReporteVentaRepositoryImpl(_context);

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
        var usuario = new Usuario
        {
            Username = "admin",
            Password = "admin123",
            Rol = RolEnum.Admin,
            Nombre = "Admin",
            Apellido = "Test",
            Activo = true
        };

        var cliente = new Cliente
        {
            Nombre = "Cliente Test",
            Apellido = "Apellido Test",
            Telefono = "123456789"
        };

        _context.Usuarios.Add(usuario);
        _context.Clientes.Add(cliente);
        _context.SaveChanges();
    }

    [Fact]
    public void ObtenerVentasPorRangoFecha_DebeRetornarVentasEnRango()
    {
        
        var fechaInicio = new DateTime(2025, 1, 1);
        var fechaFin = new DateTime(2025, 1, 31);

        var venta = CrearVentaConDetalles(new DateTime(2025, 1, 15), EstadoVentaEnum.Confirmada);
        _context.Ventas.Add(venta);
        _context.SaveChanges();

        
        var resultado = _repository.ObtenerVentasPorRangoFecha(fechaInicio, fechaFin);

        
        Assert.Single(resultado);
        Assert.Equal(venta.Id, resultado.First().Id);
    }

    [Fact]
    public void ObtenerVentasPorRangoFecha_DebeExcluirVentasAnuladas()
    {
        
        var fecha = new DateTime(2025, 2, 1);

        var ventaConfirmada = CrearVentaConDetalles(fecha, EstadoVentaEnum.Confirmada);
        var ventaAnulada = CrearVentaConDetalles(fecha, EstadoVentaEnum.Anulada);

        _context.Ventas.AddRange(ventaConfirmada, ventaAnulada);
        _context.SaveChanges();

        
        var resultado = _repository.ObtenerVentasPorRangoFecha(fecha, fecha);

        
        Assert.Single(resultado);
        Assert.Equal(EstadoVentaEnum.Confirmada, resultado.First().Estado);
    }

    [Fact]
    public void ObtenerVentasPorRangoFecha_DebeRetornarListaVaciaCuandoNoHayVentas()
    {
        
        var fechaInicio = new DateTime(2025, 3, 1);
        var fechaFin = new DateTime(2025, 3, 31);

        
        var resultado = _repository.ObtenerVentasPorRangoFecha(fechaInicio, fechaFin);

        
        Assert.Empty(resultado);
    }

    [Fact]
    public void ObtenerVentasPorRangoFecha_DebeCalcularMontosCorrectamente()
    {
        
        var fecha = new DateTime(2025, 4, 1);
        var venta = CrearVentaConDetalles(fecha, EstadoVentaEnum.Confirmada);
        _context.Ventas.Add(venta);
        _context.SaveChanges();

        
        var resultado = _repository.ObtenerVentasPorRangoFecha(fecha, fecha);

        
        var reporteVenta = resultado.First();
        Assert.True(reporteVenta.MontoTotal > 0);
        Assert.True(reporteVenta.MontoSinIva > 0);
        Assert.True(reporteVenta.MontoIva >= 0);
        // Verificar que la diferencia sea menor a 1 (tolerancia para redondeo)
        Assert.True(Math.Abs((reporteVenta.MontoSinIva + reporteVenta.MontoIva) - reporteVenta.MontoTotal) < 1);
    }

    [Fact]
    public void ObtenerVentasPorRangoFecha_DebeIncluirInformacionDelCliente()
    {
        
        var fecha = new DateTime(2025, 5, 1);
        var venta = CrearVentaConDetalles(fecha, EstadoVentaEnum.Confirmada);
        _context.Ventas.Add(venta);
        _context.SaveChanges();

        
        var resultado = _repository.ObtenerVentasPorRangoFecha(fecha, fecha);

        
        var reporteVenta = resultado.First();
        Assert.NotNull(reporteVenta.Cliente);
        Assert.NotEmpty(reporteVenta.Cliente);
    }

    [Fact]
    public void ObtenerVentasPorRangoFecha_DebeOrdenarPorFechaDescendente()
    {
        
        var fecha1 = new DateTime(2025, 6, 1);
        var fecha2 = new DateTime(2025, 6, 15);
        var fecha3 = new DateTime(2025, 6, 30);

        var venta1 = CrearVentaConDetalles(fecha1, EstadoVentaEnum.Confirmada);
        var venta2 = CrearVentaConDetalles(fecha2, EstadoVentaEnum.Confirmada);
        var venta3 = CrearVentaConDetalles(fecha3, EstadoVentaEnum.Confirmada);

        _context.Ventas.AddRange(venta1, venta2, venta3);
        _context.SaveChanges();

        
        var resultado = _repository.ObtenerVentasPorRangoFecha(fecha1, fecha3).ToList();

        
        Assert.Equal(3, resultado.Count);
        Assert.True(resultado[0].Fecha >= resultado[1].Fecha);
        Assert.True(resultado[1].Fecha >= resultado[2].Fecha);
    }

    [Fact]
    public void ObtenerResumenVentas_DebeCalcularTotalGeneralCorrectamente()
    {
        
        var fecha = new DateTime(2025, 7, 1);
        var venta1 = CrearVentaConDetalles(fecha, EstadoVentaEnum.Confirmada);
        var venta2 = CrearVentaConDetalles(fecha.AddDays(1), EstadoVentaEnum.Confirmada);

        _context.Ventas.AddRange(venta1, venta2);
        _context.SaveChanges();

        
        var resultado = _repository.ObtenerResumenVentas(fecha, fecha.AddDays(5));

        
        Assert.True(resultado.TotalGeneral > 0);
        Assert.Equal(2, resultado.CantidadOperaciones);
    }

    [Fact]
    public void ObtenerResumenVentas_DebeCalcularPromedioCorrectamente()
    {
        
        var fecha = new DateTime(2025, 8, 1);
        var venta1 = CrearVentaConDetalles(fecha, EstadoVentaEnum.Confirmada);
        var venta2 = CrearVentaConDetalles(fecha.AddDays(1), EstadoVentaEnum.Confirmada);

        _context.Ventas.AddRange(venta1, venta2);
        _context.SaveChanges();

        
        var resultado = _repository.ObtenerResumenVentas(fecha, fecha.AddDays(5));

        
        var promedioEsperado = resultado.TotalGeneral / resultado.CantidadOperaciones;
        Assert.Equal(promedioEsperado, resultado.PromedioOperacion);
    }

    [Fact]
    public void ObtenerResumenVentas_DebeRetornarCerosCuandoNoHayVentas()
    {
        
        var fecha = new DateTime(2025, 9, 1);

        
        var resultado = _repository.ObtenerResumenVentas(fecha, fecha.AddDays(30));

        
        Assert.Equal(0, resultado.TotalGeneral);
        Assert.Equal(0, resultado.CantidadOperaciones);
        Assert.Equal(0, resultado.PromedioOperacion);
    }

    [Fact]
    public void ObtenerResumenVentas_DebeExcluirVentasAnuladas()
    {
        
        var fecha = new DateTime(2025, 10, 1);
        var ventaConfirmada = CrearVentaConDetalles(fecha, EstadoVentaEnum.Confirmada);
        var ventaAnulada = CrearVentaConDetalles(fecha, EstadoVentaEnum.Anulada);

        _context.Ventas.AddRange(ventaConfirmada, ventaAnulada);
        _context.SaveChanges();

        
        var resultado = _repository.ObtenerResumenVentas(fecha, fecha);

        
        Assert.Equal(1, resultado.CantidadOperaciones);
    }

    // Métodos auxiliares
    private Venta CrearVentaConDetalles(DateTime fecha, EstadoVentaEnum estado)
    {
        var cliente = _context.Clientes.First();
        var usuario = _context.Usuarios.First();

        var venta = new Venta
        {
            FechaCreacion = fecha,
            FechaVenta = fecha,
            EstadoVenta = estado,
            ClienteId = cliente.Id,
            Cliente = cliente,
            UsuarioId = usuario.Id,
            Usuario = usuario,
            TipoPago = TipoPagoEnum.Efectivo,
            Detalles = new List<DetalleVenta>
            {
                new DetalleVenta
                {
                    PrecioUnitario = 100.00m,
                    Cantidad = 2,
                    PorcentajeIva = 0.21m
                },
                new DetalleVenta
                {
                    PrecioUnitario = 50.00m,
                    Cantidad = 1,
                    PorcentajeIva = 0.21m
                }
            }
        };

        return venta;
    }
}
