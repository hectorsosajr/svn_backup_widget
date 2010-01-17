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
                chklistRepository.Items.Add(s.Name);
            }
        }
    }
}
