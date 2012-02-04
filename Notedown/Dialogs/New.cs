using System;
using Eto.Drawing;
using Eto.Forms;
using Eto.Misc;

namespace Notedown.Dialogs
{
	public class New : Dialog
	{
        public TextBox TextBoxName { get; private set; }
        
		public New()
		{
            /* dialog attributes */
            
			this.Text = "New Note";
            this.ClientSize = new Size(400, 120);
			this.Resizable = false;
            
            /* dialog controls */
            
            var groupBoxName = new GroupBox();
            groupBoxName.Text = "Name of the new note";
            
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
            
            var layoutName = new DynamicLayout(groupBoxName);
            layoutName.BeginVertical();
            layoutName.Add(textBoxName);
            layoutName.EndVertical();
            
            var layout = new DynamicLayout(this);
            layout.BeginVertical(new Padding(10, 5), new Size(10, 10));
            
            layout.Add(groupBoxName);
            
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

