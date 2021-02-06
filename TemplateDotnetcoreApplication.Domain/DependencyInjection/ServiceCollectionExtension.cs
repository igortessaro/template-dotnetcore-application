using Microsoft.FeatureManagement;
using System;
using TemplateDotnetcoreApplication.Domain.Services;
using TemplateDotnetcoreApplication.Domain.ValueObjects;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddTransientWithFeature<IGitIgnoreService, GitIgnoreService, GitIgnoreDisableService>(Features.GitIgnoreFeature);
            services.AddTransient<ICiYmlService, CiYmlService>();
            return services;
        }

        public static IServiceCollection AddTransientWithFeature<TService, TImplementationEnable, TImplementationDisable>(this IServiceCollection services, Features featureType)
           where TService : class
           where TImplementationEnable : class, TService
           where TImplementationDisable : class, TService
        {
            services.AddTransient(CreateImplementationFactory<TService, TImplementationEnable, TImplementationDisable>(featureType));
            return services;
        }

        private static Func<IServiceProvider, TService> CreateImplementationFactory<TService, TImplementationEnable, TImplementationDisable>(Features featureType)
            where TService : class
            where TImplementationEnable : class, TService
            where TImplementationDisable : class, TService
        {
            return serviceProvider =>
            {
                var featureManager = serviceProvider.GetRequiredService<IFeatureManagerSnapshot>();
                var enable = featureManager.IsEnabledAsync(featureType.GetDescription()).ConfigureAwait(false).GetAwaiter().GetResult();

                if (!enable)
                {
                    return ActivatorUtilities.CreateInstance<TImplementationDisable>(serviceProvider);
                }

                return ActivatorUtilities.CreateInstance<TImplementationEnable>(serviceProvider);
            };
        }
    }
}
