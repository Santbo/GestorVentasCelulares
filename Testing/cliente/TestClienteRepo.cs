using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using GestionVentasCel.data;
using GestionVentasCel.exceptions.cliente;
using GestionVentasCel.models.clientes;
using GestionVentasCel.models.proveedor;
using GestionVentasCel.repository.ClienteCuentaCorriente.impl;
using Microsoft.EntityFrameworkCore;

namespace Testing.cliente
{
    public class TestClienteRepo
    {
        private AppDbContext ObtenerContexto(string dbName)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            return new AppDbContext(options);
        }

        //TODO: Hacer que tire error si el dni ya existe.

        [Fact]
        public void AgregarClienteGuardaEnDB()
        {
            using var contexto = ObtenerContexto("repo1");
            var repo = new ClienteRepositoryImpl(contexto);

            var cliente = new Cliente
            {
                Nombre = "Juan",
                Apellido = "Perez",
                TipoDocumento = GestionVentasCel.enumerations.persona.TipoDocumentoEnum.DNI,
                CondicionIVA = GestionVentasCel.enumerations.persona.CondicionIVAEnum.ConsumidorFinal,
                Dni = "12345678",
                Calle = "Calle falsa 123",
                Ciudad = "Springfield"

            };

            repo.Add(cliente);

            contexto.Clientes.Should().HaveCount(1);
            contexto.Clientes.First().Nombre.Should().Be(cliente.Nombre);
        }

        [Fact]
        public void AgregarDNIDuplicado_arrojaExcepcion()
        {
            using var contexto = ObtenerContexto("repo2");

            var cliente = new Cliente
            {
                Nombre = "Juan",
                Apellido = "Perez",
                TipoDocumento = GestionVentasCel.enumerations.persona.TipoDocumentoEnum.DNI,
                CondicionIVA = GestionVentasCel.enumerations.persona.CondicionIVAEnum.ConsumidorFinal,
                Dni = "12345678",
                Calle = "Calle falsa 123",
                Ciudad = "Springfield"

            };
            contexto.Clientes.Add(cliente);
            contexto.SaveChanges();

            var cliente2 = new Cliente
            {
                Nombre = "Jose",
                Apellido = "Gomez",
                TipoDocumento = GestionVentasCel.enumerations.persona.TipoDocumentoEnum.DNI,
                CondicionIVA = GestionVentasCel.enumerations.persona.CondicionIVAEnum.ConsumidorFinal,
                Dni = "12345678",
                Calle = "Calle falsa 123",
                Ciudad = "Springfield"

            };

            var repo = new ClienteRepositoryImpl(contexto);

            Action accion = () => { repo.Add(cliente2); };

            accion.Should().Throw<DNIDuplicadoException>();
        }
        
        [Fact]
        public void EditarDNIDuplicado_arrojaExcepcion()
        {
            using var contexto = ObtenerContexto("repo3");

            var cliente = new Cliente
            {
                Nombre = "Juan",
                Apellido = "Perez",
                TipoDocumento = GestionVentasCel.enumerations.persona.TipoDocumentoEnum.DNI,
                CondicionIVA = GestionVentasCel.enumerations.persona.CondicionIVAEnum.ConsumidorFinal,
                Dni = "12345678",
                Calle = "Calle falsa 123",
                Ciudad = "Springfield"

            };
            contexto.Clientes.Add(cliente);
            contexto.SaveChanges();

            var cliente2 = new Cliente
            {
                Id = 2,
                Nombre = "Jose",
                Apellido = "Gomez",
                TipoDocumento = GestionVentasCel.enumerations.persona.TipoDocumentoEnum.DNI,
                CondicionIVA = GestionVentasCel.enumerations.persona.CondicionIVAEnum.ConsumidorFinal,
                Dni = "12345678",
                Calle = "Calle falsa 123",
                Ciudad = "Springfield"

            };

            var repo = new ClienteRepositoryImpl(contexto);

            Action accion = () => { repo.Update(cliente2); };

            accion.Should().Throw<DNIDuplicadoException>();
        }
    }
}
