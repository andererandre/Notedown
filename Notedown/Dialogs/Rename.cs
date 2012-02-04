using System;
using Eto.Drawing;
using Eto.Forms;
using Eto.Misc;

namespace Notedown.Dialogs
{
	public class Rename : Dialog
	{
        public TextBox TextBoxName { get; private set; }
        
		public Rename()
		{
            /* dialog attributes */
            
			this.Text = "Rename Note";
            this.ClientSize = new Size(400, 120);
			this.Resizable = false;
            
            /* dialog controls*/
            
            var groupBoxDescription = new GroupBox();
            groupBoxDescription.Text = "Rename note '" + ((MainForm)Application.Instance.MainForm).Notes.CurrentNote.Name + "'";
            
            var textBoxName = new TextBox();
            textBoxName.Size = new Size(200, 20);
            
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
            
            var layoutDescription = new DynamicLayout(groupBoxDescription);
            layoutDescription.BeginVertical();
            layoutDescription.Add(textBoxName);
            layoutDescription.EndVertical();
            
            var layout = new DynamicLayout(this);
            layout.BeginVertical(new Padding(10, 5), new Size(10, 10));
            
            layout.Add(groupBoxDescription);
            
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
            
            TextBoxName = textBoxName;
		}
	}
}

