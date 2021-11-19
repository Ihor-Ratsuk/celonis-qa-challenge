namespace Celonis.Cloud.Tests.Common
{
    public interface IConfigurationProvider
    {
        TSettings GetOptions<TSettings>() where TSettings : class;
    }
}
