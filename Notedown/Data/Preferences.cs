using System;
using System.Text;
using System.IO;
using System.Configuration;
using Eto.Forms;

namespace Notedown
{
    public static class Preferences
    {
        private static Configuration ConfigFile;
        
        public static void Load()
        {
            try
            {
                ConfigFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            }
            catch (Exception e)
            {
                MessageBox.Show(Application.Instance.MainForm, "Resource file not found!" + Environment.NewLine + e.ToString());
                Environment.Exit(1);
            }
        }
        
        public static void Save()
        {
            ConfigFile.Save();
        }
        
        private static string DefaultFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + "Notedown" + Path.DirectorySeparatorChar;
        public static string Folder
        {
            get
            {
                string folder = ConfigFile.AppSettings.Settings["folder"].Value;
                return String.IsNullOrEmpty(folder) ? DefaultFolder : folder;
            }
            set
            {
                string folder = value;
                if (!folder.EndsWith(Path.DirectorySeparatorChar.ToString())) folder += Path.DirectorySeparatorChar;
                ConfigFile.AppSettings.Settings["folder"].Value = folder;
            }
        }
    }
}