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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClient));
            this.pnlLeftColumn = new System.Windows.Forms.Panel();
            this.cmdClose = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
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
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlLeftColumn.SuspendLayout();
            this.pnlHelp.SuspendLayout();
            this.pnlAddGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddGroup)).BeginInit();
            this.panel1.SuspendLayout();
            this.contextMenuStripTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeftColumn
            // 
            this.pnlLeftColumn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.pnlLeftColumn.Controls.Add(this.cmdClose);
            this.pnlLeftColumn.Controls.Add(this.btnClose);
            this.pnlLeftColumn.Controls.Add(this.pnlHelp);
            this.pnlLeftColumn.Controls.Add(this.lblHelpTitle);
            this.pnlLeftColumn.ImeMode = System.Windows.Forms.ImeMode.On;
            this.pnlLeftColumn.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftColumn.Name = "pnlLeftColumn";
            this.pnlLeftColumn.Size = new System.Drawing.Size(320, 820);
            this.pnlLeftColumn.TabIndex = 0;
            // 
            // cmdClose
            // 
            this.cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.cmdClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.cmdClose.FlatAppearance.BorderSize = 0;
            this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClose.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.ForeColor = System.Drawing.Color.White;
            this.cmdClose.Location = new System.Drawing.Point(72, 335);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(182, 50);
            this.cmdClose.TabIndex = 21;
            this.cmdClose.TabStop = false;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = false;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(0, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(56, 19);
            this.btnClose.TabIndex = 22;
            this.btnClose.Visible = false;
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
            this.pnlAddGroup.Location = new System.Drawing.Point(490, 178);
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
            this.label1.Size = new System.Drawing.Size(209, 40);
            this.label1.TabIndex = 11;
            this.label1.Text = "Taskbar groups";
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
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.contextMenuStripTray;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "Taskbar Group";
            this.trayIcon.Visible = true;
            // 
            // contextMenuStripTray
            // 
            this.contextMenuStripTray.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSettings,
            this.toolStripMenuItemExit});
            this.contextMenuStripTray.Name = "contextMenuStripTray";
            this.contextMenuStripTray.Size = new System.Drawing.Size(154, 48);
            // 
            // toolStripMenuItemSettings
            // 
            this.toolStripMenuItemSettings.Name = "toolStripMenuItemSettings";
            this.toolStripMenuItemSettings.Size = new System.Drawing.Size(153, 22);
            this.toolStripMenuItemSettings.Text = "Taskbar groups";
            this.toolStripMenuItemSettings.Click += new System.EventHandler(this.toolStripMenuItemSettings_Click);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(153, 22);
            this.toolStripMenuItemExit.Text = "Exit";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // frmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.ClientSize = new System.Drawing.Size(1000, 821);
            this.Controls.Add(this.pnlExistingGroups);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlAddGroup);
            this.Controls.Add(this.pnlLeftColumn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TaskbarGroups";
            this.pnlLeftColumn.ResumeLayout(false);
            this.pnlHelp.ResumeLayout(false);
            this.pnlAddGroup.ResumeLayout(false);
            this.pnlAddGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddGroup)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStripTray.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTray;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSettings;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.Button cmdClose;
    }
}