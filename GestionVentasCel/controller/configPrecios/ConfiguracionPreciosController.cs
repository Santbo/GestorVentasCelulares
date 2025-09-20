using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionVentasCel.models.configPrecios;
using GestionVentasCel.service.configPrecios;

namespace GestionVentasCel.controller.configPrecios
{
    public class ConfiguracionPreciosController
    {
        private readonly IConfiguracionPreciosService _service;
        public ConfiguracionPreciosController(IConfiguracionPreciosService service)
        {
            _service = service;
        }

        public void AgregarMargen(string margenAumento)
        {
            
            _service.AgregarMargen(margenAumento);
        }

        public ConfiguracionPrecios GetById(int id)
        {
            return _service.GetById(id);
        }

        public void UpdateMargen(ConfiguracionPrecios configuracionPrecios)
        {
            _service.UpdateMargen(configuracionPrecios);
        }

        public bool MargenExist(int id)
        {
            return _service.MargenExist(id);
        }

    }
}
