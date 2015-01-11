using System;
using Eto.Forms;
using Eto.Drawing;

namespace Notedown.Commands
{
    public class Delete : Command
    {
        public Delete()
        {
            this.MenuText = "&Delete";
            this.ToolBarText = "Delete";
            this.Image = Icon.FromResource("Notedown.Resources.toolbar-remove.ico");
            this.Shortcut = Application.Instance.CommonModifier | Keys.D;
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
            
            string capt = form.Notes.CurrentNote.Name;
            string text = "Do you really want to delete this note?";
            
            if (MessageBox.Show(form, text, capt, MessageBoxButtons.YesNo, MessageBoxType.Question) == DialogResult.Yes)
            {
                form.Notes.DeleteNote();
            }
        }
    }
}
