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
    }
}
