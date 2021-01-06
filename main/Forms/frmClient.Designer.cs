namespace client.Forms
{
    partial class frmClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClient));
            this.pnlLeftColumn = new System.Windows.Forms.Panel();
            this.pnlVersionInfo = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.currentVersion = new System.Windows.Forms.Label();
            this.githubVersion = new System.Windows.Forms.Label();
            this.githubLink = new System.Windows.Forms.LinkLabel();
            this.githubLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlHelp = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblHelp1 = new System.Windows.Forms.Label();
            this.lblHelp3 = new System.Windows.Forms.Label();
            this.lblHelp2 = new System.Windows.Forms.Label();
            this.lblHelpTitle = new System.Windows.Forms.Label();
            this.pnlAddGroup = new System.Windows.Forms.Panel();
            this.lblAddGroup = new System.Windows.Forms.Label();
            this.cmdAddGroup = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlExistingGroups = new System.Windows.Forms.Panel();
            this.pnlBottomMain = new System.Windows.Forms.Panel();
            this.pnlLeftColumn.SuspendLayout();
            this.pnlVersionInfo.SuspendLayout();
            this.pnlHelp.SuspendLayout();
            this.pnlAddGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddGroup)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlBottomMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeftColumn
            // 
            this.pnlLeftColumn.AutoSize = true;
            this.pnlLeftColumn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.pnlLeftColumn.Controls.Add(this.pnlVersionInfo);
            this.pnlLeftColumn.Controls.Add(this.pnlHelp);
            this.pnlLeftColumn.Controls.Add(this.lblHelpTitle);
            this.pnlLeftColumn.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeftColumn.ImeMode = System.Windows.Forms.ImeMode.On;
            this.pnlLeftColumn.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftColumn.Name = "pnlLeftColumn";
            this.pnlLeftColumn.Size = new System.Drawing.Size(307, 821);
            this.pnlLeftColumn.TabIndex = 0;
            // 
            // pnlVersionInfo
            // 
            this.pnlVersionInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlVersionInfo.Controls.Add(this.label6);
            this.pnlVersionInfo.Controls.Add(this.currentVersion);
            this.pnlVersionInfo.Controls.Add(this.githubVersion);
            this.pnlVersionInfo.Controls.Add(this.githubLink);
            this.pnlVersionInfo.Controls.Add(this.githubLabel);
            this.pnlVersionInfo.Controls.Add(this.label4);
            this.pnlVersionInfo.Controls.Add(this.label5);
            this.pnlVersionInfo.Location = new System.Drawing.Point(12, 616);
            this.pnlVersionInfo.Name = "pnlVersionInfo";
            this.pnlVersionInfo.Size = new System.Drawing.Size(292, 178);
            this.pnlVersionInfo.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label6.ForeColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(66, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 19);
            this.label6.TabIndex = 19;
            this.label6.Text = "Current Version:";
            // 
            // currentVersion
            // 
            this.currentVersion.AutoSize = true;
            this.currentVersion.BackColor = System.Drawing.Color.Transparent;
            this.currentVersion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.currentVersion.ForeColor = System.Drawing.Color.Transparent;
            this.currentVersion.Location = new System.Drawing.Point(173, 101);
            this.currentVersion.Name = "currentVersion";
            this.currentVersion.Size = new System.Drawing.Size(17, 19);
            this.currentVersion.TabIndex = 15;
            this.currentVersion.Text = "0";
            // 
            // githubVersion
            // 
            this.githubVersion.AutoSize = true;
            this.githubVersion.BackColor = System.Drawing.Color.Transparent;
            this.githubVersion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.githubVersion.ForeColor = System.Drawing.Color.Transparent;
            this.githubVersion.Location = new System.Drawing.Point(173, 130);
            this.githubVersion.Name = "githubVersion";
            this.githubVersion.Size = new System.Drawing.Size(17, 19);
            this.githubVersion.TabIndex = 14;
            this.githubVersion.Text = "0";
            // 
            // githubLink
            // 
            this.githubLink.AutoSize = true;
            this.githubLink.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.githubLink.LinkColor = System.Drawing.Color.White;
            this.githubLink.Location = new System.Drawing.Point(218, 34);
            this.githubLink.Name = "githubLink";
            this.githubLink.Size = new System.Drawing.Size(34, 17);
            this.githubLink.TabIndex = 18;
            this.githubLink.TabStop = true;
            this.githubLink.Text = "here";
            this.githubLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.githubLink_LinkClicked);
            // 
            // githubLabel
            // 
            this.githubLabel.AutoSize = true;
            this.githubLabel.BackColor = System.Drawing.Color.Transparent;
            this.githubLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.githubLabel.ForeColor = System.Drawing.Color.Transparent;
            this.githubLabel.Location = new System.Drawing.Point(75, 130);
            this.githubLabel.Name = "githubLabel";
            this.githubLabel.Size = new System.Drawing.Size(98, 19);
            this.githubLabel.TabIndex = 13;
            this.githubLabel.Text = "Latest Version:";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(22, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(243, 27);
            this.label4.TabIndex = 17;
            this.label4.Text = "Have issues/bugs?";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(22, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(243, 24);
            this.label5.TabIndex = 14;
            this.label5.Text = "Please report them to the Github";
            // 
            // pnlHelp
            // 
            this.pnlHelp.Controls.Add(this.label3);
            this.pnlHelp.Controls.Add(this.lblHelp1);
            this.pnlHelp.Controls.Add(this.lblHelp3);
            this.pnlHelp.Controls.Add(this.lblHelp2);
            this.pnlHelp.Location = new System.Drawing.Point(12, 126);
            this.pnlHelp.Name = "pnlHelp";
            this.pnlHelp.Size = new System.Drawing.Size(292, 202);
            this.pnlHelp.TabIndex = 17;
            this.pnlHelp.Visible = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(26, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(243, 26);
            this.label3.TabIndex = 17;
            this.label3.Text = "When the folder opens:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHelp1
            // 
            this.lblHelp1.BackColor = System.Drawing.Color.Transparent;
            this.lblHelp1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelp1.ForeColor = System.Drawing.Color.Transparent;
            this.lblHelp1.Location = new System.Drawing.Point(26, 59);
            this.lblHelp1.Name = "lblHelp1";
            this.lblHelp1.Size = new System.Drawing.Size(243, 40);
            this.lblHelp1.TabIndex = 14;
            this.lblHelp1.Text = "1. Right click on the shortcut named as your new group";
            // 
            // lblHelp3
            // 
            this.lblHelp3.BackColor = System.Drawing.Color.Transparent;
            this.lblHelp3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblHelp3.ForeColor = System.Drawing.Color.Transparent;
            this.lblHelp3.Location = new System.Drawing.Point(26, 155);
            this.lblHelp3.Name = "lblHelp3";
            this.lblHelp3.Size = new System.Drawing.Size(243, 22);
            this.lblHelp3.TabIndex = 16;
            this.lblHelp3.Text = "3. Enjoy your new Taskbar group";
            // 
            // lblHelp2
            // 
            this.lblHelp2.BackColor = System.Drawing.Color.Transparent;
            this.lblHelp2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblHelp2.ForeColor = System.Drawing.Color.Transparent;
            this.lblHelp2.Location = new System.Drawing.Point(26, 115);
            this.lblHelp2.Name = "lblHelp2";
            this.lblHelp2.Size = new System.Drawing.Size(243, 22);
            this.lblHelp2.TabIndex = 15;
            this.lblHelp2.Text = "2. Click on \"Pin to taskbar\"";
            // 
            // lblHelpTitle
            // 
            this.lblHelpTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblHelpTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelpTitle.ForeColor = System.Drawing.Color.Transparent;
            this.lblHelpTitle.Location = new System.Drawing.Point(41, 44);
            this.lblHelpTitle.Name = "lblHelpTitle";
            this.lblHelpTitle.Size = new System.Drawing.Size(240, 56);
            this.lblHelpTitle.TabIndex = 13;
            this.lblHelpTitle.Text = "Press on \"Add Taskbar group\" to get started";
            this.lblHelpTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlAddGroup
            // 
            this.pnlAddGroup.Controls.Add(this.lblAddGroup);
            this.pnlAddGroup.Controls.Add(this.cmdAddGroup);
            this.pnlAddGroup.Location = new System.Drawing.Point(164, 4);
            this.pnlAddGroup.Name = "pnlAddGroup";
            this.pnlAddGroup.Size = new System.Drawing.Size(340, 70);
            this.pnlAddGroup.TabIndex = 1;
            this.pnlAddGroup.Click += new System.EventHandler(this.cmdAddGroup_Click);
            this.pnlAddGroup.MouseEnter += new System.EventHandler(this.pnlAddGroup_MouseEnter);
            this.pnlAddGroup.MouseLeave += new System.EventHandler(this.pnlAddGroup_MouseLeave);
            // 
            // lblAddGroup
            // 
            this.lblAddGroup.AutoSize = true;
            this.lblAddGroup.BackColor = System.Drawing.Color.Transparent;
            this.lblAddGroup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.lblAddGroup.Location = new System.Drawing.Point(140, 24);
            this.lblAddGroup.Name = "lblAddGroup";
            this.lblAddGroup.Size = new System.Drawing.Size(119, 17);
            this.lblAddGroup.TabIndex = 8;
            this.lblAddGroup.Text = "Add taskbar group";
            this.lblAddGroup.Click += new System.EventHandler(this.cmdAddGroup_Click);
            this.lblAddGroup.MouseEnter += new System.EventHandler(this.pnlAddGroup_MouseEnter);
            this.lblAddGroup.MouseLeave += new System.EventHandler(this.pnlAddGroup_MouseLeave);
            // 
            // cmdAddGroup
            // 
            this.cmdAddGroup.BackgroundImage = global::client.Properties.Resources.AddGray;
            this.cmdAddGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdAddGroup.Location = new System.Drawing.Point(88, 14);
            this.cmdAddGroup.Margin = new System.Windows.Forms.Padding(30, 30, 10, 30);
            this.cmdAddGroup.Name = "cmdAddGroup";
            this.cmdAddGroup.Size = new System.Drawing.Size(40, 40);
            this.cmdAddGroup.TabIndex = 7;
            this.cmdAddGroup.TabStop = false;
            this.cmdAddGroup.Click += new System.EventHandler(this.cmdAddGroup_Click);
            this.cmdAddGroup.MouseEnter += new System.EventHandler(this.pnlAddGroup_MouseEnter);
            this.cmdAddGroup.MouseLeave += new System.EventHandler(this.pnlAddGroup_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(31, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 40);
            this.label1.TabIndex = 11;
            this.label1.Text = "Taskbar Groups";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(320, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(680, 133);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.label2.Location = new System.Drawing.Point(36, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(503, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Group your favourite programs and pin them to the taskbar for easy access";
            // 
            // pnlExistingGroups
            // 
            this.pnlExistingGroups.Location = new System.Drawing.Point(320, 133);
            this.pnlExistingGroups.Margin = new System.Windows.Forms.Padding(0);
            this.pnlExistingGroups.Name = "pnlExistingGroups";
            this.pnlExistingGroups.Size = new System.Drawing.Size(680, 0);
            this.pnlExistingGroups.TabIndex = 3;
            // 
            // pnlBottomMain
            // 
            this.pnlBottomMain.AutoSize = true;
            this.pnlBottomMain.Controls.Add(this.pnlAddGroup);
            this.pnlBottomMain.Location = new System.Drawing.Point(326, 162);
            this.pnlBottomMain.Name = "pnlBottomMain";
            this.pnlBottomMain.Size = new System.Drawing.Size(662, 101);
            this.pnlBottomMain.TabIndex = 4;
            // 
            // frmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.ClientSize = new System.Drawing.Size(1000, 821);
            this.Controls.Add(this.pnlBottomMain);
            this.Controls.Add(this.pnlExistingGroups);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlLeftColumn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TaskbarGroups";
            this.Resize += new System.EventHandler(this.frmClient_Resize);
            this.pnlLeftColumn.ResumeLayout(false);
            this.pnlVersionInfo.ResumeLayout(false);
            this.pnlVersionInfo.PerformLayout();
            this.pnlHelp.ResumeLayout(false);
            this.pnlAddGroup.ResumeLayout(false);
            this.pnlAddGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddGroup)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlBottomMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeftColumn;
        private System.Windows.Forms.Panel pnlAddGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAddGroup;
        private System.Windows.Forms.PictureBox cmdAddGroup;
        private System.Windows.Forms.Panel pnlExistingGroups;
        private System.Windows.Forms.Label lblHelpTitle;
        private System.Windows.Forms.Panel pnlHelp;
        private System.Windows.Forms.Label lblHelp1;
        private System.Windows.Forms.Label lblHelp3;
        private System.Windows.Forms.Label lblHelp2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label currentVersion;
        private System.Windows.Forms.Label githubVersion;
        private System.Windows.Forms.Label githubLabel;
        private System.Windows.Forms.Panel pnlVersionInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel githubLink;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlBottomMain;
    }
}