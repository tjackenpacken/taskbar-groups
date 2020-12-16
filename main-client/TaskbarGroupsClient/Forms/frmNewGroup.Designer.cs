namespace TaskbarGroupsClient
{
    partial class frmNewGroup
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.lblAddGroupIcon = new System.Windows.Forms.Label();
            this.cmdAddGroupIcon = new System.Windows.Forms.PictureBox();
            this.lblAddGroupIconDesc = new System.Windows.Forms.Label();
            this.lblAddShortcut = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlGroupIcon = new System.Windows.Forms.Panel();
            this.pnlAddShortcut = new System.Windows.Forms.Panel();
            this.lblErrorMaxShortcuts = new System.Windows.Forms.Label();
            this.cmdAddShortcut = new System.Windows.Forms.PictureBox();
            this.cmdExit = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.lblErrorTitle = new System.Windows.Forms.Label();
            this.lblErrorIcon = new System.Windows.Forms.Label();
            this.lblErrorShortcut = new System.Windows.Forms.Label();
            this.lblWith = new System.Windows.Forms.Label();
            this.lblNum = new System.Windows.Forms.Label();
            this.cmdNumDown = new System.Windows.Forms.Button();
            this.cmdNumUp = new System.Windows.Forms.Button();
            this.lblErrorNum = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddGroupIcon)).BeginInit();
            this.pnlGroupIcon.SuspendLayout();
            this.pnlAddShortcut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddShortcut)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.label2.Location = new System.Drawing.Point(46, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(500, 1);
            this.label2.TabIndex = 9;
            // 
            // txtGroupName
            // 
            this.txtGroupName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.txtGroupName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGroupName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGroupName.ForeColor = System.Drawing.Color.White;
            this.txtGroupName.Location = new System.Drawing.Point(49, 35);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(352, 32);
            this.txtGroupName.TabIndex = 8;
            this.txtGroupName.TabStop = false;
            this.txtGroupName.Text = "Name the new group...";
            this.txtGroupName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtGroupName_MouseClick);
            this.txtGroupName.TextChanged += new System.EventHandler(this.txtGroupName_TextChanged);
            this.txtGroupName.Leave += new System.EventHandler(this.txtGroupName_Leave);
            // 
            // lblAddGroupIcon
            // 
            this.lblAddGroupIcon.AutoSize = true;
            this.lblAddGroupIcon.BackColor = System.Drawing.Color.Transparent;
            this.lblAddGroupIcon.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddGroupIcon.ForeColor = System.Drawing.Color.White;
            this.lblAddGroupIcon.Location = new System.Drawing.Point(96, 15);
            this.lblAddGroupIcon.Name = "lblAddGroupIcon";
            this.lblAddGroupIcon.Size = new System.Drawing.Size(157, 30);
            this.lblAddGroupIcon.TabIndex = 11;
            this.lblAddGroupIcon.Text = "Add group icon";
            this.lblAddGroupIcon.Click += new System.EventHandler(this.cmdAddGroupIcon_Click);
            this.lblAddGroupIcon.MouseEnter += new System.EventHandler(this.cmdAddGroupIcon_MouseEnter);
            this.lblAddGroupIcon.MouseLeave += new System.EventHandler(this.cmdAddGroupIcon_MouseLeave);
            // 
            // cmdAddGroupIcon
            // 
            this.cmdAddGroupIcon.BackgroundImage = global::TaskbarGroupsClient.Properties.Resources.AddWhite;
            this.cmdAddGroupIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdAddGroupIcon.Location = new System.Drawing.Point(23, 12);
            this.cmdAddGroupIcon.Margin = new System.Windows.Forms.Padding(30, 30, 10, 30);
            this.cmdAddGroupIcon.Name = "cmdAddGroupIcon";
            this.cmdAddGroupIcon.Size = new System.Drawing.Size(60, 60);
            this.cmdAddGroupIcon.TabIndex = 10;
            this.cmdAddGroupIcon.TabStop = false;
            this.cmdAddGroupIcon.Click += new System.EventHandler(this.cmdAddGroupIcon_Click);
            this.cmdAddGroupIcon.MouseEnter += new System.EventHandler(this.cmdAddGroupIcon_MouseEnter);
            this.cmdAddGroupIcon.MouseLeave += new System.EventHandler(this.cmdAddGroupIcon_MouseLeave);
            // 
            // lblAddGroupIconDesc
            // 
            this.lblAddGroupIconDesc.AutoSize = true;
            this.lblAddGroupIconDesc.BackColor = System.Drawing.Color.Transparent;
            this.lblAddGroupIconDesc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddGroupIconDesc.ForeColor = System.Drawing.Color.White;
            this.lblAddGroupIconDesc.Location = new System.Drawing.Point(99, 46);
            this.lblAddGroupIconDesc.Name = "lblAddGroupIconDesc";
            this.lblAddGroupIconDesc.Size = new System.Drawing.Size(252, 17);
            this.lblAddGroupIconDesc.TabIndex = 12;
            this.lblAddGroupIconDesc.Text = "Chose what icon that shows in the taskbar";
            this.lblAddGroupIconDesc.Click += new System.EventHandler(this.cmdAddGroupIcon_Click);
            this.lblAddGroupIconDesc.MouseEnter += new System.EventHandler(this.cmdAddGroupIcon_MouseEnter);
            this.lblAddGroupIconDesc.MouseLeave += new System.EventHandler(this.cmdAddGroupIcon_MouseLeave);
            // 
            // lblAddShortcut
            // 
            this.lblAddShortcut.AutoSize = true;
            this.lblAddShortcut.BackColor = System.Drawing.Color.Transparent;
            this.lblAddShortcut.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddShortcut.ForeColor = System.Drawing.Color.White;
            this.lblAddShortcut.Location = new System.Drawing.Point(100, 21);
            this.lblAddShortcut.Name = "lblAddShortcut";
            this.lblAddShortcut.Size = new System.Drawing.Size(110, 17);
            this.lblAddShortcut.TabIndex = 14;
            this.lblAddShortcut.Text = "Add new shortcut";
            this.lblAddShortcut.Click += new System.EventHandler(this.cmdAddShortcut_Click);
            this.lblAddShortcut.MouseEnter += new System.EventHandler(this.cmdAddShortcut_MouseEnter);
            this.lblAddShortcut.MouseLeave += new System.EventHandler(this.cmdAddShortcut_MouseLeave);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.label4.Location = new System.Drawing.Point(46, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(500, 1);
            this.label4.TabIndex = 15;
            // 
            // pnlGroupIcon
            // 
            this.pnlGroupIcon.Controls.Add(this.cmdAddGroupIcon);
            this.pnlGroupIcon.Controls.Add(this.lblAddGroupIcon);
            this.pnlGroupIcon.Controls.Add(this.lblAddGroupIconDesc);
            this.pnlGroupIcon.Location = new System.Drawing.Point(50, 89);
            this.pnlGroupIcon.Name = "pnlGroupIcon";
            this.pnlGroupIcon.Size = new System.Drawing.Size(495, 86);
            this.pnlGroupIcon.TabIndex = 16;
            this.pnlGroupIcon.Click += new System.EventHandler(this.cmdAddGroupIcon_Click);
            this.pnlGroupIcon.MouseEnter += new System.EventHandler(this.cmdAddGroupIcon_MouseEnter);
            this.pnlGroupIcon.MouseLeave += new System.EventHandler(this.cmdAddGroupIcon_MouseLeave);
            // 
            // pnlAddShortcut
            // 
            this.pnlAddShortcut.Controls.Add(this.lblErrorMaxShortcuts);
            this.pnlAddShortcut.Controls.Add(this.lblAddShortcut);
            this.pnlAddShortcut.Controls.Add(this.cmdAddShortcut);
            this.pnlAddShortcut.Location = new System.Drawing.Point(50, 205);
            this.pnlAddShortcut.Name = "pnlAddShortcut";
            this.pnlAddShortcut.Size = new System.Drawing.Size(495, 60);
            this.pnlAddShortcut.TabIndex = 17;
            this.pnlAddShortcut.Click += new System.EventHandler(this.cmdAddShortcut_Click);
            this.pnlAddShortcut.MouseEnter += new System.EventHandler(this.cmdAddShortcut_MouseEnter);
            this.pnlAddShortcut.MouseLeave += new System.EventHandler(this.cmdAddShortcut_MouseLeave);
            // 
            // lblErrorMaxShortcuts
            // 
            this.lblErrorMaxShortcuts.AutoSize = true;
            this.lblErrorMaxShortcuts.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblErrorMaxShortcuts.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMaxShortcuts.Location = new System.Drawing.Point(265, 19);
            this.lblErrorMaxShortcuts.Name = "lblErrorMaxShortcuts";
            this.lblErrorMaxShortcuts.Size = new System.Drawing.Size(96, 19);
            this.lblErrorMaxShortcuts.TabIndex = 23;
            this.lblErrorMaxShortcuts.Text = "Error message";
            this.lblErrorMaxShortcuts.Visible = false;
            // 
            // cmdAddShortcut
            // 
            this.cmdAddShortcut.BackgroundImage = global::TaskbarGroupsClient.Properties.Resources.AddWhite;
            this.cmdAddShortcut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdAddShortcut.Location = new System.Drawing.Point(30, 10);
            this.cmdAddShortcut.Margin = new System.Windows.Forms.Padding(30, 30, 10, 30);
            this.cmdAddShortcut.Name = "cmdAddShortcut";
            this.cmdAddShortcut.Size = new System.Drawing.Size(40, 40);
            this.cmdAddShortcut.TabIndex = 15;
            this.cmdAddShortcut.TabStop = false;
            this.cmdAddShortcut.Click += new System.EventHandler(this.cmdAddShortcut_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.cmdExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.cmdExit.FlatAppearance.BorderSize = 0;
            this.cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdExit.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExit.ForeColor = System.Drawing.Color.White;
            this.cmdExit.Location = new System.Drawing.Point(302, 521);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(129, 30);
            this.cmdExit.TabIndex = 18;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = false;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.cmdSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.cmdSave.FlatAppearance.BorderSize = 0;
            this.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.ForeColor = System.Drawing.Color.White;
            this.cmdSave.Location = new System.Drawing.Point(134, 521);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(129, 30);
            this.cmdSave.TabIndex = 19;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = false;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // lblErrorTitle
            // 
            this.lblErrorTitle.AutoSize = true;
            this.lblErrorTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblErrorTitle.ForeColor = System.Drawing.Color.Red;
            this.lblErrorTitle.Location = new System.Drawing.Point(45, 15);
            this.lblErrorTitle.Name = "lblErrorTitle";
            this.lblErrorTitle.Size = new System.Drawing.Size(96, 19);
            this.lblErrorTitle.TabIndex = 20;
            this.lblErrorTitle.Text = "Error message";
            this.lblErrorTitle.Visible = false;
            // 
            // lblErrorIcon
            // 
            this.lblErrorIcon.AutoSize = true;
            this.lblErrorIcon.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblErrorIcon.ForeColor = System.Drawing.Color.Red;
            this.lblErrorIcon.Location = new System.Drawing.Point(148, 82);
            this.lblErrorIcon.Name = "lblErrorIcon";
            this.lblErrorIcon.Size = new System.Drawing.Size(96, 19);
            this.lblErrorIcon.TabIndex = 21;
            this.lblErrorIcon.Text = "Error message";
            this.lblErrorIcon.Visible = false;
            // 
            // lblErrorShortcut
            // 
            this.lblErrorShortcut.AutoSize = true;
            this.lblErrorShortcut.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblErrorShortcut.ForeColor = System.Drawing.Color.Red;
            this.lblErrorShortcut.Location = new System.Drawing.Point(150, 197);
            this.lblErrorShortcut.Name = "lblErrorShortcut";
            this.lblErrorShortcut.Size = new System.Drawing.Size(96, 19);
            this.lblErrorShortcut.TabIndex = 22;
            this.lblErrorShortcut.Text = "Error message";
            this.lblErrorShortcut.Visible = false;
            // 
            // lblWith
            // 
            this.lblWith.AutoSize = true;
            this.lblWith.BackColor = System.Drawing.Color.Transparent;
            this.lblWith.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblWith.ForeColor = System.Drawing.Color.White;
            this.lblWith.Location = new System.Drawing.Point(448, 29);
            this.lblWith.Name = "lblWith";
            this.lblWith.Size = new System.Drawing.Size(64, 25);
            this.lblWith.TabIndex = 24;
            this.lblWith.Text = "Width:";
            // 
            // lblNum
            // 
            this.lblNum.BackColor = System.Drawing.Color.Transparent;
            this.lblNum.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblNum.ForeColor = System.Drawing.Color.White;
            this.lblNum.Location = new System.Drawing.Point(506, 28);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(35, 25);
            this.lblNum.TabIndex = 25;
            this.lblNum.Text = "6";
            this.lblNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdNumDown
            // 
            this.cmdNumDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.cmdNumDown.BackgroundImage = global::TaskbarGroupsClient.Properties.Resources.NumDown;
            this.cmdNumDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdNumDown.FlatAppearance.BorderSize = 0;
            this.cmdNumDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNumDown.Location = new System.Drawing.Point(514, 56);
            this.cmdNumDown.Name = "cmdNumDown";
            this.cmdNumDown.Size = new System.Drawing.Size(18, 9);
            this.cmdNumDown.TabIndex = 27;
            this.cmdNumDown.UseVisualStyleBackColor = false;
            this.cmdNumDown.Click += new System.EventHandler(this.cmdNumDown_Click);
            // 
            // cmdNumUp
            // 
            this.cmdNumUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.cmdNumUp.BackgroundImage = global::TaskbarGroupsClient.Properties.Resources.NumUp;
            this.cmdNumUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdNumUp.FlatAppearance.BorderSize = 0;
            this.cmdNumUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNumUp.Location = new System.Drawing.Point(514, 19);
            this.cmdNumUp.Name = "cmdNumUp";
            this.cmdNumUp.Size = new System.Drawing.Size(18, 9);
            this.cmdNumUp.TabIndex = 28;
            this.cmdNumUp.UseVisualStyleBackColor = false;
            this.cmdNumUp.Click += new System.EventHandler(this.cmdNumUp_Click);
            // 
            // lblErrorNum
            // 
            this.lblErrorNum.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblErrorNum.ForeColor = System.Drawing.Color.Red;
            this.lblErrorNum.Location = new System.Drawing.Point(269, 9);
            this.lblErrorNum.Name = "lblErrorNum";
            this.lblErrorNum.Size = new System.Drawing.Size(241, 19);
            this.lblErrorNum.TabIndex = 29;
            this.lblErrorNum.Text = "Error message";
            this.lblErrorNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblErrorNum.Visible = false;
            // 
            // frmNewGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(589, 583);
            this.Controls.Add(this.lblWith);
            this.Controls.Add(this.lblErrorNum);
            this.Controls.Add(this.cmdNumUp);
            this.Controls.Add(this.cmdNumDown);
            this.Controls.Add(this.lblNum);
            this.Controls.Add(this.lblErrorShortcut);
            this.Controls.Add(this.lblErrorIcon);
            this.Controls.Add(this.lblErrorTitle);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.pnlAddShortcut);
            this.Controls.Add(this.pnlGroupIcon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGroupName);
            this.Name = "frmNewGroup";
            this.Text = "New group";
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddGroupIcon)).EndInit();
            this.pnlGroupIcon.ResumeLayout(false);
            this.pnlGroupIcon.PerformLayout();
            this.pnlAddShortcut.ResumeLayout(false);
            this.pnlAddShortcut.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddShortcut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.Label lblAddGroupIcon;
        private System.Windows.Forms.PictureBox cmdAddGroupIcon;
        private System.Windows.Forms.Label lblAddGroupIconDesc;
        private System.Windows.Forms.Label lblAddShortcut;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlGroupIcon;
        private System.Windows.Forms.Panel pnlAddShortcut;
        private System.Windows.Forms.PictureBox cmdAddShortcut;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Label lblErrorTitle;
        private System.Windows.Forms.Label lblErrorIcon;
        private System.Windows.Forms.Label lblErrorShortcut;
        private System.Windows.Forms.Label lblErrorMaxShortcuts;
        private System.Windows.Forms.Label lblWith;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.Button cmdNumDown;
        private System.Windows.Forms.Button cmdNumUp;
        private System.Windows.Forms.Label lblErrorNum;
    }
}