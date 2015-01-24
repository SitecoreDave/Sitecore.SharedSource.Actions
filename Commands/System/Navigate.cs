using Sitecore.Diagnostics;
using Sitecore.Pipelines.HttpRequest;
using System;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.HtmlControls;
using Sitecore.Web.UI.Sheer;

namespace Sitecore.SharedSource.Actions.Commands.System
{
    public class Navigate : Command 
    {
        public override void Execute(CommandContext context)
        {
            if (context == null || context.Parameters.Count == 0 || String.IsNullOrEmpty(context.Parameters["url"])) return;

            SheerResponse.CheckModified(false);
            Context.ClientPage.ClientResponse.Eval("window.open('" + context.Parameters["url"] + "', '_blank')");
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