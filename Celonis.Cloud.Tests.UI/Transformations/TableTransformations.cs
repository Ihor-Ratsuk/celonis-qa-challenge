using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Celonis.Cloud.Tests.UI.Transformations
{
    [Binding]
    public class TableTransformations
    {
        [StepArgumentTransformation()]
        public string[] TableToArray(Table table)
        {
            return table.Rows.Select(x => x.Values.First()).ToArray();
        }
    }
}
