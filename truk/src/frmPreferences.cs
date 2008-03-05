using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using SVNManagerLib;

namespace SVN_Backup_Widget
{
    public partial class frmPreferences : Form
    {
        #region Member Variables

        private SVNServerConfig _serverConfiguration = null;
        private bool _isSubversionRootValid = false;
        private bool _isRepoRootValid = false;
        private bool _isCommandRootValid = false;
        private DAL _database = null;
        private List<SubversionRepositoryInfo> _repos = null;

        #endregion

        #region Constructors

        public frmPreferences()
        {
            InitializeComponent();
            Clear();
            _serverConfiguration = new SVNServerConfig();
        }

        public frmPreferences(string pathToConfig)
        {
            InitializeComponent();
            _serverConfiguration = new SVNServerConfig(pathToConfig);
        }

        #endregion

        #region Properties

        public SVNServerConfig ServerConfiguration
        {
            get
            {
                return _serverConfiguration;
            }
        }

        #endregion        

        #region Form Events

        private void frmPreferences_Load(object sender, EventArgs e)
        {
            if (_serverConfiguration != null)
            {
                txtSubversionRoot.Text = _serverConfiguration.ServerRootDirectory;
                txtCmdRoot.Text = _serverConfiguration.CommandRootDirectory;

                if (_serverConfiguration.RepositoryMode == "custom")
                {
                    rdbMultiFolders.Checked = true;
                    SelectrdbMultiFolders();
                    SetupDatabase();
                }

                if (_serverConfiguration.RepositoryMode == "root")
                {
                    rdbAll.Checked = true;
                    txtReposRoot.Text = _serverConfiguration.RepositoryRootDirectory;
                    SelectrdbAll();
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("Press F1 to display additional instructions when a control is selected. You may also display the instructions");
            sb.Append(" by clicking the ? button in the top-right corner of the dialog and then clicking any control.");
            txtInstructions.Text = sb.ToString();
        }

        #endregion

        #region Control Events

        private void txtSubversionRoot_Leave(object sender, EventArgs e)
        {
            if (txtSubversionRoot.Text.Length > 0)
            {
                if (!ServerRootValid())
                {
                    txtSubversionRoot.ForeColor = Color.Red;
                    _isSubversionRootValid = false;
                }
                else
                {
                    txtSubversionRoot.ForeColor = Color.Black;
                    _isSubversionRootValid = true;

                    if (!txtSubversionRoot.Text.EndsWith(Path.PathSeparator.ToString()))
                    {
                        if (txtReposRoot.Text.Length == 0)
                        {
                            string root;
                            root = Path.Combine(txtSubversionRoot.Text,"Repositories");
                            txtReposRoot.Text = root;
                        }

                        ReposRootValid();

                        if (txtCmdRoot.Text.Length == 0)
                        {
                            string bin;
                            bin = Path.Combine(txtSubversionRoot.Text,"bin");
                            txtCmdRoot.Text = bin;
                        }

                        CommandRootValid();
                    }
                }
            }

            if (IsConfigurationValid())
            {
                btnOK.Enabled = true;
            }
            else
            {
                btnOK.Enabled = false;
            }

            txtCmdRoot.Focus();
        }

        private void txtReposRoot_Leave(object sender, EventArgs e)
        {
            if (txtReposRoot.Text.Length > 0)
            {
            if (!ReposRootValid())
            {
                txtReposRoot.ForeColor = Color.Red;
            }
            else
            {
                txtReposRoot.ForeColor = Color.Black;
            }
            }

            if (IsConfigurationValid())
            {
                btnOK.Enabled = true;
            }
            else
            {
                btnOK.Enabled = false;
            }
        }

        private void txtCmdRoot_Leave(object sender, EventArgs e)
        {
            if (txtCmdRoot.Text.Length > 0)
            {
            if (!CommandRootValid())
            {
                txtCmdRoot.ForeColor = Color.Red;
            }
            else
            {
                txtCmdRoot.ForeColor = Color.Black;
            }
            }

            CommandRootValid();

            if (IsConfigurationValid())
            {
                btnOK.Enabled = true;
            }
            else
            {
                btnOK.Enabled = false;
            }

            if (txtCmdRoot.Text.Length > 0)
            {
                if (rdbAll.Checked)
                {
                    txtReposRoot.Focus();
                }

                if (rdbMultiFolders.Checked)
                {
                    btnAdd.Focus();
                }
            }
        }

        private void rdbMultiFolders_CheckedChanged(object sender, EventArgs e)
        {
            SelectrdbMultiFolders();
        }

        private void rdbMultiFolders_Click(object sender, EventArgs e)
        {
            SelectrdbMultiFolders();
        }

        private void rdbAll_CheckedChanged(object sender, EventArgs e)
        {
            SelectrdbAll();
        }

        private void rdbAll_Click(object sender, EventArgs e)
        {
            SelectrdbAll();
        }

        private void lnkBrowseSub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtSubversionRoot.Text;
            folderBrowserDialog1.Description = "Select the root directory for the Subversion server.";
            
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
            txtSubversionRoot.Text = folderBrowserDialog1.SelectedPath;
            }
            
            txtSubversionRoot.Focus();
        }

