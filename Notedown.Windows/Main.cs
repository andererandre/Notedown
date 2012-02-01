using System;
using Eto;
using Eto.Forms;
using System.Drawing;

namespace Notedown
{
    class Startup
    {
        static void Main(string[] args)
        {
            Style.Add("TextConsole", (w) => { var v = w.ControlObject as System.Windows.Forms.TextBox;
				v.Font = new Font(FontFamily.GenericMonospace, 10);
            });
            var generator = Generator.GetGenerator("Eto.Platform.Windows.Generator, Eto.Platform.Windows");
            var app = new Program(generator);
            app.Run();
        }
	}
}
