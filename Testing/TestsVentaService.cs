using Xunit;
using Moq;
using FluentAssertions;
using System;
using System.Collections.Generic;
using GestionVentasCel.enumerations.ventas;
using GestionVentasCel.models.articulo;
using GestionVentasCel.models.CuentaCorreinte;
using GestionVentasCel.models.ventas;
using GestionVentasCel.repository.ClienteCuentaCorriente;
using GestionVentasCel.repository.ventas;
using GestionVentasCel.service.articulo;
using GestionVentasCel.service.reparacion;
using GestionVentasCel.service.venta.impl;
using GestionVentasCel.exceptions.venta;
using System.Windows.Forms;

public class VentaServiceTests
{
    private readonly Mock<IVentaRepository> _ventaRepoMock;
    private readonly Mock<IArticuloService> _articuloServiceMock;
    private readonly Mock<ICuentaCorrienteRepository> _ccRepoMock;
    private readonly Mock<IReparacionService> _reparacionServiceMock;
    private readonly VentaServiceImpl _serviceVenta;

    public VentaServiceTests()
    {
        _ventaRepoMock = new Mock<IVentaRepository>();
        _articuloServiceMock = new Mock<IArticuloService>();
        _ccRepoMock = new Mock<ICuentaCorrienteRepository>();
        _reparacionServiceMock = new Mock<IReparacionService>();

        _serviceVenta = new VentaServiceImpl(
            _ventaRepoMock.Object,
            _articuloServiceMock.Object,
            _ccRepoMock.Object,
            _reparacionServiceMock.Object
        );
    }


    [Fact]
    public void EliminarVenta_VentaNoExiste_LanzaExcepcion()
    {
        _ventaRepoMock.Setup(r => r.ObtenerPorIdConDetalles(1))
                      .Returns((Venta)null);

        Action act = () => _serviceVenta.EliminarVenta(1);

        act.Should().Throw<VentaNoEncontradaException>();
    }

    [Fact]
    public void EliminarVenta_VentaConfirmada_ReintegraStockYLlamaUpdateArticulo()
    {
        var articulo = new Articulo
        {
            Id = 1,
            Nombre = "prueba",
            Marca = "prueba",
            Precio = 100m,
            Stock = 0,
            Aviso_stock = 2,
            CategoriaId = 1
        };

        var venta = new Venta
        {
            Id = 1,
            EstadoVenta = EstadoVentaEnum.Confirmada,
            Detalles = new List<DetalleVenta>
        {
            new DetalleVenta
            {
                Cantidad = 5,
                PrecioUnitario = 100m,
                PorcentajeIva = 0.21m,
                Articulo = articulo,
                ArticuloId = articulo.Id
            }
        }
        };

        // Eliminar una venta debería resultar en:
        // 1. Que se obtenga la venta de la DB
        // 2. Que se reviertan los detalles, aumentando el stock de los productos vendidos según cada detalle (y que se guarden en la db)
        // 3. Finalmente, que se llame a la función Eliminar del repo de venta

        _ventaRepoMock
            .Setup(r => r.ObtenerPorIdConDetalles(1))
            .Returns(venta);

        _serviceVenta.EliminarVenta(1);

        // Ver si se revierte el stock
        articulo.Stock.Should().Be(5);

        // Ver si se actualiza el artículo en la db
        _articuloServiceMock.Verify(
            s => s.UpdateArticulo(It.Is<Articulo>(a => a.Id == articulo.Id && a.Stock == 5)),
            Times.Once);

        // Ver si se  elimina la venta en la db
        _ventaRepoMock.Verify(r => r.Eliminar(1), Times.Once);
    }

    [Fact]
    public void ObtenerMediosDePagoDisponibles_SinCuentaCorriente_DevuelveTodos()
    {
        _ccRepoMock.Setup(r => r.GetByClienteId(1)).Returns((CuentaCorriente)null);

        var result = _serviceVenta.ObtenerMediosDePagoDisponibles(1);

        result.Should().Contain(Enum.GetNames(typeof(TipoPagoEnum)));
    }

    [Fact]
    public void ObtenerMediosDePagoDisponibles_CuentaCorrienteActiva_DevuelveTodos()
    {
        var cuentaCorriente = new CuentaCorriente
        {
            Id = 1,
            ClienteId = 1,
            Activo = true,
            Movimientos = new List<MovimientoCuentaCorriente>()
        };


        _ccRepoMock.Setup(r => r.GetByClienteId(1)).Returns(cuentaCorriente);

        var result = _serviceVenta.ObtenerMediosDePagoDisponibles(1);

        result.Should().Contain(Enum.GetNames(typeof(TipoPagoEnum)));
    }

    [Fact]
    public void ObtenerMediosDePagoDisponibles_CuentaCorrienteInactiva_NoIncluyeCC()
    {
        var cuentaCorriente = new CuentaCorriente
        {
            Id = 1,
            ClienteId = 1,
            Activo = false,
            Movimientos = new List<MovimientoCuentaCorriente>()
        };
        _ccRepoMock.Setup(r => r.GetByClienteId(1)).Returns(cuentaCorriente);

        var result = _serviceVenta.ObtenerMediosDePagoDisponibles(1);

        result.Should().NotContain(TipoPagoEnum.CuentaCorriente.ToString());
    }

}
