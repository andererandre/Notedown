using System;
using Eto.Forms;

namespace Notedown.Commands
{
    public class Close : Command
    {
        public Close()
        {
            this.MenuText = "Close";
            this.ToolBarText = "Close";
            this.Shortcut = Application.Instance.CommonModifier | Keys.W;
        }

        protected override void OnExecuted(EventArgs e)
        {
            base.OnExecuted(e);

            Application.Instance.MainForm.Close();
        }
    }
}
