using System;
using Eto;
using Eto.Forms;

namespace Notedown
{
    class Startup
    {
        static void Main(string[] args)
        {
            var app = new Program(Eto.Platforms.Gtk2);
            app.Run();
        }
    }
}
