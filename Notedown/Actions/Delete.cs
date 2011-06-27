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
			this.MenuText = "Delete Note";
			this.ToolBarText = "Delete";
            this.Icon = new Icon(null, "Resources.toolbar-remove.ico");
		}
		
		protected override void OnActivated(EventArgs e)
		{
			base.OnActivated(e);
			
			// show the about dialog
			var delete = new Dialogs.Delete();
			delete.ShowDialog(Application.Instance.MainForm);
            if (delete.DialogResult == DialogResult.Yes)
            {
                ((MainForm)Application.Instance.MainForm).Notes.DeleteNote();
            }
		}
	}
}

