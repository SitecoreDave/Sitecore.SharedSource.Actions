using Sitecore.Data.Items;
using Sitecore.Diagnostics;

namespace Sitecore.SharedSource.Actions.Processors
{
    public class CopyProcessor
        : IItemActionProcessor
    {
        public void ProcessItemAction(ItemActionProcessorArg actionArg)
        {
            Assert.IsTrue(actionArg.Parameters.Count > 0, "Invalid Parameters");
            var destinationItem = actionArg.Parameters["DestinationItem"] as Item;

            actionArg.Item.CopyTo(destinationItem, actionArg.Item.Name);
        }
    }
}