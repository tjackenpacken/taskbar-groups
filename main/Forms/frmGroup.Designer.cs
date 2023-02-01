namespace client.Forms
{
    partial class frmGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGroup));
            this.lblWith = new System.Windows.Forms.Label();
            this.lblErrorNum = new System.Windows.Forms.Label();
            this.lblNum = new System.Windows.Forms.Label();
            this.lblErrorIcon = new System.Windows.Forms.Label();
            this.lblErrorTitle = new System.Windows.Forms.Label();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.pnlGroupIcon = new System.Windows.Forms.Panel();
            this.cmdAddGroupIcon = new System.Windows.Forms.PictureBox();
            this.lblAddGroupIcon = new System.Windows.Forms.Label();
            this.lblAddGroupIconDesc = new System.Windows.Forms.Label();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.pnlAddShortcut = new System.Windows.Forms.Panel();
            this.cmdAddShortcut = new System.Windows.Forms.PictureBox();
            this.lblErrorShortcut = new System.Windows.Forms.Label();
            this.lblAddShortcut = new System.Windows.Forms.Label();
            this.pnlColor = new System.Windows.Forms.Panel();
            this.pnlCustomColor1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.numOpacDown = new System.Windows.Forms.Button();
            this.numOpacUp = new System.Windows.Forms.Button();
            this.lblPercent = new System.Windows.Forms.Label();
            this.pnlAllowOpenAll = new System.Windows.Forms.CheckBox();
            this.lblOpacityTooltip = new System.Windows.Forms.Label();
            this.lblOpacity = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlCustomColor = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioCustom = new System.Windows.Forms.RadioButton();
            this.radioDark = new System.Windows.Forms.RadioButton();
            this.radioLight = new System.Windows.Forms.RadioButton();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.pnlEnd = new System.Windows.Forms.Panel();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.pnlArguments = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdSelectDirectory = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlWorkingDirectory = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlArgumentTextbox = new System.Windows.Forms.TextBox();
            this.cmdWidthDown = new System.Windows.Forms.Button();
            this.cmdWidthUp = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnlDeleteConfo = new System.Windows.Forms.Panel();
            this.confirmDelete = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlShortcuts = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlGroupIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddGroupIcon)).BeginInit();
            this.pnlAddShortcut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddShortcut)).BeginInit();
            this.pnlColor.SuspendLayout();
            this.pnlCustomColor1.SuspendLayout();
            this.pnlCustomColor.SuspendLayout();
            this.pnlEnd.SuspendLayout();
            this.pnlArguments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlDeleteConfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWith
            // 
            this.lblWith.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWith.AutoSize = true;
            this.lblWith.BackColor = System.Drawing.Color.Transparent;
            this.lblWith.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblWith.ForeColor = System.Drawing.Color.White;
            this.lblWith.Location = new System.Drawing.Point(416, 23);
            this.lblWith.Name = "lblWith";
            this.lblWith.Size = new System.Drawing.Size(64, 25);
            this.lblWith.TabIndex = 40;
            this.lblWith.Text = "Width:";
            // 
            // lblErrorNum
            // 
            this.lblErrorNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblErrorNum.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblErrorNum.ForeColor = System.Drawing.Color.Red;
            this.lblErrorNum.Location = new System.Drawing.Point(237, 3);
            this.lblErrorNum.Name = "lblErrorNum";
            this.lblErrorNum.Size = new System.Drawing.Size(241, 19);
            this.lblErrorNum.TabIndex = 44;
            this.lblErrorNum.Text = "Error message";
            this.lblErrorNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblErrorNum.Visible = false;
            // 
            // lblNum
            // 
            this.lblNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNum.BackColor = System.Drawing.Color.Transparent;
            this.lblNum.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblNum.ForeColor = System.Drawing.Color.White;
            this.lblNum.Location = new System.Drawing.Point(474, 23);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(35, 25);
            this.lblNum.TabIndex = 41;
            this.lblNum.Text = "6";
            this.lblNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblErrorIcon
            // 
            this.lblErrorIcon.AutoSize = true;
            this.lblErrorIcon.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblErrorIcon.ForeColor = System.Drawing.Color.Red;
            this.lblErrorIcon.Location = new System.Drawing.Point(155, 76);
            this.lblErrorIcon.Name = "lblErrorIcon";
            this.lblErrorIcon.Size = new System.Drawing.Size(96, 19);
            this.lblErrorIcon.TabIndex = 38;
            this.lblErrorIcon.Text = "Error message";
            this.lblErrorIcon.Visible = false;
            // 
            // lblErrorTitle
            // 
            this.lblErrorTitle.AutoSize = true;
            this.lblErrorTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblErrorTitle.ForeColor = System.Drawing.Color.Red;
            this.lblErrorTitle.Location = new System.Drawing.Point(52, 9);
            this.lblErrorTitle.Name = "lblErrorTitle";
            this.lblErrorTitle.Size = new System.Drawing.Size(96, 19);
            this.lblErrorTitle.TabIndex = 37;
            this.lblErrorTitle.Text = "Error message";
            this.lblErrorTitle.Visible = false;
            // 
            // cmdSave
            // 
            this.cmdSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.cmdSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.cmdSave.FlatAppearance.BorderSize = 0;
            this.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.ForeColor = System.Drawing.Color.White;
            this.cmdSave.Location = new System.Drawing.Point(36, 7);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(129, 30);
            this.cmdSave.TabIndex = 36;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = false;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.cmdExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.cmdExit.FlatAppearance.BorderSize = 0;
            this.cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdExit.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExit.ForeColor = System.Drawing.Color.White;
            this.cmdExit.Location = new System.Drawing.Point(179, 7);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(129, 30);
            this.cmdExit.TabIndex = 35;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = false;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // pnlGroupIcon
            // 
            this.pnlGroupIcon.AllowDrop = true;
            this.pnlGroupIcon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGroupIcon.AutoSize = true;
            this.pnlGroupIcon.Controls.Add(this.cmdAddGroupIcon);
            this.pnlGroupIcon.Controls.Add(this.lblAddGroupIcon);
            this.pnlGroupIcon.Controls.Add(this.lblAddGroupIconDesc);
            this.pnlGroupIcon.Location = new System.Drawing.Point(57, 83);
            this.pnlGroupIcon.Name = "pnlGroupIcon";
            this.pnlGroupIcon.Size = new System.Drawing.Size(466, 102);
            this.pnlGroupIcon.TabIndex = 33;
            this.pnlGroupIcon.Click += new System.EventHandler(this.cmdAddGroupIcon_Click);
            this.pnlGroupIcon.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlDragDropImg);
            this.pnlGroupIcon.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlDragDropEnterImg);
            this.pnlGroupIcon.DragLeave += new System.EventHandler(this.pnlGroupIcon_MouseLeave);
            this.pnlGroupIcon.MouseEnter += new System.EventHandler(this.pnlGroupIcon_MouseEnter);
            this.pnlGroupIcon.MouseLeave += new System.EventHandler(this.pnlGroupIcon_MouseLeave);
            // 
            // cmdAddGroupIcon
            // 
            this.cmdAddGroupIcon.BackgroundImage = global::client.Properties.Resources.AddWhite;
            this.cmdAddGroupIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdAddGroupIcon.Location = new System.Drawing.Point(31, 12);
            this.cmdAddGroupIcon.Margin = new System.Windows.Forms.Padding(30, 30, 10, 30);
            this.cmdAddGroupIcon.Name = "cmdAddGroupIcon";
            this.cmdAddGroupIcon.Size = new System.Drawing.Size(60, 60);
            this.cmdAddGroupIcon.TabIndex = 10;
            this.cmdAddGroupIcon.TabStop = false;
            this.cmdAddGroupIcon.Tag = "Unchanged";
            this.cmdAddGroupIcon.BackgroundImageChanged += new System.EventHandler(this.cmdAddGroupIcon_BackgroundImageChanged);
            this.cmdAddGroupIcon.Click += new System.EventHandler(this.cmdAddGroupIcon_Click);
            this.cmdAddGroupIcon.MouseEnter += new System.EventHandler(this.pnlGroupIcon_MouseEnter);
            this.cmdAddGroupIcon.MouseLeave += new System.EventHandler(this.pnlGroupIcon_MouseLeave);
            // 
            // lblAddGroupIcon
            // 
            this.lblAddGroupIcon.AutoSize = true;
            this.lblAddGroupIcon.BackColor = System.Drawing.Color.Transparent;
            this.lblAddGroupIcon.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddGroupIcon.ForeColor = System.Drawing.Color.White;
            this.lblAddGroupIcon.Location = new System.Drawing.Point(104, 15);
            this.lblAddGroupIcon.Name = "lblAddGroupIcon";
            this.lblAddGroupIcon.Size = new System.Drawing.Size(190, 30);
            this.lblAddGroupIcon.TabIndex = 11;
            this.lblAddGroupIcon.Text = "Change group icon";
            this.lblAddGroupIcon.Click += new System.EventHandler(this.cmdAddGroupIcon_Click);
            this.lblAddGroupIcon.MouseEnter += new System.EventHandler(this.pnlGroupIcon_MouseEnter);
            this.lblAddGroupIcon.MouseLeave += new System.EventHandler(this.pnlGroupIcon_MouseLeave);
            // 
            // lblAddGroupIconDesc
            // 
            this.lblAddGroupIconDesc.AutoSize = true;
            this.lblAddGroupIconDesc.BackColor = System.Drawing.Color.Transparent;
            this.lblAddGroupIconDesc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddGroupIconDesc.ForeColor = System.Drawing.Color.White;
            this.lblAddGroupIconDesc.Location = new System.Drawing.Point(107, 46);
            this.lblAddGroupIconDesc.Name = "lblAddGroupIconDesc";
            this.lblAddGroupIconDesc.Size = new System.Drawing.Size(245, 17);
            this.lblAddGroupIconDesc.TabIndex = 12;
            this.lblAddGroupIconDesc.Text = "Select the icon that shows in the taskbar ";
            this.lblAddGroupIconDesc.Click += new System.EventHandler(this.cmdAddGroupIcon_Click);
            this.lblAddGroupIconDesc.MouseEnter += new System.EventHandler(this.pnlGroupIcon_MouseEnter);
            this.lblAddGroupIconDesc.MouseLeave += new System.EventHandler(this.pnlGroupIcon_MouseLeave);
            // 
            // txtGroupName
            // 
            this.txtGroupName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.txtGroupName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGroupName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGroupName.ForeColor = System.Drawing.Color.White;
            this.txtGroupName.Location = new System.Drawing.Point(56, 29);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(395, 32);
            this.txtGroupName.TabIndex = 30;
            this.txtGroupName.TabStop = false;
            this.txtGroupName.Text = "Name the new group...";
            this.txtGroupName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtGroupName_MouseClick);
            this.txtGroupName.TextChanged += new System.EventHandler(this.txtGroupName_TextChanged);
            this.txtGroupName.Leave += new System.EventHandler(this.txtGroupName_Leave);
            // 
            // pnlAddShortcut
            // 
            this.pnlAddShortcut.AllowDrop = true;
            this.pnlAddShortcut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAddShortcut.AutoSize = true;
            this.pnlAddShortcut.Controls.Add(this.cmdAddShortcut);
            this.pnlAddShortcut.Controls.Add(this.lblErrorShortcut);
            this.pnlAddShortcut.Controls.Add(this.lblAddShortcut);
            this.pnlAddShortcut.Location = new System.Drawing.Point(57, 237);
            this.pnlAddShortcut.Name = "pnlAddShortcut";
            this.pnlAddShortcut.Size = new System.Drawing.Size(466, 81);
            this.pnlAddShortcut.TabIndex = 45;
            this.pnlAddShortcut.Click += new System.EventHandler(this.pnlAddShortcut_Click);
            this.pnlAddShortcut.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlDragDropExt);
            this.pnlAddShortcut.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlDragDropEnterExt);
            this.pnlAddShortcut.DragLeave += new System.EventHandler(this.pnlAddShortcut_MouseLeave);
            this.pnlAddShortcut.MouseEnter += new System.EventHandler(this.pnlAddShortcut_MouseEnter);
            this.pnlAddShortcut.MouseLeave += new System.EventHandler(this.pnlAddShortcut_MouseLeave);
            // 
            // cmdAddShortcut
            // 
            this.cmdAddShortcut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdAddShortcut.BackgroundImage = global::client.Properties.Resources.AddGray;
            this.cmdAddShortcut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdAddShortcut.Location = new System.Drawing.Point(214, 16);
            this.cmdAddShortcut.Margin = new System.Windows.Forms.Padding(30, 30, 10, 30);
            this.cmdAddShortcut.Name = "cmdAddShortcut";
            this.cmdAddShortcut.Size = new System.Drawing.Size(35, 35);
            this.cmdAddShortcut.TabIndex = 15;
            this.cmdAddShortcut.TabStop = false;
            this.cmdAddShortcut.Click += new System.EventHandler(this.pnlAddShortcut_Click);
            this.cmdAddShortcut.MouseEnter += new System.EventHandler(this.pnlAddShortcut_MouseEnter);
            this.cmdAddShortcut.MouseLeave += new System.EventHandler(this.pnlAddShortcut_MouseLeave);
            // 
            // lblErrorShortcut
            // 
            this.lblErrorShortcut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblErrorShortcut.AutoSize = true;
            this.lblErrorShortcut.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblErrorShortcut.ForeColor = System.Drawing.Color.Red;
            this.lblErrorShortcut.Location = new System.Drawing.Point(186, 51);
            this.lblErrorShortcut.Name = "lblErrorShortcut";
            this.lblErrorShortcut.Size = new System.Drawing.Size(96, 19);
            this.lblErrorShortcut.TabIndex = 23;
            this.lblErrorShortcut.Text = "Error message";
            this.lblErrorShortcut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblErrorShortcut.Visible = false;
            // 
            // lblAddShortcut
            // 
            this.lblAddShortcut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAddShortcut.AutoSize = true;
            this.lblAddShortcut.BackColor = System.Drawing.Color.Transparent;
            this.lblAddShortcut.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddShortcut.ForeColor = System.Drawing.Color.White;
            this.lblAddShortcut.Location = new System.Drawing.Point(182, 51);
            this.lblAddShortcut.Name = "lblAddShortcut";
            this.lblAddShortcut.Size = new System.Drawing.Size(110, 17);
            this.lblAddShortcut.TabIndex = 14;
            this.lblAddShortcut.Text = "Add new shortcut";
            this.lblAddShortcut.Click += new System.EventHandler(this.pnlAddShortcut_Click);
            this.lblAddShortcut.MouseEnter += new System.EventHandler(this.pnlAddShortcut_MouseEnter);
            this.lblAddShortcut.MouseLeave += new System.EventHandler(this.pnlAddShortcut_MouseLeave);
            // 
            // pnlColor
            // 
            this.pnlColor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlColor.AutoSize = true;
            this.pnlColor.Controls.Add(this.pnlCustomColor1);
            this.pnlColor.Controls.Add(this.numOpacDown);
            this.pnlColor.Controls.Add(this.numOpacUp);
            this.pnlColor.Controls.Add(this.lblPercent);
            this.pnlColor.Controls.Add(this.pnlAllowOpenAll);
            this.pnlColor.Controls.Add(this.lblOpacityTooltip);
            this.pnlColor.Controls.Add(this.lblOpacity);
            this.pnlColor.Controls.Add(this.label1);
            this.pnlColor.Controls.Add(this.pnlCustomColor);
            this.pnlColor.Controls.Add(this.radioCustom);
            this.pnlColor.Controls.Add(this.radioDark);
            this.pnlColor.Controls.Add(this.radioLight);
            this.pnlColor.Location = new System.Drawing.Point(99, 578);
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Size = new System.Drawing.Size(368, 164);
            this.pnlColor.TabIndex = 48;
            // 
            // pnlCustomColor1
            // 
            this.pnlCustomColor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCustomColor1.Controls.Add(this.panel3);
            this.pnlCustomColor1.Location = new System.Drawing.Point(254, 75);
            this.pnlCustomColor1.Name = "pnlCustomColor1";
            this.pnlCustomColor1.Size = new System.Drawing.Size(15, 15);
            this.pnlCustomColor1.TabIndex = 5;
            this.pnlCustomColor1.Click += new System.EventHandler(this.pnlCustomColor1_Click);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(34, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(15, 15);
            this.panel3.TabIndex = 4;
            // 
            // numOpacDown
            // 
            this.numOpacDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.numOpacDown.BackgroundImage = global::client.Properties.Resources.NumDownWhite;
            this.numOpacDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.numOpacDown.FlatAppearance.BorderSize = 0;
            this.numOpacDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.numOpacDown.Location = new System.Drawing.Point(258, 115);
            this.numOpacDown.Name = "numOpacDown";
            this.numOpacDown.Size = new System.Drawing.Size(16, 8);
            this.numOpacDown.TabIndex = 49;
            this.numOpacDown.UseVisualStyleBackColor = false;
            this.numOpacDown.Click += new System.EventHandler(this.numOpacDown_Click);
            // 
            // numOpacUp
            // 
            this.numOpacUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.numOpacUp.BackgroundImage = global::client.Properties.Resources.NumUpWhite;
            this.numOpacUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.numOpacUp.FlatAppearance.BorderSize = 0;
            this.numOpacUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.numOpacUp.Location = new System.Drawing.Point(258, 101);
            this.numOpacUp.Name = "numOpacUp";
            this.numOpacUp.Size = new System.Drawing.Size(16, 8);
            this.numOpacUp.TabIndex = 50;
            this.numOpacUp.UseVisualStyleBackColor = false;
            this.numOpacUp.Click += new System.EventHandler(this.numOpacUp_Click);
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lblPercent.ForeColor = System.Drawing.Color.White;
            this.lblPercent.Location = new System.Drawing.Point(224, 102);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(21, 20);
            this.lblPercent.TabIndex = 5;
            this.lblPercent.Text = "%";
            // 
            // pnlAllowOpenAll
            // 
            this.pnlAllowOpenAll.AutoSize = true;
            this.pnlAllowOpenAll.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.pnlAllowOpenAll.ForeColor = System.Drawing.Color.White;
            this.pnlAllowOpenAll.Location = new System.Drawing.Point(72, 131);
            this.pnlAllowOpenAll.Name = "pnlAllowOpenAll";
            this.pnlAllowOpenAll.Size = new System.Drawing.Size(278, 24);
            this.pnlAllowOpenAll.TabIndex = 49;
            this.pnlAllowOpenAll.Text = "Allow open-all shortcuts (Ctrl + Enter)";
            this.pnlAllowOpenAll.UseVisualStyleBackColor = true;
            this.pnlAllowOpenAll.CheckedChanged += new System.EventHandler(this.pnlAllowOpenAll_CheckedChanged);
            // 
            // lblOpacityTooltip
            // 
            this.lblOpacityTooltip.AutoSize = true;
            this.lblOpacityTooltip.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lblOpacityTooltip.ForeColor = System.Drawing.Color.White;
            this.lblOpacityTooltip.Location = new System.Drawing.Point(135, 101);
            this.lblOpacityTooltip.Name = "lblOpacityTooltip";
            this.lblOpacityTooltip.Size = new System.Drawing.Size(63, 20);
            this.lblOpacityTooltip.TabIndex = 4;
            this.lblOpacityTooltip.Text = "Opacity:";
            // 
            // lblOpacity
            // 
            this.lblOpacity.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lblOpacity.ForeColor = System.Drawing.Color.White;
            this.lblOpacity.Location = new System.Drawing.Point(193, 102);
            this.lblOpacity.Name = "lblOpacity";
            this.lblOpacity.Size = new System.Drawing.Size(35, 20);
            this.lblOpacity.TabIndex = 50;
            this.lblOpacity.Text = "10";
            this.lblOpacity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.label1.Location = new System.Drawing.Point(197, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 1);
            this.label1.TabIndex = 49;
            // 
            // pnlCustomColor
            // 
            this.pnlCustomColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCustomColor.Controls.Add(this.panel1);
            this.pnlCustomColor.Location = new System.Drawing.Point(231, 75);
            this.pnlCustomColor.Name = "pnlCustomColor";
            this.pnlCustomColor.Size = new System.Drawing.Size(15, 15);
            this.pnlCustomColor.TabIndex = 3;
            this.pnlCustomColor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioCustom_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(34, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(15, 15);
            this.panel1.TabIndex = 4;
            // 
            // radioCustom
            // 
            this.radioCustom.AutoSize = true;
            this.radioCustom.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioCustom.ForeColor = System.Drawing.Color.White;
            this.radioCustom.Location = new System.Drawing.Point(112, 69);
            this.radioCustom.Name = "radioCustom";
            this.radioCustom.Size = new System.Drawing.Size(115, 24);
            this.radioCustom.TabIndex = 2;
            this.radioCustom.TabStop = true;
            this.radioCustom.Text = "Custom color";
            this.radioCustom.UseVisualStyleBackColor = true;
            this.radioCustom.Click += new System.EventHandler(this.radioCustom_Click);
            // 
            // radioDark
            // 
            this.radioDark.AutoSize = true;
            this.radioDark.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioDark.ForeColor = System.Drawing.Color.White;
            this.radioDark.Location = new System.Drawing.Point(143, 9);
            this.radioDark.Name = "radioDark";
            this.radioDark.Size = new System.Drawing.Size(96, 24);
            this.radioDark.TabIndex = 1;
            this.radioDark.TabStop = true;
            this.radioDark.Text = "Dark color";
            this.radioDark.UseVisualStyleBackColor = true;
            this.radioDark.Click += new System.EventHandler(this.radioDark_Click);
            // 
            // radioLight
            // 
            this.radioLight.AutoSize = true;
            this.radioLight.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioLight.ForeColor = System.Drawing.Color.White;
            this.radioLight.Location = new System.Drawing.Point(143, 39);
            this.radioLight.Name = "radioLight";
            this.radioLight.Size = new System.Drawing.Size(98, 24);
            this.radioLight.TabIndex = 0;
            this.radioLight.TabStop = true;
            this.radioLight.Text = "Light color";
            this.radioLight.UseVisualStyleBackColor = true;
            this.radioLight.Click += new System.EventHandler(this.radioLight_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.cmdDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.cmdDelete.FlatAppearance.BorderSize = 0;
            this.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDelete.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDelete.ForeColor = System.Drawing.Color.White;
            this.cmdDelete.Location = new System.Drawing.Point(321, 7);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(129, 30);
            this.cmdDelete.TabIndex = 46;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = false;
            this.cmdDelete.Click += new System.EventHandler(this.openDeleteConformation);
            // 
            // pnlEnd
            // 
            this.pnlEnd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlEnd.AutoSize = true;
            this.pnlEnd.Controls.Add(this.cmdDelete);
            this.pnlEnd.Controls.Add(this.cmdSave);
            this.pnlEnd.Controls.Add(this.cmdExit);
            this.pnlEnd.Location = new System.Drawing.Point(41, 756);
            this.pnlEnd.Name = "pnlEnd";
            this.pnlEnd.Size = new System.Drawing.Size(482, 44);
            this.pnlEnd.TabIndex = 47;
            // 
            // pnlArguments
            // 
            this.pnlArguments.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlArguments.AutoSize = true;
            this.pnlArguments.Controls.Add(this.label7);
            this.pnlArguments.Controls.Add(this.label6);
            this.pnlArguments.Controls.Add(this.cmdSelectDirectory);
            this.pnlArguments.Controls.Add(this.label5);
            this.pnlArguments.Controls.Add(this.pnlWorkingDirectory);
            this.pnlArguments.Controls.Add(this.label3);
            this.pnlArguments.Controls.Add(this.pnlArgumentTextbox);
            this.pnlArguments.Location = new System.Drawing.Point(34, 581);
            this.pnlArguments.Name = "pnlArguments";
            this.pnlArguments.Size = new System.Drawing.Size(482, 131);
            this.pnlArguments.TabIndex = 48;
            this.pnlArguments.Visible = false;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.label7.Location = new System.Drawing.Point(34, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(440, 1);
            this.label7.TabIndex = 53;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.label6.Location = new System.Drawing.Point(34, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(335, 1);
            this.label6.TabIndex = 50;
            // 
            // cmdSelectDirectory
            // 
            this.cmdSelectDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.cmdSelectDirectory.FlatAppearance.BorderSize = 0;
            this.cmdSelectDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSelectDirectory.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cmdSelectDirectory.ForeColor = System.Drawing.Color.White;
            this.cmdSelectDirectory.Location = new System.Drawing.Point(375, 79);
            this.cmdSelectDirectory.Name = "cmdSelectDirectory";
            this.cmdSelectDirectory.Size = new System.Drawing.Size(97, 27);
            this.cmdSelectDirectory.TabIndex = 52;
            this.cmdSelectDirectory.Text = "Select Directory";
            this.cmdSelectDirectory.UseVisualStyleBackColor = false;
            this.cmdSelectDirectory.Click += new System.EventHandler(this.cmdSelectDirectory_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(31, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 20);
            this.label5.TabIndex = 51;
            this.label5.Text = "Working Directory:";
            // 
            // pnlWorkingDirectory
            // 
            this.pnlWorkingDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.pnlWorkingDirectory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pnlWorkingDirectory.Enabled = false;
            this.pnlWorkingDirectory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.pnlWorkingDirectory.ForeColor = System.Drawing.Color.White;
            this.pnlWorkingDirectory.Location = new System.Drawing.Point(35, 85);
            this.pnlWorkingDirectory.Name = "pnlWorkingDirectory";
            this.pnlWorkingDirectory.Size = new System.Drawing.Size(330, 16);
            this.pnlWorkingDirectory.TabIndex = 50;
            this.pnlWorkingDirectory.TextChanged += new System.EventHandler(this.pnlWorkingDirectory_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(31, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Arguments:";
            // 
            // pnlArgumentTextbox
            // 
            this.pnlArgumentTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.pnlArgumentTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pnlArgumentTextbox.Enabled = false;
            this.pnlArgumentTextbox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.pnlArgumentTextbox.ForeColor = System.Drawing.Color.White;
            this.pnlArgumentTextbox.Location = new System.Drawing.Point(34, 33);
            this.pnlArgumentTextbox.Name = "pnlArgumentTextbox";
            this.pnlArgumentTextbox.Size = new System.Drawing.Size(425, 16);
            this.pnlArgumentTextbox.TabIndex = 0;
            this.pnlArgumentTextbox.TextChanged += new System.EventHandler(this.pnlArgumentTextbox_TextChanged);
            this.pnlArgumentTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pnlArgumentTextbox_KeyDown);
            // 
            // cmdWidthDown
            // 
            this.cmdWidthDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdWidthDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.cmdWidthDown.BackgroundImage = global::client.Properties.Resources.NumDownWhite;
            this.cmdWidthDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdWidthDown.FlatAppearance.BorderSize = 0;
            this.cmdWidthDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdWidthDown.Location = new System.Drawing.Point(483, 51);
            this.cmdWidthDown.Name = "cmdWidthDown";
            this.cmdWidthDown.Size = new System.Drawing.Size(16, 8);
            this.cmdWidthDown.TabIndex = 42;
            this.cmdWidthDown.UseVisualStyleBackColor = false;
            this.cmdWidthDown.Click += new System.EventHandler(this.cmdWidthDown_Click);
            // 
            // cmdWidthUp
            // 
            this.cmdWidthUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdWidthUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.cmdWidthUp.BackgroundImage = global::client.Properties.Resources.NumUpWhite;
            this.cmdWidthUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdWidthUp.FlatAppearance.BorderSize = 0;
            this.cmdWidthUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdWidthUp.Location = new System.Drawing.Point(483, 13);
            this.cmdWidthUp.Name = "cmdWidthUp";
            this.cmdWidthUp.Size = new System.Drawing.Size(16, 8);
            this.cmdWidthUp.TabIndex = 43;
            this.cmdWidthUp.UseVisualStyleBackColor = false;
            this.cmdWidthUp.Click += new System.EventHandler(this.cmdWidthUp_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::client.Properties.Resources.grayline;
            this.pictureBox1.Location = new System.Drawing.Point(56, 74);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(467, 5);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 49;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::client.Properties.Resources.grayline;
            this.pictureBox2.Location = new System.Drawing.Point(56, 180);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(467, 5);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 50;
            this.pictureBox2.TabStop = false;
            // 
            // pnlDeleteConfo
            // 
            this.pnlDeleteConfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pnlDeleteConfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDeleteConfo.Controls.Add(this.confirmDelete);
            this.pnlDeleteConfo.Controls.Add(this.label2);
            this.pnlDeleteConfo.Location = new System.Drawing.Point(163, 395);
            this.pnlDeleteConfo.Name = "pnlDeleteConfo";
            this.pnlDeleteConfo.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.pnlDeleteConfo.Size = new System.Drawing.Size(253, 78);
            this.pnlDeleteConfo.TabIndex = 51;
            this.pnlDeleteConfo.Visible = false;
            // 
            // confirmDelete
            // 
            this.confirmDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.confirmDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.confirmDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.confirmDelete.FlatAppearance.BorderSize = 0;
            this.confirmDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirmDelete.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmDelete.ForeColor = System.Drawing.Color.White;
            this.confirmDelete.Location = new System.Drawing.Point(82, 45);
            this.confirmDelete.Name = "confirmDelete";
            this.confirmDelete.Size = new System.Drawing.Size(99, 25);
            this.confirmDelete.TabIndex = 47;
            this.confirmDelete.Text = "Yes";
            this.confirmDelete.UseVisualStyleBackColor = false;
            this.confirmDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 43);
            this.label2.TabIndex = 0;
            this.label2.Text = "Are you sure you want to delete this group?";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlShortcuts
            // 
            this.pnlShortcuts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlShortcuts.AutoScroll = true;
            this.pnlShortcuts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlShortcuts.Location = new System.Drawing.Point(57, 191);
            this.pnlShortcuts.Name = "pnlShortcuts";
            this.pnlShortcuts.Size = new System.Drawing.Size(489, 40);
            this.pnlShortcuts.TabIndex = 52;
            this.pnlShortcuts.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.pnlShortcuts_ControlAdded);
            // 
            // frmGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(574, 821);
            this.Controls.Add(this.pnlShortcuts);
            this.Controls.Add(this.pnlDeleteConfo);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlArguments);
            this.Controls.Add(this.pnlEnd);
            this.Controls.Add(this.pnlAddShortcut);
            this.Controls.Add(this.pnlColor);
            this.Controls.Add(this.lblWith);
            this.Controls.Add(this.lblErrorNum);
            this.Controls.Add(this.cmdWidthDown);
            this.Controls.Add(this.lblNum);
            this.Controls.Add(this.lblErrorIcon);
            this.Controls.Add(this.lblErrorTitle);
            this.Controls.Add(this.pnlGroupIcon);
            this.Controls.Add(this.cmdWidthUp);
            this.Controls.Add(this.txtGroupName);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(590, 39);
            this.Name = "frmGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New group";
            this.Load += new System.EventHandler(this.frmGroup_Load);
            this.SizeChanged += new System.EventHandler(this.frmGroup_SizeChanged);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.frmGroup_MouseClick);
            this.pnlGroupIcon.ResumeLayout(false);
            this.pnlGroupIcon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddGroupIcon)).EndInit();
            this.pnlAddShortcut.ResumeLayout(false);
            this.pnlAddShortcut.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddShortcut)).EndInit();
            this.pnlColor.ResumeLayout(false);
            this.pnlColor.PerformLayout();
            this.pnlCustomColor1.ResumeLayout(false);
            this.pnlCustomColor.ResumeLayout(false);
            this.pnlEnd.ResumeLayout(false);
            this.pnlArguments.ResumeLayout(false);
            this.pnlArguments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlDeleteConfo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWith;
        private System.Windows.Forms.Label lblErrorNum;
        private System.Windows.Forms.Button cmdWidthDown;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.Label lblErrorIcon;
        private System.Windows.Forms.Label lblErrorTitle;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Panel pnlGroupIcon;
        private System.Windows.Forms.PictureBox cmdAddGroupIcon;
        private System.Windows.Forms.Label lblAddGroupIcon;
        private System.Windows.Forms.Label lblAddGroupIconDesc;
        private System.Windows.Forms.Button cmdWidthUp;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.Panel pnlAddShortcut;
        private System.Windows.Forms.Label lblErrorShortcut;
        private System.Windows.Forms.Label lblAddShortcut;
        private System.Windows.Forms.PictureBox cmdAddShortcut;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Panel pnlEnd;
        private System.Windows.Forms.Panel pnlColor;
        private System.Windows.Forms.RadioButton radioCustom;
        private System.Windows.Forms.RadioButton radioDark;
        private System.Windows.Forms.RadioButton radioLight;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Panel pnlCustomColor;
        private System.Windows.Forms.Label lblOpacityTooltip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.Label lblOpacity;
        private System.Windows.Forms.Button numOpacDown;
        private System.Windows.Forms.Button numOpacUp;
        private System.Windows.Forms.Panel pnlArguments;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pnlArgumentTextbox;
        private System.Windows.Forms.CheckBox pnlAllowOpenAll;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox pnlWorkingDirectory;
        private System.Windows.Forms.Button cmdSelectDirectory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel pnlDeleteConfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button confirmDelete;
        private System.Windows.Forms.Panel pnlCustomColor1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel pnlShortcuts;
    }
}