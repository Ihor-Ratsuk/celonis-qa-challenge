using Celonis.Cloud.Tests.UI.PageObjects.Base;
using Celonis.Cloud.Tests.UI.PageObjects.Metadata;
using OpenQA.Selenium;

namespace Celonis.Cloud.Tests.UI.PageObjects
{
    [PageTitle("Business Views")]
    [PageUrl("/package-manager/ui/views/ui")]
    public class BusinessViewsPage : BasePage
    {
        public BusinessViewsPage(IWebDriver driver) : base(driver) { }
    }
}
