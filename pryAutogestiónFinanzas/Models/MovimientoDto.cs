namespace pryAutoGestionFinanzas.Models
{
    public class MovimientoDto
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = "";
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; } = "";
        public string Categoria { get; set; } = "";
        public string MedioPago { get; set; } = "";

        // NUEVO
        public string CreadoPor { get; set; } = "";
    }
}