using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace Notedown
{
    public class Note : Eto.Forms.IListItem
    {
        public string Name;
        public string Content;
        public string Dir;
        
        public Note(string name, string text, string path)
        {
            Name = name;
            Content = text;
            Dir = path;
        }
        
        public void Delete()
        {
            File.Delete(Dir);
        }
        
        public void Save()
        {
            if (File.ReadAllText(Dir, Encoding.UTF8) != Content)
            {
                File.WriteAllText(Dir, Content, Encoding.UTF8);
            }
        }
        
        public bool Rename(string name)
        {
            if (!String.Equals(Name, name))
            {
                name = name.Replace(Path.DirectorySeparatorChar.ToString(), String.Empty);
                int i = Dir.LastIndexOf(Name);
                string dir = Dir.Remove(i, Name.Length).Insert(i, name);
                
                if (!File.Exists(dir))
                {
                    File.Delete(Dir);
                    Name = name;
                    Dir = dir;
                    File.WriteAllText(Dir, Content, Encoding.UTF8);
                    return true;
                }
            }
            return false;
        }
        
        public string Text
        {
            get { return Name; }
        }
        
        public string Key
        {
            get { return Name; }
        }
    }
    
    public class NoteView
    {
        private string directory;
        private List<Note> notes = new List<Note>();
        public Eto.Forms.ListBox ListBox = new Eto.Forms.ListBox() { Style = "ListNative" };
        public Eto.Forms.TextArea TextArea = new Eto.Forms.TextArea() { Style = "TextConsole" };
        
        public NoteView(string dir)
        {
            directory = dir;
            
            TextArea.TextChanged += delegate
            {
                if (ListBox.SelectedIndex < 0) return;
                notes[ListBox.SelectedIndex].Content = TextArea.Text;
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
            
            if (!File.Exists(file))
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                File.WriteAllText(file, text, Encoding.UTF8);
            }
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
            foreach (Note note in notes)
            {
                note.Save();
            }
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