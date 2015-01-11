using System;
using Eto.Drawing;
using Eto.Forms;
using System.ComponentModel;

namespace Notedown.Dialogs
{
    public class Input : Dialog<bool>, INotifyPropertyChanged
    {
        string data;

        public string Data
        {
            get { return data; }
            set
            {
                data = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Data"));
            }
        }

        public Input(string caption, string text)
        {
            /* dialog attributes */
            
            Title = caption;
            MinimumSize = new Size(400, 0);
            Resizable = false;
            
            /* dialog controls */
            
            var textBox = new TextBox();
            textBox.TextBinding.Bind(this, r => r.Data);
            
            var buttonOk = new Button { Text = "Ok" };
            buttonOk.Click += (sender, e) => Close(true);
            
            var buttonCancel = new Button { Text = "Cancel" };
            buttonCancel.Click += (sender, e) => Close(false);
            
            /* dialog layout */

            var groupBox = new GroupBox
            {
                Text = text,
                Content = new TableLayout
                { 
                    Padding = new Padding(10), 
                    Rows = { textBox } 
                }
            };

            Content = new TableLayout
            {
                Padding = new Padding(10),
                Rows =
                {
                    groupBox,
                    TableLayout.Horizontal(null, buttonCancel, buttonOk, null).With(r => r.Spacing = new Size(5, 5))
                }
            };
            
            /* dialog accessors */
            
            DefaultButton = buttonOk;
            AbortButton = buttonCancel;
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
