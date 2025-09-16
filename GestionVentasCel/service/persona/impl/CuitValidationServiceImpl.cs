using GestionVentasCel.data;

namespace GestionVentasCel.service.persona.impl
{
    public class CuitValidationServiceImpl : ICuitValidationService
    {
        private readonly AppDbContext _context;

        public CuitValidationServiceImpl(AppDbContext context)
        {
            _context = context;
        }

        public bool ValidarCuit(string cuit)
        {
            if (string.IsNullOrWhiteSpace(cuit))
                return false;

            // Limpiar el CUIT (remover guiones y espacios)
            cuit = cuit.Replace("-", "").Replace(" ", "");

            // Verificar que tenga 11 dígitos
            if (cuit.Length != 11 || !cuit.All(char.IsDigit))
                return false;

            // Validar el dígito verificador
            return ValidarDigitoVerificador(cuit);
        }

        public bool CuitExiste(string cuit, int? excludeId = null)
        {
            if (string.IsNullOrWhiteSpace(cuit))
                return false;

            cuit = FormatearCuit(cuit);

            var query = _context.Personas.Where(p => p.Dni == cuit);

            if (excludeId.HasValue)
            {
                query = query.Where(p => p.Id != excludeId.Value);
            }

            return query.Any();
        }

        public string FormatearCuit(string cuit)
        {
            if (string.IsNullOrWhiteSpace(cuit))
                return string.Empty;

            // Limpiar el CUIT
            cuit = cuit.Replace("-", "").Replace(" ", "");

            // Formatear como XX-XXXXXXXX-X
            if (cuit.Length == 11)
            {
                return $"{cuit.Substring(0, 2)}-{cuit.Substring(2, 8)}-{cuit.Substring(10, 1)}";
            }

            return cuit;
        }

        private bool ValidarDigitoVerificador(string cuit)
        {
            if (cuit.Length != 11)
                return false;

            int[] multiplicadores = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            int suma = 0;

            for (int i = 0; i < 10; i++)
            {
                suma += int.Parse(cuit[i].ToString()) * multiplicadores[i];
            }

            int resto = suma % 11;
            int digitoVerificador = resto < 2 ? resto : 11 - resto;

            return digitoVerificador == int.Parse(cuit[10].ToString());
        }
    }
}
