using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace ADProjectSettingsManager
{
    [Serializable]
    public class Settings
    {
        [Browsable(false)]
        public List<string> Projects { get; set; }
    }
}