using System.Text.Json;
using pryAutogestionFinanzas.Models;

namespace pryAutogestionFinanzas.Services
{
    public class CatalogosService
    {
        private readonly HttpClient _http;

        public CatalogosService(ApiClient apiClient)
        {
            _http = apiClient.Http;
        }

        public async Task<CatalogosResponseDto> GetCatalogosAsync()
        {
            var resp = await _http.GetAsync("/api/catalogos");
            resp.EnsureSuccessStatusCode();

            var json = await resp.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<CatalogosResponseDto>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return data ?? new CatalogosResponseDto();
        }
    }
}