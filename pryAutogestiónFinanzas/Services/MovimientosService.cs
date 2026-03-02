using pryAutogestionFinanzas.Models;
using System.Text;
using System.Text.Json;

namespace pryAutogestionFinanzas.Services
{
    public class MovimientosService
    {
        private readonly HttpClient _http;

        public MovimientosService(ApiClient apiClient)
        {
            _http = apiClient.Http;
        }

        public async Task<MovimientoDto?> CreateAsync(CreateMovimientoDto dto)
        {
            var json = JsonSerializer.Serialize(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var resp = await _http.PostAsync("/api/movimientos", content);

            if (!resp.IsSuccessStatusCode)
            {
                var error = await resp.Content.ReadAsStringAsync();
                throw new Exception(error);
            }

            var responseJson = await resp.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<MovimientoDto>(responseJson,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        public async Task<List<dynamic>> GetByTipoAsync(string tipo)
        {
            var resp = await _http.GetAsync($"/api/movimientos?tipo={tipo}");
            resp.EnsureSuccessStatusCode();

            var json = await resp.Content.ReadAsStringAsync();
            return System.Text.Json.JsonSerializer.Deserialize<List<dynamic>>(json,
                new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new();
        }
    }
}