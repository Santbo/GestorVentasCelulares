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
