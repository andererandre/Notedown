using System;
using Eto;
using Eto.Forms;

namespace Notedown
{
    class Startup
    {
        static void Main(string[] args)
        {
            var generator = Generator.GetGenerator("Eto.Platform.Windows.Generator, Eto.Platform.Windows");
            var app = new Program(generator);
            app.Run();
        }
	}
}
