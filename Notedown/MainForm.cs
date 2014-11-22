using System;
using System.Text;
using System.IO;
using System.ComponentModel;
using Eto;
using Eto.Forms;
using Eto.Drawing;

namespace Notedown
{
    public class MainForm : Form
    {
        public NoteView Notes { get; private set; }

        public MainForm()
        {
            Title = "Notedown";
            Icon = Icon.FromResource("Icon.ico");
            ClientSize = new Size(800, 600);
            Style = "MainWindow";

            Update();
        }

        public void Update()
        {
            Preferences.Load();
            Notes = NoteView.CreateFromDirectory(Preferences.Folder);

            GenerateMenu();
            GenerateToolBar();

            GenerateContent();
        }

        public bool PromptSave()
        {
            if (Notes.Changed)
            {
                var result = MessageBox.Show(this, "Do you want to save your unsaved changes?", MessageBoxButtons.YesNoCancel, MessageBoxType.Question);
                if (result != DialogResult.Yes)
                    return false;

                Notes.Save();
            }
            return true;
        }

        void GenerateActions()
        {
        }

        void GenerateContent()
        {
            var splitter = new Splitter();
            splitter.Panel1 = Notes.ListBox;
            splitter.Panel2 = Notes.TextArea;
            splitter.Position = 200;

            Content = splitter;
            splitter.Panel1.Focus();
        }

        void GenerateMenu()
        {
            var menu = new MenuBar
            {
                AboutItem = new Commands.About(),
                QuitItem = new Commands.Quit(),
            };

            var file = menu.Items.GetSubmenu("&File");
            file.Items.Add(new Commands.Save());
            file.Items.Add(new Commands.New());
            file.Items.Add(new Commands.Delete());
            file.Items.Add(new Commands.Rename());
            file.Items.Add(new SeparatorMenuItem());

            menu.ApplicationItems.Add(new Commands.Preferences(), 900);

            Notes.GenerateMenu(menu);

            Menu = menu;
        }

        void GenerateToolBar()
        {
            var toolbar = new ToolBar { Style = "ToolBar" };
            toolbar.Items.Add(new Commands.New());
            toolbar.Items.Add(new Commands.Delete());
            toolbar.Items.Add(new Commands.Rename());
            //toolbar.Items.AddFlexibleSpace();
            //toolbar.Items.Add(new Commands.Preferences());
            //toolbar.Items.Add(new Commands.About());
            
            ToolBar = toolbar;
        }
    }
}
