using System;
using template_dotnetcore_application.Domain.Gateways.GitLab;
using template_dotnetcore_application.Infrastructure.Gateways.GitLab;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        private static readonly Uri _gitlabApiUri = new Uri("https://gitlab.com/api/v4/");

        public static IServiceCollection AddGateways(this IServiceCollection services)
        {
            // https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
            services.AddHttpClient<IGitLabApi, GitLabApi>(client =>
            {
                client.BaseAddress = _gitlabApiUri;
            });
            // TODO: .AddPolicyHandler(GetRetryPolicy()).AddPolicyHandler(GetCircuitBreakerPolicy());

            return services;
        }
    }
}
