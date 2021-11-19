using System;

namespace Celonis.Cloud.Tests.Common
{
    public static class ConfigurationService
    {
        private static IConfigurationProvider configurationProvider;

        private static IConfigurationProvider ConfigurationProvider
        {
            get
            {
                if (configurationProvider == null)
                {
                    throw new Exception("ConfigurationService is not configured.");
                }
                return configurationProvider;
            }
        }

        public static TOptions GetOptions<TOptions>() where TOptions : class
        {
            return ConfigurationProvider.GetOptions<TOptions>();
        }

        public static void SetConfigurationProvider(IConfigurationProvider configurationProvider)
        {
            ConfigurationService.configurationProvider = configurationProvider;
        }
    }
}
