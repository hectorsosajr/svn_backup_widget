using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

using SVNManagerLib;
using Nini.Config;

namespace SVN_Backup_Widget
{
    public partial class frmMain : Form
    {
        #region Member Variables

        private SVNServerConfig _config;
        private SVNController _controller;
        private string _filePatterns = string.Empty;
        private Hashtable _profileIndex = new Hashtable();
        private bool _isNew;
        private bool _isUpdate;
        private static string _mode = string.Empty;

        #endregion

        #region Constructors

        public frmMain()
        {
            InitializeComponent();
            InitializeForm();
        }

        #endregion

        #region Form Events

        private void frmMain_Shown(object sender, EventArgs e)
        {
            if (ServerPrefsExists())
            {
                if (ServerPrefsValid())
                {
                    EnableProfiles();
                }
            }
        }

        private void lnkServer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var prefs = new frmPreferences();
            DialogResult result = prefs.ShowDialog();

            if (result == DialogResult.OK)
            {
                _config = prefs.ServerConfiguration;
                _mode = _config.RepositoryMode;
                picSvrStatus.Image = imgIcons.Images[1];

                LoadRepos();
                EnableProfiles();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            fbdDumpDir.Description = "Select dump directory";
            fbdDumpDir.ShowNewFolderButton = true;
            DialogResult result = fbdDumpDir.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtDumpDir.Text = fbdDumpDir.SelectedPath;
            }
        }

        private void cboRepos_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrepareFileName();
        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {
            _filePatterns = txtFilePattern.Text;
            PrepareFileName();
        }

        private void txtFilePattern_Leave(object sender, EventArgs e)
        {
            PrepareFileName();
        }

        private void cboProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            int currItemId = cboProfiles.SelectedIndex;

