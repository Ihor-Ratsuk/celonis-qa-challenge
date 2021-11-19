using Celonis.Cloud.Tests.UI.Contexts;
using Celonis.Cloud.Tests.UI.PageObjects.Base;
using Celonis.Cloud.Tests.UI.PageObjects.Metadata;
using FluentAssertions;
using System;
using System.Linq;
using System.Reflection;
using TechTalk.SpecFlow;

namespace Celonis.Cloud.Tests.UI.Steps
{
    [Binding]
    public class GenericPageSteps
    {
        private readonly ConfigurationContext configurationContext;
        private readonly DriverContext driverContext;

        public GenericPageSteps(ConfigurationContext configurationContext, DriverContext driverContext)
        {
            this.configurationContext = configurationContext;
            this.driverContext = driverContext;
        }

        [Then("'(.*)' application page is opened")]
        public void ThenApplicationPageIsOpened(string applicationName)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(type => type.GetCustomAttributes<PageTitleAttribute>()
                    .Any(attribute =>
                        {
                            return attribute.Title == applicationName;
                        }));

            if (type == null)
            {
                throw new Exception($"PageObject with '{applicationName}' title not found.");
            }

            var page = (BasePage)Activator.CreateInstance(type, driverContext.Driver);

            page.WaitUntilOpened()
                .Should().BeTrue($"'{applicationName}' application page is opened");
        }
    }
}
