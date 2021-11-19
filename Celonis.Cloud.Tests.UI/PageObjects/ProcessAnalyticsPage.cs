using Celonis.Cloud.Tests.UI.PageObjects.Base;
using Celonis.Cloud.Tests.UI.PageObjects.Metadata;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;

namespace Celonis.Cloud.Tests.UI.PageObjects
{
    [PageTitle("Process Analytics")]
    [PageUrl("/process-mining/ui")]
    public class ProcessAnalyticsPage : BasePage
    {
        private IList<IWebElement> workspacesTitles =>
            driver.FindElements(By.CssSelector("workspaces-sidebar div.ce-item-group__label span"));

        public ProcessAnalyticsPage(IWebDriver driver) : base(driver) { }

        public string[] GetWorkspacesTitles()
        {
            return workspacesTitles
                .Select(element => element.Text)
                .ToArray();
        }

        public bool IsLinkToProcessAnalyticsAccessible(string workspaceName)
        {
            var locator = GetLinkToWorkspaceAnalysis(workspaceName);

            return driver.FindElements(locator).Any();
        }

        public void NavigateToAnalyticsInWorkspace(string workspaceName)
        {
            var locator = GetLinkToWorkspaceAnalysis(workspaceName);
            var link = driver.FindElement(locator);

            new Actions(driver)
                .MoveToElement(link)
                .Click()
                .Build()
                .Perform();
        }

        private By GetLinkToWorkspaceAnalysis(string workspaceName)
        {
            return By.XPath(
                $".//workspace-section//ce-section[.//h3[contains(text(), '{workspaceName}')]]//ce-tile//a");
        }
    }
}
