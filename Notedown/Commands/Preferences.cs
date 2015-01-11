using System;
using Eto.Forms;
using Eto.Drawing;
using Eto;

namespace Notedown.Commands
{
    public class Preferences : Command
    {
        public Preferences()
        {
            this.MenuText = "Preferences...";
            this.ToolBarText = "Preferences";
            if (Platform.Instance.IsMac)
                this.Shortcut = Application.Instance.CommonModifier | Keys.Comma;
            this.Image = Icon.FromResource("Notedown.Resources.toolbar-preferences.ico");
        }

        protected override void OnExecuted(EventArgs e)
        {
            base.OnExecuted(e);
            var form = (MainForm)Application.Instance.MainForm;
            
            var dialog = new Dialogs.Preferences { Folder = Notedown.Preferences.Folder };
            if (dialog.ShowModal(Application.Instance.MainForm))
            {
                Notedown.Preferences.Folder = dialog.Folder;
                Notedown.Preferences.Save();
                form.Update();
            }
        }
    }
}
