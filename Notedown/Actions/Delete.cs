using System;
using Eto.Forms;
using Eto.Drawing;

namespace Notedown.Actions
{
    public class Delete : ButtonAction
    {
        public const string ActionID = "delete";
        
        public Delete()
        {
            this.ID = ActionID;
            this.MenuText = "&Delete";
            this.ToolBarText = "Delete";
            this.Icon = Icon.FromResource("Notedown.Resources.toolbar-remove.ico");
            this.Accelerator = Application.Instance.CommonModifier | Key.D;
        }
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
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
