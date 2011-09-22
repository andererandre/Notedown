using System;
using Eto;
using Eto.Forms;

namespace Notedown
{
    class Startup
    {
        static void Main(string[] args)
        {
            var generator = Generator.GetGenerator("Eto.Platform.GtkSharp.Generator, Eto.Platform.Gtk");
            var app = new Program(generator);
            app.Run();
        }
	}
}
