using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionVentasCel.models.categoria;
using GestionVentasCel.models.configPrecios;

namespace GestionVentasCel.repository.configPrecios
{
    public interface IConfiguracionPreciosRepository
    {
        void Add(ConfiguracionPrecios configuracionPrecios);
        void Update(ConfiguracionPrecios configuracionPrecios);

        ConfiguracionPrecios? GetById(int id);

        bool MargenExist(int id);

    }
}
