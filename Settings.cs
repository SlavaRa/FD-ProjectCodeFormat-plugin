﻿using PluginCore;
using PluginCore.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace ProjectCodeFormat
{
    [Serializable]
    public class Settings
    {
        public Settings()
        {
            DefaultItem = new Item("default");
        }

        [Browsable(false)]
        public Item DefaultItem { get; set; }

        [Browsable(false)]
        public List<Item> Items { get; set; }

        internal bool Has(string path)
        {
            foreach (Item item in Items)
                if (item.Path == path)
                    return true;
            return false;
        }

        internal Item Add(string path)
        {
            Item item = new Item(path);
            Items.Add(item);
            return item;
        }

        internal Item Get(string path)
        {
            foreach (Item item in Items)
                if (item.Path == path)
                    return item;
            return DefaultItem;
        }

        internal bool Remove(string path)
        {
            foreach (Item item in Items)
                if (item.Path == path)
                    return Items.Remove(item);
            return false;
        }
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

        internal string GetName()
        {
            return System.IO.Path.GetFileNameWithoutExtension(Path);
        }

        internal string GetExtension()
        {
            return System.IO.Path.GetExtension(Path);
        }
    }

    [Serializable]
    public class ItemSettings
    {
        public ItemSettings()
        {
            CopyFrom(PluginBase.Settings);
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

        internal void CopyFrom(ISettings settings)
        {
            CodingStyle = settings.CodingStyle;
            TabIndents = settings.TabIndents;
            IndentSize = settings.IndentSize;
            TabWidth = settings.TabWidth;
            UseTabs = settings.UseTabs;
            CustomProjectsDir = settings.CustomProjectsDir;
            CustomSnippetDir = settings.CustomSnippetDir;
            CustomTemplateDir = settings.CustomTemplateDir;
        }

        internal void CopyFrom(ItemSettings settings)
        {
            CodingStyle = settings.CodingStyle;
            TabIndents = settings.TabIndents;
            IndentSize = settings.IndentSize;
            TabWidth = settings.TabWidth;
            UseTabs = settings.UseTabs;
            CustomProjectsDir = settings.CustomProjectsDir;
            CustomSnippetDir = settings.CustomSnippetDir;
            CustomTemplateDir = settings.CustomTemplateDir;
        }

        internal void CopyTo(ISettings settings)
        {
            settings.CodingStyle = CodingStyle;
            settings.TabIndents = TabIndents;
            settings.IndentSize = IndentSize;
            settings.TabWidth = TabWidth;
            settings.UseTabs = UseTabs;
            settings.CustomProjectsDir = CustomProjectsDir;
            settings.CustomSnippetDir = CustomSnippetDir;
            settings.CustomTemplateDir = CustomTemplateDir;
        }
    }
}