            if (currItemId == 0)
            {
                txtDumpDir.Text = string.Empty;
                txtDumpDir.Enabled = false;
                txtFilePattern.Text = string.Empty;
                txtFilePattern.Enabled = false;
                chkIncremental.Checked = false;
                btnRun.Enabled = false;
                btnNew.Enabled = true;
                btnDelete.Enabled = false;
                btnSave.Enabled = false;

                if (cboRepos.Items.Count > 0)
                {
                    cboRepos.SelectedIndex = 0;
                }

                _isNew = false;
                _isUpdate = false;
            }
            else
            {
                var dal = new DAL();
                var repoIndex = (int)_profileIndex[currItemId];
                ProfileDetails d = dal.LoadProfileDetails(repoIndex);

                if (d != null)
                {
                    txtDumpDir.Text = d.DumpDirectory;
                    txtDumpDir.Enabled = true;
                    txtFilePattern.Text = d.FilePattern;
                    txtFilePattern.Enabled = true;
                    chkIncremental.Checked = d.Incremental;
                    txtRevisions.Text = d.Revisions;

                    int idx = cboRepos.FindStringExact(d.Repository);
                    cboRepos.SelectedIndex = idx;
                    btnRun.Enabled = true;
                    btnNew.Enabled = true;
                    btnDelete.Enabled = true;
                    btnSave.Enabled = true;

                    _isNew = false;
                    _isUpdate = true;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var det = new ProfileDetails();
            string repoName;
            int idx;

            det.DumpDirectory = txtDumpDir.Text;
            det.FilePattern = txtFilePattern.Text;
            det.Incremental = chkIncremental.Checked;
            det.Revisions = txtRevisions.Text;
            det.RootDumpFilePath = txtBaseFile.Text;

            var dal = new DAL();

            if (_isUpdate)
            {
                repoName = cboRepos.Text;

                idx = Convert.ToInt32(_profileIndex[cboProfiles.SelectedIndex]);

                det.ProfileID = idx;
                det.Repository = repoName;

                dal.UpdateProfile(det);
            }

            if (_isNew)
            {
                string profileName = cboProfiles.Text;
                repoName = cboRepos.Text;

                det.Repository = repoName;

                dal.CreateProfile(profileName,det);

                _profileIndex = new Hashtable();
                cboProfiles.Items.Clear();
                cboRepos.Items.Clear();

                InitializeForm();

                idx = cboProfiles.FindStringExact(profileName);
                cboProfiles.SelectedIndex = idx;

                _isNew = false;
                _isUpdate = false;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            const string pattern = "[REPOSITORYNAME][DATE:yyyyMMdd].svndump";

            if (!ProfileDatabaseExists())
            {
                var dal = new DAL();
                dal.CreateDatabase();
            }

            btnSave.Enabled = true;
            btnRun.Enabled = false;
            btnDelete.Enabled = false;

            if (cboRepos.Items.Count > 0)
            {
                cboRepos.SelectedIndex = 0;
            }

            txtDumpDir.Text = string.Empty;
            txtFilePattern.Text = pattern;
            chkIncremental.Checked = false;
            txtRevisions.Text = string.Empty;

            cboProfiles.Text = string.Empty;
            cboProfiles.Focus();

            _isNew = true;
            _isUpdate = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var dal = new DAL();

            int idx = cboProfiles.SelectedIndex;

            int currId = (int)_profileIndex[idx];

            dal.DeleteProfile(currId);

            _profileIndex = new Hashtable();
            cboProfiles.Items.Clear();
            cboRepos.Items.Clear();

            InitializeForm();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            var cmd = new SvnCommands();
            string profileName;

            profileName = cboProfiles.Text;

            Cursor = Cursors.WaitCursor;
 
            cmd.RunDump(profileName);

            Cursor = Cursors.Default;
        }

        #endregion

        #region Private Members

        private void GetServerConfigFile()
        {
            string configPath = Utilities.GetConfigFilePath();

            if (File.Exists(configPath))
            {
                _config = new SVNServerConfig(configPath);
            }
        }

        private static string GetConfigPath()
        {
            string configPath = Utilities.GetConfigFilePath();

            return configPath;
        }

        private static bool ServerPrefsExists()
        {
            return File.Exists(GetConfigPath());
        }

        private static bool ServerPrefsValid()
        {
            bool retval = false;
            string configPath = GetConfigPath();

            try
            {
                IniConfigSource config;
                config = new IniConfigSource(configPath);

                string serverDir;
                serverDir = config.Configs["subversion"].GetString("serverdir");
                string repoRoot;
                repoRoot = config.Configs["subversion"].GetString("reporoot");
                string commandDir;
                commandDir = config.Configs["subversion"].GetString("commanddir");

                _mode = config.Configs["repositories"].GetString("mode");

                if (serverDir.Length > 0) retval = true;
                if (serverDir.Length > 0 && repoRoot.Length > 0) retval = true;
                if (serverDir.Length > 0 && repoRoot.Length > 0 && commandDir.Length > 0) retval = true;
            }
            catch (FileNotFoundException)
            {}
            catch (NullReferenceException)
            {}

            return retval;
        }

        private static bool ProfileDatabaseExists()
        {
            string configPath = Assembly.GetExecutingAssembly().Location;
            FileInfo cInfo = new FileInfo(configPath);
            configPath = Path.Combine(cInfo.DirectoryName, "BackupProfiles.db");

            return File.Exists(configPath);
        }

        private void InitializeForm()
        {
            cboProfiles.Items.Add("<none>");
            cboProfiles.SelectedIndex = 0;

            cboRepos.Items.Add("<none>");
            cboRepos.SelectedIndex = 0;

            bool exists = ServerPrefsExists();
            bool valid = ServerPrefsValid();

            if (exists)
            {
                if (valid)
                {
                    picSvrStatus.Image = imgIcons.Images[1];
                    GetServerConfigFile();
                    LoadRepos();

                    if (ProfileDatabaseExists())
                    {
                        LoadNames();
                    }
                    else
                    {
                        DAL dal = new DAL();
                        dal.CreateDatabase();
                        LoadNames();
                    }

                    btnNew.Enabled = true;
                }
                else
                {
                    picSvrStatus.Image = imgIcons.Images[7];
                    btnNew.Enabled = false;
                }
            }
        }

        private void LoadNames()
        {
            DAL dal = new DAL();
            dal.LoadProfileNames();

            foreach (Profile p in dal.Profiles)
            {
                int idx = cboProfiles.Items.Add(p.Name);
                _profileIndex.Add(idx, p.ID);
            }
        }

        private void LoadRepos()
        {
            cboRepos.Items.Clear();

            if (_mode == "root")
            {
                _controller = new SVNController(_config);

                foreach (SVNRepository r in _controller.RepositoryCollection)
                {
                    cboRepos.Items.Add(r.Name);
                }
            }

            if (_mode == "custom")
            {
                DAL dal = new DAL();

                List<SubversionRepositoryInfo> repos = dal.LoadRepositories();

                foreach (SubversionRepositoryInfo repo in repos)
                {
                    cboRepos.Items.Add(repo.Name);
                }
            }

            if (cboRepos.Items.Count > 0)
            {
                cboRepos.SelectedIndex = 0;
                PrepareFileName();
            }
        }

        private void PrepareFileName()
        {
            string fileName = string.Empty;

            if (_filePatterns != string.Empty)
            {
                fileName = Utilities.ParseFilePattern(_filePatterns, cboRepos.Text);

                txtFilePattern.Text = _filePatterns;
            }

            lblFileName.Text = fileName;
        }

        private void EnableProfiles()
        {
            //txtDumpDir.Enabled = true;
            //txtFilePattern.Enabled = true;
            cboProfiles.Enabled = true;
            cboRepos.Enabled = true;
            btnBrowse.Enabled = true;
            btnNew.Enabled = true;

            cboProfiles.Focus();
        }

        #endregion

        #region Control Events

        private void lnkSupport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.systemwidgets.com/Support/Forums/tabid/72/view/topics/forumid/2/Default.aspx");
        }

        private void lnkFeatures_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.systemwidgets.com/Support/FeedbackCenter/tabid/55/fbType/Search/ProductID/6/Status/Open/Default.aspx");
        }

        private void chkIncremental_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIncremental.Checked)
            {
                txtBaseFile.Enabled = true;
                btnBrowseBase.Enabled = true;
            }
            else
            {
                txtBaseFile.Enabled = false;
                btnBrowseBase.Enabled = false;
            }
        }

        private void btnAutoGenerate_Click(object sender, EventArgs e)
        {
            var dialog = new ProfileGeneratorDialog();

            dialog.ShowMe(_controller);
        } 

        #endregion
    }
}