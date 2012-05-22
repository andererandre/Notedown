using System;
using Eto.Drawing;
using Eto.Forms;
using Eto.Misc;

namespace Notedown.Dialogs
{
    public class Input : Dialog
    {
        private TextBox textBox;
        public string Data { get { return textBox.Text; } }
        
        public Input(string caption, string text)
        {
            /* dialog attributes */
            
            this.Text = caption;
            this.ClientSize = new Size(400, 120);
            this.Resizable = false;
            
            /* dialog controls */
            
            var groupBox = new GroupBox();
            groupBox.Text = text;
            
            var textBox = new TextBox();
            textBox.Size = new Size(200, 20);
            
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
            
            var layoutName = new DynamicLayout(groupBox);
            layoutName.BeginVertical();
            layoutName.Add(textBox);
            layoutName.EndVertical();
            
            var layout = new DynamicLayout(this);
            layout.BeginVertical(new Padding(10, 5), new Size(10, 10));
            
            layout.Add(groupBox);
            
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
            
            this.DefaultButton = buttonOk;
            this.AbortButton = buttonCancel;
            this.textBox = textBox;
        }
    }
}
