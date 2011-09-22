using System;
using Eto.Drawing;
using Eto.Forms;
using Eto.Misc;

namespace Notedown.Dialogs
{
	public class New : Dialog
	{
        public TextBox TextBoxName { get; set; }
        
		public New()
		{
            // form
			this.Text = "New Note";
			this.ClientSize = new Size(350, 110);
			this.Resizable = true;
            
            // label description
            var labelDescription = new Label();
            labelDescription.Text = "Add a new note to the list";
            labelDescription.HorizontalAlign = HorizontalAlign.Center;
            labelDescription.VerticalAlign = VerticalAlign.Middle;
            
            // label name
            var labelName = new Label();
            labelName.Text = "Name:";
            labelName.HorizontalAlign = HorizontalAlign.Center;
            labelName.VerticalAlign = VerticalAlign.Middle;
            
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
         
            // layout
            var layout = new DynamicLayout(this);
            layout.BeginVertical(new Padding(10, 5), new Size(10, 10));
            
            layout.Add(labelDescription);
            
            layout.BeginVertical(Padding.Empty, Size.Empty);
            layout.BeginHorizontal();
            layout.Add(labelName);
            layout.Add(textBoxName);
            layout.EndHorizontal();
            layout.EndVertical();
            
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
            TextBoxName = textBoxName;
		}
	}
}

