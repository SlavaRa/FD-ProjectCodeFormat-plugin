using PluginCore;
using System.Collections.Generic;
using System.IO;
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
            if (projects.Nodes.Count > 0 && projects.SelectedNode == null) projects.SelectedNode = projects.Nodes[0];
        }

        private void RefreshButtons()
        {
            bool selNodeNotNull = projects.SelectedNode != null;
            reset.Enabled = selNodeNotNull;
            remove.Enabled = selNodeNotNull;
        }

        private string GetProjectExtension()
        {
            return "." + PluginBase.CurrentProject.Language + "proj";
        }

        private bool IsValidFile(string path)
        {
            return Path.GetExtension(path) == GetProjectExtension();
        }

        private void OnAddClick(object sender, System.EventArgs e)
        {
            string projExt = GetProjectExtension();
            string projectPath = PluginBase.CurrentProject.ProjectPath;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "(*." + projExt + ")|*." + projExt;
            dialog.InitialDirectory = Path.GetDirectoryName(projectPath);
            dialog.FileName = Path.GetFileName(projectPath);
            dialog.FileOk += OnOpenFIleDialogOk;
            dialog.ShowDialog(this);
        }

        private void OnOpenFIleDialogOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string projectPath = ((OpenFileDialog)sender).FileName;
            if (!IsValidFile(projectPath)) return;
            ((Settings)pluginMain.Settings).Projects.Add(projectPath);
            RefreshProjectsTree();
            RefreshButtons();
        }
    }
}