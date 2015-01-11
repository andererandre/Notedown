using System;
using Eto;
using Eto.Forms;
using System.ComponentModel;

namespace Notedown
{
    public class Program : Application
    {
        public Program(string platformId)
            : base(platformId)
        {
        }

        protected override void OnTerminating (CancelEventArgs e)
        {
            base.OnTerminating (e);
            var form = this.MainForm as MainForm;
            if (!form.PromptSave ())
                e.Cancel = true;
        }
        
        protected override void OnInitialized(EventArgs e)
        {
            this.Name = "Notedown";
            this.MainForm = new MainForm();
            base.OnInitialized(e);
            this.MainForm.Show();
        }
    }
}
