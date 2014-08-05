using System.Collections.Generic;
using System.Windows.Forms;

namespace ADProjectSettingsManager.Controls
{
    public partial class PluginUI : Form
    {
        private PluginMain pluginMain;

        public PluginUI(PluginMain pluginMain)
        {
            this.pluginMain = pluginMain;
            InitializeComponent();
            RefreshProjectsTree();
            RefreshButtons();
        }

        private void RefreshProjectsTree()
        {
            Settings settings = (Settings)pluginMain.Settings;
            foreach (string project in settings.Projects) projects.Nodes.Add(project);
            if (projects.Nodes.Count > 0) projects.SelectedNode = projects.Nodes[0];
        }

        private void RefreshButtons()
        {
            bool selNodeNotNull = projects.SelectedNode != null;
            reset.Enabled = selNodeNotNull;
            remove.Enabled = selNodeNotNull;
        }
    }
}