using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionVentasCel.models.configPrecios;

namespace GestionVentasCel.service.configPrecios
{
    public interface IConfiguracionPreciosService
    {
        void AgregarMargen(string margenAumento);
        void UpdateMargen(ConfiguracionPrecios configuracionPrecios);

        ConfiguracionPrecios GetById(int id);

        bool MargenExist(int id);

    }
}
