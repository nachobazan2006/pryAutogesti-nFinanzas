using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace pryAutogestionFinanzas.Services
{
    public class ApiClient
    {
        private readonly HttpClient _http;

        public HttpClient Http => _http;

        public ApiClient()
        {
            _http = new HttpClient();

            // 🔥 IMPORTANTE: puerto exacto de tu backend
            _http.BaseAddress = new Uri("https://localhost:7245/api/");
        }

        public async Task<T?> GetAsync<T>(string endpoint)
        {
            var response = await _http.GetAsync(endpoint);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            var body = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(body,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }

        public async Task<T?> PostAsync<T>(string endpoint, object data)
        {
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.PostAsync(endpoint, content);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            var body = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(body,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }

        public async Task PutAsync(string endpoint, object data)
        {
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.PutAsync(endpoint, content);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());
        }

        public async Task DeleteAsync(string endpoint)
        {
            var response = await _http.DeleteAsync(endpoint);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());
        }
    }
}