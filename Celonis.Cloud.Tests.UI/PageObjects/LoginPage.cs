using Celonis.Cloud.Tests.UI.PageObjects.Base;
using OpenQA.Selenium;

namespace Celonis.Cloud.Tests.UI.PageObjects
{
    public class LoginPage : BasePage
    {
        private IWebElement emailInput => driver.FindElement(
            By.CssSelector("[cetestinguid='login-form-username-input']"));

        private IWebElement passwordInput => driver.FindElement(
            By.CssSelector("[cetestinguid='login-form-password-input']"));

        private IWebElement signInButton => driver.FindElement(
            By.CssSelector("[cetestinguid='login-form-submit-button']"));

        public LoginPage(IWebDriver driver) : base(driver)
        { }

        public void TryLogin(string email, string password)
        {
            emailInput.SendKeys(email);
            passwordInput.SendKeys(password);
            signInButton.Click();
        }
    }
}
