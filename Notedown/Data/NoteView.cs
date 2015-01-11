using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using Eto.Forms;

namespace Notedown
{
    public class NoteView
    {
        string directory;
        List<Note> notes;

        public ListBox  ListBox  { get; private set; }

        public TextArea TextArea { get; private set; }

        public bool Changed
        {
            get
            {
                foreach (Note note in notes)
                {
                    if (note.Changed)
                        return true;
                }
                return false;
            }
        }

        public NoteView(string dir)
        {
            directory = dir;
            notes = new List<Note>();
            
            ListBox = new ListBox { Style = "ListNative" };
            TextArea = new TextArea { Style = "TextConsole" };

            var updatingNote = false;
            
            TextArea.TextChanged += delegate
            {
                if (ListBox.SelectedIndex < 0)
                    return;
                var note = notes[ListBox.SelectedIndex];
                bool changed = note.Changed;
                note.Content = TextArea.Text;
                if (changed != note.Changed)
                    ListBox.Invalidate();
            };

            TextArea.SelectionChanged += delegate
            {
                if (ListBox.SelectedIndex < 0 || updatingNote)
                    return;
                notes[ListBox.SelectedIndex].Selection = TextArea.Selection;
            };
            
            ListBox.SelectedIndexChanged += delegate
            {
                if (ListBox.SelectedIndex < 0)
                    return;
                var note = notes[ListBox.SelectedIndex];
                updatingNote = true;
                TextArea.Text = note.Content;
                TextArea.Selection = note.Selection;
                TextArea.Focus();
                updatingNote = false;
            };
        }

        public int Count
        {
            get
            {
                return notes.Count;
            }
        }

        public Note this [int i]
        {
            get
            {
                return notes[i];
            }
            set
            {
                notes[i] = value;
            }
        }

        public Note CurrentNote
        {
            get { return ListBox.SelectedIndex >= 0 ? notes[ListBox.SelectedIndex] : null; }
        }

        public void AddNote(string name)
        {
            AddNote(name, string.Empty, directory + name + ".txt");
        }

        public void AddNote(string name, string text, string file)
        {
            var note = new Note(name, text, file);
            notes.Add(note);
            ListBox.Items.Add(note);
            if (ListBox.SelectedIndex < 0)
                ListBox.SelectedIndex = 0;
        }

        public void DeleteNote()
        {
            DeleteNote(ListBox.SelectedIndex);
        }

        public void DeleteNote(Note note)
        {
            DeleteNote(ListBox.Items.IndexOf(note));
        }

        public void DeleteNote(int index)
        {
            notes[index].Delete();
            notes.RemoveAt(index);
            ListBox.Items.RemoveAt(index);
        }

        public void Save()
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            foreach (Note note in notes)
            {
                note.Save();
            }
            ListBox.Invalidate();
        }

        public static NoteView CreateFromDirectory(string dir)
        {
            var result = new NoteView(dir);
            
            if (!Directory.Exists(dir))
                return result;
            
            string[] files = Directory.GetFiles(dir);
            if (files.Length != 0)
            {
                foreach (string file in files)
                {
                    string name = file.Replace(dir, "").Replace(".txt", "");
                    string text = File.ReadAllText(file, Encoding.UTF8);
                    result.AddNote(name, text, file);
                }
                result.ListBox.SelectedIndex = 0;
            }
            
            return result;
        }

        public void GenerateMenu(ISubmenu subMenu)
        {
            var file = subMenu.Items.GetSubmenu("&File");

            file.Items.AddSeparator(600);
            file.Items.Add(new Commands.NextNote(this), 600);
            file.Items.Add(new Commands.PreviousNote(this), 600);
            file.Items.AddSeparator(600);
        }

        public void GoToNextNote()
        {
            ListBox.SelectedIndex = (ListBox.SelectedIndex + 1) % ListBox.Items.Count;
        }

        public void GoToPreviousNote()
        {
            var index = ListBox.SelectedIndex - 1;
            while (index < 0)
                index += ListBox.Items.Count;
            ListBox.SelectedIndex = index;
        }
    }
}
