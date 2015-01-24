using System.Collections.Specialized;
using Sitecore.Diagnostics;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.HtmlControls;
using Sitecore.Web.UI.Sheer;

namespace Sitecore.SharedSource.Actions.Commands.Item
{
    public class Action : Command 
    {
        public override void Execute(CommandContext context)
        {
            if (context.Items.Length != 1) return;
            var items = context.Items[0];
            var nameValueCollection = new NameValueCollection();
            nameValueCollection["id"] = items.ID.ToString();
            //Context.ClientPage.Start(this, (items.HasClones ? "ConfirmBeforeRun" : "Run"), nameValueCollection);
            Context.ClientPage.Start(this, "Run", nameValueCollection);
        }

        public void Run(ClientPipelineArgs args)
        {
            if (!SheerResponse.CheckModified()) return;
            
            //Context.ClientPage.ClientResponse.ShowModalDialog("/sitecore/shell/Applications/Dialogs/Action.aspx", "1300px", "700px", string.Empty, true);
            Context.ClientPage.ClientResponse.ShowModalDialog("/sitecore/shell/Applications/Dialogs/Action.aspx", "300px", "300px", string.Empty, true);

            //if (!args.IsPostBack)
            //{
            //    string item = args.Parameters["id"];
            //    Item item1 = Context.ContentDatabase.Items[item];
            //    if (item1 == null)
            //    {
            //        SheerResponse.Alert("Item not found.", new string[0]);
            //        return;
            //    }
            //    UrlString urlString = new UrlString("/sitecore/shell/Applications/Templates/Change template.aspx");
            //    urlString.Append("id", item1.ID.ToString());
            //    Context.ClientPage.ClientResponse.ShowModalDialog(urlString.ToString(), "1300px", "700px", string.Empty, true);
            //    args.WaitForPostBack();
            //}
            //else if (args.Result == "yes")
            //{
            //    Context.ClientPage.SendMessage(this, "item:templatechanged");
            //    return;
            //}

            //execute action
        }

        public override CommandState QueryState(CommandContext context)
        {
            CommandState commandState;
            Error.AssertObject(context, "context");
            if ((int)context.Items.Length == 0)
            {
                return CommandState.Disabled;
            }
            var items = context.Items;
            var num = 0;
            while (true)
            {
                if (num >= items.Length)
                {
                    return base.QueryState(context);
                }
                var item = items[num];
                if (!item.Access.CanDelete())
                {
                    commandState = CommandState.Disabled;
                    break;
                }
                if (item.Appearance.ReadOnly)
                {
                    commandState = CommandState.Disabled;
                    break;
                }
                if (!Command.IsLockedByOther(item))
                {
                    num++;
                }
                else
                {
                    commandState = CommandState.Disabled;
                    break;
                }
            }
            return commandState;
        }

        public override string GetClick(CommandContext context, string click)
        {
            //Assert.ArgumentNotNull(context, "context");
            //Assert.ArgumentNotNull(click, "click");
            //string[] str = new string[] { click, null };
            //string[] strArrays = new string[] { this._click };
            //str[1] = StringUtil.GetString(strArrays);
            //return StringUtil.GetString(str);
            return click;
        }


        /// <summary>
        /// Gets the submenu items.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>The submenu.</returns>
        public override Control[] GetSubmenuItems(CommandContext context)
        {
            Assert.ArgumentNotNull(context, "context");
            return null;
        }
    }
}