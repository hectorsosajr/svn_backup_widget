using System.IO;
using SVNManagerLib;

namespace SVN_Backup_Widget
{
    public class SvnCommands
    {
        #region Member Variables

        private SVNServerConfig _serverConfiguration = null;
        private SVNController _controller = null; 

        #endregion

        public bool RunDump(string profileName)
        {
            bool retval = false;

            DumpArgs args = GetDumpArgsFromProfileName(profileName);

            string configPath = Utilities.GetConfigFilePath();

            if (File.Exists(configPath))
            {
                _serverConfiguration = new SVNServerConfig(configPath);
                _controller = new SVNController(_serverConfiguration);

                SVNRepository repo = _controller.RepositoryCollection[args.RepositoryName];
                retval = repo.DumpRepository(args);
            }

            return retval;
        }

        #region Private Members

        private static DumpArgs GetDumpArgsFromProfileName(string profileName)
        {
            DumpArgs args = new DumpArgs();
            DAL dal = new DAL();

            int profileID = dal.GetProfileId(profileName);

            if (profileID > 0)
            {
                ProfileDetails det = dal.LoadProfileDetails(profileID);

                string filePattern = Utilities.ParseFilePattern(det.FilePattern, det.Repository);

                args.DumpFileName = Path.Combine(det.DumpDirectory, filePattern); 
                args.RevisionArg = det.Revisions;
                args.UseIncremental = det.Incremental;
                args.UseQuiet = true;
                args.RepositoryName = det.Repository;
            }

            return args;
        } 

        #endregion
    }
}
