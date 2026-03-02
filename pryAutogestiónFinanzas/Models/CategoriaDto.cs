namespace pryAutogestionFinanzas.Models
{
    public class CategoriaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Tipo { get; set; } = ""; // "Ingreso" o "Egreso"
    }
}