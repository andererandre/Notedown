using System;
using System.Reflection;
using Eto.Drawing;
using Eto.Forms;
using Eto.Misc;

namespace Notedown.Dialogs
{
    public class About : Dialog
    {
        public About()
        {
            /* dialog attributes */
            
            this.Text = "About Notedown";
            this.ClientSize = new Size(300, 280);
            this.Resizable = false;
            
            /* dialog controls */
            
            var imageView = new ImageView();
            imageView.Image = Icon.FromResource("Icon.ico");
            imageView.Size = new Size(128, 128);
            
            var labelTitle = new Label();
            labelTitle.Text = "Notedown";
            labelTitle.Size = new Size(240, 24);
            labelTitle.Font = new Font(FontFamily.Sans, 16);
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
            button.Size = new Size(90, 26);
            button.Click += delegate
            {
                Close();
            };
            
            /* dialog layout */
            
            var layout = new DynamicLayout(this);
            layout.AddColumn(imageView, labelTitle, labelVersion, labelCopyright);
            layout.AddCentered(button);
        }
    }
}
