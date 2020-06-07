using template_dotnetcore_application.Domain.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<IGitIgnoreService, GitIgnoreService>();
            services.AddTransient<ICiYmlService, CiYmlService>();
            return services;
        }
    }
}
