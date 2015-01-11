using System;
using Eto.Forms;

namespace Notedown.Commands
{
    public class PreviousNote : Command
    {
        NoteView notes;

        public PreviousNote(NoteView notes)
        {
            this.notes = notes;
            this.MenuText = "Previous Note";
            this.Shortcut = Application.Instance.CommonModifier | Keys.Alt | Keys.Up;
        }

        protected override void OnExecuted(EventArgs e)
        {
            base.OnExecuted(e);
            notes.GoToPreviousNote();
        }
    }
}

