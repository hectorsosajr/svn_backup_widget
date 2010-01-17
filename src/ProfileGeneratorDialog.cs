using System.Windows.Forms;
using SVNManagerLib;

namespace SVN_Backup_Widget
{
    public partial class ProfileGeneratorDialog : Form
    {
        public ProfileGeneratorDialog()
        {
            InitializeComponent();
        }

        SVNController Server { get; set; }

        public void ShowMe(SVNController Controller)
        {
            Server = Controller;

            InitializeDialog();

            ShowDialog();
        }

        private void InitializeDialog()
        {
            foreach (SVNRepository s in Server.RepositoryCollection)
            {
                var item = new ListViewItem(s.Name) {ImageIndex = 0};

                lsvRepositories.Items.Add(item);
            }
        }

        private void chkAll_CheckedChanged(object sender, System.EventArgs e)
        {
            foreach (ListViewItem item in lsvRepositories.Items)
            {
                if (chkAll.Checked)
                {
                    item.Checked = true;
                }
                else
                {
                    item.Checked = false;
                }
            }
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
