using System;

namespace Celonis.Cloud.Tests.UI.PageObjects.Metadata
{
    public class PageTitleAttribute : Attribute
    {
        public string Title { get; set; }

        public PageTitleAttribute(string title)
        {
            Title = title;
        }
    }
}
