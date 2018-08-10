namespace MapleCLBUpdate
{
    partial class MainForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Account1 = new System.Windows.Forms.TabPage();
            this.clientForm1 = new MapleCLBUpdate.Forms.ClientForm();
            this.AddTab = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.Account1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Account1);
            this.tabControl1.Controls.Add(this.AddTab);
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(567, 257);
            this.tabControl1.TabIndex = 0;
            // 
            // Account1
            // 
            this.Account1.Controls.Add(this.clientForm1);
            this.Account1.Location = new System.Drawing.Point(4, 22);
            this.Account1.Name = "Account1";
            this.Account1.Padding = new System.Windows.Forms.Padding(3);
            this.Account1.Size = new System.Drawing.Size(559, 231);
            this.Account1.TabIndex = 0;
            this.Account1.Text = "Default";
            this.Account1.UseVisualStyleBackColor = true;
            // 
            // clientForm1
            // 
            this.clientForm1.Location = new System.Drawing.Point(0, 3);
            this.clientForm1.Name = "clientForm1";
            this.clientForm1.Size = new System.Drawing.Size(566, 222);
            this.clientForm1.TabIndex = 1;
            // 
            // AddTab
            // 
            this.AddTab.Location = new System.Drawing.Point(4, 22);
            this.AddTab.Name = "AddTab";
            this.AddTab.Padding = new System.Windows.Forms.Padding(3);
            this.AddTab.Size = new System.Drawing.Size(563, 231);
            this.AddTab.TabIndex = 1;
            this.AddTab.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(563, 250);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MapleStoryCLB Version 195";
            this.tabControl1.ResumeLayout(false);
            this.Account1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Account1;
        private Forms.ClientForm clientForm1;
        private System.Windows.Forms.TabPage AddTab;
    }
}

