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
            /* dialog attributes */
            
			this.Text = "Delete Note";
            this.ClientSize = new Size(350, 90);
            this.Resizable = false;
            
            /* dialog controls */
            
            var labelDescription = new Label();
            labelDescription.Text = "Delete note '" + ((MainForm)Application.Instance.MainForm).Notes.CurrentNote.Name + "'?";
            labelDescription.HorizontalAlign = HorizontalAlign.Center;
            labelDescription.VerticalAlign = VerticalAlign.Middle;
            
			var buttonOk = new Button();
            buttonOk.Text = "Yes";
			buttonOk.Size = new Size(90, 26);
			buttonOk.Click += delegate
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
			};
            
            var buttonCancel = new Button();
            buttonCancel.Text = "No";
            buttonCancel.Size = new Size(90, 26);
            buttonCancel.Click += delegate
            {
                this.DialogResult = DialogResult.No;
                this.Close();
            };
            
            /* dialog layout */
            
            var layout = new DynamicLayout(this);
            layout.BeginVertical(new Padding(10, 5), new Size(10, 10));
            
            layout.Add(labelDescription);
            
            layout.BeginVertical(Padding.Empty, Size.Empty);
            layout.BeginHorizontal();
            layout.Add(null, true);
            layout.Add(buttonCancel);
            layout.Add(buttonOk);
            layout.Add(null, true);
            layout.EndHorizontal();
            layout.EndVertical();
            
            layout.EndVertical();
		}
	}
}

