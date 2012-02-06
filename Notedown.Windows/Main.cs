using System;
using System.Drawing;
using Eto;
using Eto.Forms;
using Windows = System.Windows.Forms;

namespace Notedown
{
    class Startup
    {
        static void Main(string[] args)
        {
            Style.Add<TextArea, Windows.TextBox>("TextConsole", (widget, control) => {
				control.Font = new Font(FontFamily.GenericMonospace, 10);
            });
			
            var generator = Generator.GetGenerator("Eto.Platform.Windows.Generator, Eto.Platform.Windows");
            var app = new Program(generator);
            app.Run();
        }
	}
}
