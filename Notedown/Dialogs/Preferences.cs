using System;
using Eto.Drawing;
using Eto.Forms;
using Eto.Misc;

namespace Notedown.Dialogs
{
	public class Preferences : Dialog
	{
        public TextBox TextBoxFolder { get; set; }
        
		public Preferences()
		{
            // form
			this.Text = "Preferences";
			this.ClientSize = new Size(500, 120);
			this.Resizable = false;
            
            // label name
            var labelFolder = new Label();
            labelFolder.Text = "Notes Folder:";
            labelFolder.HorizontalAlign = HorizontalAlign.Center;
            
            // textbox name
            var textBoxFolder = new TextBox();
            textBoxFolder.Text = Notedown.Preferences.Folder;
            textBoxFolder.Size = new Size(400, 20);
            
            // button ok
			var buttonOk = new Button();
            buttonOk.Text = "Ok";
			buttonOk.Size = new Size(90, 26);
			buttonOk.Click += delegate
            {
                this.DialogResult = DialogResult.Ok;
                this.Close();
			};
            
            // button cancel
            var buttonCancel = new Button();
            buttonCancel.Text = "Cancel";
            buttonCancel.Size = new Size(90, 26);
            buttonCancel.Click += delegate
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };
            
            // textbox layout
            var textBoxLayout = new TableLayout(new Panel { Size = new Size(90, 30) }, 3, 1);
            textBoxLayout.Padding = new Padding(0, 5);
            textBoxLayout.SetColumnScale(0);
            textBoxLayout.SetColumnScale(2);
            textBoxLayout.Add(textBoxFolder, 1, 0);
            
            // button layout
            var buttonLayout = new TableLayout(new Panel { Size = new Size(90, 36) }, 4, 1);
            buttonLayout.Padding = new Padding(0, 5);
            buttonLayout.SetColumnScale(0);
            buttonLayout.SetColumnScale(3);
            buttonLayout.Add(buttonCancel, 1, 0);
            buttonLayout.Add(buttonOk, 2, 0);
         
            // form layout
            var layout = new TableLayout(this, 1, 5);
            layout.Padding = new Padding(0, 10);
            layout.SetRowScale(0);
            layout.SetRowScale(4);
            layout.Add(labelFolder, 0, 1);
            layout.Add(textBoxLayout.Container, 0, 2);
            layout.Add(buttonLayout.Container, 0, 3);
            
            // public accessors
            TextBoxFolder = textBoxFolder;
		}
	}
}

