using Celonis.Cloud.Tests.UI.PageObjects.Base;
using Celonis.Cloud.Tests.UI.PageObjects.Metadata;
using OpenQA.Selenium;

namespace Celonis.Cloud.Tests.UI.PageObjects
{
    [PageTitle("Process Repository")]
    [PageUrl("/process-repository/ui")]
    public class ProcessRepositoryPage : BasePage
    {
        public ProcessRepositoryPage(IWebDriver driver) : base(driver) { }
    }
}
