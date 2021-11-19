using Celonis.Cloud.Tests.Common;
using Celonis.Cloud.Tests.Common.Configuration;
using Celonis.Cloud.Tests.UI.Configuration;

namespace Celonis.Cloud.Tests.UI.Contexts
{
    public class ConfigurationContext
    {
        public IApplicationOptions ApplicationOptions => configurationProvider.GetOptions<IApplicationOptions>();

        public IUsersOptions UsersOptions => configurationProvider.GetOptions<IUsersOptions>();

        public IDriverOptions DriverOptions => configurationProvider.GetOptions<IDriverOptions>();

        private readonly IConfigurationProvider configurationProvider;

        public ConfigurationContext()
        {
            configurationProvider = new Common.ConfigurationProvider()
                .AddJsonFile("configuration.json")
                .MapOptions<IApplicationOptions, ApplicationOptions>()
                .MapOptions<IUsersOptions, UsersOptions>(Common.Configuration.UsersOptions.Section)
                .MapOptions<IDriverOptions, DriverOptions>(Configuration.DriverOptions.Section);
        }
    }
}
