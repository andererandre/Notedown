using System;
using System.Text;
using System.IO;
using System.Configuration;
using Eto.Forms;

namespace Notedown
{
    public static class Preferences
    {
        private static Configuration config;
        private static string defaultFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + "Notedown" + Path.DirectorySeparatorChar;
        
        public static void Load()
        {
            try
            {
                config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            }
            catch (Exception e)
            {
                MessageBox.Show(Application.Instance.MainForm, "Resource file not found!" + Environment.NewLine + e.ToString());
                Environment.Exit(1);
            }
        }
        
        public static void Save()
        {
            config.Save();
        }
        
        public static string Folder
        {
            get
            {
                string folder = config.AppSettings.Settings["folder"].Value;
                return String.IsNullOrEmpty(folder) ? defaultFolder : folder;
            }
            set
            {
                string folder = value;
                if (!folder.EndsWith(Path.DirectorySeparatorChar.ToString())) folder += Path.DirectorySeparatorChar;
                config.AppSettings.Settings["folder"].Value = folder;
            }
        }
    }
}