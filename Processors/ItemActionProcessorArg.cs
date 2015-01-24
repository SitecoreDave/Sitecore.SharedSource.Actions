using System.Collections.Generic;
using Sitecore.Data.Items;

namespace Sitecore.SharedSource.Actions.Processors
{
    public class ItemActionProcessorArg
    {
        public Item Item { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
    }
}