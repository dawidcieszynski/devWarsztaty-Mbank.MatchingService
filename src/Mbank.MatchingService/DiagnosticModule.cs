using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Mbank.MatchingService
{
    public class VersionResponse
    {
        public string Version { get; set; }
    }

    public class DiagnosticModule
    {
        public Task Version(HttpContext context)
        {
            var versionResponse = new VersionResponse
            {
                Version = "0.0.1"
            };

            var jsonResponse = JsonConvert.SerializeObject(versionResponse);
            return context.Response.WriteAsync(jsonResponse);
        }
    }
}
