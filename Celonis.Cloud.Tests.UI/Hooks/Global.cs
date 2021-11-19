using Celonis.Cloud.Tests.UI.Contexts;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.UnitTestProvider;

namespace Celonis.Cloud.Tests.UI.Hooks
{
    [Binding]
    public class Global
    {
        private readonly DriverContext driverContext;

        public Global(DriverContext driverContext)
        {
            this.driverContext = driverContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            driverContext.ResetDriver();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driverContext.ResetDriver();
        }
    }
}
