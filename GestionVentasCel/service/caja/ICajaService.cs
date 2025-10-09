using GestionVentasCel.enumerations.ventas;
using GestionVentasCel.models.caja;

namespace GestionVentasCel.service.caja
{
    public interface ICajaService
    {
        // Caja
        void CrearCaja(Caja caja);
        void AbrirCaja(int usuarioId, decimal montoApertura);
        void ActualizarCaja(Caja caja);
        IEnumerable<Caja> ListarCajas();
        Caja? ObtenerPorId(int id);
        Caja? ObtenerConMovimientos(int id);
        bool Existe(int id);
        void CerrarCaja(int id, decimal montoCierre);
        bool EstaCerrada(int id);
        bool HayCajaAbierta();
        int ObtenerCajaActualAbierta();

        // Movimientos
        void RegistrarRetiro(int cajaId, decimal monto, string descripcion);
        void RegistrarVenta(int cajaId, decimal monto, TipoPagoEnum tipoPago);
        IEnumerable<MovimientoCaja> ListarMovimientosCaja(int cajaId);
    }
}
