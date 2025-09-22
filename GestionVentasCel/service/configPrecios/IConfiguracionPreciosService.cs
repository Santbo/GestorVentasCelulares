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
