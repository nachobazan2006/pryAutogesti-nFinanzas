using System.Net.Http;
using pryAutogestionFinanzas.Constants;

namespace pryAutogestionFinanzas.Services
{
    public class ApiClient
    {
        public HttpClient Http { get; }

        public ApiClient()
        {
            Http = new HttpClient();
            Http.BaseAddress = new Uri(AppConfig.BaseUrl);
        }
    }
}