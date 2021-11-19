using Celonis.Cloud.Tests.UI.PageObjects.Metadata;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Linq;
using System.Reflection;

namespace Celonis.Cloud.Tests.UI.PageObjects.Base
{
    public abstract class BasePage
    {
        public const int WaitForElementTimeout = 10;
        public const int WaitPageLoadTimeout = 20;

        protected readonly IWebDriver driver;

        private string url;
        public string Url
        {
            get
            {
                if (url == null)
                {
                    var attribute = this.GetType().GetCustomAttributes<PageUrlAttribute>().FirstOrDefault();
                    url = attribute == null ? string.Empty : attribute.Url;
                }
                return url;
            }
        }

        private string title;
        public string Title
        {
            get
            {
                if (title == null)
                {
                    var attribute = this.GetType().GetCustomAttributes<PageTitleAttribute>().FirstOrDefault();
                    title = attribute == null ? string.Empty : attribute.Title;
                }
                return title;
            }
        }

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public virtual bool WaitUntilOpened()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WaitPageLoadTimeout));
            return wait.Until(ExpectedConditions.TitleContains(Title)) &&
                wait.Until(ExpectedConditions.UrlContains(Url));
        }

        protected bool WaitForElementExists(By locator, int timeout = WaitForElementTimeout)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(driver => driver.FindElements(locator).Any());
            }
            catch (Exception) { }
            return false;
        }

        public bool WaitForElementDisappear(By locator, int timeout = WaitForElementTimeout)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(driver => !driver.FindElements(locator).Any());
            }
            catch (Exception) { }
            return false;
        }
    }
}
