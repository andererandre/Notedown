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
            var version = Assembly.GetEntryAssembly().GetName().Version;
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
            
            // button layout
            var buttonLayout = new TableLayout (new Panel { Size = new Size(90, 26) }, 3, 1);
            buttonLayout.Padding = Padding.Empty;
            buttonLayout.SetColumnScale (0);
            buttonLayout.SetColumnScale (2);
            buttonLayout.Add(button, 1, 0);
            
            // form layout
            var layout = new TableLayout(this, 1, 5);
            layout.Padding = new Padding(0, 10);
            layout.Add(imageView, 0, 0, true, true);
            layout.Add(labelTitle, 0, 1);
            layout.Add (labelVersion, 0, 2);
            layout.Add(labelCopyright, 0, 3);
            layout.Add(buttonLayout.Container, 0, 4);
		}
	}
}

