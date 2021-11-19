using Celonis.Cloud.Tests.UI.PageObjects.Base;
using Celonis.Cloud.Tests.UI.PageObjects.Metadata;
using OpenQA.Selenium;

namespace Celonis.Cloud.Tests.UI.PageObjects
{
    [PageTitle("Studio")]
    [PageUrl("/package-manager/ui/studio/ui")]
    public class StudioPage : BasePage
    {
        public StudioPage(IWebDriver driver) : base(driver) { }
    }
}
