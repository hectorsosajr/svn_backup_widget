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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileGeneratorDialog));
            this.lsvRepositories = new System.Windows.Forms.ListView();
            this.imgSmall = new System.Windows.Forms.ImageList(this.components);
            this.btnGenerate = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lsvRepositories
            // 
            this.lsvRepositories.CheckBoxes = true;
            this.lsvRepositories.FullRowSelect = true;
            this.lsvRepositories.Location = new System.Drawing.Point(13, 43);
            this.lsvRepositories.Name = "lsvRepositories";
            this.lsvRepositories.Size = new System.Drawing.Size(426, 123);
            this.lsvRepositories.SmallImageList = this.imgSmall;
            this.lsvRepositories.TabIndex = 0;
            this.lsvRepositories.UseCompatibleStateImageBehavior = false;
            this.lsvRepositories.View = System.Windows.Forms.View.List;
            // 
            // imgSmall
            // 
            this.imgSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgSmall.ImageStream")));
            this.imgSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imgSmall.Images.SetKeyName(0, "SmallFolder.ico");
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(261, 190);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(128, 44);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Generate Profiles";
            this.btnGenerate.UseVisualStyleBackColor = true;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(13, 20);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(131, 17);
            this.chkAll.TabIndex = 2;
            this.chkAll.Text = "Select All Repositories";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(83, 190);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(128, 44);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ProfileGeneratorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(451, 246);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lsvRepositories);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProfileGeneratorDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto Profile Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lsvRepositories;
        private System.Windows.Forms.ImageList imgSmall;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Button btnClose;

    }
}