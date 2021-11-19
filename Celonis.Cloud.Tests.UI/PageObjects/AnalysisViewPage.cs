using Celonis.Cloud.Tests.UI.PageObjects.Base;
using Celonis.Cloud.Tests.UI.PageObjects.Metadata;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;

namespace Celonis.Cloud.Tests.UI.PageObjects
{
    [PageTitle("Analysis")]
    [PageUrl("/process-mining/analysis/")]
    public class AnalysisViewPage : BasePage
    {
        protected IList<IWebElement> tabs =>
            driver.FindElements(By.CssSelector("div.tabs div.tabs__item:not([title='Create Sheet'])"));

        protected IWebElement createSheetButton =>
            driver.FindElement(By.CssSelector("div.tabs div.tabs__item[title='Create Sheet']"));

        protected IWebElement createNewProcessExplorer => driver.FindElement(
            By.XPath(".//div[contains(@class, 'app-launcher__tile') and .//div[text()='Process Explorer']]"));

        protected IWebElement enableEditModeLink => driver.FindElement(
            By.XPath(".//*[contains(@class,'analysis-menu__item') and .//*[contains(text(),'Edit')]]"));

        protected readonly By loaderLocator = By.CssSelector("div.loader--blobs");

        public AnalysisViewPage(IWebDriver driver) : base(driver) { }

        public bool IsInEditMode()
        {
            return driver.FindElements(
                By.XPath(".//*[contains(@class,'analysis-menu__item') and .//*[contains(text(),'Edit')]]//input")).Any();
        }

        public void EnableEditMode()
        {
            new Actions(driver)
                .MoveToElement(enableEditModeLink)
                .Click(enableEditModeLink)
                .Build()
                .Perform();
        }

        public void WaitUntilLoaderAppear()
        {
            WaitForElementExists(loaderLocator, WaitPageLoadTimeout);
        }

        public void WaitUntilLoaderDisappear()
        {
            WaitForElementDisappear(loaderLocator, WaitPageLoadTimeout);
        }
    }
}
