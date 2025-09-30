using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionVentasCel.models.caja;
using GestionVentasCel.service.caja;

namespace GestionVentasCel.controller.caja
{
    public class CajaController
    {
        private readonly ICajaService _service;

        public CajaController(ICajaService cajaService)
        {
            _service = cajaService;
        }

        // Caja
        public void CrearCaja(Caja caja)
        {
            _service.CrearCaja(caja);
        }

        public void AbrirCaja(int usuarioId, decimal montoApertura)
        {
            _service.AbrirCaja(usuarioId, montoApertura);
        }

        public void ActualizarCaja(Caja caja)
        {
            _service.ActualizarCaja(caja);
        }

        public IEnumerable<Caja> ListarCajas()
        {
            return _service.ListarCajas();
        }

        public Caja? ObtenerPorId(int id)
        {
            return _service.ObtenerPorId(id);
        }

        public Caja? ObtenerConMovimientos(int id)
        {
            return _service.ObtenerConMovimientos(id);
        }

        public bool Existe(int id)
        {
            return _service.Existe(id);
        }

        public void CerrarCaja(int id, decimal montoCierre)
        {
            _service.CerrarCaja(id, montoCierre);
        }

        // Movimientos
        public void RegistrarRetiro(int cajaId, decimal monto, string descripcion)
        {
            _service.RegistrarRetiro(cajaId, monto, descripcion);
        }

        public void RegistrarVenta(int cajaId, decimal monto)
        {
            _service.RegistrarVenta(cajaId, monto);
        }

        public IEnumerable<MovimientoCaja> ListarMovimientosCaja(int cajaId)
        {
            return _service.ListarMovimientosCaja(cajaId);
        }
    }
}

