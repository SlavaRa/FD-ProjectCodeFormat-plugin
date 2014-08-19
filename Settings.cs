using PluginCore;
using PluginCore.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;
namespace ADProjectSettingsManager
{
    [Serializable]
    public class Settings
    {
        [Browsable(false)]
        public List<Item> Items { get; set; }
    }

    [Serializable]
    public class Item
    {
        public Item(string path)
        {
            Path = path;
            Settings = new ItemSettings();
        }

        [Browsable(false)]
        public string Path { get; private set; }

        [Browsable(false)]
        public ItemSettings Settings { get; private set; }
    }

    [Serializable]
    public class ItemSettings
    {
        public ItemSettings()
        {
            ISettings settings = PluginBase.Settings;
            CodingStyle = settings.CodingStyle;
            TabIndents = settings.TabIndents;
            IndentSize = settings.IndentSize;
            TabWidth = settings.TabWidth;
            UseTabs = settings.UseTabs;
            CustomProjectsDir = settings.CustomProjectsDir;
            CustomSnippetDir = settings.CustomSnippetDir;
            CustomTemplateDir = settings.CustomTemplateDir;
        }

        #region Indenting

        [DisplayName("Coding Style Type")]
        [DefaultValue(CodingStyle.BracesAfterLine)]
        [LocalizedCategory("FlashDevelop.Category.Indenting")]
        [LocalizedDescription("FlashDevelop.Description.CodingStyle")]
        public CodingStyle CodingStyle { get; set; }

        [DefaultValue(true)]
        [DisplayName("Use Tab Indents")]
        [LocalizedCategory("FlashDevelop.Category.Indenting")]
        [LocalizedDescription("FlashDevelop.Description.TabIndents")]
        public Boolean TabIndents { get; set; }

        [DefaultValue(4)]
        [DisplayName("Indenting Size")]
        [LocalizedCategory("FlashDevelop.Category.Indenting")]
        [LocalizedDescription("FlashDevelop.Description.IndentSize")]
        public int IndentSize { get; set; }

        [DefaultValue(4)]
        [DisplayName("Width Of Tab")]
        [LocalizedCategory("FlashDevelop.Category.Indenting")]
        [LocalizedDescription("FlashDevelop.Description.TabWidth")]
        public int TabWidth { get; set; }

        [DefaultValue(true)]
        [DisplayName("Use Tab Characters")]
        [LocalizedCategory("FlashDevelop.Category.Indenting")]
        [LocalizedDescription("FlashDevelop.Description.UseTabs")]
        public bool UseTabs { get; set; }

        #endregion

        #region Paths

        [DefaultValue("")]
        [DisplayName("Custom Snippet Directory")]
        [LocalizedCategory("FlashDevelop.Category.Paths")]
        [LocalizedDescription("FlashDevelop.Description.CustomSnippetDir")]
        [Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
        public string CustomSnippetDir { get; set; }

        [DefaultValue("")]
        [DisplayName("Custom Template Directory")]
        [LocalizedCategory("FlashDevelop.Category.Paths")]
        [LocalizedDescription("FlashDevelop.Description.CustomTemplateDir")]
        [Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
        public string CustomTemplateDir { get; set; }

        [DefaultValue("")]
        [DisplayName("Custom Projects Directory")]
        [LocalizedCategory("FlashDevelop.Category.Paths")]
        [LocalizedDescription("FlashDevelop.Description.CustomProjectsDir")]
        [Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
        public string CustomProjectsDir { get; set; }

        #endregion
    }
}