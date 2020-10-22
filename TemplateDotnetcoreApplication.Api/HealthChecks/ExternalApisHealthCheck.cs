using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading;
using System.Threading.Tasks;

namespace TemplateDotnetcoreApplication.Api.HealthChecks
{
    public sealed class ExternalApisHealthCheck : IHealthCheck
    {
        public string Name => "external_api";

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var healthCheckResultHealthy = true;

            if (healthCheckResultHealthy)
            {
                return Task.FromResult(HealthCheckResult.Healthy("A healthy result."));
            }

            return Task.FromResult(HealthCheckResult.Unhealthy("An unhealthy result."));
        }
    }
}
