using Celonis.Cloud.Tests.UI.Contexts;
using Celonis.Cloud.Tests.UI.PageObjects;
using FluentAssertions;
using FluentAssertions.Execution;
using TechTalk.SpecFlow;

namespace Celonis.Cloud.Tests.UI.Steps
{
    [Binding]
    public class AnalyticsViewPageSteps
    {
        private readonly DriverContext driverContext;

        public AnalyticsViewPageSteps(DriverContext driverContext)
        {
            this.driverContext = driverContext;
        }

        [When("navigates to process explorer")]
        [When("a user navigates to process explorer")]
        public void WhenAUserNavigatesToProcessExplorer()
        {
            var page = new ProcessExplorerPage(driverContext.Driver);
            page.WaitUntilOpened();
            page.NavigateToProcessExplorer();
        }

        [Then("process graph is displayed")]
        public void ThenProcessGraphIsDisplayed()
        {
            var page = new ProcessExplorerPage(driverContext.Driver);
            using (new AssertionScope())
            {
                page.ProcessGraphIsDisplayed().Should()
                    .BeTrue("Process graph is displayed");
                page.ActivitiesInformationIsDisplayed().Should()
                    .BeTrue("Activities information is displayed");
                page.ConnectionsInformationIsDisplayed().Should()
                    .BeTrue("Connections information is displayed");
            }
        }
    }
}
