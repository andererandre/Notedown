using System;
using Eto.Forms;
using Eto.Drawing;

namespace Notedown.Actions
{
	public class Rename : ButtonAction
	{
		public const string ActionID = "rename";
		
		public Rename()
		{
			this.ID = ActionID;
			this.MenuText = "&Rename";
			this.ToolBarText = "Rename";
            this.Icon = new Icon(null, "Notedown.Resources.toolbar-rename.ico");
            this.Accelerator = Application.Instance.CommonModifier | Key.R;
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
            
            // create new note
            var dialog = new Dialogs.Rename();
            dialog.ShowDialog(Application.Instance.MainForm);
            if (dialog.DialogResult == DialogResult.Ok)
            {
                if (form.Notes.CurrentNote.Rename(dialog.TextBoxName.Text))
                {
                    form.Notes.ListBox.Invalidate();
                }
                else MessageBox.Show(form, "A note with that name already exists!", MessageBoxButtons.OK, MessageBoxType.Error);
            }
		}
	}
}

