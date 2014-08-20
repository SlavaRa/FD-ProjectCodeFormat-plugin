using PluginCore;
using PluginCore.Helpers;
using PluginCore.Managers;
using PluginCore.Utilities;
using ProjectCodeFormat.Controls;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace ProjectCodeFormat
{
    public class PluginMain : IPlugin
    {
        private string name = "ProjectCodeFormat";
        private string guid = "463e5424-175d-4452-8583-94b1edd7ae76";
        private string desc = "";//TODO slavara: implement me
        private string help = "";
        private string auth = "SlavaRa";
        private string settingFilename;
        private Settings settings;

        #region Required Properties

        /// <summary>
        /// Api level of the plugin
        /// </summary>
        public int Api
        {
            get { return 1; }
        }

        /// <summary>
        /// Name of the plugin
        /// </summary> 
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        /// GUID of the plugin
        /// </summary>
        public string Guid
        {
            get { return guid; }
        }

        /// <summary>
        /// Author of the plugin
        /// </summary> 
        public string Author
        {
            get { return auth; }
        }

        /// <summary>
        /// Description of the plugin
        /// </summary> 
        public string Description
        {
            get { return desc; }
        }

        /// <summary>
        /// Web address for help
        /// </summary> 
        public string Help
        {
            get { return help; }
        }

        /// <summary>
        /// Internal access to settings
        /// </summary>
        [Browsable(false)]
        public object Settings
        {
            get { return settings; }
        }

        #endregion

        #region Required Methods

        public void Initialize()
        {
            InitBasics();
            LoadSettings();
            AddEventHandlers();
            CreateMenuItems();
        }

        public void Dispose()
        {
            settings.DefaultSettings.Settings.CopyTo(PluginBase.Settings);
            SaveSettings();
        }

        public void HandleEvent(object sender, NotifyEvent e, HandlingPriority prority)
        {
            switch (e.Type)
            {
                case EventType.Command:
                    DataEvent de = (DataEvent)e;
                    if (de.Action == "ProjectManager.Project")
                    {
                        settings.Get(PluginBase.CurrentProject.ProjectPath).Settings.CopyTo(PluginBase.Settings);
                    }
                    break;
            }
        }

        #endregion

        #region Custom Methods

        private void InitBasics()
        {
            string dataPath = Path.Combine(PathHelper.DataDir, Name);
            if (!Directory.Exists(dataPath)) Directory.CreateDirectory(dataPath);
            settingFilename = Path.Combine(dataPath, "Settings.fdb");
        }

        private void AddEventHandlers()
        {
            EventManager.AddEventHandler(this, EventType.Command);
        }

        private void LoadSettings()
        {
            settings = new Settings();
            if (!File.Exists(settingFilename)) SaveSettings();
            else settings = (Settings)ObjectSerializer.Deserialize(settingFilename, settings);
            if (settings.Items == null)
            {
                settings.Items = new List<Item>();
                SaveSettings();
            }
        }

        private void CreateMenuItems()
        {
            System.Drawing.Image icon = PluginBase.MainForm.FindImage("99");
            ToolStripMenuItem item = new ToolStripMenuItem("Project Code Format", icon, OpenPanel);
            ToolStripMenuItem menu = (ToolStripMenuItem)PluginBase.MainForm.FindMenuItem("ViewMenu");
            PluginBase.MainForm.RegisterShortcutItem("ViewMenu.ProjectCodeFormat", item);
            menu.DropDownItems.Add(item);
        }

        private void SaveSettings()
        {
            ObjectSerializer.Serialize(settingFilename, settings);
        }

        #endregion

        #region Event Handlers

        private void OpenPanel(object sender, System.EventArgs e)
        {
            new PluginUI(this).Show();
        }

        #endregion
    }
}