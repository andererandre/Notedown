using System;
using Eto.Forms;
using Eto.Drawing;

namespace Notedown.Actions
{
	public class About : ButtonAction
	{
		public const string ActionID = "about";
		
		public About()
		{
			this.ID = ActionID;
			this.MenuText = "About Notedown";
			this.ToolBarText = "About";
            this.Icon = new Icon(null, "toolbar-about.png");
		}
		
		protected override void OnActivated(EventArgs e)
		{
			base.OnActivated(e);
			
			// show the about dialog
			var about = new Dialogs.About();
			about.ShowDialog(Application.Instance.MainForm);
		}
	}
}

