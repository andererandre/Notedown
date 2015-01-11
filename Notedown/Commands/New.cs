using System;
using Eto.Forms;
using Eto.Drawing;

namespace Notedown.Commands
{
    public class New : Command
    {
        public New()
        {
            this.MenuText = "&New";
            this.ToolBarText = "New";
            this.Image = Icon.FromResource("Notedown.Resources.toolbar-add.ico");
            this.Shortcut = Application.Instance.CommonModifier | Keys.N;
        }

        protected override void OnExecuted(EventArgs e)
        {
            base.OnExecuted(e);
            var form = (MainForm)Application.Instance.MainForm;
            var dialog = new Dialogs.Input("New Note", "Create new note");
            
            if (dialog.ShowModal(Application.Instance.MainForm))
            {
                form.Notes.AddNote(dialog.Data);
            }
        }
    }
}
