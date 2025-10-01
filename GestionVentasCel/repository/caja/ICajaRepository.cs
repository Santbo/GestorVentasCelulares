using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionVentasCel.models.caja;

namespace GestionVentasCel.repository.caja
{
    public interface ICajaRepository
    {
        // Caja
        void Add(Caja caja);
        void Update(Caja caja);
        IEnumerable<Caja> GetAll();
        Caja? GetById(int id);
        Caja? GetWithMovimientosById(int id);
        bool Exist(int id);
        bool EstaCerrada(int id);
        bool HayCajaAbierta();
        Caja? ObtenerCajaActualAbierta();

        // Movimientos
        void AddMovimiento(MovimientoCaja movimiento);
        IEnumerable<MovimientoCaja> GetMovimientosCaja(int cajaId);
    }
}
