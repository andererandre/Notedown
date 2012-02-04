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
            this.Text = "Notedown";
            this.Icon = new Icon(null, "Notedown.Icon.ico");
            this.Size = new Size(1280, 800);
            
            this.Load += HandleLoad;
            this.Closing += HandleClosing;
        }
        
        private void HandleLoad(object sender, EventArgs e)
        {
            Preferences.Load();
            Notes = NoteView.CreateFromDirectory(Preferences.Folder);
            
            GenerateActions();
            GenerateContent();
        }
        
        private void HandleClosing(object sender, CancelEventArgs e)
        {
            if (Notes.Changed)
            {
                switch (MessageBox.Show(this, "Do you want to save your unsaved changes?", MessageBoxButtons.YesNoCancel, MessageBoxType.Question))
                {
                    case DialogResult.Yes:
                        Notes.Save();
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }
        
        private void GenerateActions()
        {
            // generate action args
            GenerateActionArgs args = new GenerateActionArgs();
            Application.Instance.GetSystemActions(args);
            args.Actions.Add(new Actions.About());
            args.Actions.Add(new Actions.Quit());
            args.Actions.Add(new Actions.Close());
            args.Actions.Add(new Actions.New());
            args.Actions.Add(new Actions.Save());
            args.Actions.Add(new Actions.Delete());
            args.Actions.Add(new Actions.Preferences());
            args.Actions.Add(new Actions.Rename());
            
            // generate menu and toolbar
            GenerateMenu(args);
            GenerateToolBar(args);
        }
        
        private void GenerateContent()
        {
            var splitter = new Splitter();
            splitter.Panel1 = Notes.ListBox;
            splitter.Panel2 = Notes.TextArea;
            splitter.Position = 200;
            
            this.AddDockedControl(splitter);
            this.Shown += delegate
            {
                splitter.Panel1.Focus();
            };
        }
        
        private void GenerateMenu(GenerateActionArgs args)
        {
            var main = args.Menu.FindAddSubMenu("Notedown", 0);
            var file = args.Menu.FindAddSubMenu("&File", 0);
            var edit = args.Menu.FindAddSubMenu("&Edit", 0);
            var window = args.Menu.FindAddSubMenu("&Window", 1000);
            var help = args.Menu.FindAddSubMenu("Help", 1000);
            
            if (Generator.ID == "mac")
            {
                main.Actions.Add(Actions.About.ActionID);
                main.Actions.AddSeparator();
                main.Actions.Add(Actions.Preferences.ActionID);
                main.Actions.AddSeparator();
                main.Actions.Add("mac_hide");
                main.Actions.Add("mac_hideothers");
                main.Actions.Add("mac_showall");
                main.Actions.AddSeparator();
                main.Actions.Add(Actions.Quit.ActionID);
                
                edit.Actions.Add("mac_undo");
                edit.Actions.Add("mac_redo");
                edit.Actions.AddSeparator();
                edit.Actions.Add("mac_cut");
                edit.Actions.Add("mac_copy");
                edit.Actions.Add("mac_paste");
                edit.Actions.Add("mac_delete");
                edit.Actions.AddSeparator();
                edit.Actions.Add("mac_selectAll");
                
                file.Actions.Add(Actions.Save.ActionID);
                file.Actions.Add(Actions.New.ActionID);
                file.Actions.Add(Actions.Delete.ActionID);
                file.Actions.Add(Actions.Rename.ActionID);
                
                window.Actions.Add("mac_performMiniaturize");
                window.Actions.Add("mac_performZoom");
            }
            else
            {
                file.Actions.Add(Actions.Preferences.ActionID);
                file.Actions.AddSeparator();
                file.Actions.Add(Actions.Save.ActionID);
                file.Actions.Add(Actions.New.ActionID);
                file.Actions.Add(Actions.Delete.ActionID);
                file.Actions.Add(Actions.Rename.ActionID);
                file.Actions.AddSeparator();
                file.Actions.Add(Actions.Quit.ActionID);
                
                help.Actions.Add(Actions.About.ActionID);
            }
            
            this.Menu = args.Menu.GenerateMenuBar();
        }
        
        private void GenerateToolBar(GenerateActionArgs args)
        {
            args.ToolBar.Add(Actions.New.ActionID);
            args.ToolBar.Add(Actions.Delete.ActionID);
            args.ToolBar.Add(Actions.Rename.ActionID);
            //args.ToolBar.AddFlexibleSpace();
            //args.ToolBar.Add(Actions.Preferences.ActionID);
            //args.ToolBar.Add(Actions.About.ActionID);
            
            this.ToolBar = args.ToolBar.GenerateToolBar();
            this.ToolBar.Style = "ToolBar";
        }
    }
}
