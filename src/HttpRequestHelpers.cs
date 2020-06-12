using System.Net.Http;
using System.Text;
using Utf8Json;

namespace ShieldTech.MethodExtensions
{
    public static class HttpRequestHelpers
    {
        public static StringContent GenerateJsonContent<TModel>(TModel model)
        {
            return new StringContent(JsonSerializer.ToJsonString(model), Encoding.UTF8, "application/json");
        }
    }
}