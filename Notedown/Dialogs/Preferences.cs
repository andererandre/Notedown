using System;
using Eto.Drawing;
using Eto.Forms;
using System.ComponentModel;

namespace Notedown.Dialogs
{
    public class Preferences : Dialog<bool>, INotifyPropertyChanged
    {
        string folder;

        public string Folder
        {
            get { return folder; }
            set
            {
                folder = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Folder"));
            }
        }

        public Preferences()
        {
            /* dialog attributes */
            
            Title = "Preferences";
            MinimumSize = new Size(400, 0);
            Resizable = false;
            
            /* dialog controls */
            
            var textBoxFolder = new TextBox();
            textBoxFolder.TextBinding.Bind(this, r => r.Folder);
            
            var buttonOk = new Button { Text = "Ok" };
            buttonOk.Click += (sender, e) => Close(true);
            
            var buttonCancel = new Button { Text = "Cancel" };
            buttonCancel.Click += (sender, e) => Close(false);

            var buttonSelect = new Button { Text = "Select Folder" };
            buttonSelect.Click += (sender, e) =>
            {
                var dlg = new SelectFolderDialog { Directory = Folder };
                if (dlg.ShowDialog(this) == DialogResult.Ok)
                    Folder = dlg.Directory;
            };
            
            /* dialog layout */

            var groupBoxFolder = new GroupBox
            {
                Text = "Notes folder",
                Content = new TableLayout
                { 
                    Padding = new Padding(10), 
                    Rows =
                    { 
                        new TableRow(new TableCell(new TableLayout(null, textBoxFolder, null), true), buttonSelect)
                    } 
                }
            };

            Content = new TableLayout
            {
                Padding = new Padding(10),
                Spacing = new Size(5, 5),
                Rows =
                {
                    groupBoxFolder,
                    TableLayout.Horizontal(null, buttonCancel, buttonOk, null).With(r => r.Spacing = new Size(5, 5))
                }
            };

            /* default accessors */
            
            DefaultButton = buttonOk;
            AbortButton = buttonCancel;
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
