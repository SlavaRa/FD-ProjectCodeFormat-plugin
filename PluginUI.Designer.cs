namespace ADProjectSettingsManager.Controls
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
            this.projects = new System.Windows.Forms.TreeView();
            this.properties = new System.Windows.Forms.PropertyGrid();
            this.remove = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // projects
            // 
            this.projects.Location = new System.Drawing.Point(13, 13);
            this.projects.Name = "projects";
            this.projects.Size = new System.Drawing.Size(178, 387);
            this.projects.TabIndex = 0;
            this.projects.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnProjectsAfterSelected);
            // 
            // properties
            // 
            this.properties.Location = new System.Drawing.Point(197, 13);
            this.properties.Name = "properties";
            this.properties.Size = new System.Drawing.Size(415, 387);
            this.properties.TabIndex = 1;
            this.properties.ToolbarVisible = false;
            // 
            // remove
            // 
            this.remove.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.remove.Location = new System.Drawing.Point(94, 406);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(97, 23);
            this.remove.TabIndex = 2;
            this.remove.Text = "Remove";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.OnRemoveClick);
            // 
            // add
            // 
            this.add.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.add.Location = new System.Drawing.Point(13, 406);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 23);
            this.add.TabIndex = 3;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.OnAddClick);
            // 
            // close
            // 
            this.close.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.close.Location = new System.Drawing.Point(537, 406);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 4;
            this.close.Text = "close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.Close_Click);
            // 
            // reset
            // 
            this.reset.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.reset.Location = new System.Drawing.Point(456, 406);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(75, 23);
            this.reset.TabIndex = 5;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            // 
            // PluginUI
            // 
            this.AcceptButton = this.close;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.close);
            this.Controls.Add(this.add);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.properties);
            this.Controls.Add(this.projects);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PluginUI";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ADProject\'s settings manager";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView projects;
        private System.Windows.Forms.PropertyGrid properties;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button reset;
    }
}