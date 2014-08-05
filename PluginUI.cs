using System.Windows.Forms;

namespace ADProjectSettingsManager.Controls
{
    public partial class PluginUI : Form
    {
        private PluginMain pluginMain;

        public PluginUI(PluginMain pluginMain)
        {
            // TODO: Complete member initialization
            this.pluginMain = pluginMain;
            InitializeComponent();
        }
    }
}