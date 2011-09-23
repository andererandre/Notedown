using System;
using Eto.Forms;
using Eto.Drawing;

namespace Notedown.Actions
{
	public class New : ButtonAction
	{
		public static string ActionID = "new";
		
		public New()
		{
			this.ID = ActionID;
			this.MenuText = "New Note";
			this.ToolBarText = "New";
            this.Icon = new Icon(null, "Notedown.Resources.toolbar-add.ico");
		}
		
		protected override void OnActivated(EventArgs e)
		{
			base.OnActivated(e);
            
            // create new note
            var dialog = new Dialogs.New();
            dialog.ShowDialog(Application.Instance.MainForm);
            if (dialog.DialogResult == DialogResult.Ok)
            {
                ((MainForm)Application.Instance.MainForm).Notes.AddNote(dialog.TextBoxName.Text);
            }
		}
	}
}

