namespace GestionVentasCel.models.configPrecios
{
    public class ConfiguracionPrecios
    {
        public int Id { get; set; }
        public decimal MargenAumento { get; set; } // ej: 1.30 (30%)
        public DateTime UltimaActualizacion { get; set; } = DateTime.Now;

    }
}
