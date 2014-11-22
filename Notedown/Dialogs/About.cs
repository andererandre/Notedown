using System;
using System.Reflection;
using Eto.Drawing;
using Eto.Forms;

namespace Notedown.Dialogs
{
    public class About : Dialog
    {
        public About()
        {
            /* dialog attributes */
            
            this.Title = "About Notedown";
            this.MinimumSize = new Size(300, 0);
            this.Resizable = false;
            
            /* dialog controls */
            
            var imageView = new ImageView();
            imageView.Image = Icon.FromResource("Icon.ico");
            imageView.Size = new Size(128, 128);
            
            var labelTitle = new Label();
            labelTitle.Text = "Notedown";
            labelTitle.Font = new Font(FontFamilies.Sans, 16);
            labelTitle.HorizontalAlign = HorizontalAlign.Center;
            
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            var labelVersion = new Label();
            labelVersion.Text = string.Format("Version {0}", version);
            labelVersion.HorizontalAlign = HorizontalAlign.Center;
            
            var labelCopyright = new Label();
            labelCopyright.Text = "Copyright by Andre Straubmeier";
            labelCopyright.HorizontalAlign = HorizontalAlign.Center;
            
            var button = new Button();
            button.Text = "Close";
            button.Click += (sender, e) => Close();
            
            /* dialog layout */
            
            Content = new TableLayout
            {
                Padding = new Padding(10),
                Spacing = new Size(5, 5),
                Rows =
                {
                    imageView, labelTitle, labelVersion, labelCopyright,
                    TableLayout.AutoSized(button, centered: true)
                }
            };

            AbortButton = DefaultButton = button;
        }
    }
}
