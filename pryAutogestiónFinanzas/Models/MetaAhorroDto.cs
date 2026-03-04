using System;

namespace pryAutogestionFinanzas.Models
{
    public class MetaAhorroDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public decimal Objetivo { get; set; }
        public string Moneda { get; set; } = "";
        public string LugarGuardado { get; set; } = "";
        public DateTime? FechaObjetivo { get; set; }
    }
}