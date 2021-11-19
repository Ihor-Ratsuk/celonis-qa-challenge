using Celonis.Cloud.Tests.UI.Contexts;
using Celonis.Cloud.Tests.UI.PageObjects;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Celonis.Cloud.Tests.UI.Steps
{
    [Binding]
    public sealed class LoginPageSteps
    {
        private readonly ConfigurationContext configurationContext;
        private readonly DriverContext driverContext;

        public LoginPageSteps(ConfigurationContext configurationContext, DriverContext driverContext)
        {
            this.configurationContext = configurationContext;
            this.driverContext = driverContext;
        }

        [Given("a user is on the login page")]
        public void GivenAUserIsOnTheLoginPage()
        {
            driverContext.ResetDriver();
            driverContext.Driver.Navigate()
                .GoToUrl(configurationContext.ApplicationOptions.ApplicationRootUrl);
        }

        [Given("a user is logged in")]
        [When("a user is logged in")]
        public void WhenAUserIsLoggedIn()
        {
            var user = configurationContext.UsersOptions.User;
            driverContext.Authenticate(user.Email, user.Password);
        }

        [When("valid credentials are provided")]
        public void WhenValidCredentialsAreProvided()
        {
            var loginPage = new LoginPage(driverContext.Driver);
            var user = configurationContext.UsersOptions.User;
            loginPage.TryLogin(user.Email, user.Password);
        }

        [Then("user navigated to a main page")]
        public void ThenUserNavigatedToAMainPage()
        {
            var mainPage = new MainPage(driverContext.Driver);
            Assert.IsTrue(mainPage.AppSwitcher.IsDisplayed(), "Application swithcer is shown.");
        }
    }
}
