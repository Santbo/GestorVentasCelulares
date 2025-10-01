using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionVentasCel.enumerations.caja;
using GestionVentasCel.enumerations.ventas;
using GestionVentasCel.exceptions.caja;
using GestionVentasCel.models.caja;
using GestionVentasCel.repository.caja;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GestionVentasCel.service.caja.impl
{
    public class CajaServiceImpl : ICajaService
    {
        private readonly ICajaRepository _repo;

        public CajaServiceImpl(ICajaRepository cajaRepository)
        {
            _repo = cajaRepository;
        }

        // --- Caja ---
        public void CrearCaja(Caja caja)
        {
            _repo.Add(caja);
        }

        public void AbrirCaja(int usuarioId, decimal montoApertura)
        {
            // Verifico que no exista una caja abierta
            var cajasAbiertas = _repo.GetAll().Where(c => c.Estado == EstadoCajaEnum.Abierta);
            if (cajasAbiertas.Any())
                throw new CajaYaAbiertaException("Ya existe una caja abierta. Debe cerrarla antes de abrir una nueva.");

            var nuevaCaja = new Caja
            {
                UsuarioId = usuarioId,
                FechaApertura = DateTime.Now,
                MontoApertura = montoApertura,
                Estado = EstadoCajaEnum.Abierta
            };

            _repo.Add(nuevaCaja);
        }

        public void ActualizarCaja(Caja caja)
        {
            if (!_repo.Exist(caja.Id))
                throw new CajaNoEncontradaException("La caja no existe.");

            _repo.Update(caja);
        }

        public IEnumerable<Caja> ListarCajas() => _repo.GetAll();

        public Caja? ObtenerPorId(int id) => _repo.GetById(id);

        public Caja? ObtenerConMovimientos(int id) => _repo.GetWithMovimientosById(id);

        public bool Existe(int id) => _repo.Exist(id);

        public void CerrarCaja(int id, decimal montoCierre)
        {
            var caja = _repo.GetById(id);

            if (caja == null)
                throw new CajaNoEncontradaException("La caja no existe.");

            if (caja.Estado == EstadoCajaEnum.Cerrada)
                throw new CajaYaCerradaException("La caja ya está cerrada.");

            caja.MontoCierre = montoCierre;
            caja.FechaCierre = DateTime.Now;
            caja.Estado = EstadoCajaEnum.Cerrada;

            _repo.Update(caja);
        }

        public bool EstaCerrada(int id)
        {
            return _repo.EstaCerrada(id);
        }

        public bool HayCajaAbierta()
        {
            return _repo.HayCajaAbierta();
        }

        public int ObtenerCajaActualAbierta()
        {
            var caja = _repo.ObtenerCajaActualAbierta();
            return caja.Id;
        }

        // --- Movimientos ---
        public void RegistrarRetiro(int cajaId, decimal monto, string descripcion)
        {
            var caja = _repo.GetById(cajaId);

            if (caja == null)
                throw new CajaNoEncontradaException("La caja no existe.");

            if (caja.Estado == EstadoCajaEnum.Cerrada)
                throw new CajaYaCerradaException("No se pueden registrar movimientos en una caja cerrada.");

            var movimiento = new MovimientoCaja
            {
                CajaId = caja.Id,
                TipoMovimiento = TipoMovimientoEnum.Retiro,
                Monto = monto,
                Descripcion = descripcion,
                Fecha = DateTime.Now,
                TipoPago = TipoPagoEnum.Retiro
            };

            _repo.AddMovimiento(movimiento);
        }

        public void RegistrarVenta(int cajaId, decimal monto, TipoPagoEnum tipoPago)
        {
            var caja = _repo.GetById(cajaId);

            if (caja == null)
                throw new CajaNoEncontradaException("La caja no existe.");

            if (caja.Estado == EstadoCajaEnum.Cerrada)
                throw new CajaYaCerradaException("No se pueden registrar movimientos en una caja cerrada.");

            var movimiento = new MovimientoCaja
            {
                CajaId = caja.Id,
                TipoMovimiento = TipoMovimientoEnum.Venta,
                TipoPago = tipoPago,
                Monto = monto,
                Descripcion = "Venta automática",
                Fecha = DateTime.Now
            };

            _repo.AddMovimiento(movimiento);
        }

        public IEnumerable<MovimientoCaja> ListarMovimientosCaja(int cajaId)
        {
            if (!_repo.Exist(cajaId))
                throw new CajaNoEncontradaException("La caja no existe.");

            return _repo.GetMovimientosCaja(cajaId);
        }
    }
}
