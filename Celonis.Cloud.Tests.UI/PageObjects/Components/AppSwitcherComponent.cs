using Celonis.Cloud.Tests.UI.PageObjects.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Celonis.Cloud.Tests.UI.PageObjects.Components
{
    public class AppSwitcherComponent : BaseContainer
    {
        private IList<IWebElement> navigationBarTitles =>
            ContainerElement.FindElements(By.CssSelector("li.ce-app-switcher__list-item a"));

        private By dropdownTitlesLocator = By.CssSelector("div.cdk-overlay-container a");

        private IList<IWebElement> dropdownTitles => driver.FindElements(dropdownTitlesLocator);

        private IWebElement moreButton =>
            ContainerElement.FindElement(By.CssSelector("div.ce-app-switcher__more"));

        public AppSwitcherComponent(IWebDriver driver, By locator) : base(driver, locator) { }

        public void NavigateTo(string applicationName)
        {
            var element = navigationBarTitles
                .FirstOrDefault(x => x.Text == applicationName);

            if (element == null)
            {
                OpenMoreDropdown();
                element = dropdownTitles.FirstOrDefault(x => x.Text == applicationName);
            }

            if (element == null)
            {
                throw new Exception($"Can't locate '{applicationName}' application.");
            }

            new Actions(driver)
                .MoveToElement(element)
                .Click()
                .Build()
                .Perform();
        }

        public string[] GetApplicationsTitles()
        {
            var titles = navigationBarTitles
                .Select(x => x.Text)
                .ToList();

            OpenMoreDropdown();

            var hiddenTitles = dropdownTitles
                .Select(x => x.Text)
                .ToArray();

            titles.AddRange(hiddenTitles);

            return titles.ToArray();
        }

        private void OpenMoreDropdown()
        {
            new Actions(driver)
                .MoveToElement(moreButton)
                .Click(moreButton)
                .Build()
                .Perform();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WaitForElementTimeout));
            wait.Until(ExpectedConditions.ElementToBeClickable(dropdownTitlesLocator));
        }
    }
}
