using Celonis.Cloud.Tests.UI.Contexts;
using Celonis.Cloud.Tests.UI.PageObjects;
using FluentAssertions;
using FluentAssertions.Execution;
using TechTalk.SpecFlow;

namespace Celonis.Cloud.Tests.UI.Steps
{
    [Binding]
    public class ProcessAnalyticsPageSteps
    {
        private readonly DriverContext driverContext;

        public ProcessAnalyticsPageSteps(DriverContext driverContext)
        {
            this.driverContext = driverContext;
        }

        [When("a user opens analysis in '(.*)' workspace")]
        public void WhenAUserOpensAnalysisInWorkspace(string workspaceName)
        {
            new ProcessAnalyticsPage(driverContext.Driver)
                .NavigateToAnalyticsInWorkspace(workspaceName);
        }

        [Then("list of workspaces is displayed, including:")]
        public void ThenListOfWorkspaceIsDisplayed(string[] workspaces)
        {
            new ProcessAnalyticsPage(driverContext.Driver)
                .GetWorkspacesTitles()
                .Should().Contain(workspaces);
        }

        [Then("link to process analytics is displayed for each workspace")]
        public void ThenReferenceToProcessAnalyticsIsDisplayedForEachWorkspace()
        {
            var page = new ProcessAnalyticsPage(driverContext.Driver);
            var workspaces = page.GetWorkspacesTitles();

            using (new AssertionScope())
            {
                foreach (var workspaceName in workspaces)
                {
                    page.IsLinkToProcessAnalyticsAccessible(workspaceName)
                        .Should().BeTrue();
                }
            }
        }
    }
}
