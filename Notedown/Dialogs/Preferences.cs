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
			this.ClientSize = new Size(400, 120);
			this.Resizable = false;
            
            // box general
            var boxGeneral = new GroupBox();
            boxGeneral.Text = "General";
            
            // label name
            var labelFolder = new Label();
            labelFolder.Text = "Notes Folder:";
            labelFolder.HorizontalAlign = HorizontalAlign.Center;
            labelFolder.VerticalAlign = VerticalAlign.Middle;
            
            // textbox name
            var textBoxFolder = new TextBox();
            textBoxFolder.Text = Notedown.Preferences.Folder;
            
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
            
            // layout box general
            var layoutBoxGeneral = new DynamicLayout(boxGeneral);
            layoutBoxGeneral.BeginVertical();
            
            layoutBoxGeneral.BeginHorizontal();
            layoutBoxGeneral.Add(labelFolder);
            layoutBoxGeneral.Add(textBoxFolder);
            layoutBoxGeneral.EndHorizontal();
            
            layoutBoxGeneral.EndVertical();
            layoutBoxGeneral.Generate();
            
            // layout
            var layout = new DynamicLayout(this);
            layout.BeginVertical(new Padding(10, 5), new Size(10, 10));
            
            layout.Add(boxGeneral);
            
            layout.BeginVertical(Padding.Empty, Size.Empty);
            layout.BeginHorizontal();
            layout.Add(null, true);
            layout.Add(buttonCancel);
            layout.Add(buttonOk);
            layout.Add(null, true);
            layout.EndHorizontal();
            layout.EndVertical();
            
            layout.EndVertical();
            layout.Generate();
            
            // public accessors
            TextBoxFolder = textBoxFolder;
		}
	}
}

