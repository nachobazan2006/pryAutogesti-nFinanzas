using pryAutogestionFinanzas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pryAutogestionFinanzas.Services
{
    public class MetasAhorroService
    {
        private readonly ApiClient _api;

        public MetasAhorroService(ApiClient api)
        {
            _api = api;
        }

        public async Task<List<MetaAhorroDto>?> GetAllAsync()
        {
            return await _api.GetAsync<List<MetaAhorroDto>>("MetasAhorro");
        }

        public async Task<MetaAhorroDto?> CreateAsync(MetaAhorroDto dto)
        {
            return await _api.PostAsync<MetaAhorroDto>("MetasAhorro", dto);
        }

        public async Task UpdateAsync(int id, MetaAhorroDto dto)
        {
            await _api.PutAsync($"MetasAhorro/{id}", dto);
        }

        public async Task DeleteAsync(int id)
        {
            await _api.DeleteAsync($"MetasAhorro/{id}");
        }
    }
}