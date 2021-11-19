using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Celonis.Cloud.Tests.Api.Extensions
{
    public static class SerializationExtensions
    {
        private static JsonSerializerOptions options => new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public static StringContent ToStringContent<T>(this T data) where T : class
        {
            var json = JsonSerializer.Serialize(data, options);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        public static async Task<T> Deserialize<T>(this HttpResponseMessage response) where T : class
        {
            return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync(), options);
        }
    }
}
