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
            this.lblHelpTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlVersionInfo = new System.Windows.Forms.Panel();
            this.githubLink = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.currentVersion = new System.Windows.Forms.Label();
            this.githubVersion = new System.Windows.Forms.Label();
            this.githubLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.portabilityButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlHelp = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblHelp1 = new System.Windows.Forms.Label();
            this.lblHelp3 = new System.Windows.Forms.Label();
            this.lblHelp2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlExistingShortcuts = new System.Windows.Forms.TableLayoutPanel();
            this.pnlAddGroup = new System.Windows.Forms.Panel();
            this.lblAddGroup = new System.Windows.Forms.Label();
            this.cmdAddGroup = new System.Windows.Forms.PictureBox();
            this.pnlLeftColumn.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.pnlVersionInfo.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlHelp.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlAddGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeftColumn
            // 
            this.pnlLeftColumn.AutoSize = true;
            this.pnlLeftColumn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.pnlLeftColumn.Controls.Add(this.lblHelpTitle);
            this.pnlLeftColumn.Controls.Add(this.tableLayoutPanel2);
            this.pnlLeftColumn.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeftColumn.ImeMode = System.Windows.Forms.ImeMode.On;
            this.pnlLeftColumn.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftColumn.Name = "pnlLeftColumn";
            this.pnlLeftColumn.Size = new System.Drawing.Size(312, 821);
            this.pnlLeftColumn.TabIndex = 0;
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
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.pnlVersionInfo, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.pnlHelp, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 126);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 248F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 153F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(306, 683);
            this.tableLayoutPanel2.TabIndex = 18;
            // 
            // pnlVersionInfo
            // 
            this.pnlVersionInfo.Controls.Add(this.githubLink);
            this.pnlVersionInfo.Controls.Add(this.label6);
            this.pnlVersionInfo.Controls.Add(this.currentVersion);
            this.pnlVersionInfo.Controls.Add(this.githubVersion);
            this.pnlVersionInfo.Controls.Add(this.githubLabel);
            this.pnlVersionInfo.Controls.Add(this.label4);
            this.pnlVersionInfo.Location = new System.Drawing.Point(3, 533);
            this.pnlVersionInfo.Name = "pnlVersionInfo";
            this.pnlVersionInfo.Size = new System.Drawing.Size(300, 116);
            this.pnlVersionInfo.TabIndex = 18;
            // 
            // githubLink
            // 
            this.githubLink.ActiveLinkColor = System.Drawing.Color.White;
            this.githubLink.AutoSize = true;
            this.githubLink.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.githubLink.LinkColor = System.Drawing.Color.White;
            this.githubLink.Location = new System.Drawing.Point(44, 28);
            this.githubLink.Name = "githubLink";
            this.githubLink.Size = new System.Drawing.Size(201, 17);
            this.githubLink.TabIndex = 20;
            this.githubLink.TabStop = true;
            this.githubLink.Text = "Please report them to the GitHub";
            this.githubLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.githubLink.VisitedLinkColor = System.Drawing.Color.White;
            this.githubLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.githubLink_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label6.ForeColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(60, 54);
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
            this.currentVersion.Location = new System.Drawing.Point(170, 54);
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
            this.githubVersion.Location = new System.Drawing.Point(163, 83);
            this.githubVersion.Name = "githubVersion";
            this.githubVersion.Size = new System.Drawing.Size(17, 19);
            this.githubVersion.TabIndex = 14;
            this.githubVersion.Text = "0";
            // 
            // githubLabel
            // 
            this.githubLabel.AutoSize = true;
            this.githubLabel.BackColor = System.Drawing.Color.Transparent;
            this.githubLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.githubLabel.ForeColor = System.Drawing.Color.Transparent;
            this.githubLabel.Location = new System.Drawing.Point(61, 83);
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
            this.label4.Location = new System.Drawing.Point(-3, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(295, 27);
            this.label4.TabIndex = 17;
            this.label4.Text = "Have issues/bugs?";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.portabilityButton);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Location = new System.Drawing.Point(3, 285);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 179);
            this.panel2.TabIndex = 20;
            // 
            // portabilityButton
            // 
            this.portabilityButton.BackColor = System.Drawing.Color.Transparent;
            this.portabilityButton.BackgroundImage = global::client.Properties.Resources.toggleOff;
            this.portabilityButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.portabilityButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.portabilityButton.FlatAppearance.BorderSize = 0;
            this.portabilityButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.portabilityButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.portabilityButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.portabilityButton.ForeColor = System.Drawing.Color.Transparent;
            this.portabilityButton.Location = new System.Drawing.Point(111, 53);
            this.portabilityButton.Name = "portabilityButton";
            this.portabilityButton.Size = new System.Drawing.Size(66, 31);
            this.portabilityButton.TabIndex = 21;
            this.portabilityButton.TabStop = false;
            this.portabilityButton.Tag = "n";
            this.portabilityButton.UseVisualStyleBackColor = false;
            this.portabilityButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(3, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(283, 90);
            this.label8.TabIndex = 20;
            this.label8.Text = resources.GetString("label8.Text");
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(35, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(218, 23);
            this.label7.TabIndex = 18;
            this.label7.Text = "Portability Mode\r\n\r\n\r\n";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(23, 1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(243, 27);
            this.label11.TabIndex = 17;
            this.label11.Text = "Want portability?";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlHelp
            // 
            this.pnlHelp.Controls.Add(this.label5);
            this.pnlHelp.Controls.Add(this.label3);
            this.pnlHelp.Controls.Add(this.lblHelp1);
            this.pnlHelp.Controls.Add(this.lblHelp3);
            this.pnlHelp.Controls.Add(this.lblHelp2);
            this.pnlHelp.Location = new System.Drawing.Point(3, 3);
            this.pnlHelp.Name = "pnlHelp";
            this.pnlHelp.Size = new System.Drawing.Size(300, 224);
            this.pnlHelp.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(25, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(243, 40);
            this.label5.TabIndex = 18;
            this.label5.Text = "1. Click on the group you want to pin to open the shortcuts folder";
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
            this.label3.Text = "Pin your first shortcut:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHelp1
            // 
            this.lblHelp1.BackColor = System.Drawing.Color.Transparent;
            this.lblHelp1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelp1.ForeColor = System.Drawing.Color.Transparent;
            this.lblHelp1.Location = new System.Drawing.Point(26, 92);
            this.lblHelp1.Name = "lblHelp1";
            this.lblHelp1.Size = new System.Drawing.Size(243, 40);
            this.lblHelp1.TabIndex = 14;
            this.lblHelp1.Text = "2. Right click on the shortcut named as your new group";
            // 
            // lblHelp3
            // 
            this.lblHelp3.BackColor = System.Drawing.Color.Transparent;
            this.lblHelp3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblHelp3.ForeColor = System.Drawing.Color.Transparent;
            this.lblHelp3.Location = new System.Drawing.Point(26, 168);
            this.lblHelp3.Name = "lblHelp3";
            this.lblHelp3.Size = new System.Drawing.Size(243, 22);
            this.lblHelp3.TabIndex = 16;
            this.lblHelp3.Text = "4. Enjoy your new Taskbar group";
            // 
            // lblHelp2
            // 
            this.lblHelp2.BackColor = System.Drawing.Color.Transparent;
            this.lblHelp2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblHelp2.ForeColor = System.Drawing.Color.Transparent;
            this.lblHelp2.Location = new System.Drawing.Point(26, 138);
            this.lblHelp2.Name = "lblHelp2";
            this.lblHelp2.Size = new System.Drawing.Size(243, 22);
            this.lblHelp2.TabIndex = 15;
            this.lblHelp2.Text = "3. Click on \"Pin to taskbar\"";
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
            this.panel1.Size = new System.Drawing.Size(677, 133);
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
            // pnlExistingShortcuts
            // 
            this.pnlExistingShortcuts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlExistingShortcuts.ColumnCount = 1;
            this.pnlExistingShortcuts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlExistingShortcuts.Location = new System.Drawing.Point(320, 148);
            this.pnlExistingShortcuts.Name = "pnlExistingShortcuts";
            this.pnlExistingShortcuts.RowCount = 1;
            this.pnlExistingShortcuts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlExistingShortcuts.Size = new System.Drawing.Size(674, 36);
            this.pnlExistingShortcuts.TabIndex = 5;
            // 
            // pnlAddGroup
            // 
            this.pnlAddGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAddGroup.Controls.Add(this.lblAddGroup);
            this.pnlAddGroup.Controls.Add(this.cmdAddGroup);
            this.pnlAddGroup.Location = new System.Drawing.Point(502, 193);
            this.pnlAddGroup.Name = "pnlAddGroup";
            this.pnlAddGroup.Size = new System.Drawing.Size(318, 68);
            this.pnlAddGroup.TabIndex = 1;
            this.pnlAddGroup.Click += new System.EventHandler(this.cmdAddGroup_Click);
            this.pnlAddGroup.MouseEnter += new System.EventHandler(this.pnlAddGroup_MouseEnter);
            this.pnlAddGroup.MouseLeave += new System.EventHandler(this.pnlAddGroup_MouseLeave);
            // 
            // lblAddGroup
            // 
            this.lblAddGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblAddGroup.AutoSize = true;
            this.lblAddGroup.BackColor = System.Drawing.Color.Transparent;
            this.lblAddGroup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.lblAddGroup.Location = new System.Drawing.Point(129, 24);
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
            this.cmdAddGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cmdAddGroup.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdAddGroup.BackgroundImage")));
            this.cmdAddGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdAddGroup.Location = new System.Drawing.Point(77, 14);
            this.cmdAddGroup.Margin = new System.Windows.Forms.Padding(30, 30, 10, 30);
            this.cmdAddGroup.Name = "cmdAddGroup";
            this.cmdAddGroup.Size = new System.Drawing.Size(40, 38);
            this.cmdAddGroup.TabIndex = 7;
            this.cmdAddGroup.TabStop = false;
            this.cmdAddGroup.Click += new System.EventHandler(this.cmdAddGroup_Click);
            this.cmdAddGroup.MouseEnter += new System.EventHandler(this.pnlAddGroup_MouseEnter);
            this.cmdAddGroup.MouseLeave += new System.EventHandler(this.pnlAddGroup_MouseLeave);
            // 
            // frmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.ClientSize = new System.Drawing.Size(1014, 821);
            this.Controls.Add(this.pnlAddGroup);
            this.Controls.Add(this.pnlExistingShortcuts);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlLeftColumn);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Taskbar Groups";
            this.SizeChanged += new System.EventHandler(this.frmClient_SizeChanged);
            this.pnlLeftColumn.ResumeLayout(false);
            this.pnlLeftColumn.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.pnlVersionInfo.ResumeLayout(false);
            this.pnlVersionInfo.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnlHelp.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlAddGroup.ResumeLayout(false);
            this.pnlAddGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddGroup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeftColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblHelpTitle;
        private System.Windows.Forms.Panel pnlHelp;
        private System.Windows.Forms.Label lblHelp1;
        private System.Windows.Forms.Label lblHelp3;
        private System.Windows.Forms.Label lblHelp2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button portabilityButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel pnlExistingShortcuts;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel pnlVersionInfo;
        private System.Windows.Forms.LinkLabel githubLink;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label currentVersion;
        private System.Windows.Forms.Label githubVersion;
        private System.Windows.Forms.Label githubLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlAddGroup;
        private System.Windows.Forms.Label lblAddGroup;
        private System.Windows.Forms.PictureBox cmdAddGroup;
    }
}