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
            Settings settings = (Settings)pluginMain.Settings;
            Item defaultItem = settings.DefaultSettings;
            projects.SelectedNode = projects.Nodes.Add(defaultItem.Path, defaultItem.GetName());
            projects.Nodes.Add(".as3proj", "ActionScript 3").Tag = string.Empty;
            projects.Nodes.Add(".hxproj", "Haxe").Tag = string.Empty;
            foreach (Item item in settings.Items)
            {
                PluginCore.Managers.TraceManager.Add(item.GetExt());
                projects.Nodes[item.GetExt()].Nodes.Add(item.Path, item.GetName());
            }
            projects.ExpandAll();
            properties.SelectedObject = defaultItem.Settings;
        }

        private void RefreshButtons()
        {
            bool enabled = projects.Nodes.Count > 0 
                && projects.SelectedNode != null
                && projects.SelectedNode.Index > 0
                && projects.SelectedNode.Tag != string.Empty;
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
            if (!IsValidFile(path) || settings.Has(path)) return;
            Item item = settings.Add(path);
            TreeNode node = projects.Nodes[item.GetExt()];
            node.Expand();
            projects.SelectedNode = node.Nodes.Add(item.Path, item.GetName());
            properties.SelectedObject = item.Settings;
            RefreshButtons();
        }

        private void OnRemoveClick(object sender, System.EventArgs e)
        {
            TreeNode node = projects.SelectedNode;
            Settings settings = (Settings)pluginMain.Settings;
            settings.Remove(node.Name);
            node.Parent.Expand();
            node.Parent.Nodes.Remove(node);
            projects.SelectedNode = projects.Nodes[0];
            properties.SelectedObject = settings.DefaultSettings.Settings;
            RefreshButtons();
        }

        private void OnProjectsAfterSelected(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            RefreshButtons();
            if (e.Node.Tag == string.Empty) properties.SelectedObject = null;
            else
            {
                Item item = ((Settings)pluginMain.Settings).Get(projects.SelectedNode.Name);
                properties.SelectedObject = item.Settings;
            }
        }

        #endregion
    }
}