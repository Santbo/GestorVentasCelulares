namespace GestionVentasCel.service.persona
{
    public interface ICuitValidationService
    {
        bool ValidarCuit(string cuit);
        bool CuitExiste(string cuit, int? excludeId = null);
        string FormatearCuit(string cuit);
    }
}
