using Microsoft.Extensions.Configuration;
using System;
using TemplateDotnetcoreApplication.Domain.Gateways.GitLab;
using TemplateDotnetcoreApplication.Infrastructure.Gateways.GitLab;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddGateways(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IGitLabApi, GitLabApi>(client =>
            {
                client.BaseAddress = new Uri(configuration.GetSection("Gateways:GitLabApi").Value);
                client.DefaultRequestHeaders.Add("PRIVATE-TOKEN", "kZWfLzWLSnKMjPi7mLW6");
            });

            return services;
        }
    }
}
