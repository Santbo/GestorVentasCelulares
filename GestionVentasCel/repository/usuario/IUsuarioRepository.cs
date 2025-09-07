using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionVentasCel.models.usuario;

namespace GestionVentasCel.repository.usuario
{
    public interface IUsuarioRepository
    { 

        Usuario? GetById(int id);
        Usuario? GetByUsername (string username);
        IEnumerable<Usuario> GetAll();
        void Add(Usuario usuario);
        void Update(Usuario usuario);

        bool Exist(int id);
    }
}
