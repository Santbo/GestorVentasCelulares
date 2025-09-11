using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionVentasCel.models.articulo;


namespace GestionVentasCel.repository.articulo
{
    public interface IArticuloRepository
    {
        Articulo? GetById(int id);
        IEnumerable<Articulo> GetAll();
        void Add(Articulo articulo);
        void Update(Articulo articulo);
        bool Exist(int id);

        
    }
}
