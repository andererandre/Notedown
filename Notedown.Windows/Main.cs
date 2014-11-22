using System;
using System.Drawing;
using Eto;
using Eto.Forms;
using Windows = System.Windows.Forms;
using Eto.WinForms.Forms.Controls;

namespace Notedown
{
    class Startup
    {
		[STAThread]
        static void Main(string[] args)
        {
            Style.Add<TextAreaHandler>("TextConsole", handler => {
				handler.Control.Font = new Font(FontFamily.GenericMonospace, 10);
            });

            var app = new Program(Eto.Platforms.WinForms);
            app.Run();
        }
    }
}
