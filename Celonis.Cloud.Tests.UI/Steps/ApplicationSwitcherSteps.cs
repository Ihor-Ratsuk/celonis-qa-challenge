using Celonis.Cloud.Tests.Api;
using Celonis.Cloud.Tests.UI.Contexts;
using Celonis.Cloud.Tests.UI.PageObjects;
using FluentAssertions;
using System.Net;
using TechTalk.SpecFlow;

namespace Celonis.Cloud.Tests.UI.Steps
{
    [Binding]
    public class ApplicationSwitcherSteps
    {
        private readonly DriverContext driverContext;

        public ApplicationSwitcherSteps(DriverContext driverContext)
        {
            this.driverContext = driverContext;
        }

        [Given("a user is on the '(.*)'")]
        [When("a user select '(.*)' in navigation bar")]
        [When("a user navigates to '(.*)'")]
        public void WhenAUserSelectApplicationInNavigationBar(string applicationName)
        {
            new MainPage(driverContext.Driver)
                .AppSwitcher.NavigateTo(applicationName);
        }

        [Then("applications are displayed in navigation bar")]
        public void ThenApplicationsAreDisplayedInNavigationBar(string[] applications)
        {
            new MainPage(driverContext.Driver)
                .AppSwitcher.GetApplicationsTitles()
                .Should().Contain(applications);
        }
    }
}
