using System;
using System.Text;
using System.IO;
using Eto.Forms;

namespace Notedown
{
    public class Note : IListItem
    {
        public string Name    { get; private set; }
        public string Dir     { get; private set; }
        public string Content { get; set; }
        public bool   Changed { get { return !File.Exists(Dir) || File.ReadAllText(Dir, Encoding.UTF8) != Content; } }
        public Range<int> Selection { get; set; }
        
        public Note(string name, string text, string path)
        {
            Name = name;
            Content = text;
            Dir = path;
            Selection = new Range<int>(0, -1);
        }
        
        public void Delete()
        {
            File.Delete(Dir);
        }
        
        public void Save()
        {
            if (Changed) File.WriteAllText(Dir, Content, Encoding.UTF8);
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
            get { return Changed ? "[*] " + Name : Name; }
            set { }
        }
        
        public string Key
        {
            get { return Name; }
        }
    }
}
