using Celonis.Cloud.Tests.UI.PageObjects.Base;
using Celonis.Cloud.Tests.UI.PageObjects.Metadata;
using OpenQA.Selenium;

namespace Celonis.Cloud.Tests.UI.PageObjects
{
    [PageTitle("Celonis Gallery")]
    [PageUrl("/try/ui/celonis-gallery/ui")]
    public class CelonisGalleryPage : BasePage
    {
        public CelonisGalleryPage(IWebDriver driver) : base(driver) { }
    }
}
