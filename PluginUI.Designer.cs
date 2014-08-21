namespace ProjectCodeFormat.Controls
{
    partial class PluginUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.container = new System.Windows.Forms.SplitContainer();
            this.add = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.projects = new System.Windows.Forms.TreeView();
            this.reset = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.properties = new System.Windows.Forms.PropertyGrid();
            this.container.Panel1.SuspendLayout();
            this.container.Panel2.SuspendLayout();
            this.container.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.container.Location = new System.Drawing.Point(0, 0);
            this.container.Margin = new System.Windows.Forms.Padding(4);
            this.container.Name = "container";
            // 
            // container.Panel1
            // 
            this.container.Panel1.Controls.Add(this.add);
            this.container.Panel1.Controls.Add(this.remove);
            this.container.Panel1.Controls.Add(this.projects);
            this.container.Panel1MinSize = 190;
            // 
            // container.Panel2
            // 
            this.container.Panel2.Controls.Add(this.reset);
            this.container.Panel2.Controls.Add(this.close);
            this.container.Panel2.Controls.Add(this.properties);
            this.container.Panel2MinSize = 140;
            this.container.Size = new System.Drawing.Size(624, 429);
            this.container.SplitterDistance = 190;
            this.container.SplitterWidth = 2;
            this.container.TabIndex = 6;
            this.container.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.OnSplitterMoved);
            // 
            // add
            // 
            this.add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.add.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.add.Location = new System.Drawing.Point(6, 399);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 23);
            this.add.TabIndex = 6;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.OnAddClick);
            // 
            // remove
            // 
            this.remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.remove.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.remove.Location = new System.Drawing.Point(87, 399);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(97, 23);
            this.remove.TabIndex = 5;
            this.remove.Text = "Remove";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.OnRemoveClick);
            // 
            // projects
            // 
            this.projects.Location = new System.Drawing.Point(6, 6);
            this.projects.Name = "projects";
            this.projects.Size = new System.Drawing.Size(178, 387);
            this.projects.TabIndex = 4;
            this.projects.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnProjectsAfterSelected);
            this.projects.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnProjectsKeyDown);
            // 
            // reset
            // 
            this.reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.reset.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.reset.Location = new System.Drawing.Point(269, 399);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(75, 23);
            this.reset.TabIndex = 8;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.OnResetClick);
            // 
            // close
            // 
            this.close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.close.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.close.Location = new System.Drawing.Point(350, 399);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 7;
            this.close.Text = "close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.OnCloseClick);
            // 
            // properties
            // 
            this.properties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.properties.Location = new System.Drawing.Point(8, 6);
            this.properties.Name = "properties";
            this.properties.Size = new System.Drawing.Size(418, 388);
            this.properties.TabIndex = 6;
            this.properties.ToolbarVisible = false;
            // 
            // PluginUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(624, 429);
            this.Controls.Add(this.container);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(640, 468);
            this.Name = "PluginUI";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ADProject\'s settings manager";
            this.container.Panel1.ResumeLayout(false);
            this.container.Panel2.ResumeLayout(false);
            this.container.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer container;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.TreeView projects;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.PropertyGrid properties;

    }
}