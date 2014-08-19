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
            projects.Nodes.Clear();
            foreach (string project in ((Settings)pluginMain.Settings).Projects) projects.Nodes.Add(project);
            if (projects.Nodes.Count > 0 && projects.SelectedNode == null) projects.SelectedNode = projects.Nodes[0];
        }

        private void RefreshButtons()
        {
            bool enabled = projects.Nodes.Count > 0 && projects.SelectedNode != null;
            reset.Enabled = enabled;
            remove.Enabled = enabled;
        }

        private string GetProjectExtension()
        {
            return "." + PluginBase.CurrentProject.Language + "proj";
        }

        private bool IsValidFile(string path)
        {
            return Path.GetExtension(path) == GetProjectExtension();
        }

        #region Event Handlers

        private void OnAddClick(object sender, System.EventArgs e)
        {
            string projExt = GetProjectExtension();
            string projectPath = PluginBase.CurrentProject.ProjectPath;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "(*" + projExt + ")|*" + projExt;
            dialog.InitialDirectory = Path.GetDirectoryName(projectPath);
            dialog.FileName = Path.GetFileName(projectPath);
            dialog.FileOk += OnOpenFileDialogOk;
            dialog.ShowDialog(this);
        }

        private void OnOpenFileDialogOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Settings settings = (Settings)pluginMain.Settings;
            string projectPath = ((OpenFileDialog)sender).FileName;
            if (!IsValidFile(projectPath) || settings.Projects.Contains(projectPath)) return;
            (settings).Projects.Add(projectPath);
            projects.SelectedNode = projects.Nodes.Add(projectPath);
            RefreshButtons();
        }

        private void OnRemoveClick(object sender, System.EventArgs e)
        {
            ((Settings)pluginMain.Settings).Projects.Remove(projects.SelectedNode.Text);
            projects.Nodes.Remove(projects.SelectedNode);
            RefreshButtons();
        }

        private void OnProjectsAfterSelected(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            RefreshButtons();
        }

        #endregion
    }
}