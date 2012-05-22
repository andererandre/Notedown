using System;
using Eto.Forms;
using Eto.Drawing;

namespace Notedown.Actions
{
    public class Save : ButtonAction
    {
        public const string ActionID = "save";
        
        public Save()
        {
            this.ID = ActionID;
            this.MenuText = "&Save";
            this.ToolBarText = "Save";
            this.Icon = Icon.FromResource("Notedown.Resources.toolbar-save.ico");
            this.Accelerator = Application.Instance.CommonModifier | Key.S;
        }
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            var form = (MainForm)Application.Instance.MainForm;
            
            form.Notes.Save();
        }
    }
}
