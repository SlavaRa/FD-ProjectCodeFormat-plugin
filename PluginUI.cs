using PluginCore;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ADProjectSettingsManager.Controls
{
    public partial class PluginUI : Form
    {
        private readonly List<string> projectExtensions;
        private readonly string extensionsFilter;
        private readonly PluginMain pluginMain;

        #region Constructors

        public PluginUI(PluginMain pluginMain)
        {
            this.pluginMain = pluginMain;
            projectExtensions = new List<string>() { ".as3proj", ".hxproj" };
            for (int i = 0; i < projectExtensions.Count; i++)
            {
                string ext = projectExtensions[i];
                if (i == 0) extensionsFilter = "(*" + ext + ")|*" + ext;
                else extensionsFilter += "|(*" + ext + ")|*" + ext;
            }
            InitializeComponent();
            RefreshProjectsTree();
            RefreshButtons();
        }

        #endregion

        #region Custom Methods

        private void RefreshProjectsTree()
        {
            projects.Nodes.Clear();
            foreach (Item item in ((Settings)pluginMain.Settings).Items)
            {
                string path = item.Path;
                projects.Nodes.Add(path, Path.GetFileNameWithoutExtension(path));
                properties.SelectedObject = item.Settings;
            }
            if (projects.Nodes.Count > 0 && projects.SelectedNode == null) projects.SelectedNode = projects.Nodes[0];
        }

        private void RefreshButtons()
        {
            bool enabled = projects.Nodes.Count > 0 && projects.SelectedNode != null;
            reset.Enabled = enabled;
            remove.Enabled = enabled;
        }

        private bool IsValidFile(string path)
        {
            return projectExtensions.Contains(Path.GetExtension(path));
        }

        #endregion

        #region Event Handlers

        private void OnAddClick(object sender, System.EventArgs e)
        {
            string path = PluginBase.CurrentProject.ProjectPath;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = extensionsFilter;
            dialog.InitialDirectory = Path.GetDirectoryName(path);
            dialog.FileName = Path.GetFileName(path);
            dialog.FileOk += OnOpenFileDialogOk;
            dialog.ShowDialog(this);
        }

        private void OnOpenFileDialogOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Settings settings = (Settings)pluginMain.Settings;
            string path = ((OpenFileDialog)sender).FileName;
            if (!IsValidFile(path)) return;
            foreach (Item item in settings.Items)
                if (item.Path == path) return;
            Item newItem = new Item(path);
            settings.Items.Add(newItem);
            projects.SelectedNode = projects.Nodes.Add(path, Path.GetFileNameWithoutExtension(path));
            properties.SelectedObject = newItem.Settings;
            RefreshButtons();
        }

        private void OnRemoveClick(object sender, System.EventArgs e)
        {
            Settings settings = (Settings)pluginMain.Settings;
            TreeNode node = projects.SelectedNode;
            string path = node.Name;
            foreach (Item item in settings.Items)
                if (item.Path == path)
                {
                    settings.Items.Remove(item);
                    break;
                }
            projects.Nodes.Remove(node);
            properties.SelectedObject = null;
            RefreshButtons();
        }

        private void OnProjectsAfterSelected(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            RefreshButtons();
            string path = projects.SelectedNode.Name;
            foreach (Item item in ((Settings)pluginMain.Settings).Items)
                if (item.Path == path)
                {
                    properties.SelectedObject = item.Settings;
                    break;
                }
        }

        #endregion
    }
}