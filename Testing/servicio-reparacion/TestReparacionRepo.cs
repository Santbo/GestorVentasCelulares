using GestionVentasCel.data;
using GestionVentasCel.enumerations.reparacion;
using GestionVentasCel.models.reparacion;
using GestionVentasCel.repository.reparacion.impl;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using Xunit;
using System.Linq;
using GestionVentasCel.models.servicio;
using GestionVentasCel.models.clientes;
using GestionVentasCel.enumerations.persona;
using System.Runtime.InteropServices;

namespace Testing.ServiciosReparaciones;
public class ReparacionRepositoryTests
{
    private AppDbContext CrearContexto()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        return new AppDbContext(options);
    }

    [Fact]
    public void ListarReparacionesTerminadasCliente_DeberiaFiltrarCorrectamente()
    {
        using var context = CrearContexto();
        var cliente = new Cliente
        {
            Nombre = "prueba",
            Apellido = "Prueba",
            TipoDocumento = TipoDocumentoEnum.DNI,
            CondicionIVA = CondicionIVAEnum.ConsumidorFinal,
            Calle = "Calle falsa 123",
            Ciudad = "springfield",
            Telefono = "1233123123"
        };
        context.Clientes.Add(cliente);
        
        var repo = new ReparacionRepositoryImpl(context);

        context.Reparaciones.AddRange(new[]
        {
            new Reparacion { Id=1, Dispositivo = new Dispositivo { Nombre="X", ClienteId=cliente.Id }, Estado=EstadoReparacionEnum.Terminado, Total=50 },
            new Reparacion { Id=2, Dispositivo = new Dispositivo { Nombre="Y", ClienteId=cliente.Id }, Estado=EstadoReparacionEnum.Ingresado, Total=100 },
            new Reparacion { Id=3, Dispositivo = new Dispositivo { Nombre="Z", ClienteId=2 }, Estado=EstadoReparacionEnum.Terminado, Total=200 }
        });
        context.SaveChanges();

        // Act
        var terminadas = repo.ListarReparacionesTerminadasCliente(cliente.Id);

        // Assert
        terminadas.Should().HaveCount(1);
        terminadas.First().Estado.Should().Be(EstadoReparacionEnum.Terminado);
        terminadas.First().Dispositivo.ClienteId.Should().Be(cliente.Id);
    }

}
