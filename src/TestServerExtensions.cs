using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.TestHost;

namespace ShieldTech.MethodExtensions
{
    public static class TestServerExtensions
    {
        public static HttpClient GenerateHttpClient(this TestServer server)
        {
            var client = server.CreateClient();
            client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}