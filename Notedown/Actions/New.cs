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
            var dialog = new Dialogs.Input("New Note", "Create new note");
            
            if (dialog.ShowDialog(Application.Instance.MainForm) == DialogResult.Ok)
            {
                form.Notes.AddNote(dialog.Data);
            }
		}
	}
}