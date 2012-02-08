using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace Notedown
{
    public class NoteView
    {
        private string directory;
        private List<Note> notes;
        
        public Eto.Forms.ListBox  ListBox  { get; private set; }
        public Eto.Forms.TextArea TextArea { get; private set; }
        
        public bool Changed
        {
            get
            {
                foreach (Note note in notes)
                {
                    if (note.Changed) return true;
                }
                return false;
            }
        }
        
        public NoteView(string dir)
        {
            directory = dir;
            notes = new List<Note>();
            
            ListBox  = new Eto.Forms.ListBox()  { Style = "ListNative" };
            TextArea = new Eto.Forms.TextArea() { Style = "TextConsole" };
            
            TextArea.TextChanged += delegate
            {
                if (ListBox.SelectedIndex < 0) return;
                bool changed = notes[ListBox.SelectedIndex].Changed;
                notes[ListBox.SelectedIndex].Content = TextArea.Text;
                if (changed != notes[ListBox.SelectedIndex].Changed) ListBox.Invalidate();
            };
            
            ListBox.SelectedIndexChanged += delegate
            {
                if (ListBox.SelectedIndex < 0) return;
                TextArea.Text = notes[ListBox.SelectedIndex].Content;
            };
        }
        
        public int Count
        {
            get
            {
                return notes.Count;
            }
        }
        
        public Note this[int i]
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
        
        public void AddNote(string name) { AddNote(name, string.Empty, directory + name + ".txt"); }
        public void AddNote(string name, string text, string file)
        {
            Note note = new Note(name, text, file);
            notes.Add(note);
            ListBox.Items.Add(note);
            if (ListBox.SelectedIndex < 0) ListBox.SelectedIndex = 0;
        }
        
        public void DeleteNote() { DeleteNote(ListBox.SelectedIndex); }
        public void DeleteNote(Note note) { DeleteNote(ListBox.Items.IndexOf(note)); }
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
            NoteView result = new NoteView(dir);
            
            if (!Directory.Exists(dir)) return result;
            
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
    }
}
