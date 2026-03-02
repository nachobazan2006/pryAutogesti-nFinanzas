using pryAutogestionFinanzas.Models;

namespace pryAutogestionFinanzas.Models
{
    public class CatalogosResponseDto
    {
        public List<CategoriaDto> Categorias { get; set; } = new();
        public List<MedioPagoDto> MediosPago { get; set; } = new();
    }
}