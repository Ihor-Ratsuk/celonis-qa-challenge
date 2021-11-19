using Celonis.Cloud.Tests.UI.PageObjects.Base;
using Celonis.Cloud.Tests.UI.PageObjects.Metadata;
using OpenQA.Selenium;

namespace Celonis.Cloud.Tests.UI.PageObjects
{
    [PageTitle("Task Mining")]
    [PageUrl("/task-mining/ui")]
    public class TaskMiningPage : BasePage
    {
        public TaskMiningPage(IWebDriver driver) : base(driver) { }
    }
}
