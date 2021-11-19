using Celonis.Cloud.Tests.Common.Configuration;
//using NUnit.Framework;

namespace Celonis.Cloud.Tests.Api
{
    //[TestFixture]
    public abstract class BaseTest
    {
        protected readonly IApplicationOptions applicationSettings;
        protected readonly IUsersOptions usersSettings;

        public BaseTest()
        {
            var provider = new Common.ConfigurationProvider()
                .AddJsonFile("configuration.json")
                .MapOptions<IApplicationOptions, ApplicationOptions>()
                .MapOptions<IUsersOptions, UsersOptions>(UsersOptions.Section);

            applicationSettings = provider.GetOptions<IApplicationOptions>();
            usersSettings = provider.GetOptions<IUsersOptions>();
        }
    }
}
