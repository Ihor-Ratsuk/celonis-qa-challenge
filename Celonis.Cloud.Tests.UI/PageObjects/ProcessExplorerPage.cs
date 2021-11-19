using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Celonis.Cloud.Tests.UI.PageObjects
{
    public class ProcessExplorerPage : AnalysisViewPage
    {
        private By processExplorerComponentLocator =>
            By.CssSelector("div[ce-process-explorer='component']");

        private IWebElement activitiesPanelTitle => driver.FindElement(By.XPath(
                ".//div[@ce-process-explorer='component']//div[@class='pe-controls__header']//span[text()='Activities']"));

        private IWebElement connectionsPanelTitle => driver.FindElement(By.XPath(
                ".//div[@ce-process-explorer='component']//div[@class='pe-controls__header']//span[text()='Connections']"));

        private By processGraphLocator =
            By.CssSelector("div[ce-process-explorer='component'] div[ce-process-graph]");

        private IWebElement processGraphElement =>
            driver.FindElement(processGraphLocator);

        private By activitiesLocator = By.CssSelector("div[ce-process-explorer='component'] g.node");

        private IList<IWebElement> activitiesElements => driver.FindElements(activitiesLocator);

        private By connectionsLocator = By.CssSelector("div[ce-process-explorer='component'] g.edge");

        private IList<IWebElement> connectionsElements => driver.FindElements(connectionsLocator);

        public ProcessExplorerPage(IWebDriver driver) : base(driver) { }

        public void NavigateToProcessExplorer()
        {
            foreach (var tab in tabs)
            {
                new Actions(driver)
                    .MoveToElement(tab)
                    .Click(tab)
                    .Build()
                    .Perform();

                if (ProcessExplorerTabIsActive())
                {
                    return;
                }
            }

            if (!IsInEditMode())
            {
                EnableEditMode();
                WaitUntilLoaderAppear();
                WaitUntilLoaderDisappear();
            }

            new Actions(driver)
                    .MoveToElement(createSheetButton)
                    .Click(createSheetButton)
                    .Build()
                    .Perform();

            new Actions(driver)
                .MoveToElement(createNewProcessExplorer)
                .Click(createNewProcessExplorer)
                .Build()
                .Perform();
        }

        public bool ProcessExplorerTabIsActive()
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WaitForElementTimeout));
                wait.IgnoreExceptionTypes(typeof(WebDriverTimeoutException));
                return wait.Until(driver =>
                {
                    return driver.FindElements(processExplorerComponentLocator).Any();
                });
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ProcessGraphIsDisplayed()
        {
            return WaitForElementExists(processGraphLocator) &&
               WaitForElementExists(activitiesLocator) &&
               WaitForElementExists(connectionsLocator);
        }

        public bool ActivitiesInformationIsDisplayed()
        {
            return activitiesPanelTitle.Displayed;
        }

        public bool ConnectionsInformationIsDisplayed()
        {
            return connectionsPanelTitle.Displayed;
        }
    }
}
