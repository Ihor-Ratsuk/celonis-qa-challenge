using Celonis.Cloud.Tests.Common.Configuration;
using Celonis.Cloud.Tests.UI.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Celonis.Cloud.Tests.UI.Contexts
{
    public class DriverContext
    {
        private readonly IDriverOptions driverOptions;
        private readonly IApplicationOptions applicationOptions;
        private readonly AuthServiceContext authServiceContext;


        private IWebDriver driver;
        public IWebDriver Driver => driver ??= InitDriver();

        public DriverContext(AuthServiceContext authServiceContext, ConfigurationContext configurationContext)
        {
            driverOptions = configurationContext.DriverOptions;
            applicationOptions = configurationContext.ApplicationOptions;
            this.authServiceContext = authServiceContext;
        }

        public void ResetDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }

        public void Authenticate(string email, string password)
        {
            Driver.Navigate().GoToUrl(applicationOptions.ApplicationRootUrl);
            var cookies = authServiceContext.Authenticate(email, password);
            foreach (var cookie in cookies)
            {
                Driver.Manage().Cookies.AddCookie(
                    new Cookie(cookie.Name, cookie.Value)
                );
            }
            Driver.Navigate().GoToUrl(applicationOptions.ApplicationRootUrl);
        }

        private IWebDriver InitDriver()
        {
            switch (driverOptions.Browser)
            {
                case Browser.Chrome:
                    {
                        var options = new ChromeOptions();
                        options.AddArgument("start-maximized");
                        var driver = new ChromeDriver(options);
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                        return driver;
                    }
                default: throw new Exception($"'{driverOptions.Browser}' browser not supported.");
            }
        }
    }
}
