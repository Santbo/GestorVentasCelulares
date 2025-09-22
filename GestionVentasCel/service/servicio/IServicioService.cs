using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionVentasCel.models.servicio;

namespace GestionVentasCel.service.servicio
{
    public interface IServicioService
    {
        void Add(string nombre,
                        decimal precio,
                        List<ServicioArticulo> articulosUsados,
                        string descripcion = null);
        void Update (Servicio servicio);
        void ToggleEstado(int id);
        Servicio? GetById(int id);

        Servicio? GetServicioConArticulos(int id);
        IEnumerable<Servicio> GetAll();
        IEnumerable<ServicioArticulo> GetAllArticulosUsados(int id);

    }
}
