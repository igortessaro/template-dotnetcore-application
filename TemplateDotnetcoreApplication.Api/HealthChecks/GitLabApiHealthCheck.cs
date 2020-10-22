using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading;
using System.Threading.Tasks;
using TemplateDotnetcoreApplication.Domain.Gateways.GitLab;

namespace TemplateDotnetcoreApplication.Api.HealthChecks
{
    public sealed class GitLabApiHealthCheck : IHealthCheck
    {
        private readonly IGitLabApi _gitLabApi;

        public GitLabApiHealthCheck(IGitLabApi gitLabApi)
        {
            _gitLabApi = gitLabApi;
        }

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
