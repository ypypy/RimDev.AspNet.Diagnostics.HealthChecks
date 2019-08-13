using Microsoft.Extensions.Diagnostics.HealthChecks;
using Owin;
using System.Collections.Generic;
using System.Linq;

namespace RimDev.AspNet.Diagnostics.HealthChecks
{
    public static class IAppBuilderExtensions
    {
        public static void UseHealthChecks(
            this IAppBuilder app,
            string url,
            HealthCheckOptions options,
            params HealthCheckConfig[] healthChecks)
        {
            var loggerFactory = new Microsoft.Extensions.Logging.LoggerFactory();
            var logger = loggerFactory.CreateLogger(nameof(HealthCheckMiddleware));

            app.Map(url, appBuilder =>
            {
                appBuilder.Use<HealthCheckMiddleware>(
                    logger,
                    options,
                    healthChecks);
            });
        }

        public static void UseHealthChecks(
            this IAppBuilder app,
            string url,
            params HealthCheckConfig[] healthChecks)
        {
            UseHealthChecks(app, url, new HealthCheckOptions(), healthChecks);
        }

        public static void UseHealthChecks(
            this IAppBuilder app,
            string url,
            HealthCheckOptions options,
            IEnumerable<HealthCheckConfig> healthChecks)
        {
            UseHealthChecks(app, url, options, healthChecks.ToArray());
        }

        public static void UseHealthChecks(
            this IAppBuilder app,
            string url,
            IEnumerable<HealthCheckConfig> healthChecks)
        {
            UseHealthChecks(app, url, new HealthCheckOptions(), healthChecks.ToArray());
        }
    }
}