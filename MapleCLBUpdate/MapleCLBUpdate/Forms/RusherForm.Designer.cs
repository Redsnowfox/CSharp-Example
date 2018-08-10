namespace MapleCLBUpdate.Forms
{
    partial class RusherForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RusherForm));
            this.rusherTab = new System.Windows.Forms.TabControl();
            this.rusherPage = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MapStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusSep2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.RushList = new System.Windows.Forms.ToolStripDropDownButton();
            this.RushTree = new System.Windows.Forms.TreeView();
            this.levelSelectPage = new System.Windows.Forms.TabPage();
            this.rusherTab.SuspendLayout();
            this.rusherPage.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rusherTab
            // 
            this.rusherTab.Controls.Add(this.rusherPage);
            this.rusherTab.Controls.Add(this.levelSelectPage);
            this.rusherTab.Location = new System.Drawing.Point(3, 3);
            this.rusherTab.Name = "rusherTab";
            this.rusherTab.SelectedIndex = 0;
            this.rusherTab.Size = new System.Drawing.Size(581, 325);
            this.rusherTab.TabIndex = 0;
            // 
            // rusherPage
            // 
            this.rusherPage.Controls.Add(this.statusStrip1);
            this.rusherPage.Controls.Add(this.RushTree);
            this.rusherPage.Location = new System.Drawing.Point(4, 22);
            this.rusherPage.Name = "rusherPage";
            this.rusherPage.Padding = new System.Windows.Forms.Padding(3);
            this.rusherPage.Size = new System.Drawing.Size(573, 299);
            this.rusherPage.TabIndex = 0;
            this.rusherPage.Text = "Rusher";
            this.rusherPage.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.MapStatus,
            this.StatusSep2,
            this.RushList});
            this.statusStrip1.Location = new System.Drawing.Point(3, 274);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(567, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel.Text = "Status:";
            // 
            // MapStatus
            // 
            this.MapStatus.Name = "MapStatus";
            this.MapStatus.Size = new System.Drawing.Size(32, 17);
            this.MapStatus.Text = "Ideal";
            // 
            // StatusSep2
            // 
            this.StatusSep2.Name = "StatusSep2";
            this.StatusSep2.Size = new System.Drawing.Size(363, 17);
            this.StatusSep2.Spring = true;
            // 
            // RushList
            // 
            this.RushList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RushList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RushList.Image = ((System.Drawing.Image)(resources.GetObject("RushList.Image")));
            this.RushList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RushList.Name = "RushList";
            this.RushList.Size = new System.Drawing.Size(115, 20);
            this.RushList.Text = "Continenent Rush";
            // 
            // RushTree
            // 
            this.RushTree.Location = new System.Drawing.Point(0, 0);
            this.RushTree.Name = "RushTree";
            this.RushTree.Size = new System.Drawing.Size(573, 276);
            this.RushTree.TabIndex = 0;
            this.RushTree.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.RushTree_MouseDoubleClick);
            // 
            // levelSelectPage
            // 
            this.levelSelectPage.Location = new System.Drawing.Point(4, 22);
            this.levelSelectPage.Name = "levelSelectPage";
            this.levelSelectPage.Padding = new System.Windows.Forms.Padding(3);
            this.levelSelectPage.Size = new System.Drawing.Size(573, 299);
            this.levelSelectPage.TabIndex = 1;
            this.levelSelectPage.Text = "Level Select";
            this.levelSelectPage.UseVisualStyleBackColor = true;
            // 
            // RusherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 321);
            this.Controls.Add(this.rusherTab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RusherForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rusher";
            this.TopMost = true;
            this.rusherTab.ResumeLayout(false);
            this.rusherPage.ResumeLayout(false);
            this.rusherPage.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl rusherTab;
        private System.Windows.Forms.TabPage rusherPage;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel MapStatus;
        private System.Windows.Forms.ToolStripStatusLabel StatusSep2;
        private System.Windows.Forms.ToolStripDropDownButton RushList;
        private System.Windows.Forms.TreeView RushTree;
        private System.Windows.Forms.TabPage levelSelectPage;
    }
}