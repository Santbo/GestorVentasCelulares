using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionVentasCel.models.categoria;
using GestionVentasCel.models.usuario;

namespace GestionVentasCel.service.categoria
{
    public interface ICategoriaService
    {
        void AgregarCategoria(string nombre, string descripcion);
        IEnumerable<Categoria> listarCategoria();

        void UpdateCategoria(Categoria categoria);

        void ToggleActivo(int id);

        Categoria? GetById(int id);
    }
}
