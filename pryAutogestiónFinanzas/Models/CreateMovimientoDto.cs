namespace pryAutogestionFinanzas.Models
{
    public class CreateMovimientoDto
    {
        public string Tipo { get; set; } = ""; // "Ingreso" o "Egreso"
        public int CategoriaId { get; set; }
        public int MedioPagoId { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string? Descripcion { get; set; }
    }
}