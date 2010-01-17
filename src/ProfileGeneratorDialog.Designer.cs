namespace SVN_Backup_Widget
{
    partial class ProfileGeneratorDialog
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
            this.chklistRepository = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // chklistRepository
            // 
            this.chklistRepository.FormattingEnabled = true;
            this.chklistRepository.Location = new System.Drawing.Point(13, 36);
            this.chklistRepository.Name = "chklistRepository";
            this.chklistRepository.Size = new System.Drawing.Size(426, 139);
            this.chklistRepository.TabIndex = 0;
            // 
            // ProfileGeneratorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(451, 323);
            this.Controls.Add(this.chklistRepository);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProfileGeneratorDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto Profile Generator";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chklistRepository;
    }
}