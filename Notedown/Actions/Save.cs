using System;
using Eto.Forms;

namespace Notedown.Actions
{
	public class Save : ButtonAction
	{
		public const string ActionID = "save";
		
		public Save()
		{
			this.ID = ActionID;
			this.MenuText = "&Save Notes";
			this.ToolBarText = "Save";
            this.Accelerator = Application.Instance.CommonModifier | Key.S;
		}
		
		protected override void OnActivated(EventArgs e)
		{
			base.OnActivated(e);
            
            ((MainForm)Application.Instance.MainForm).Notes.Save();
		}
	}
}

