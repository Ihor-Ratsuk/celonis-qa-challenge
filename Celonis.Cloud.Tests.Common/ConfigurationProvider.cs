using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.IO;

namespace Celonis.Cloud.Tests.Common
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        private readonly IConfigurationBuilder configurationBuilder;
        private readonly IServiceCollection serviceCollection;

        private IServiceProvider serviceProvider;
        private IServiceProvider ServiceProvider =>
            serviceProvider ??= serviceCollection.BuildServiceProvider();

        public ConfigurationProvider()
        {
            configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddEnvironmentVariables();

            serviceCollection = new ServiceCollection();
        }

        public virtual ConfigurationProvider AddJsonFile(string fileName)
        {
            configurationBuilder
                .AddJsonFile(path: fileName, optional: false, reloadOnChange: false);
            return this;
        }

        public virtual ConfigurationProvider MapOptions<TService, TImplementation>(string configSectionName = null)
            where TService : class
            where TImplementation : class, TService
        {
            var configuration = configurationBuilder.Build();
            IConfiguration configurationSection =
                string.IsNullOrEmpty(configSectionName) ? configuration : configuration.GetSection(configSectionName);
            serviceCollection.Configure<TImplementation>(configurationSection);
            serviceCollection.AddSingleton<TService>(sp =>
            {
                return sp.GetService<IOptions<TImplementation>>().Value;
            });
            serviceProvider = null;
            return this;
        }

        public TSettings GetOptions<TSettings>() where TSettings : class
        {
            return ServiceProvider.GetService<TSettings>();
        }
    }
}
