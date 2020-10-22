using System.Net.Http;
using System.Threading.Tasks;

namespace TemplateDotnetcoreApplication.Infrastructure.Gateways.Core
{
    public class GatewayService
    {
        private readonly HttpClient _httpClient;

        public GatewayService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TResult> GetAsync<TResult>(string endpoint)
        {
            var responseMessage = await _httpClient.GetAsync(endpoint);
            var response = await responseMessage.Content.ReadAsStringAsync();
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<TResult>(response);

            return result;
        }
    }
}
