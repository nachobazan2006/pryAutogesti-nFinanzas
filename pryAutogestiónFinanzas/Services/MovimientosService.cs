using pryAutogestionFinanzas.Models;
using pryAutoGestionFinanzas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pryAutogestionFinanzas.Services
{
    public class MovimientosService
    {
        private readonly ApiClient _api;

        public MovimientosService(ApiClient api)
        {
            _api = api;
        }

        public Task<List<MovimientoDto>?> GetAllAsync()
            => _api.GetAsync<List<MovimientoDto>>("movimientos");

        public Task<MovimientoDto?> GetByIdAsync(int id)
            => _api.GetAsync<MovimientoDto>($"movimientos/{id}");

        public Task<MovimientoDto?> CreateAsync(CreateMovimientoDto dto)
            => _api.PostAsync<MovimientoDto>("movimientos", dto);

        public async Task<List<MovimientoDto>> GetByTipoAsync(string tipo)
        {
            var lista = await GetAllAsync() ?? new List<MovimientoDto>();

            return lista
                .Where(x => string.Equals(x.Tipo, tipo, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // UPDATE (full update)
        public Task UpdateAsync(int id, CreateMovimientoDto dto)
            => _api.PutAsync($"movimientos/{id}", dto);

        // DELETE
        public Task DeleteAsync(int id)
            => _api.DeleteAsync($"movimientos/{id}");
    }
}