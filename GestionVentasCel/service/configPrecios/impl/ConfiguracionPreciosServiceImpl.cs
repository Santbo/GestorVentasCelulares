using GestionVentasCel.exceptions.configPrecios;
using GestionVentasCel.models.configPrecios;
using GestionVentasCel.repository.configPrecios;

namespace GestionVentasCel.service.configPrecios.impl
{
    public class ConfiguracionPreciosServiceImpl : IConfiguracionPreciosService
    {
        private readonly IConfiguracionPreciosRepository _repo;
        public ConfiguracionPreciosServiceImpl(IConfiguracionPreciosRepository repo)
        {
            _repo = repo;
        }
        public void AgregarMargen(string margenAumento)
        {
            var factor = 1 + (decimal.Parse(margenAumento) / 100);
            var margen = new ConfiguracionPrecios
            {
                MargenAumento = factor
            };
            _repo.Add(margen);
        }

        public ConfiguracionPrecios GetById(int id)
        {

            if (!_repo.MargenExist(id)) throw new MargenNoAgregadoException("No hay un margen agregado aun.");
            var margen = _repo.GetById(id);

            return margen;
        }

        public bool MargenExist(int id)
        {
            return _repo.MargenExist(id);
        }

        public void UpdateMargen(ConfiguracionPrecios configuracionPrecios)
        {
            _repo.Update(configuracionPrecios);
        }
    }
}
