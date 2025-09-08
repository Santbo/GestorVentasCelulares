using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionVentasCel.models.categoria;
using GestionVentasCel.models.usuario;

namespace GestionVentasCel.repository.categoria
{
    public interface ICategoriaRepository
    {

        Categoria? GetById(int id);
        IEnumerable<Categoria> GetAll();
        void Add(Categoria categoria);
        void Update(Categoria categoria);
        bool Exist(int id);

        bool NombreExist(string nombre);
    }
}
