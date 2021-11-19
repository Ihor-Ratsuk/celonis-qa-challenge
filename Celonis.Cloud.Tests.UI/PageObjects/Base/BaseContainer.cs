using OpenQA.Selenium;

namespace Celonis.Cloud.Tests.UI.PageObjects.Base
{
    public abstract class BaseContainer
    {
        public const int WaitForElementTimeout = 10;

        protected readonly By locator;
        protected readonly IWebDriver driver;

        protected IWebElement ContainerElement =>
            driver.FindElement(locator);

        public BaseContainer(IWebDriver driver, By locator)
        {
            this.driver = driver;
            this.locator = locator;
        }

        public bool IsDisplayed()
        {
            return driver.FindElement(locator).Displayed;
        }
    }
}
