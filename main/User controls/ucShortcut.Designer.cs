namespace client.User_controls
{
    partial class ucShortcut
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
            this.picIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // picIcon
            // 
            this.picIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picIcon.Location = new System.Drawing.Point(16, 11);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(23, 23);
            this.picIcon.TabIndex = 0;
            this.picIcon.TabStop = false;
            this.picIcon.Click += new System.EventHandler(this.ucShortcut_Click);
            this.picIcon.MouseEnter += new System.EventHandler(this.ucShortcut_MouseEnter);
            this.picIcon.MouseLeave += new System.EventHandler(this.ucShortcut_MouseLeave);
            // 
            // ucShortcut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.picIcon);
            this.Name = "ucShortcut";
            this.Size = new System.Drawing.Size(55, 45);
            this.Load += new System.EventHandler(this.ucShortcut_Load);
            this.Click += new System.EventHandler(this.ucShortcut_Click);
            this.MouseEnter += new System.EventHandler(this.ucShortcut_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ucShortcut_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picIcon;
    }
}
