using System;
using Eto.Forms;
using Eto.Drawing;

namespace Notedown.Actions
{
	public class Rename : ButtonAction
	{
		public static string ActionID = "rename";
		
		public Rename()
		{
			this.ID = ActionID;
			this.MenuText = "Rename Note";
			this.ToolBarText = "Rename";
            this.Icon = new Icon(null, "Notedown.Resources.toolbar-rename.ico");
		}
		
		protected override void OnActivated(EventArgs e)
		{
			base.OnActivated(e);
            
            // create new note
            var dialog = new Dialogs.Rename();
            dialog.ShowDialog(Application.Instance.MainForm);
            if (dialog.DialogResult == DialogResult.Ok)
            {
                if (((MainForm)Application.Instance.MainForm).Notes.CurrentNote.Rename(dialog.TextBoxName.Text))
                {
                    ((MainForm)Application.Instance.MainForm).Notes.ListBox.Invalidate();
                }
                else MessageBox.Show(Application.Instance.MainForm, "A note with that name already exists!");
            }
		}
	}
}

