using System;

namespace Celonis.Cloud.Tests.UI.PageObjects.Metadata
{
    public class PageUrlAttribute : Attribute
    {
        public string Url { get; set; }

        public PageUrlAttribute(string url)
        {
            Url = url;
        }
    }
}
