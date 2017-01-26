using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Mbank.MatchingService
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            this.SetUpRoutes(app);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        private void SetUpRoutes(IApplicationBuilder app)
        {
            var routeBuilder = new RouteBuilder(app);

            routeBuilder.MapGet("version", context =>
            {
                var diagnosticModule = new DiagnosticModule();
                return diagnosticModule.Version(context);
            });

            var routes = routeBuilder.Build();
            app.UseRouter(routes);
        }
    }
}
