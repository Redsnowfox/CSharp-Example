namespace MapleCLBUpdate.Forms
{
    partial class ClientForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.accountTabPage = new System.Windows.Forms.TabPage();
            this.skillGroup = new System.Windows.Forms.GroupBox();
            this.lockSkillBtn = new System.Windows.Forms.Button();
            this.levelSkill = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.skillManualSelect = new System.Windows.Forms.TextBox();
            this.skillSelect = new System.Windows.Forms.ListBox();
            this.FeaturesGroup = new System.Windows.Forms.GroupBox();
            this.MiscBtn = new System.Windows.Forms.Button();
            this.packetBtn = new System.Windows.Forms.Button();
            this.inventoryBtn = new System.Windows.Forms.Button();
            this.rusherBtn = new System.Windows.Forms.Button();
            this.statsGroup = new System.Windows.Forms.GroupBox();
            this.actionStat = new System.Windows.Forms.Label();
            this.actionLabel = new System.Windows.Forms.Label();
            this.timeStat = new System.Windows.Forms.Label();
            this.monsterStat = new System.Windows.Forms.Label();
            this.peopleStat = new System.Windows.Forms.Label();
            this.expStat = new System.Windows.Forms.Label();
            this.mesoStat = new System.Windows.Forms.Label();
            this.mapStat = new System.Windows.Forms.Label();
            this.channelStat = new System.Windows.Forms.Label();
            this.levelStat = new System.Windows.Forms.Label();
            this.nameStat = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AccountGroup = new System.Windows.Forms.GroupBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.modeSelect = new System.Windows.Forms.ComboBox();
            this.slotBox = new System.Windows.Forms.TextBox();
            this.channelSelect = new System.Windows.Forms.ComboBox();
            this.picBox = new System.Windows.Forms.TextBox();
            this.worldSelect = new System.Windows.Forms.ComboBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.userNameBox = new System.Windows.Forms.TextBox();
            this.logTabPage = new System.Windows.Forms.TabPage();
            this.log = new System.Windows.Forms.TextBox();
            this.upTimer = new System.Windows.Forms.Timer(this.components);
            this.tabControl.SuspendLayout();
            this.accountTabPage.SuspendLayout();
            this.skillGroup.SuspendLayout();
            this.FeaturesGroup.SuspendLayout();
            this.statsGroup.SuspendLayout();
            this.AccountGroup.SuspendLayout();
            this.logTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.accountTabPage);
            this.tabControl.Controls.Add(this.logTabPage);
            this.tabControl.Location = new System.Drawing.Point(3, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(556, 221);
            this.tabControl.TabIndex = 0;
            // 
            // accountTabPage
            // 
            this.accountTabPage.Controls.Add(this.skillGroup);
            this.accountTabPage.Controls.Add(this.FeaturesGroup);
            this.accountTabPage.Controls.Add(this.statsGroup);
            this.accountTabPage.Controls.Add(this.AccountGroup);
            this.accountTabPage.Location = new System.Drawing.Point(4, 22);
            this.accountTabPage.Name = "accountTabPage";
            this.accountTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.accountTabPage.Size = new System.Drawing.Size(548, 195);
            this.accountTabPage.TabIndex = 0;
            this.accountTabPage.Text = "Account";
            this.accountTabPage.UseVisualStyleBackColor = true;
            // 
            // skillGroup
            // 
            this.skillGroup.Controls.Add(this.lockSkillBtn);
            this.skillGroup.Controls.Add(this.levelSkill);
            this.skillGroup.Controls.Add(this.label10);
            this.skillGroup.Controls.Add(this.skillManualSelect);
            this.skillGroup.Controls.Add(this.skillSelect);
            this.skillGroup.Location = new System.Drawing.Point(178, 7);
            this.skillGroup.Name = "skillGroup";
            this.skillGroup.Size = new System.Drawing.Size(190, 92);
            this.skillGroup.TabIndex = 3;
            this.skillGroup.TabStop = false;
            this.skillGroup.Text = "Skill Select";
            // 
            // lockSkillBtn
            // 
            this.lockSkillBtn.Location = new System.Drawing.Point(99, 55);
            this.lockSkillBtn.Name = "lockSkillBtn";
            this.lockSkillBtn.Size = new System.Drawing.Size(85, 23);
            this.lockSkillBtn.TabIndex = 4;
            this.lockSkillBtn.Text = "Lock Skill";
            this.lockSkillBtn.UseVisualStyleBackColor = true;
            // 
            // levelSkill
            // 
            this.levelSkill.Location = new System.Drawing.Point(160, 29);
            this.levelSkill.Name = "levelSkill";
            this.levelSkill.Size = new System.Drawing.Size(24, 20);
            this.levelSkill.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(102, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Manual Mode";
            // 
            // skillManualSelect
            // 
            this.skillManualSelect.Location = new System.Drawing.Point(99, 29);
            this.skillManualSelect.Name = "skillManualSelect";
            this.skillManualSelect.Size = new System.Drawing.Size(55, 20);
            this.skillManualSelect.TabIndex = 1;
            // 
            // skillSelect
            // 
            this.skillSelect.FormattingEnabled = true;
            this.skillSelect.Location = new System.Drawing.Point(6, 18);
            this.skillSelect.Name = "skillSelect";
            this.skillSelect.Size = new System.Drawing.Size(87, 69);
            this.skillSelect.TabIndex = 0;
            // 
            // FeaturesGroup
            // 
            this.FeaturesGroup.Controls.Add(this.MiscBtn);
            this.FeaturesGroup.Controls.Add(this.packetBtn);
            this.FeaturesGroup.Controls.Add(this.inventoryBtn);
            this.FeaturesGroup.Controls.Add(this.rusherBtn);
            this.FeaturesGroup.Location = new System.Drawing.Point(177, 101);
            this.FeaturesGroup.Name = "FeaturesGroup";
            this.FeaturesGroup.Size = new System.Drawing.Size(191, 88);
            this.FeaturesGroup.TabIndex = 2;
            this.FeaturesGroup.TabStop = false;
            this.FeaturesGroup.Text = "Features";
            // 
            // MiscBtn
            // 
            this.MiscBtn.Location = new System.Drawing.Point(100, 21);
            this.MiscBtn.Name = "MiscBtn";
            this.MiscBtn.Size = new System.Drawing.Size(75, 23);
            this.MiscBtn.TabIndex = 3;
            this.MiscBtn.Text = "Misc";
            this.MiscBtn.UseVisualStyleBackColor = true;
            this.MiscBtn.Click += new System.EventHandler(this.MiscBtn_Click);
            // 
            // packetBtn
            // 
            this.packetBtn.Location = new System.Drawing.Point(19, 21);
            this.packetBtn.Name = "packetBtn";
            this.packetBtn.Size = new System.Drawing.Size(75, 23);
            this.packetBtn.TabIndex = 2;
            this.packetBtn.Text = "Packet View";
            this.packetBtn.UseVisualStyleBackColor = true;
            // 
            // inventoryBtn
            // 
            this.inventoryBtn.Location = new System.Drawing.Point(100, 50);
            this.inventoryBtn.Name = "inventoryBtn";
            this.inventoryBtn.Size = new System.Drawing.Size(75, 23);
            this.inventoryBtn.TabIndex = 1;
            this.inventoryBtn.Text = "Inventory";
            this.inventoryBtn.UseVisualStyleBackColor = true;
            this.inventoryBtn.Click += new System.EventHandler(this.inventoryBtn_Click);
            // 
            // rusherBtn
            // 
            this.rusherBtn.Location = new System.Drawing.Point(19, 50);
            this.rusherBtn.Name = "rusherBtn";
            this.rusherBtn.Size = new System.Drawing.Size(75, 23);
            this.rusherBtn.TabIndex = 0;
            this.rusherBtn.Text = "Map Rusher";
            this.rusherBtn.UseVisualStyleBackColor = true;
            this.rusherBtn.Click += new System.EventHandler(this.rusherBtn_Click);
            // 
            // statsGroup
            // 
            this.statsGroup.Controls.Add(this.actionStat);
            this.statsGroup.Controls.Add(this.actionLabel);
            this.statsGroup.Controls.Add(this.timeStat);
            this.statsGroup.Controls.Add(this.monsterStat);
            this.statsGroup.Controls.Add(this.peopleStat);
            this.statsGroup.Controls.Add(this.expStat);
            this.statsGroup.Controls.Add(this.mesoStat);
            this.statsGroup.Controls.Add(this.mapStat);
            this.statsGroup.Controls.Add(this.channelStat);
            this.statsGroup.Controls.Add(this.levelStat);
            this.statsGroup.Controls.Add(this.nameStat);
            this.statsGroup.Controls.Add(this.label9);
            this.statsGroup.Controls.Add(this.label8);
            this.statsGroup.Controls.Add(this.label7);
            this.statsGroup.Controls.Add(this.label6);
            this.statsGroup.Controls.Add(this.label5);
            this.statsGroup.Controls.Add(this.label4);
            this.statsGroup.Controls.Add(this.label3);
            this.statsGroup.Controls.Add(this.label2);
            this.statsGroup.Controls.Add(this.label1);
            this.statsGroup.Location = new System.Drawing.Point(374, 6);
            this.statsGroup.Name = "statsGroup";
            this.statsGroup.Size = new System.Drawing.Size(171, 183);
            this.statsGroup.TabIndex = 1;
            this.statsGroup.TabStop = false;
            this.statsGroup.Text = "Stats";
            // 
            // actionStat
            // 
            this.actionStat.AutoSize = true;
            this.actionStat.Location = new System.Drawing.Point(64, 150);
            this.actionStat.Name = "actionStat";
            this.actionStat.Size = new System.Drawing.Size(37, 13);
            this.actionStat.TabIndex = 19;
            this.actionStat.Text = "Offline";
            // 
            // actionLabel
            // 
            this.actionLabel.AutoSize = true;
            this.actionLabel.Location = new System.Drawing.Point(6, 150);
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(40, 13);
            this.actionLabel.TabIndex = 18;
            this.actionLabel.Text = "Action:";
            // 
            // timeStat
            // 
            this.timeStat.AutoSize = true;
            this.timeStat.Location = new System.Drawing.Point(61, 135);
            this.timeStat.Name = "timeStat";
            this.timeStat.Size = new System.Drawing.Size(49, 13);
            this.timeStat.TabIndex = 17;
            this.timeStat.Text = "00:00:00";
            // 
            // monsterStat
            // 
            this.monsterStat.AutoSize = true;
            this.monsterStat.Location = new System.Drawing.Point(61, 120);
            this.monsterStat.Name = "monsterStat";
            this.monsterStat.Size = new System.Drawing.Size(37, 13);
            this.monsterStat.TabIndex = 16;
            this.monsterStat.Text = "Offline";
            // 
            // peopleStat
            // 
            this.peopleStat.AutoSize = true;
            this.peopleStat.Location = new System.Drawing.Point(61, 105);
            this.peopleStat.Name = "peopleStat";
            this.peopleStat.Size = new System.Drawing.Size(37, 13);
            this.peopleStat.TabIndex = 15;
            this.peopleStat.Text = "Offline";
            // 
            // expStat
            // 
            this.expStat.AutoSize = true;
            this.expStat.Location = new System.Drawing.Point(61, 91);
            this.expStat.Name = "expStat";
            this.expStat.Size = new System.Drawing.Size(37, 13);
            this.expStat.TabIndex = 14;
            this.expStat.Text = "Offline";
            // 
            // mesoStat
            // 
            this.mesoStat.AutoSize = true;
            this.mesoStat.Location = new System.Drawing.Point(61, 75);
            this.mesoStat.Name = "mesoStat";
            this.mesoStat.Size = new System.Drawing.Size(37, 13);
            this.mesoStat.TabIndex = 13;
            this.mesoStat.Text = "Offline";
            // 
            // mapStat
            // 
            this.mapStat.AutoSize = true;
            this.mapStat.Location = new System.Drawing.Point(61, 60);
            this.mapStat.Name = "mapStat";
            this.mapStat.Size = new System.Drawing.Size(37, 13);
            this.mapStat.TabIndex = 12;
            this.mapStat.Text = "Offline";
            // 
            // channelStat
            // 
            this.channelStat.AutoSize = true;
            this.channelStat.Location = new System.Drawing.Point(61, 45);
            this.channelStat.Name = "channelStat";
            this.channelStat.Size = new System.Drawing.Size(37, 13);
            this.channelStat.TabIndex = 11;
            this.channelStat.Text = "Offline";
            // 
            // levelStat
            // 
            this.levelStat.AutoSize = true;
            this.levelStat.Location = new System.Drawing.Point(61, 30);
            this.levelStat.Name = "levelStat";
            this.levelStat.Size = new System.Drawing.Size(37, 13);
            this.levelStat.TabIndex = 10;
            this.levelStat.Text = "Offline";
            // 
            // nameStat
            // 
            this.nameStat.AutoSize = true;
            this.nameStat.Location = new System.Drawing.Point(61, 15);
            this.nameStat.Name = "nameStat";
            this.nameStat.Size = new System.Drawing.Size(37, 13);
            this.nameStat.TabIndex = 9;
            this.nameStat.Text = "Offline";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Working:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Monsters:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "People:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Exp:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mesos:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Map:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Channel:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Level:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // AccountGroup
            // 
            this.AccountGroup.Controls.Add(this.connectButton);
            this.AccountGroup.Controls.Add(this.modeSelect);
            this.AccountGroup.Controls.Add(this.slotBox);
            this.AccountGroup.Controls.Add(this.channelSelect);
            this.AccountGroup.Controls.Add(this.picBox);
            this.AccountGroup.Controls.Add(this.worldSelect);
            this.AccountGroup.Controls.Add(this.passwordBox);
            this.AccountGroup.Controls.Add(this.userNameBox);
            this.AccountGroup.Location = new System.Drawing.Point(6, 6);
            this.AccountGroup.Name = "AccountGroup";
            this.AccountGroup.Size = new System.Drawing.Size(165, 183);
            this.AccountGroup.TabIndex = 0;
            this.AccountGroup.TabStop = false;
            this.AccountGroup.Text = "Account";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(21, 153);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(121, 23);
            this.connectButton.TabIndex = 7;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // modeSelect
            // 
            this.modeSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modeSelect.FormattingEnabled = true;
            this.modeSelect.Items.AddRange(new object[] {
            "Login Mode",
            "Farm Mode"});
            this.modeSelect.Location = new System.Drawing.Point(21, 125);
            this.modeSelect.Name = "modeSelect";
            this.modeSelect.Size = new System.Drawing.Size(121, 21);
            this.modeSelect.TabIndex = 6;
            this.modeSelect.SelectedIndex = 0;
            // 
            // slotBox
            // 
            this.slotBox.Location = new System.Drawing.Point(108, 72);
            this.slotBox.MaxLength = 2;
            this.slotBox.Name = "slotBox";
            this.slotBox.Size = new System.Drawing.Size(51, 20);
            this.slotBox.TabIndex = 5;
            // 
            // channelSelect
            // 
            this.channelSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.channelSelect.FormattingEnabled = true;
            this.channelSelect.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.channelSelect.Location = new System.Drawing.Point(108, 98);
            this.channelSelect.Name = "channelSelect";
            this.channelSelect.Size = new System.Drawing.Size(51, 21);
            this.channelSelect.TabIndex = 4;
            // 
            // picBox
            // 
            this.picBox.Location = new System.Drawing.Point(7, 73);
            this.picBox.MaxLength = 50;
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(95, 20);
            this.picBox.TabIndex = 3;
            // 
            // worldSelect
            // 
            this.worldSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.worldSelect.FormattingEnabled = true;
            this.worldSelect.Items.AddRange(new object[] {
            "Scania",
            "Bera",
            "Broa",
            "Windia",
            "Khaini",
            "Bellocan",
            "Mardia",
            "Kradia",
            "Yellonde",
            "Dementhos",
            "Galicia",
            "El Nido",
            "Zenith",
            "Arcania",
            "Chaos",
            "Nova",
            "Renegades"});
            this.worldSelect.Location = new System.Drawing.Point(6, 98);
            this.worldSelect.Name = "worldSelect";
            this.worldSelect.Size = new System.Drawing.Size(96, 21);
            this.worldSelect.TabIndex = 2;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(7, 46);
            this.passwordBox.MaxLength = 50;
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(152, 20);
            this.passwordBox.TabIndex = 1;
            // 
            // userNameBox
            // 
            this.userNameBox.Location = new System.Drawing.Point(6, 19);
            this.userNameBox.MaxLength = 50;
            this.userNameBox.Name = "userNameBox";
            this.userNameBox.Size = new System.Drawing.Size(153, 20);
            this.userNameBox.TabIndex = 0;
            // 
            // logTabPage
            // 
            this.logTabPage.Controls.Add(this.log);
            this.logTabPage.Location = new System.Drawing.Point(4, 22);
            this.logTabPage.Name = "logTabPage";
            this.logTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.logTabPage.Size = new System.Drawing.Size(548, 195);
            this.logTabPage.TabIndex = 1;
            this.logTabPage.Text = "Logs";
            this.logTabPage.UseVisualStyleBackColor = true;
            // 
            // log
            // 
            this.log.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.log.ForeColor = System.Drawing.SystemColors.InfoText;
            this.log.Location = new System.Drawing.Point(0, 0);
            this.log.Multiline = true;
            this.log.Name = "log";
            this.log.ReadOnly = true;
            this.log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.log.Size = new System.Drawing.Size(552, 195);
            this.log.TabIndex = 0;
            // 
            // upTimer
            // 
            this.upTimer.Interval = 1000;
            this.upTimer.Tick += new System.EventHandler(this.UpTimer_Tick);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Name = "ClientForm";
            this.Size = new System.Drawing.Size(562, 222);
            this.tabControl.ResumeLayout(false);
            this.accountTabPage.ResumeLayout(false);
            this.skillGroup.ResumeLayout(false);
            this.skillGroup.PerformLayout();
            this.FeaturesGroup.ResumeLayout(false);
            this.statsGroup.ResumeLayout(false);
            this.statsGroup.PerformLayout();
            this.AccountGroup.ResumeLayout(false);
            this.AccountGroup.PerformLayout();
            this.logTabPage.ResumeLayout(false);
            this.logTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage accountTabPage;
        private System.Windows.Forms.GroupBox AccountGroup;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.ComboBox modeSelect;
        private System.Windows.Forms.TextBox slotBox;
        private System.Windows.Forms.ComboBox channelSelect;
        private System.Windows.Forms.TextBox picBox;
        private System.Windows.Forms.ComboBox worldSelect;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox userNameBox;
        private System.Windows.Forms.TabPage logTabPage;
        private System.Windows.Forms.TextBox log;
        private System.Windows.Forms.GroupBox statsGroup;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label timeStat;
        private System.Windows.Forms.Label monsterStat;
        private System.Windows.Forms.Label peopleStat;
        private System.Windows.Forms.Label expStat;
        private System.Windows.Forms.Label mesoStat;
        private System.Windows.Forms.Label mapStat;
        private System.Windows.Forms.Label channelStat;
        private System.Windows.Forms.Label levelStat;
        private System.Windows.Forms.Label nameStat;
        private System.Windows.Forms.GroupBox skillGroup;
        private System.Windows.Forms.ListBox skillSelect;
        private System.Windows.Forms.GroupBox FeaturesGroup;
        private System.Windows.Forms.Button packetBtn;
        private System.Windows.Forms.Button inventoryBtn;
        private System.Windows.Forms.Button rusherBtn;
        private System.Windows.Forms.TextBox levelSkill;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox skillManualSelect;
        private System.Windows.Forms.Button lockSkillBtn;
        private System.Windows.Forms.Button MiscBtn;
        private System.Windows.Forms.Timer upTimer;
        private System.Windows.Forms.Label actionStat;
        private System.Windows.Forms.Label actionLabel;
    }
}
