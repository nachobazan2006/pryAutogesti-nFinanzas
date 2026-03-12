using System;

namespace pryAutogestionFinanzas.Models
{
    public class AporteAhorroDto
    {
        public int Id { get; set; }
        public int MetaAhorroId { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string? Notas { get; set; }
        public string? CreadoPor { get; set; }
    }
}