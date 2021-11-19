using Celonis.Cloud.Tests.UI.PageObjects.Base;
using Celonis.Cloud.Tests.UI.PageObjects.Metadata;
using OpenQA.Selenium;

namespace Celonis.Cloud.Tests.UI.PageObjects
{
    [PageTitle("Machine Learning")]
    [PageUrl("/machine-learning/ui")]
    public class MachineLearningPage : BasePage
    {
        public MachineLearningPage(IWebDriver driver) : base(driver) { }
    }
}
