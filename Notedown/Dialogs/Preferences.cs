using System;
using Eto.Drawing;
using Eto.Forms;
using Eto.Misc;

namespace Notedown.Dialogs
{
	public class Preferences : Dialog
	{
        public TextBox TextBoxFolder { get; private set; }
        
		public Preferences()
		{
            /* dialog attributes */
            
			this.Text = "Preferences";
			this.ClientSize = new Size(400, 120);
			this.Resizable = false;
            
            /* dialog controls */
            
            var groupBoxFolder = new GroupBox();
            groupBoxFolder.Text = "Notes folder";
            
            var textBoxFolder = new TextBox();
            textBoxFolder.Text = Notedown.Preferences.Folder;
            
			var buttonOk = new Button();
            buttonOk.Text = "Ok";
			buttonOk.Size = new Size(90, 26);
			buttonOk.Click += delegate
            {
                this.DialogResult = DialogResult.Ok;
                this.Close();
			};
            
            var buttonCancel = new Button();
            buttonCancel.Text = "Cancel";
            buttonCancel.Size = new Size(90, 26);
            buttonCancel.Click += delegate
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };
            
            /* dialog layout */
            
            var layoutFolder = new DynamicLayout(groupBoxFolder);
            layoutFolder.BeginVertical();
            layoutFolder.Add(textBoxFolder);
            layoutFolder.EndVertical();
            
            var layout = new DynamicLayout(this);
            layout.BeginVertical(new Padding(10, 5), new Size(10, 10));
            
            layout.Add(groupBoxFolder);
            
            layout.BeginVertical(Padding.Empty, Size.Empty);
            layout.BeginHorizontal();
            layout.Add(null, true);
            layout.Add(buttonCancel);
            layout.Add(buttonOk);
            layout.Add(null, true);
            layout.EndHorizontal();
            layout.EndVertical();
            
            layout.EndVertical();
            
            /* dialog accessors */
            
            TextBoxFolder = textBoxFolder;
		}
	}
}

