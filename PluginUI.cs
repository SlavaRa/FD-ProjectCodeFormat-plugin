using PluginCore;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ProjectCodeFormat.Controls
{
    public partial class PluginUI : Form
    {
        private readonly List<string> projectExtensions = new List<string>() { ".as3proj", ".hxproj" };
        private readonly Dictionary<string, string> projExtToName = new Dictionary<string, string>();
        private readonly string extensionsFilter;
        private readonly PluginMain pluginMain;

        #region Constructors

        public PluginUI(PluginMain pluginMain)
        {
            this.pluginMain = pluginMain;
            projExtToName.Add(".as3proj", "ActionScript 3");
            projExtToName.Add(".hxproj", "Haxe");
            for (int i = 0; i < projectExtensions.Count; i++)
            {
                string ext = projectExtensions[i];
                if (i == 0) extensionsFilter = "(*" + ext + ")|*" + ext;
                else extensionsFilter += "|(*" + ext + ")|*" + ext;
            }
            InitializeComponent();
            InitializeProjectsTree();
            RefreshButtons();
        }

        #endregion

        #region Custom Methods

        private void InitializeProjectsTree()
        {
            projects.Nodes.Clear();
            Settings settings = (Settings)pluginMain.Settings;
            Item defaultItem = settings.DefaultItem;
            projects.Nodes.Add(defaultItem.Path, defaultItem.GetName()).Tag = "default";
            foreach (string ext in projExtToName.Keys) projects.Nodes.Add(ext, projExtToName[ext]).Tag = "node";
            foreach (Item item in settings.Items) projects.Nodes[item.GetExtension()].Nodes.Add(item.Path, item.GetName());
            projects.ExpandAll();
            Item curProjItem = settings.Get(PluginBase.CurrentProject.ProjectPath);
            TreeNode node = projects.Nodes[curProjItem.GetExtension()];
            if (node != null) node = node.Nodes[curProjItem.Path];
            projects.SelectedNode = node ?? projects.Nodes[0];
            properties.SelectedObject = curProjItem.Settings;
        }

        private void RefreshButtons()
        {
            bool enabled = projects.SelectedNode != null
                && projects.SelectedNode.Tag as string != "default"
                && projects.SelectedNode.Tag as string != "node";
            reset.Enabled = enabled;
            remove.Enabled = enabled;
        }

        private void Remove(TreeNode node)
        {
            string tag = (string)node.Tag;
            if (tag == "default" || tag == "node") return;
            Settings settings = (Settings)pluginMain.Settings;
            settings.Remove(node.Name);
            node.Parent.Expand();
            node.Parent.Nodes.Remove(node);
            projects.SelectedNode = projects.Nodes[0];
            properties.SelectedObject = settings.DefaultItem.Settings;
            RefreshButtons();
        }

        #endregion

        #region Event Handlers

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            switch((Keys)e.KeyChar)
            {
                case Keys.Escape:
                    Hide();
                    return;
            }
            base.OnKeyPress(e);
        }

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
            if (!projectExtensions.Contains(Path.GetExtension(path)) || settings.Has(path)) return;
            Item item = settings.Add(path);
            TreeNode node = projects.Nodes[item.GetExtension()];
            node.Expand();
            projects.SelectedNode = node.Nodes.Add(item.Path, item.GetName());
            properties.SelectedObject = item.Settings;
            RefreshButtons();
        }

        private void OnRemoveClick(object sender, System.EventArgs e)
        {
            Remove(projects.SelectedNode);
        }

        private void OnProjectsAfterSelected(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            RefreshButtons();
            TreeNode node = projects.SelectedNode;
            string tag = (string)node.Tag;
            if (tag == "node") properties.SelectedObject = null;
            else properties.SelectedObject = ((Settings)pluginMain.Settings).Get(node.Name).Settings;
            properties.Enabled = tag != "node";
        }

        private void OnProjectsKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    Remove(projects.SelectedNode);
                    break;
            }
        }

        private void OnResetClick(object sender, System.EventArgs e)
        {
            TreeNode node = projects.SelectedNode;
            string tag = (string)node.Tag;
            if (tag == "node" || tag == "default") return;
            Settings settings = (Settings)pluginMain.Settings;
            ItemSettings itemSettings = settings.Get(node.Name).Settings;
            itemSettings.CopyFrom(settings.DefaultItem.Settings);
            properties.SelectedObject = itemSettings;
        }

        private void OnCloseClick(object sender, System.EventArgs e)
        {
            Hide();
        }

        private void OnSplitterMoved(object sender, System.Windows.Forms.SplitterEventArgs e)
        {
            projects.Width = container.Panel1.Width - container.Margin.Horizontal;
        }

        #endregion

    }
}