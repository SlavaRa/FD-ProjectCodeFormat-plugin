using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    }
}