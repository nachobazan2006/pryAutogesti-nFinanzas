using pryAutogestionFinanzas.Models;

namespace pryAutogestionFinanzas.Helpers
{
    public static class MovimientoFactory
    {
        public static CreateMovimientoDto CrearEgreso(int categoriaId, int medioPagoId, decimal monto, DateTime fecha, string? desc)
        {
            return new CreateMovimientoDto
            {
                Tipo = "Egreso",
                CategoriaId = categoriaId,
                MedioPagoId = medioPagoId,
                Monto = monto,
                Fecha = fecha,
                Descripcion = desc
            };
        }

        public static CreateMovimientoDto CrearIngreso(int categoriaId, int medioPagoId, decimal monto, DateTime fecha, string? desc)
        {
            return new CreateMovimientoDto
            {
                Tipo = "Ingreso",
                CategoriaId = categoriaId,
                MedioPagoId = medioPagoId,
                Monto = monto,
                Fecha = fecha,
                Descripcion = desc
            };
        }
    }
}