using System;
using Eto.Forms;
using Eto.Drawing;

namespace Notedown.Actions
{
	public class New : ButtonAction
	{
		public const string ActionID = "new";
		
		public New()
		{
			this.ID = ActionID;
			this.MenuText = "&New";
			this.ToolBarText = "New";
            this.Icon = new Icon(null, "Notedown.Resources.toolbar-add.ico");
            this.Accelerator = Application.Instance.CommonModifier | Key.N;
		}
		
		protected override void OnActivated(EventArgs e)
		{
			base.OnActivated(e);
            var form = (MainForm)Application.Instance.MainForm;
            
            // create new note
            var dialog = new Dialogs.New();
            dialog.ShowDialog(Application.Instance.MainForm);
            if (dialog.DialogResult == DialogResult.Ok)
            {
                form.Notes.AddNote(dialog.TextBoxName.Text);
            }
		}
	}
}

