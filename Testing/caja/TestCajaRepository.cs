using GestionVentasCel.data;
using GestionVentasCel.enumerations.caja;
using GestionVentasCel.enumerations.ventas;
using GestionVentasCel.models.caja;
using GestionVentasCel.repository.caja.impl;
using Microsoft.EntityFrameworkCore;

namespace Testing.caja
{
    public class TestCajaRepository
    {

        private readonly AppDbContext _context;
        private readonly CajaRepositoryImpl _repo;
        public TestCajaRepository()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new AppDbContext(options);
            _repo = new CajaRepositoryImpl(_context);

        }

        [Fact]
        public void Add_DeberiaGuardarCajaEnBaseDeDatos()
        {
            var caja = new Caja { UsuarioId = 1, MontoApertura = 1000, Estado = EstadoCajaEnum.Abierta };

            _repo.Add(caja);
            var guardada = _context.Caja.FirstOrDefault();

            Assert.NotNull(guardada);
            Assert.Equal(1000, guardada.MontoApertura);
        }

        [Fact]
        public void HayCajaAbierta_DeberiaRetornarTrue_SiExisteUnaCajaAbierta()
        {
            _context.Caja.Add(new Caja { UsuarioId = 1, Estado = EstadoCajaEnum.Abierta, MontoApertura = 500 });
            _context.SaveChanges();

            bool resultado = _repo.HayCajaAbierta();

            Assert.True(resultado);
        }

        [Fact]
        public void ObtenerCajaActualAbierta_DeberiaRetornarCajaAbierta()
        {
            var caja = new Caja { UsuarioId = 1, Estado = EstadoCajaEnum.Abierta, MontoApertura = 700 };
            _context.Caja.Add(caja);
            _context.SaveChanges();

            var resultado = _repo.ObtenerCajaActualAbierta();

            Assert.NotNull(resultado);
            Assert.Equal(EstadoCajaEnum.Abierta, resultado.Estado);
        }

        [Fact]
        public void GetMovimientosCaja_DeberiaRetornarSoloMovimientosDeEsaCaja()
        {
            var caja = new Caja { UsuarioId = 1, Estado = EstadoCajaEnum.Abierta };
            _context.Caja.Add(caja);
            _context.SaveChanges();

            _context.MovimientosCaja.Add(new MovimientoCaja { CajaId = caja.Id, Monto = 200, TipoMovimiento = TipoMovimientoEnum.Venta, TipoPago = TipoPagoEnum.Efectivo });
            _context.MovimientosCaja.Add(new MovimientoCaja { CajaId = 999, Monto = 500, TipoMovimiento = TipoMovimientoEnum.Retiro, TipoPago = TipoPagoEnum.Retiro });
            _context.SaveChanges();

            var movimientos = _repo.GetMovimientosCaja(caja.Id);

            Assert.Single(movimientos);
            Assert.Equal(200, movimientos.First().Monto);
        }

        [Fact]
        public void EstaCerrada_DeberiaRetornarTrue_SiLaCajaEstaCerrada()
        {
            _context.Caja.Add(new Caja { UsuarioId = 1, Estado = EstadoCajaEnum.Cerrada });
            _context.SaveChanges();

            bool resultado = _repo.EstaCerrada(_context.Caja.First().Id);

            Assert.True(resultado);
        }
    }
}
