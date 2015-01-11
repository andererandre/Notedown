using System;
using Eto.Forms;

namespace Notedown.Commands
{
    public class NextNote : Command
    {
        NoteView notes;

        public NextNote(NoteView notes)
        {
            this.notes = notes;
            this.MenuText = "Next Note";
            this.Shortcut = Application.Instance.CommonModifier | Keys.Alt | Keys.Down;
        }

        protected override void OnExecuted(EventArgs e)
        {
            base.OnExecuted(e);
            notes.GoToNextNote();
        }
    }
}

