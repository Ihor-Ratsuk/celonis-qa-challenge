using Celonis.Cloud.Tests.UI.PageObjects.Base;
using Celonis.Cloud.Tests.UI.PageObjects.Components;
using OpenQA.Selenium;

namespace Celonis.Cloud.Tests.UI.PageObjects
{
    public class MainPage : BasePage
    {
        public AppSwitcherComponent AppSwitcher =>
            new AppSwitcherComponent(driver, By.CssSelector("ce-app-switcher"));

        public MainPage(IWebDriver driver) : base(driver) { }
    }
}
