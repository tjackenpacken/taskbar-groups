namespace client.User_controls
{
    partial class ucProgramShortcut
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
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdNumUp = new System.Windows.Forms.Button();
            this.cmdNumDown = new System.Windows.Forms.Button();
            this.picShortcut = new System.Windows.Forms.PictureBox();
            this.txtShortcutName = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picShortcut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.cmdDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.cmdDelete.FlatAppearance.BorderSize = 0;
            this.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDelete.ForeColor = System.Drawing.Color.White;
            this.cmdDelete.Location = new System.Drawing.Point(362, 11);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(83, 27);
            this.cmdDelete.TabIndex = 21;
            this.cmdDelete.Text = "Delete Group";
            this.cmdDelete.UseVisualStyleBackColor = false;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            this.cmdDelete.MouseEnter += new System.EventHandler(this.ucProgramShortcut_MouseEnter);
            this.cmdDelete.MouseLeave += new System.EventHandler(this.ucProgramShortcut_MouseLeave);
            // 
            // cmdNumUp
            // 
            this.cmdNumUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.cmdNumUp.BackgroundImage = global::client.Properties.Resources.NumUpWhite;
            this.cmdNumUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdNumUp.FlatAppearance.BorderSize = 0;
            this.cmdNumUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNumUp.Location = new System.Drawing.Point(16, 12);
            this.cmdNumUp.Name = "cmdNumUp";
            this.cmdNumUp.Size = new System.Drawing.Size(14, 7);
            this.cmdNumUp.TabIndex = 30;
            this.cmdNumUp.UseVisualStyleBackColor = false;
            this.cmdNumUp.Click += new System.EventHandler(this.cmdNumUp_Click);
            this.cmdNumUp.MouseEnter += new System.EventHandler(this.ucProgramShortcut_MouseEnter);
            this.cmdNumUp.MouseLeave += new System.EventHandler(this.ucProgramShortcut_MouseLeave);
            // 
            // cmdNumDown
            // 
            this.cmdNumDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.cmdNumDown.BackgroundImage = global::client.Properties.Resources.NumDownWhite;
            this.cmdNumDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdNumDown.FlatAppearance.BorderSize = 0;
            this.cmdNumDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNumDown.Location = new System.Drawing.Point(16, 30);
            this.cmdNumDown.Name = "cmdNumDown";
            this.cmdNumDown.Size = new System.Drawing.Size(14, 7);
            this.cmdNumDown.TabIndex = 29;
            this.cmdNumDown.UseVisualStyleBackColor = false;
            this.cmdNumDown.Click += new System.EventHandler(this.cmdNumDown_Click);
            this.cmdNumDown.MouseEnter += new System.EventHandler(this.ucProgramShortcut_MouseEnter);
            this.cmdNumDown.MouseLeave += new System.EventHandler(this.ucProgramShortcut_MouseLeave);
            // 
            // picShortcut
            // 
            this.picShortcut.BackgroundImage = global::client.Properties.Resources.AddWhite;
            this.picShortcut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picShortcut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picShortcut.Location = new System.Drawing.Point(69, 9);
            this.picShortcut.Margin = new System.Windows.Forms.Padding(30, 30, 10, 30);
            this.picShortcut.Name = "picShortcut";
            this.picShortcut.Size = new System.Drawing.Size(30, 30);
            this.picShortcut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picShortcut.TabIndex = 17;
            this.picShortcut.TabStop = false;
            this.picShortcut.BackgroundImageChanged += new System.EventHandler(this.picShortcut_BackgroundImageChanged);
            this.picShortcut.Click += new System.EventHandler(this.picShortcut_Click);
            this.picShortcut.DragDrop += new System.Windows.Forms.DragEventHandler(this.picShortcut_DragDrop);
            this.picShortcut.DragEnter += new System.Windows.Forms.DragEventHandler(this.picShortcut_DragEnter);
            // 
            // txtShortcutName
            // 
            this.txtShortcutName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtShortcutName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.txtShortcutName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtShortcutName.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtShortcutName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtShortcutName.ForeColor = System.Drawing.Color.White;
            this.txtShortcutName.Location = new System.Drawing.Point(112, 13);
            this.txtShortcutName.Name = "txtShortcutName";
            this.txtShortcutName.Size = new System.Drawing.Size(205, 22);
            this.txtShortcutName.TabIndex = 31;
            this.txtShortcutName.TabStop = false;
            this.txtShortcutName.Text = "Program Name";
            this.txtShortcutName.Click += new System.EventHandler(this.txtShortcutName_Click);
            this.txtShortcutName.TextChanged += new System.EventHandler(this.lbTextbox_TextChanged);
            this.txtShortcutName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ucProgramShortcut_KeyDown);
            this.txtShortcutName.MouseEnter += new System.EventHandler(this.ucProgramShortcut_MouseEnter);
            this.txtShortcutName.MouseLeave += new System.EventHandler(this.ucProgramShortcut_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::client.Properties.Resources.pencil;
            this.pictureBox1.Location = new System.Drawing.Point(338, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.ucProgramShortcut_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.ucProgramShortcut_MouseLeave);
            // 
            // ucProgramShortcut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.Controls.Add(this.picShortcut);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtShortcutName);
            this.Controls.Add(this.cmdNumUp);
            this.Controls.Add(this.cmdNumDown);
            this.Controls.Add(this.cmdDelete);
            this.DoubleBuffered = true;
            this.Name = "ucProgramShortcut";
            this.Size = new System.Drawing.Size(467, 50);
            this.Load += new System.EventHandler(this.ucProgramShortcut_Load);
            this.SizeChanged += new System.EventHandler(this.ucProgramShortcut_SizeChanged);
            this.Click += new System.EventHandler(this.ucProgramShortcut_Click);
            this.MouseEnter += new System.EventHandler(this.ucProgramShortcut_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ucProgramShortcut_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.picShortcut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picShortcut;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdNumUp;
        private System.Windows.Forms.Button cmdNumDown;
        private System.Windows.Forms.TextBox txtShortcutName;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
