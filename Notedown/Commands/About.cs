using System;
using Eto.Forms;
using Eto.Drawing;

namespace Notedown.Commands
{
    public class About : Command
    {
        public About()
        {
            this.MenuText = "About Notedown";
            this.ToolBarText = "About";
            this.Image = Icon.FromResource("Notedown.Resources.toolbar-about.ico");
        }

        protected override void OnExecuted(EventArgs e)
        {
            base.OnExecuted(e);

            var about = new Dialogs.About();
            about.ShowModal(Application.Instance.MainForm);
        }
    }
}
