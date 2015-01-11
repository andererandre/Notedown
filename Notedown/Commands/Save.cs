using System;
using Eto.Forms;
using Eto.Drawing;

namespace Notedown.Commands
{
    public class Save : Command
    {
        public Save()
        {
            this.MenuText = "&Save";
            this.ToolBarText = "Save";
            this.Image = Icon.FromResource("Notedown.Resources.toolbar-save.ico");
            this.Shortcut = Application.Instance.CommonModifier | Keys.S;
        }

        protected override void OnExecuted(EventArgs e)
        {
            base.OnExecuted(e);
            var form = (MainForm)Application.Instance.MainForm;
            
            form.Notes.Save();
        }
    }
}
