namespace GestionVentasCel.enumerations.ventas
{
    public enum TipoFacturaEnum
    {
        /// <summary>
        /// RI a otro RI
        /// </summary>
        FacturaA,

        /// <summary>
        /// RI a CF, Exento o Monotributista. Si el monto es mayor de $10.000.000, se tiene que incluir el cliente.
        /// </summary>
        FacturaB,

        /// <summary>
        /// Monotributista o Exento a cualquier tipo de cliente, no se debería usar acá.
        /// </summary>
        FacturaC
    }
}
