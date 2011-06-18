using System;
using Eto.Drawing;
using Eto.Forms;
using Eto.Misc;

namespace Notedown.Dialogs
{
	public class Rename : Dialog
	{
        public TextBox TextBoxName { get; set; }
        
		public Rename()
		{
            // form
			this.Text = "Rename Note";
			this.ClientSize = new Size(300, 110);
			this.Resizable = false;
            
            // label name
            var labelName = new Label();
            labelName.Text = "Please enter the new name of the note:";
            labelName.HorizontalAlign = HorizontalAlign.Center;
            
            // textbox name
            var textBoxName = new TextBox();
            textBoxName.Size = new Size(200, 20);
            
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
            textBoxLayout.Add(textBoxName, 1, 0);
            
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
            layout.Add(labelName, 0, 1);
            layout.Add(textBoxLayout.Container, 0, 2);
            layout.Add(buttonLayout.Container, 0, 3);
            
            // public accessors
            TextBoxName = textBoxName;
		}
	}
}

