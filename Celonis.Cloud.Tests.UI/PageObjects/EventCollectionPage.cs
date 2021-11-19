using Celonis.Cloud.Tests.UI.PageObjects.Base;
using Celonis.Cloud.Tests.UI.PageObjects.Metadata;
using OpenQA.Selenium;

namespace Celonis.Cloud.Tests.UI.PageObjects
{
    [PageTitle("Event Collection")]
    [PageUrl("/integration/ui/pools")]
    public class EventCollectionPage : BasePage
    {
        public EventCollectionPage(IWebDriver driver) : base(driver) { }
    }
}
