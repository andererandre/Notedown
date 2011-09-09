using System;
using Eto;
using Eto.Forms;
using Eto.Misc;

namespace Notedown
{
    public class Program : Application
    {
        public Program(Generator generator) : base(generator) { }
        
        public override void OnInitialized(EventArgs e)
        {
            this.MainForm = new MainForm();
            base.OnInitialized(e);
            this.MainForm.Show();
        }
        
        static void Main(string[] args)
        {
            Generator generator;
            
            if (Platform.IsLinux)
            {
                generator = Generator.GetGenerator ("Eto.Platform.GtkSharp.Generator, Eto.Platform.Gtk");
            }
            else if (Platform.IsWindows)
            {
                generator = Generator.GetGenerator ("Eto.Platform.Windows.Generator, Eto.Platform.Windows");
            }
            else
            {
                generator = new Eto.Platform.Mac.Generator();
            }
            
            var app = new Program(generator);
            app.Run();
        }
	}
}
