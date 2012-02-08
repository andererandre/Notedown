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
            
            var dialog = new Dialogs.Input("Rename Note", "Rename note '" + form.Notes.CurrentNote.Name + "'");
            
            if (dialog.ShowDialog(Application.Instance.MainForm) == DialogResult.Ok)
            {
                if (form.Notes.CurrentNote.Rename(dialog.Data))
                {
                    form.Notes.ListBox.Invalidate();
                }
                else MessageBox.Show(form, "A note with that name already exists!", MessageBoxButtons.OK, MessageBoxType.Error);
            }
		}
	}
}