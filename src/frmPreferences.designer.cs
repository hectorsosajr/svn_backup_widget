namespace SVN_Backup_Widget
{
    partial class frmPreferences
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
            Skybound.VisualTips.VisualTip visualTip1 = new Skybound.VisualTips.VisualTip();
            Skybound.VisualTips.VisualTip visualTip2 = new Skybound.VisualTips.VisualTip();
            Skybound.VisualTips.VisualTip visualTip3 = new Skybound.VisualTips.VisualTip();
            Skybound.VisualTips.Rendering.VisualTipOfficeRenderer visualTipOfficeRenderer1 = new Skybound.VisualTips.Rendering.VisualTipOfficeRenderer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPreferences));
            Skybound.VisualTips.VisualTip visualTip4 = new Skybound.VisualTips.VisualTip();
            Skybound.VisualTips.VisualTip visualTip5 = new Skybound.VisualTips.VisualTip();
            Skybound.VisualTips.VisualTip visualTip6 = new Skybound.VisualTips.VisualTip();
            this.txtSubversionRoot = new System.Windows.Forms.TextBox();
            this.txtReposRoot = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lnkBrowseSub = new System.Windows.Forms.LinkLabel();
            this.lnkBrowseRepo = new System.Windows.Forms.LinkLabel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.textboxProvider1 = new XPControls.TextboxProvider();
            this.txtCmdRoot = new System.Windows.Forms.TextBox();
            this.txtInstructions = new System.Windows.Forms.TextBox();
            this.lnkBrowsCmd = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.vtpPreferences = new Skybound.VisualTips.VisualTipProvider(this.components);
            this.lstMulti = new System.Windows.Forms.ListBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.rdbMultiFolders = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdbAll = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.fbdRepo = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSubversionRoot
            // 
            this.txtSubversionRoot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSubversionRoot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubversionRoot.Location = new System.Drawing.Point(66, 59);
            this.txtSubversionRoot.Name = "txtSubversionRoot";
            this.textboxProvider1.SetRenderTextbox(this.txtSubversionRoot, true);
            this.txtSubversionRoot.Size = new System.Drawing.Size(262, 13);
            this.textboxProvider1.SetStyle(this.txtSubversionRoot, XPControls.Style.Rounded);
            this.txtSubversionRoot.TabIndex = 1;
            visualTip1.Text = "This is the directory where the Subversion binaries were installed.";
            visualTip1.Title = "Subversion Installation Directory";
            this.vtpPreferences.SetVisualTip(this.txtSubversionRoot, visualTip1);
            this.txtSubversionRoot.Leave += new System.EventHandler(this.txtSubversionRoot_Leave);
            // 
            // txtReposRoot
            // 
            this.txtReposRoot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtReposRoot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReposRoot.Location = new System.Drawing.Point(25, 51);
            this.txtReposRoot.Name = "txtReposRoot";
            this.textboxProvider1.SetRenderTextbox(this.txtReposRoot, true);
            this.txtReposRoot.Size = new System.Drawing.Size(262, 13);
            this.textboxProvider1.SetStyle(this.txtReposRoot, XPControls.Style.Rounded);
            this.txtReposRoot.TabIndex = 6;
            visualTip2.Text = "This is the parent directory for all the repositories.";
            visualTip2.Title = "Repositories Root Directory";
            this.vtpPreferences.SetVisualTip(this.txtReposRoot, visualTip2);
            this.txtReposRoot.Enter += new System.EventHandler(this.txtReposRoot_Enter);
            this.txtReposRoot.Leave += new System.EventHandler(this.txtReposRoot_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Subversion Installation Directory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Repositories Root Directory";
            // 
            // lnkBrowseSub
            // 
            this.lnkBrowseSub.AutoSize = true;
            this.lnkBrowseSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkBrowseSub.ForeColor = System.Drawing.Color.Transparent;
            this.lnkBrowseSub.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkBrowseSub.LinkColor = System.Drawing.SystemColors.ActiveCaption;
            this.lnkBrowseSub.Location = new System.Drawing.Point(344, 59);
            this.lnkBrowseSub.Name = "lnkBrowseSub";
            this.lnkBrowseSub.Size = new System.Drawing.Size(60, 13);
            this.lnkBrowseSub.TabIndex = 2;
            this.lnkBrowseSub.TabStop = true;
            this.lnkBrowseSub.Text = "Browse...";
            this.lnkBrowseSub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBrowseSub_LinkClicked);
            // 
            // lnkBrowseRepo
            // 
            this.lnkBrowseRepo.AutoSize = true;
            this.lnkBrowseRepo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkBrowseRepo.ForeColor = System.Drawing.Color.Transparent;
            this.lnkBrowseRepo.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkBrowseRepo.LinkColor = System.Drawing.SystemColors.ActiveCaption;
            this.lnkBrowseRepo.Location = new System.Drawing.Point(303, 50);
            this.lnkBrowseRepo.Name = "lnkBrowseRepo";
            this.lnkBrowseRepo.Size = new System.Drawing.Size(60, 13);
            this.lnkBrowseRepo.TabIndex = 7;
            this.lnkBrowseRepo.TabStop = true;
            this.lnkBrowseRepo.Text = "Browse...";
            this.lnkBrowseRepo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBrowseRepo_LinkClicked);
            // 
            // txtCmdRoot
            // 
            this.txtCmdRoot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCmdRoot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCmdRoot.Location = new System.Drawing.Point(66, 114);
            this.txtCmdRoot.Name = "txtCmdRoot";
            this.textboxProvider1.SetRenderTextbox(this.txtCmdRoot, true);
            this.txtCmdRoot.Size = new System.Drawing.Size(262, 13);
            this.textboxProvider1.SetStyle(this.txtCmdRoot, XPControls.Style.Rounded);
            this.txtCmdRoot.TabIndex = 3;
            visualTip3.Text = "This is the directory where the command-line programs reside. This is usually the" +
                " bin directory under the server\'s installation directory.";
            visualTip3.Title = "Command-Line Tools Directory";
            this.vtpPreferences.SetVisualTip(this.txtCmdRoot, visualTip3);
            this.txtCmdRoot.Leave += new System.EventHandler(this.txtCmdRoot_Leave);
            // 
            // txtInstructions
            // 
            this.textboxProvider1.SetBorderColor(this.txtInstructions, System.Drawing.Color.White);
            this.txtInstructions.Location = new System.Drawing.Point(49, 478);
            this.txtInstructions.Multiline = true;
            this.txtInstructions.Name = "txtInstructions";
            this.txtInstructions.Size = new System.Drawing.Size(373, 50);
            this.textboxProvider1.SetStyle(this.txtInstructions, XPControls.Style.Square);
            this.txtInstructions.TabIndex = 25;
            this.txtInstructions.TabStop = false;
            this.txtInstructions.Text = "Test";
            // 
            // lnkBrowsCmd
            // 
            this.lnkBrowsCmd.AutoSize = true;
            this.lnkBrowsCmd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkBrowsCmd.ForeColor = System.Drawing.Color.Transparent;
            this.lnkBrowsCmd.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkBrowsCmd.LinkColor = System.Drawing.SystemColors.ActiveCaption;
            this.lnkBrowsCmd.Location = new System.Drawing.Point(344, 115);
            this.lnkBrowsCmd.Name = "lnkBrowsCmd";
            this.lnkBrowsCmd.Size = new System.Drawing.Size(60, 13);
            this.lnkBrowsCmd.TabIndex = 4;
            this.lnkBrowsCmd.TabStop = true;
            this.lnkBrowsCmd.Text = "Browse...";
            this.lnkBrowsCmd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBrowsCmd_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Command-Line Tools Directory";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 534);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 49);
            this.panel1.TabIndex = 19;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(347, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(266, 14);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(101)))), ((int)(((byte)(163)))));
            this.lblTitle.Location = new System.Drawing.Point(63, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(193, 16);
            this.lblTitle.TabIndex = 20;
            this.lblTitle.Text = "Modify server directory settings";
            // 
            // vtpPreferences
            // 
            this.vtpPreferences.DisplayMode = Skybound.VisualTips.VisualTipDisplayMode.HelpRequested;
            this.vtpPreferences.InitialDelay = 500;
            this.vtpPreferences.Renderer = visualTipOfficeRenderer1;
            this.vtpPreferences.TitleImage = ((System.Drawing.Image)(resources.GetObject("vtpPreferences.TitleImage")));
            // 
            // lstMulti
            // 
            this.lstMulti.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lstMulti.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstMulti.Enabled = false;
            this.lstMulti.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMulti.FormattingEnabled = true;
            this.lstMulti.Location = new System.Drawing.Point(17, 26);
            this.lstMulti.Name = "lstMulti";
            this.lstMulti.Size = new System.Drawing.Size(262, 93);
            this.lstMulti.TabIndex = 9;
            visualTip4.DisabledMessage = "This control is disabled";
            visualTip4.Text = "This contains a list of all the repository directories that you want to be manage" +
                "d by PainlessSVN.";
            visualTip4.Title = "List Of Repositories";
            this.vtpPreferences.SetVisualTip(this.lstMulti, visualTip4);
            this.lstMulti.SelectedIndexChanged += new System.EventHandler(this.lstMulti_SelectedIndexChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(286, 56);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(68, 23);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Remove";
            this.btnDelete.UseVisualStyleBackColor = true;
            visualTip5.Text = "Removes a Subversion repository from the list.";
            visualTip5.Title = "Remove Repository";
            this.vtpPreferences.SetVisualTip(this.btnDelete, visualTip5);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(285, 26);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(69, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            visualTip6.Text = "Adds a Subversion repository to the list.";
            visualTip6.Title = "Add Repository";
            this.vtpPreferences.SetVisualTip(this.btnAdd, visualTip6);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // rdbMultiFolders
            // 
            this.rdbMultiFolders.AutoSize = true;
            this.rdbMultiFolders.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.rdbMultiFolders.Location = new System.Drawing.Point(3, 3);
            this.rdbMultiFolders.Name = "rdbMultiFolders";
            this.rdbMultiFolders.Size = new System.Drawing.Size(223, 17);
            this.rdbMultiFolders.TabIndex = 8;
            this.rdbMultiFolders.TabStop = true;
            this.rdbMultiFolders.Text = "Repositories in different directories";
            this.rdbMultiFolders.UseVisualStyleBackColor = true;
            this.rdbMultiFolders.Click += new System.EventHandler(this.rdbMultiFolders_Click);
            this.rdbMultiFolders.CheckedChanged += new System.EventHandler(this.rdbMultiFolders_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 155);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 308);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Repositories";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Controls.Add(this.rdbMultiFolders);
            this.panel3.Controls.Add(this.lstMulti);
            this.panel3.Location = new System.Drawing.Point(19, 144);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(372, 140);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rdbAll);
            this.panel2.Controls.Add(this.txtReposRoot);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lnkBrowseRepo);
            this.panel2.Location = new System.Drawing.Point(19, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(372, 89);
            this.panel2.TabIndex = 0;
            // 
            // rdbAll
            // 
            this.rdbAll.AutoSize = true;
            this.rdbAll.Checked = true;
            this.rdbAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbAll.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.rdbAll.Location = new System.Drawing.Point(3, 0);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(230, 17);
            this.rdbAll.TabIndex = 5;
            this.rdbAll.TabStop = true;
            this.rdbAll.Text = "All repositories in the same directory";
            this.rdbAll.UseVisualStyleBackColor = true;
            this.rdbAll.Click += new System.EventHandler(this.rdbAll_Click);
            this.rdbAll.CheckedChanged += new System.EventHandler(this.rdbAll_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 487);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // fbdRepo
            // 
            this.fbdRepo.Description = "Select the path to a repository";
            // 
            // frmPreferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(434, 583);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtInstructions);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lnkBrowsCmd);
            this.Controls.Add(this.txtCmdRoot);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lnkBrowseSub);
            this.Controls.Add(this.txtSubversionRoot);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPreferences";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modify server directory settings";
            this.Load += new System.EventHandler(this.frmPreferences_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSubversionRoot;
        private System.Windows.Forms.TextBox txtReposRoot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lnkBrowseSub;
        private System.Windows.Forms.LinkLabel lnkBrowseRepo;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private XPControls.TextboxProvider textboxProvider1;
        private System.Windows.Forms.LinkLabel lnkBrowsCmd;
        private System.Windows.Forms.TextBox txtCmdRoot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblTitle;
        private Skybound.VisualTips.VisualTipProvider vtpPreferences;
        private System.Windows.Forms.RadioButton rdbMultiFolders;
        private System.Windows.Forms.ListBox lstMulti;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdbAll;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtInstructions;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FolderBrowserDialog fbdRepo;
    }
}