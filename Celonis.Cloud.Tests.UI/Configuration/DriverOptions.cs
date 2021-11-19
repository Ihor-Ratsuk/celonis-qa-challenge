namespace Celonis.Cloud.Tests.UI.Configuration
{
    public class DriverOptions : IDriverOptions
    {
        public const string Section = "Driver";
        public Browser Browser { get; set; }
    }
}
