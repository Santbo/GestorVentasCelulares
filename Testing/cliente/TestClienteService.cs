using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using GestionVentasCel.enumerations.cuentaCorriente;
using GestionVentasCel.exceptions.cliente;
using GestionVentasCel.models.clientes;
using GestionVentasCel.models.CuentaCorreinte;
using GestionVentasCel.repository.ClienteCuentaCorriente;
using GestionVentasCel.repository.persona;
using GestionVentasCel.service.cliente.impl;
using Moq;

namespace Testing.cliente
{
    public class TestClienteService
    {
        private readonly Mock<IClienteRepository> _clienteRepoMock = new();
        private readonly Mock<IPersonaRepository> _personaRepoMock = new();
        private readonly Mock<ICuentaCorrienteRepository> _cuentaRepoMock = new();
        private readonly ClienteServiceImpl _service;

        public TestClienteService()
        {
            _service = new ClienteServiceImpl(_clienteRepoMock.Object, _personaRepoMock.Object, _cuentaRepoMock.Object);
        }

        [Fact]
        public void CrearCuentaCorriente_DeberiaCrearSiNoExiste()
        {
            var cliente = new Cliente { Id = 1 };

            _clienteRepoMock.Setup(r => r.Exist(It.IsAny<int>())).Returns(true);
            _cuentaRepoMock.Setup(r => r.GetByClienteId(cliente.Id)).Returns((CuentaCorriente?)null);

            _service.CrearCuentaCorriente(cliente);

            _cuentaRepoMock.Verify(r => r.Add(It.Is<CuentaCorriente>(c => c.Cliente == cliente)), Times.Once);
        }

        [Fact]
        public void CrearCuentaCorriente_DeberiaLanzarSiClienteIdEsCero()
        {
            var cliente = new Cliente { Id = 123 };
            

            Action act = () => _service.CrearCuentaCorriente(cliente);

            act.Should().Throw<ClienteInexistenteException>();
        }

        [Fact]
        public void CrearCuentaCorriente_DeberiaLanzarSiYaExiste()
        {
            var cliente = new Cliente { Id = 1 };
            var cuentaExistente = new CuentaCorriente { Cliente = cliente };

            _cuentaRepoMock.Setup(r => r.GetByClienteId(cliente.Id)).Returns(cuentaExistente);

            Action act = () => _service.CrearCuentaCorriente(cliente);

            act.Should().Throw<CuentaCorrienteDuplicadaException>();
        }

        [Fact]
        public void EliminarMovimiento_DeberiaEliminarCorrectamente()
        {
            var movimiento = new MovimientoCuentaCorriente { Id = 10, CuentaCorrienteId = 1 };
            var cuenta = new CuentaCorriente
            {
                Id = 1,
                Movimientos = new List<MovimientoCuentaCorriente> {
                    new MovimientoCuentaCorriente { Id = 10 }
                }
            };

            _cuentaRepoMock.Setup(r => r.GetById(1)).Returns(cuenta);

            _service.EliminarMovimiento(movimiento);

            cuenta.Movimientos.Should().BeEmpty();
            _cuentaRepoMock.Verify(r => r.Update(cuenta), Times.Once);
        }

        [Fact]
        public void EliminarMovimiento_DeberiaLanzarSiCuentaNoExiste()
        {
            var movimiento = new MovimientoCuentaCorriente { CuentaCorrienteId = 99 };

            _cuentaRepoMock.Setup(r => r.GetById(99)).Returns((CuentaCorriente?)null);

            Action act = () => _service.EliminarMovimiento(movimiento);

            act.Should().Throw<CuentaCorrienteInexistenteException>();
        }

        [Fact]
        public void EliminarMovimiento_DeberiaLanzarSiMovimientoNoPertenece()
        {
            var movimiento = new MovimientoCuentaCorriente { Id = 10, CuentaCorrienteId = 1 };
            var cuenta = new CuentaCorriente
            {
                Id = 1,
                Movimientos = new List<MovimientoCuentaCorriente> {
                        new MovimientoCuentaCorriente { Id = 99 }
                    }
            };

            _cuentaRepoMock.Setup(r => r.GetById(1)).Returns(cuenta);

            Action act = () => _service.EliminarMovimiento(movimiento);

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void ObtenerSaldo_DeberiaSumarCorrectamente()
        {
            var cuenta = new CuentaCorriente
            {
                Movimientos = new List<MovimientoCuentaCorriente> {
                    new MovimientoCuentaCorriente { Tipo = TipoMovimiento.Aumento, Monto = 100 },
                    new MovimientoCuentaCorriente { Tipo = TipoMovimiento.Disminucion, Monto = 40 },
                    new MovimientoCuentaCorriente { Tipo = TipoMovimiento.Aumento, Monto = 60 }
                }
            };

            var saldo = _service.ObtenerSaldoCuentaCorriente(cuenta);

            saldo.Should().Be(120);
        }


    }
}
