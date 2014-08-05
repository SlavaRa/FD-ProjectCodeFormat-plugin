using ADProjectSettingsManager.Controls;
using PluginCore;
using PluginCore.Helpers;
using PluginCore.Utilities;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace ADProjectSettingsManager
{
    public class PluginMain : IPlugin
    {
        private string name = "ADProjectSettingsManager";
        private string guid = "463e5424-175d-4452-8583-94b1edd7ae76";
        private string desc = "";//TODO slavara: implement me
        private string help = "www.flashdevelop.org/community/";
        private string auth = "FlashDevelop Team";
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
            SaveSettings();
        }

        public void HandleEvent(object sender, NotifyEvent e, HandlingPriority prority)
        {
        }

        #endregion

        #region Custom Methods

        private void InitBasics()
        {
            string dataPath = Path.Combine(PathHelper.DataDir, "ADProjectSettingsManager");
            if (!Directory.Exists(dataPath)) Directory.CreateDirectory(dataPath);
            settingFilename = Path.Combine(dataPath, "Settings.fdb");
        }

        private void AddEventHandlers()
        {
        }

        private void LoadSettings()
        {
            settings = new Settings();
            if (!File.Exists(settingFilename)) SaveSettings();
            else settings = (Settings)ObjectSerializer.Deserialize(settingFilename, settings); ;
        }

        private void CreateMenuItems()
        {
            System.Drawing.Image icon = PluginBase.MainForm.FindImage("99");
            ToolStripMenuItem item = new ToolStripMenuItem("ADProject's settings manager", icon, OpenPanel);
            ToolStripMenuItem menu = (ToolStripMenuItem)PluginBase.MainForm.FindMenuItem("ViewMenu");
            PluginBase.MainForm.RegisterShortcutItem("ViewMenu.ADProjectSettingsManager", item);
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