        private void lnkBrowseRepo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtReposRoot.Text;
            folderBrowserDialog1.Description = "Select the Directory you wish to use to store the Repository Stores in.";
            
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
            txtReposRoot.Text = folderBrowserDialog1.SelectedPath;
        }

            txtReposRoot.Focus();

            ReposRootValid();

            if (IsConfigurationValid())
            {
                btnOK.Enabled = true;
            }
            else
            {
                btnOK.Enabled = false;
            }
        }

        private void lnkBrowsCmd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtCmdRoot.Text;
            folderBrowserDialog1.Description = "Select the Directory that contains the Subversion executables.";
            
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
            txtCmdRoot.Text = folderBrowserDialog1.SelectedPath;
        }

            txtCmdRoot.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_serverConfiguration.ConfigFilePath == string.Empty)
            {
                string path;
                path = Utilities.GetConfigFilePath();

                _serverConfiguration.ConfigFilePath = new FileInfo(path).DirectoryName;
                _serverConfiguration.ConfigFileName = new FileInfo(path).Name;
            }

            _serverConfiguration.ServerRootDirectory = txtSubversionRoot.Text;
            _serverConfiguration.RepositoryRootDirectory = txtReposRoot.Text;
            _serverConfiguration.CommandRootDirectory = txtCmdRoot.Text;

            if (rdbMultiFolders.Checked)
            {
                _serverConfiguration.RepositoryMode = "custom";
            }

            if (rdbAll.Checked)
            {
                _serverConfiguration.RepositoryMode = "root";
            }

            _serverConfiguration.Save();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            fbdRepo.ShowNewFolderButton = true;
            DialogResult result = fbdRepo.ShowDialog();

            if (result == DialogResult.OK)
            {
                string path = fbdRepo.SelectedPath;
                DirectoryInfo d = new DirectoryInfo(path);

                if (Equals(_database, null))
                {
                    _database = new DAL();
                }

                SubversionRepositoryInfo r = new SubversionRepositoryInfo();
                r.Name = d.Name;
                r.RepositoryPath = path;

                int id = _database.AddRepository(r.Name, r.RepositoryPath);

                r.RepositoryId = id;

                if (Equals(_repos, null))
                {
                    _repos = new List<SubversionRepositoryInfo>();
                }

                _repos.Add(r);

                lstMulti.Items.Add(r);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstMulti.SelectedItem == null)
            {
                MessageBox.Show("Please Select a repository from the list", "A repository must be selected",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                SubversionRepositoryInfo delRepo = (SubversionRepositoryInfo)lstMulti.SelectedItem;
                int id = delRepo.RepositoryId;

                _database.DeleteRepository(id);

                lstMulti.Items.Remove(delRepo.Name);

                btnDelete.Enabled = false;
                btnAdd.Focus();
            }
        }

        private void lstMulti_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = true;
        }

        private void txtReposRoot_Enter(object sender, EventArgs e)
        {
            if (txtReposRoot.Text.Length > 0)
            {
                if (!ReposRootValid())
                {
                    txtReposRoot.ForeColor = Color.Red;
                }
                else
                {
                    txtReposRoot.ForeColor = Color.Black;
                }
            }
        }

        #endregion

        #region Public Members

        public void Clear()
        {
            txtCmdRoot.Text = string.Empty;
            txtReposRoot.Text = string.Empty;
            txtSubversionRoot.Text = string.Empty;

            lstMulti.Items.Clear();

            rdbAll.Checked = true;
        }

        #endregion

        #region Private Members

        private void SetupDatabase()
        {
            _database = new DAL();

            _repos = _database.LoadRepositories();

            foreach (SubversionRepositoryInfo info in _repos)
            {
                lstMulti.Items.Add(info.Name);
            }
        }

        private bool ServerRootValid()
        {
            bool retval = false;

            if (txtSubversionRoot.Text.Length > 0)
            {
                DirectoryInfo dir = new DirectoryInfo(txtSubversionRoot.Text);

                if (!dir.Exists)
                {
                    _isSubversionRootValid = false;
                    retval = false;
                }
                else
                {
                    _isSubversionRootValid = true;
                    retval = true;
                }
            }
            else
            {
                _isSubversionRootValid = false;
                retval = false;
            }

            return retval;
        }

        private bool ReposRootValid()
        {
            bool retval = false;

            if (txtReposRoot.Text.Length > 0)
            {
                DirectoryInfo dir = new DirectoryInfo(txtReposRoot.Text);

                if (!dir.Exists)
                {
                    _isRepoRootValid = false;
                    retval = false;
                }
                else
                {
                    _isRepoRootValid = true;
                    retval = true;
                }
            }
            else
            {
                _isRepoRootValid = false;
                retval = false;
            }

            return retval;
        }

        private bool CommandRootValid()
        {
            bool retval = false;

            if (txtCmdRoot.Text.Length > 0)
            {
                DirectoryInfo dir = new DirectoryInfo(txtCmdRoot.Text);

                if (!dir.Exists)
                {
                    _isCommandRootValid = false;
                    retval = false;
                }
                else
                {
                    _isCommandRootValid = true;
                    retval = true;
                }
            }
            else
            {
                _isCommandRootValid = false;
                retval = false;
            }

            return retval;
        }

        private bool IsConfigurationValid()
        {
            bool retval = false;

            if (_isCommandRootValid && _isRepoRootValid && _isSubversionRootValid)
            {
                retval = true;
            }
            else
            {
                retval = false;
            }

            if (rdbMultiFolders.Checked && _isSubversionRootValid && _isCommandRootValid)
            {
                retval = true;
            }

            return retval;
        }

        private void SelectrdbAll()
        {
            txtReposRoot.Enabled = true;
            lnkBrowseRepo.Enabled = true;

            lstMulti.Enabled = false;
            lstMulti.BackColor = Color.FromName("ControlLight");
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;

            if (rdbAll.Checked)
            {
                rdbMultiFolders.Checked = false;

                ReposRootValid();

                if (IsConfigurationValid())
                {
                    btnOK.Enabled = true;
                }
                else
                {
                    btnOK.Enabled = false;
                }
            }
        }

        private void SelectrdbMultiFolders()
        {
            txtReposRoot.Enabled = false;
            lnkBrowseRepo.Enabled = false;

            lstMulti.Enabled = true;
            lstMulti.BackColor = Color.White;
            btnAdd.Enabled = true;

            if (lstMulti.SelectedItem != null)
            {
                btnDelete.Enabled = true;
            }

            if (rdbMultiFolders.Checked)
            {
                rdbAll.Checked = false;

                if (IsConfigurationValid())
                {
                    btnOK.Enabled = true;
                }
                else
                {
                    btnOK.Enabled = false;
                }
            }
        }

        #endregion
    }
}