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
            // form
            this.Text = "About Notedown";
            this.ClientSize = new Size(300, 280);
            this.Resizable = false;
            
            // image
            var imageView = new ImageView();
            imageView.Image = new Icon(null, "Notedown.Icon.ico");
            imageView.Size = new Size(128, 128);
            
            // label title
            var labelTitle = new Label();
            labelTitle.Text = "Notedown";
            labelTitle.Size = new Size(240, 24);
            labelTitle.Font = new Font(FontFamily.Sans, 16);
            labelTitle.HorizontalAlign = HorizontalAlign.Center;
            
            // label version
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            var labelVersion = new Label();
            labelVersion.Text = string.Format("Version {0}", version);
            labelVersion.HorizontalAlign = HorizontalAlign.Center;
            
            // label copyright
            var labelCopyright = new Label();
            labelCopyright.Text = "Copyright by Andre Straubmeier";
            labelCopyright.HorizontalAlign = HorizontalAlign.Center;
            
            // button close
            var button = new Button();
            button.Text = "Close";
            button.Size = new Size(90, 26);
            button.Click += delegate
            {
                Close ();
            };
            
            // layout
            var layout = new DynamicLayout(this);
            layout.AddColumn(imageView, labelTitle, labelVersion, labelCopyright);
            layout.AddCentered(button);
            layout.Generate();
		}
	}
}

