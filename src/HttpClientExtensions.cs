using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ShieldTech.MethodExtensions
{
    public static class HttpClientExtensions
    {
        public static void AddAuthorizationDefaultHeader(this HttpClient client, string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public static async Task<HttpResponseMessage> SendPostWithJsonBody(this HttpClient client, string route, object body)
        {
            return await client.SendAsync(new HttpRequestMessage(HttpMethod.Post, route)
            {
                Content = HttpRequestHelpers.GenerateJsonContent(body)
            });
        }
 
    }
}