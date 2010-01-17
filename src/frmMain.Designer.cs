namespace SVN_Backup_Widget
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.imgIcons = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picSvrStatus = new System.Windows.Forms.PictureBox();
            this.lnkServer = new System.Windows.Forms.LinkLabel();
            this.grpProfiles = new System.Windows.Forms.GroupBox();
            this.btnBrowseBase = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBaseFile = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRevisions = new System.Windows.Forms.TextBox();
            this.chkIncremental = new System.Windows.Forms.CheckBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDumpDir = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilePattern = new System.Windows.Forms.TextBox();
            this.cboRepos = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.cboProfiles = new System.Windows.Forms.ComboBox();
            this.fbdDumpDir = new System.Windows.Forms.FolderBrowserDialog();
            this.textboxProvider1 = new XPControls.TextboxProvider();
            this.ttGeneral = new System.Windows.Forms.ToolTip(this.components);
            this.lnkSupport = new System.Windows.Forms.LinkLabel();
            this.lnkFeatures = new System.Windows.Forms.LinkLabel();
            this.btnAutoGenerate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSvrStatus)).BeginInit();
            this.grpProfiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgIcons
            // 
            this.imgIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgIcons.ImageStream")));
            this.imgIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imgIcons.Images.SetKeyName(0, "error_16x16.gif");
            this.imgIcons.Images.SetKeyName(1, "ok_16x16.gif");
            this.imgIcons.Images.SetKeyName(2, "SmallRepositories.ico");
            this.imgIcons.Images.SetKeyName(3, "SmallServer_vista.ico");
            this.imgIcons.Images.SetKeyName(4, "dbrun_16x16.gif");
            this.imgIcons.Images.SetKeyName(5, "dbadd_16x16.gif");
            this.imgIcons.Images.SetKeyName(6, "dbdelete_16x16.gif");
            this.imgIcons.Images.SetKeyName(7, "invalid.gif");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(33, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // picSvrStatus
            // 
            this.picSvrStatus.Image = ((System.Drawing.Image)(resources.GetObject("picSvrStatus.Image")));
            this.picSvrStatus.InitialImage = null;
            this.picSvrStatus.Location = new System.Drawing.Point(165, 24);
            this.picSvrStatus.Name = "picSvrStatus";
            this.picSvrStatus.Size = new System.Drawing.Size(16, 16);
            this.picSvrStatus.TabIndex = 2;
            this.picSvrStatus.TabStop = false;
            // 
            // lnkServer
            // 
            this.lnkServer.AutoSize = true;
            this.lnkServer.Location = new System.Drawing.Point(71, 24);
            this.lnkServer.Name = "lnkServer";
            this.lnkServer.Size = new System.Drawing.Size(88, 13);
            this.lnkServer.TabIndex = 3;
            this.lnkServer.TabStop = true;
            this.lnkServer.Text = "Server Properties";
            this.lnkServer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkServer_LinkClicked);
            // 
            // grpProfiles
            // 
            this.grpProfiles.Controls.Add(this.btnBrowseBase);
            this.grpProfiles.Controls.Add(this.label6);
            this.grpProfiles.Controls.Add(this.txtBaseFile);
            this.grpProfiles.Controls.Add(this.btnDelete);
            this.grpProfiles.Controls.Add(this.btnNew);
            this.grpProfiles.Controls.Add(this.label5);
            this.grpProfiles.Controls.Add(this.txtRevisions);
            this.grpProfiles.Controls.Add(this.chkIncremental);
            this.grpProfiles.Controls.Add(this.btnRun);
            this.grpProfiles.Controls.Add(this.btnBrowse);
            this.grpProfiles.Controls.Add(this.label4);
            this.grpProfiles.Controls.Add(this.txtDumpDir);
            this.grpProfiles.Controls.Add(this.lblFileName);
            this.grpProfiles.Controls.Add(this.label3);
            this.grpProfiles.Controls.Add(this.label2);
            this.grpProfiles.Controls.Add(this.label1);
            this.grpProfiles.Controls.Add(this.txtFilePattern);
            this.grpProfiles.Controls.Add(this.cboRepos);
            this.grpProfiles.Controls.Add(this.btnSave);
            this.grpProfiles.Controls.Add(this.cboProfiles);
            this.grpProfiles.Location = new System.Drawing.Point(33, 75);
            this.grpProfiles.Name = "grpProfiles";
            this.grpProfiles.Size = new System.Drawing.Size(363, 465);
            this.grpProfiles.TabIndex = 4;
            this.grpProfiles.TabStop = false;
            this.grpProfiles.Text = "Profiles";
            // 
            // btnBrowseBase
            // 
            this.btnBrowseBase.Enabled = false;
            this.btnBrowseBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseBase.Location = new System.Drawing.Point(326, 383);
            this.btnBrowseBase.Name = "btnBrowseBase";
            this.btnBrowseBase.Size = new System.Drawing.Size(31, 23);
            this.btnBrowseBase.TabIndex = 19;
            this.btnBrowseBase.Text = "...";
            this.btnBrowseBase.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 370);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Base Dump File";
            // 
            // txtBaseFile
            // 
            this.txtBaseFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBaseFile.Enabled = false;
            this.txtBaseFile.Location = new System.Drawing.Point(14, 389);
            this.txtBaseFile.Name = "txtBaseFile";
            this.textboxProvider1.SetRenderTextbox(this.txtBaseFile, true);
            this.txtBaseFile.Size = new System.Drawing.Size(306, 13);
            this.textboxProvider1.SetStyle(this.txtBaseFile, XPControls.Style.Rounded);
            this.txtBaseFile.TabIndex = 17;
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ImageIndex = 6;
            this.btnDelete.ImageList = this.imgIcons;
            this.btnDelete.Location = new System.Drawing.Point(247, 77);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(74, 23);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Enabled = false;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ImageIndex = 5;
            this.btnNew.ImageList = this.imgIcons;
            this.btnNew.Location = new System.Drawing.Point(132, 77);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(69, 23);
            this.btnNew.TabIndex = 15;
            this.btnNew.Text = "New";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(176, 323);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Revisions";
            // 
            // txtRevisions
            // 
            this.txtRevisions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRevisions.Location = new System.Drawing.Point(179, 343);
            this.txtRevisions.Name = "txtRevisions";
            this.textboxProvider1.SetRenderTextbox(this.txtRevisions, true);
            this.txtRevisions.Size = new System.Drawing.Size(142, 13);
            this.textboxProvider1.SetStyle(this.txtRevisions, XPControls.Style.Rounded);
            this.txtRevisions.TabIndex = 13;
            // 
            // chkIncremental
            // 
            this.chkIncremental.AutoSize = true;
            this.chkIncremental.Location = new System.Drawing.Point(15, 339);
            this.chkIncremental.Name = "chkIncremental";
            this.chkIncremental.Size = new System.Drawing.Size(131, 17);
            this.chkIncremental.TabIndex = 12;
            this.chkIncremental.Text = "Incremental Dump File";
            this.chkIncremental.UseVisualStyleBackColor = true;
            this.chkIncremental.CheckedChanged += new System.EventHandler(this.chkIncremental_CheckedChanged);
            // 
            // btnRun
            // 
            this.btnRun.Enabled = false;
            this.btnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.ImageIndex = 4;
            this.btnRun.ImageList = this.imgIcons;
            this.btnRun.Location = new System.Drawing.Point(17, 77);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(64, 23);
            this.btnRun.TabIndex = 11;
            this.btnRun.Text = "Run";
            this.btnRun.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Enabled = false;
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(327, 274);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(31, 23);
            this.btnBrowse.TabIndex = 10;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Dump Directory";
            // 
            // txtDumpDir
            // 
            this.txtDumpDir.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDumpDir.Enabled = false;
            this.txtDumpDir.Location = new System.Drawing.Point(15, 280);
            this.txtDumpDir.Name = "txtDumpDir";
            this.textboxProvider1.SetRenderTextbox(this.txtDumpDir, true);
            this.txtDumpDir.Size = new System.Drawing.Size(306, 13);
            this.textboxProvider1.SetStyle(this.txtDumpDir, XPControls.Style.Rounded);
            this.txtDumpDir.TabIndex = 8;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.Location = new System.Drawing.Point(18, 224);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(210, 16);
            this.lblFileName.TabIndex = 7;
            this.lblFileName.Text = "Dump File Name from Pattern";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "File Name Pattern";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Repositories";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Profile Name";
            // 
            // txtFilePattern
            // 
            this.txtFilePattern.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFilePattern.Enabled = false;
            this.txtFilePattern.Location = new System.Drawing.Point(15, 190);
            this.txtFilePattern.Name = "txtFilePattern";
            this.textboxProvider1.SetRenderTextbox(this.txtFilePattern, true);
            this.txtFilePattern.Size = new System.Drawing.Size(306, 13);
            this.textboxProvider1.SetStyle(this.txtFilePattern, XPControls.Style.Rounded);
            this.txtFilePattern.TabIndex = 3;
            this.txtFilePattern.Text = "[REPOSITORYNAME][DATE:yyyyMMdd].svndump";
            this.txtFilePattern.TextChanged += new System.EventHandler(this.txtFileName_TextChanged);
            this.txtFilePattern.Leave += new System.EventHandler(this.txtFilePattern_Leave);
            // 
            // cboRepos
            // 
            this.cboRepos.Enabled = false;
            this.cboRepos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboRepos.FormattingEnabled = true;
            this.cboRepos.Location = new System.Drawing.Point(15, 139);
            this.cboRepos.Name = "cboRepos";
            this.textboxProvider1.SetRenderTextbox(this.cboRepos, true);
            this.cboRepos.Size = new System.Drawing.Size(306, 21);
            this.textboxProvider1.SetStyle(this.cboRepos, XPControls.Style.Rounded);
            this.cboRepos.TabIndex = 2;
            this.cboRepos.SelectedIndexChanged += new System.EventHandler(this.cboRepos_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(132, 426);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cboProfiles
            // 
            this.cboProfiles.Enabled = false;
            this.cboProfiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboProfiles.FormattingEnabled = true;
            this.cboProfiles.Location = new System.Drawing.Point(14, 38);
            this.cboProfiles.Name = "cboProfiles";
            this.textboxProvider1.SetRenderTextbox(this.cboProfiles, true);
            this.cboProfiles.Size = new System.Drawing.Size(306, 21);
            this.textboxProvider1.SetStyle(this.cboProfiles, XPControls.Style.Rounded);
            this.cboProfiles.TabIndex = 0;
            this.cboProfiles.SelectedIndexChanged += new System.EventHandler(this.cboProfiles_SelectedIndexChanged);
            // 
            // lnkSupport
            // 
            this.lnkSupport.AutoSize = true;
            this.lnkSupport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkSupport.Image = ((System.Drawing.Image)(resources.GetObject("lnkSupport.Image")));
            this.lnkSupport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkSupport.Location = new System.Drawing.Point(68, 565);
            this.lnkSupport.Name = "lnkSupport";
            this.lnkSupport.Size = new System.Drawing.Size(82, 17);
            this.lnkSupport.TabIndex = 5;
            this.lnkSupport.TabStop = true;
            this.lnkSupport.Text = "      Support";
            this.lnkSupport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkSupport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSupport_LinkClicked);
            // 
            // lnkFeatures
            // 
            this.lnkFeatures.AutoSize = true;
            this.lnkFeatures.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkFeatures.Image = ((System.Drawing.Image)(resources.GetObject("lnkFeatures.Image")));
            this.lnkFeatures.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkFeatures.Location = new System.Drawing.Point(209, 565);
            this.lnkFeatures.Name = "lnkFeatures";
            this.lnkFeatures.Size = new System.Drawing.Size(145, 17);
            this.lnkFeatures.TabIndex = 6;
            this.lnkFeatures.TabStop = true;
            this.lnkFeatures.Text = "      Feature Requests";
            this.lnkFeatures.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkFeatures.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkFeatures_LinkClicked);
            // 
            // btnAutoGenerate
            // 
            this.btnAutoGenerate.Location = new System.Drawing.Point(236, 21);
            this.btnAutoGenerate.Name = "btnAutoGenerate";
            this.btnAutoGenerate.Size = new System.Drawing.Size(143, 23);
            this.btnAutoGenerate.TabIndex = 7;
            this.btnAutoGenerate.Text = "Auto Generate Profiles";
            this.btnAutoGenerate.UseVisualStyleBackColor = true;
            this.btnAutoGenerate.Click += new System.EventHandler(this.btnAutoGenerate_Click);
            // 
            // frmMain
            // 
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(423, 591);
            this.Controls.Add(this.btnAutoGenerate);
            this.Controls.Add(this.lnkFeatures);
            this.Controls.Add(this.lnkSupport);
            this.Controls.Add(this.grpProfiles);
            this.Controls.Add(this.lnkServer);
            this.Controls.Add(this.picSvrStatus);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SVN Backup Widget - 1.3.0";
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSvrStatus)).EndInit();
            this.grpProfiles.ResumeLayout(false);
            this.grpProfiles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imgIcons;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picSvrStatus;
        private System.Windows.Forms.LinkLabel lnkServer;
        private System.Windows.Forms.GroupBox grpProfiles;
        private System.Windows.Forms.ComboBox cboProfiles;
        private System.Windows.Forms.ComboBox cboRepos;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtFilePattern;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDumpDir;
        private System.Windows.Forms.FolderBrowserDialog fbdDumpDir;
        private XPControls.TextboxProvider textboxProvider1;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRevisions;
        private System.Windows.Forms.CheckBox chkIncremental;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ToolTip ttGeneral;
        private System.Windows.Forms.LinkLabel lnkSupport;
        private System.Windows.Forms.LinkLabel lnkFeatures;
        private System.Windows.Forms.Button btnBrowseBase;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBaseFile;
        private System.Windows.Forms.Button btnAutoGenerate;
    }
}