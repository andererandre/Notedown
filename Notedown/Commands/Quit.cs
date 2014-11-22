using System;
using Eto.Forms;

namespace Notedown.Commands
{
    public class Quit : Command
    {
        public Quit()
        {
            this.MenuText = "&Quit";
            this.ToolBarText = "Quit";
            this.Shortcut = Application.Instance.CommonModifier | Keys.Q;
        }

        protected override void OnExecuted(EventArgs e)
        {
            base.OnExecuted(e);

            Application.Instance.Quit();
        }
    }
}
