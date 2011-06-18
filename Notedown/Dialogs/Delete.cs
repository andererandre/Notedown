using System;
using Eto.Drawing;
using Eto.Forms;
using Eto.Misc;

namespace Notedown.Dialogs
{
	public class Delete : Dialog
	{
		public Delete()
		{
            // form
			this.Text = "Delete Note";
			this.ClientSize = new Size(300, 100);
            this.Resizable = false;
            
            // label name
            var labelName = new Label();
            labelName.Text = "Delete note '" + ((MainForm)Application.Instance.MainForm).Notes.CurrentNote + "'?";
            labelName.HorizontalAlign = HorizontalAlign.Center;
            
            // button ok
			var buttonOk = new Button();
            buttonOk.Text = "Yes";
			buttonOk.Size = new Size(90, 26);
			buttonOk.Click += delegate
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
			};
            
            // button cancel
            var buttonCancel = new Button();
            buttonCancel.Text = "No";
            buttonCancel.Size = new Size(90, 26);
            buttonCancel.Click += delegate
            {
                this.DialogResult = DialogResult.No;
                this.Close();
            };
            
            // button layout
            var buttonLayout = new TableLayout(new Panel { Size = new Size(90, 36) }, 4, 1);
            buttonLayout.Padding = new Padding(0, 5);
            buttonLayout.SetColumnScale(0);
            buttonLayout.SetColumnScale(3);
            buttonLayout.Add(buttonCancel, 1, 0);
            buttonLayout.Add(buttonOk, 2, 0);
         
            // form layout
            var layout = new TableLayout(this, 1, 4);
            layout.Padding = new Padding(0, 10);
            layout.SetRowScale(0);
            layout.SetRowScale(3);
            layout.Add(labelName, 0, 1);
            layout.Add(buttonLayout.Container, 0, 2);
		}
	}
}

