using Xunit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using GestionVentasCel.data;
using GestionVentasCel.enumerations.cuentaCorriente;
using GestionVentasCel.enumerations.reparacion;
using GestionVentasCel.enumerations.ventas;
using GestionVentasCel.exceptions.venta;
using GestionVentasCel.models.articulo;
using GestionVentasCel.models.reparacion;
using GestionVentasCel.models.ventas;
using GestionVentasCel.service.venta;
using GestionVentasCel.service.venta.impl;
using GestionVentasCel.repository.ventas.impl;
using Moq;
using GestionVentasCel.repository.ventas;
using FluentAssertions;
using GestionVentasCel.models.clientes;
using GestionVentasCel.enumerations.persona;
using GestionVentasCel.models.usuario;
using GestionVentasCel.models.CuentaCorreinte;

namespace Testing.ventas;
public class VentaRepoTest
{
    public Venta CrearVenta()
    {
        var articulo = new Articulo
        {
            Id = 1,
            Nombre = "Prueba",
            Stock = 10,
            Aviso_stock = 2,
            Precio = 100m,
            Marca = "marca",
            CategoriaId = 1
        };
        var reparacion = new Reparacion
        {
            Id = 1,
            FechaIngreso = DateTime.Now,
            Estado = EstadoReparacionEnum.Ingresado,
            Total = 500m,
            Dispositivo = new Dispositivo { Id = 1, Nombre = "Dispositivo Test" },
            ReparacionServicios = new List<ReparacionServicio>(),
            Diagnostico = "",
            FallasReportadas = ""
        };

        return new Venta
        {
            Id = 1,
            EstadoVenta = EstadoVentaEnum.Borrador,
            TipoPago = TipoPagoEnum.Efectivo,
            ClienteId = 1,
            Cliente = new Cliente
            {
                Nombre = "Prueba",
                TipoDocumento = TipoDocumentoEnum.CUIT,
                Dni = "12345678",
                CondicionIVA = CondicionIVAEnum.ConsumidorFinal,
                Calle = "Calle falsa 123",
                Ciudad = "Ciudad"
            },
            Usuario = new Usuario
            {
                Nombre = "Prueba",
                TipoDocumento = TipoDocumentoEnum.CUIT,
                Dni = "12345678",
                Username = "prueba",
                Password = "prueba",
                Calle = "Calle falsa 123",
                Ciudad = "Ciudad"
            },
            Detalles = new List<DetalleVenta>
            {
                new DetalleVenta
                {
                    VentaId = 1,
                    Cantidad = 2,
                    PrecioUnitario = 100m,
                    PorcentajeIva = 0.21m,
                    Articulo = articulo,
                    ArticuloId = articulo.Id
                },
                new DetalleVenta
                {
                    VentaId = 1,
                    PrecioUnitario = 500m,
                    Cantidad = 1,
                    PorcentajeIva = 0.21m,
                    Reparacion = reparacion,
                    ReparacionId = reparacion.Id
                }
            }
        };
    }

    public AppDbContext CrearContextoMemoria (string Nombre)
    {
        var opciones = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: Nombre).Options;
        return new AppDbContext(opciones);
    }


    [Fact]
    public void ConfirmarVenta_VentaExistente_CambiaEstadoStockYReparacion()
    {
        using var contexto = CrearContextoMemoria("repo1");
        var repo = new VentaRepositoryImpl(contexto);
        var venta = CrearVenta();

        repo.Agregar(venta);

        repo.ConfirmarVenta(venta.Id);

        var articulo = contexto.Articulos.First(a => a.Id == 1);
        var reparacion = contexto.Reparaciones.First(r => r.Id == 1);

        // La venta dice que se vendieron dos artículos, si el stock empieza en 10, ahora debe ser 10 - 2 = 8

        articulo.Stock.Should().Be(8);
        reparacion.Estado.Should().Be(EstadoReparacionEnum.Entregado);
        

    }

    [Fact]
    public void ConfirmarVenta_VentaNoExiste_LanzaExcepcion()
    {
        using var context = CrearContextoMemoria("repo2");
        var repo = new VentaRepositoryImpl(context);

        Action accion = () => { repo.ConfirmarVenta(123); };
        accion.Should().Throw<VentaNoEncontradaException>();
    }

    [Fact]
    public void ConfirmarVenta_VentaYaConfirmada_LanzaExcepcion()
    {
        using var contexto = CrearContextoMemoria("repo3");
        var repo = new VentaRepositoryImpl(contexto);
        var venta = CrearVenta();

        repo.Agregar(venta);

        repo.ConfirmarVenta(venta.Id);

        Action accion = () => { repo.ConfirmarVenta(venta.Id); };

        accion.Should().Throw<ConfirmacionVentaDupicadaException>();

    }

    [Fact]
    public void ConfirmarVenta_TipoPagoCuentaCorriente_CreaCuentaSiNoExiste()
    {
        using var contexto = CrearContextoMemoria("repo4");
        var repo = new VentaRepositoryImpl(contexto);
        var venta = CrearVenta();

        // La venta tiene que tener el modo de pago de Cuenta Corriente, y la función CrearVenta() la crea como Efectivo
        venta.TipoPago = TipoPagoEnum.CuentaCorriente;

        repo.Agregar(venta);

        repo.ConfirmarVenta(venta.Id);

        // Assert
        var cuenta = contexto.CuentasCorrientes
            .Include(c => c.Movimientos)
            .FirstOrDefault(c => c.ClienteId == venta.ClienteId);

        // Si la cuenta no existe, se debería haber creado
        cuenta.Should().NotBeNull();
        // E insertado un solo movimiento
        cuenta.Movimientos.Should().HaveCount(1);

        var movimiento = cuenta.Movimientos.First();

        // los datos dle movimeinto deberían coincidir ocn los de la venta.
        movimiento.Tipo.Should().Be(TipoMovimiento.Aumento);
        movimiento.Monto.Should().Be(venta.TotalConIva);
        movimiento.VentaId.Should().Be(venta.Id);
        movimiento.Fecha.Should().Be(venta.FechaVenta);
    }

    [Fact]
    public void ConfirmarVenta_TipoPagoCuentaCorriente_NoCreaCuentaSiYaExiste()
    {
        // La forma de testear no es directa, sino que consiste en agregar una cuenta corriente al contexto
        // y asegurarse de que después de llamar a ConfirmarVenta() solamente existe una cuenta corriente.
        // Si existe mas de una cuenta, quiere decir que ConfirmarVenta() agregó una nueva, lo cual no debería
        // pasar.

        using var contexto = CrearContextoMemoria("repo5");
        var repo = new VentaRepositoryImpl(contexto);
        var venta = CrearVenta();

        // La venta tiene que tener el modo de pago de Cuenta Corriente, y la función CrearVenta() la crea como Efectivo
        venta.TipoPago = TipoPagoEnum.CuentaCorriente;

        repo.Agregar(venta);

        // Crear la cuenta corriente antes de confirmar la venta.

        contexto.CuentasCorrientes.Add(new CuentaCorriente
        {
            Cliente = venta.Cliente,
            ClienteId = venta.ClienteId,
        });
        contexto.SaveChanges();

        repo.ConfirmarVenta(venta.Id);

        // Si esto es distinto de 1, entonces es porque se creó una nueva cuenta corriente
        contexto.Ventas.Should().HaveCount(1);

    }

}
