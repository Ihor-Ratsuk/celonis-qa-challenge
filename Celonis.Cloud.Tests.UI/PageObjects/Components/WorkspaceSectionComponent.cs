using Celonis.Cloud.Tests.UI.PageObjects.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Celonis.Cloud.Tests.UI.PageObjects.Components
{
    public class WorkspaceSectionComponent : BaseContainer
    {
        private IWebElement titleElement =>
            ContainerElement.FindElement(By.CssSelector("ce-section h3"));

        private IList<IWebElement> linksToAnalysis =>
            ContainerElement.FindElements(By.CssSelector("ce-section a"));

        public string Title => titleElement.Text;

        public WorkspaceSectionComponent(IWebDriver driver, By locator)
            : base(driver, locator) { }

        public void ClickOnFirstAnalysis()
        {
            var link = linksToAnalysis.FirstOrDefault();

            if (link == null)
            {
                throw new Exception("Workspace doesn't include any analysis.");
            }

            new Actions(driver)
                .MoveToElement(link)
                .Click()
                .Build()
                .Perform();
        }
    }
}
