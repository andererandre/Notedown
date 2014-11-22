using System;
using Eto.Forms;
using Eto.Drawing;

namespace Notedown.Commands
{
    public class Rename : Command
    {
        public Rename()
        {
            this.MenuText = "&Rename";
            this.ToolBarText = "Rename";
            this.Image = Icon.FromResource("Notedown.Resources.toolbar-rename.ico");
            this.Shortcut = Application.Instance.CommonModifier | Keys.R;
        }

        protected override void OnExecuted(EventArgs e)
        {
            base.OnExecuted(e);
            var form = (MainForm)Application.Instance.MainForm;
            
            if (form.Notes.Count == 0)
            {
                MessageBox.Show(form, "No notes available.", MessageBoxButtons.OK, MessageBoxType.Error);
                return;
            }
            var note = form.Notes.CurrentNote;
            var dialog = new Dialogs.Input("Rename Note", "Rename note '" + note.Name + "'");
            dialog.Data = note.Name;
            
            if (dialog.ShowModal(Application.Instance.MainForm))
            {
                if (note.Rename(dialog.Data))
                {
                    form.Notes.ListBox.Invalidate();
                }
                else
                    MessageBox.Show(form, "A note with that name already exists!", MessageBoxButtons.OK, MessageBoxType.Error);
            }
        }
    }
}
