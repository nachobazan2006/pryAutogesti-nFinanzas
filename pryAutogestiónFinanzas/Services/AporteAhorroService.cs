using pryAutogestionFinanzas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pryAutogestionFinanzas.Services
{
    public class AportesAhorroService
    {
        private readonly ApiClient _api;

        public AportesAhorroService(ApiClient api)
        {
            _api = api;
        }

        public async Task<List<AporteAhorroDto>?> GetByMetaAsync(int metaId)
        {
            return await _api.GetAsync<List<AporteAhorroDto>>($"AportesAhorro/ByMeta/{metaId}");
        }

        public async Task<AporteAhorroDto?> CreateAsync(AporteAhorroDto dto)
        {
            return await _api.PostAsync<AporteAhorroDto>("AportesAhorro", dto);
        }

        public async Task DeleteAsync(int id)
        {
            await _api.DeleteAsync($"AportesAhorro/{id}");
        }
    }
}