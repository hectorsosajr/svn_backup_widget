using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace SVN_Backup_Widget
{
    public class DAL
    {
        #region Member Variables

        private List<Profile> _profiles = new List<Profile>();
        private List<SubversionRepositoryInfo> _repositories = new List<SubversionRepositoryInfo>();
        private string _fileName = "BackupProfiles.db"; 

        #endregion

        #region Properties

        public List<Profile> Profiles
        {
            get
            {
                return _profiles;
            }
            set
            {
                _profiles = value;
            }
        } 

        #endregion

        #region Public Members

        public void CreateDatabase()
        {
            StringBuilder sb = new StringBuilder();
            SQLiteConnection conn = GetDatabaseConnection();

            sb.Append("CREATE TABLE [Details] (");
            sb.Append(Environment.NewLine);
            sb.Append("[DetailsID] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT,");
            sb.Append(Environment.NewLine);
            sb.Append("[ProfileID] INTEGER  NOT NULL,");
            sb.Append(Environment.NewLine);
            sb.Append("[Repository] VARCHAR(100)  NOT NULL,");
            sb.Append(Environment.NewLine);
            sb.Append("[DumpDirectory] VARCHAR(255)  NOT NULL,");
            sb.Append(Environment.NewLine);
            sb.Append("[FilePattern] VARCHAR(255)  NOT NULL,");
            sb.Append(Environment.NewLine);
            sb.Append("[Incremental] BOOLEAN DEFAULT '0' NULL,");
            sb.Append(Environment.NewLine);
            sb.Append("[Revisions] VARCHAR(50)  NULL");
            sb.Append(Environment.NewLine);
            sb.Append("[RootDumpFilePath] VARCHAR(255)  NOT NULL,");
            sb.Append(Environment.NewLine);
            sb.Append(");");
            sb.Append(Environment.NewLine);
            sb.Append("CREATE TABLE [Profiles] (");
            sb.Append(Environment.NewLine);
            sb.Append("[ID] INTEGER  NOT NULL PRIMARY KEY,");
            sb.Append(Environment.NewLine);
            sb.Append("[ProfileName] VARCHAR(50)  NOT NULL");
            sb.Append(Environment.NewLine);
            sb.Append(");");
            sb.Append("CREATE TABLE [Repositories] (");
            sb.Append(Environment.NewLine);
            sb.Append("[RepoID] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT,");
            sb.Append(Environment.NewLine);
            sb.Append("[RepoName] NVARCHAR(255)  NOT NULL,");
            sb.Append(Environment.NewLine);
            sb.Append("[RepoPath] NVARCHAR(4000)  NOT NULL");
            sb.Append(Environment.NewLine);
            sb.Append(");");

            SQLiteCommand cmd = new SQLiteCommand(sb.ToString());

            conn.Open();
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
        }

        public void LoadProfileNames()
        {
            SQLiteConnection conn = GetDatabaseConnection();
            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Profiles");
            SQLiteDataReader dr;

            conn.Open();
            cmd.Connection = conn;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Profile p = new Profile();
                p.ID = Convert.ToInt32(dr["ID"]);
                p.Name = dr["ProfileName"].ToString();
                _profiles.Add(p);
            }

            dr.Close();
            conn.Close();
        }

        public ProfileDetails LoadProfileDetails(int profileId)
        {
            ProfileDetails det = null;
            string sql = "SELECT * FROM Details WHERE ProfileID = @ProfileId";
            SQLiteConnection conn = GetDatabaseConnection();
            SQLiteCommand cmd = new SQLiteCommand(sql);
            SQLiteParameter param = new SQLiteParameter("ProfileId", profileId);
            cmd.Parameters.Add(param);
            SQLiteDataReader dr;

            conn.Open();
            cmd.Connection = conn;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                det = new ProfileDetails();
                det.DumpDirectory = dr["DumpDirectory"].ToString();
                det.Repository = dr["Repository"].ToString();
                det.FilePattern = dr["FilePattern"].ToString();
                det.Incremental = Convert.ToBoolean(dr["Incremental"]);

                try
                {
                    det.Revisions = dr["Revisions"].ToString();
                }
                catch (IndexOutOfRangeException)
                {}

                det.RootDumpFilePath = dr["RootDumpFilePath"].ToString();
            }

            dr.Close();
            conn.Close();

            return det;
        }

        public void UpdateProfile(ProfileDetails details)
        {
            StringBuilder sbSQL = new StringBuilder();
            SQLiteConnection conn = GetDatabaseConnection();
            SQLiteCommand cmd;

            sbSQL.Append("UPDATE Details ");
            sbSQL.Append("SET Repository = @Repository, ");
            sbSQL.Append("DumpDirectory = @DumpDirectory, ");
            sbSQL.Append("FilePattern = @FilePattern, ");
            sbSQL.Append("Incremental = @Incremental, ");
            sbSQL.Append("Revisions = @Revisions, ");
            sbSQL.Append("RootDumpFilePath = @RootDumpFilePath ");
            sbSQL.Append("WHERE ProfileID = @ProfileId");

            cmd = new SQLiteCommand(sbSQL.ToString());
            SQLiteParameter param = new SQLiteParameter("Repository", details.Repository);
            cmd.Parameters.Add(param);
            param = new SQLiteParameter("DumpDirectory", details.DumpDirectory);
            cmd.Parameters.Add(param);
            param = new SQLiteParameter("FilePattern", details.FilePattern);
            cmd.Parameters.Add(param);
            param = new SQLiteParameter("Incremental", details.Incremental);
            cmd.Parameters.Add(param);
            param = new SQLiteParameter("Revisions", details.Revisions);
            cmd.Parameters.Add(param);
            param = new SQLiteParameter("ProfileId", details.ProfileID);
            cmd.Parameters.Add(param);
            param = new SQLiteParameter("RootDumpFilePath", details.RootDumpFilePath);
            cmd.Parameters.Add(param);

            conn.Open();
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void CreateProfile(string profileName, ProfileDetails details)
        {
            int ID = CreateProfile(profileName);

            details.ProfileID = ID;

            CreateProfileDetails(details);
        }

        public void DeleteProfile(int profileId)
        {
            StringBuilder sbSQL = new StringBuilder();
            SQLiteConnection conn = GetDatabaseConnection();
            SQLiteCommand cmd;

            sbSQL.Append("DELETE FROM Profiles ");
            sbSQL.Append("WHERE ID = @ProfileId");

            cmd = new SQLiteCommand(sbSQL.ToString());
            SQLiteParameter param = new SQLiteParameter("ProfileId", profileId);
            cmd.Parameters.Add(param);

            conn.Open();
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();

            conn.Close();

            DeleteProfileDetails(profileId);
        }

        public int GetProfileId(string profileName)
        {
            int profileId;
            StringBuilder sbSQL = new StringBuilder();
            SQLiteConnection conn = GetDatabaseConnection();
            SQLiteCommand cmd;

            sbSQL.Append("SELECT ID FROM Profiles ");
            sbSQL.Append("WHERE ProfileName COLLATE nocase = @Name");

            cmd = new SQLiteCommand(sbSQL.ToString());
            SQLiteParameter param = new SQLiteParameter("Name", profileName);
            cmd.Parameters.Add(param);

            conn.Open();
            cmd.Connection = conn;
            object obj = cmd.ExecuteScalar();
            profileId = Convert.ToInt32(obj);

            conn.Close();

            return profileId;
        }

        public List<SubversionRepositoryInfo> LoadRepositories()
        {
            SQLiteConnection conn = GetDatabaseConnection();
            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Repositories");
            SQLiteDataReader dr;

            conn.Open();
            cmd.Connection = conn;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                SubversionRepositoryInfo r = new SubversionRepositoryInfo();
                r.RepositoryId = Convert.ToInt32(dr["RepoID"]);
                r.Name = dr["RepoName"].ToString();
                r.RepositoryPath = dr["RepoPath"].ToString();
                _repositories.Add(r);
            }

            dr.Close();
            conn.Close();

            return _repositories;
        }

        public void DeleteRepository(int RepositoryId)
        {
            StringBuilder sbSQL = new StringBuilder();
            SQLiteConnection conn = GetDatabaseConnection();
            SQLiteCommand cmd;

            sbSQL.Append("DELETE FROM Repositories ");
            sbSQL.Append("WHERE RepoID = @RepoId");

            cmd = new SQLiteCommand(sbSQL.ToString());
            SQLiteParameter param = new SQLiteParameter("RepoId", RepositoryId);
            cmd.Parameters.Add(param);

            conn.Open();
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public int AddRepository(string RepositoryName, string RepositoryPath)
        {
            int newRepoId;
            StringBuilder sbSQL = new StringBuilder();
            SQLiteConnection conn = GetDatabaseConnection();
            SQLiteCommand cmd;

            sbSQL.Append("INSERT INTO Repositories (RepoName,RepoPath) ");
            sbSQL.Append("VALUES (@RepoName,@RepoPath); ");
            sbSQL.Append("SELECT last_insert_rowid() As RepositoryID;");

            cmd = new SQLiteCommand(sbSQL.ToString());
            SQLiteParameter param = new SQLiteParameter("RepoName", RepositoryName);
            cmd.Parameters.Add(param);
            param = new SQLiteParameter("RepoPath", RepositoryPath);
            cmd.Parameters.Add(param);

            conn.Open();
            cmd.Connection = conn;
            object obj = cmd.ExecuteScalar();
            newRepoId = Convert.ToInt32(obj);

            conn.Close();

            return newRepoId;
        }

        public int GetRepositoryId(string RepositoryName)
        {
            int profileId;
            StringBuilder sbSQL = new StringBuilder();
            SQLiteConnection conn = GetDatabaseConnection();
            SQLiteCommand cmd;

            sbSQL.Append("SELECT RepoID FROM Repositories ");
            sbSQL.Append("WHERE RepoName COLLATE nocase = @Name");

            cmd = new SQLiteCommand(sbSQL.ToString());
            SQLiteParameter param = new SQLiteParameter("Name", RepositoryName);
            cmd.Parameters.Add(param);

            conn.Open();
            cmd.Connection = conn;
            object obj = cmd.ExecuteScalar();
            profileId = Convert.ToInt32(obj);

            conn.Close();

            return profileId;
        }

        #endregion

        #region Private Members

        private SQLiteConnection GetDatabaseConnection()
        {
            return new SQLiteConnection("Data Source=" + _fileName + ";Version=3;New=False;Compress=True;");
        }

        private int CreateProfile(string profileName)
        {
            StringBuilder sbSQL = new StringBuilder();
            SQLiteConnection conn = GetDatabaseConnection();
            SQLiteCommand cmd;

            sbSQL.Append("INSERT INTO Profiles (ProfileName) ");
            sbSQL.Append("VALUES (@ProfileName); ");
            sbSQL.Append("SELECT last_insert_rowid() As ProfileID;");

            cmd = new SQLiteCommand(sbSQL.ToString());
            SQLiteParameter param = new SQLiteParameter("ProfileName", profileName);
            cmd.Parameters.Add(param);

            conn.Open();
            cmd.Connection = conn;
            object obj = cmd.ExecuteScalar();
            int newProfileId = Convert.ToInt32(obj);

            conn.Close();

            return newProfileId;
        }

        private void CreateProfileDetails(ProfileDetails details)
        {
            StringBuilder sbSQL = new StringBuilder();
            SQLiteConnection conn = GetDatabaseConnection();
            SQLiteCommand cmd;

            sbSQL.Append("INSERT INTO Details ");
            sbSQL.Append("(ProfileID,Repository,DumpDirectory,FilePattern,Incremental,Revisions) ");
            sbSQL.Append("VALUES ");
            sbSQL.Append("(@ProfileId,@Repository,@DumpDirectory,@FilePattern,@Incremental,@Revisions)");

            cmd = new SQLiteCommand(sbSQL.ToString());
            SQLiteParameter param = new SQLiteParameter("Repository", details.Repository);
            cmd.Parameters.Add(param);
            param = new SQLiteParameter("DumpDirectory", details.DumpDirectory);
            cmd.Parameters.Add(param);
            param = new SQLiteParameter("FilePattern", details.FilePattern);
            cmd.Parameters.Add(param);
            param = new SQLiteParameter("Incremental", details.Incremental);
            cmd.Parameters.Add(param);
            param = new SQLiteParameter("Revisions", details.Revisions);
            cmd.Parameters.Add(param);
            param = new SQLiteParameter("ProfileId", details.ProfileID);
            cmd.Parameters.Add(param);
            param = new SQLiteParameter("RootDumpFilePath", details.RootDumpFilePath);
            cmd.Parameters.Add(param);

            conn.Open();
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        private void DeleteProfileDetails(int profileId)
        {
            StringBuilder sbSQL = new StringBuilder();
            SQLiteConnection conn = GetDatabaseConnection();
            SQLiteCommand cmd;

            sbSQL.Append("DELETE FROM Details ");
            sbSQL.Append("WHERE ProfileID = @ProfileId");

            cmd = new SQLiteCommand(sbSQL.ToString());
            SQLiteParameter param = new SQLiteParameter("ProfileId", profileId);
            cmd.Parameters.Add(param);

            conn.Open();
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        #endregion
    }

    #region Profile Class

    public class Profile
    {
        private string _name;
        private int id;

        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
    } 

    #endregion

    #region ProfileDetails Class

    public class ProfileDetails
    {
        #region Member Variables

        private string _dumpDirectory;
        private string _repository;
        private string _filePattern;
        private bool _incremental;
        private string _revisions;
        private int _profileId;
        private string _rootDumpFilePath;

        #endregion

        #region Properties

        public string Repository
        {
            get
            {
                return _repository;
            }
            set
            {
                _repository = value;
            }
        }

        public string DumpDirectory
        {
            get
            {
                return _dumpDirectory;
            }
            set
            {
                _dumpDirectory = value;
            }
        }

        public string FilePattern
        {
            get
            {
                return _filePattern;
            }
            set
            {
                _filePattern = value;
            }
        }

        public bool Incremental
        {
            get
            {
                return _incremental;
            }
            set
            {
                _incremental = value;
            }
        }

        public string Revisions
        {
            get
            {
                return _revisions;
            }
            set
            {
                _revisions = value;
            }
        }

        public int ProfileID
        {
            get
            {
                return _profileId;
            }
            set
            {
                _profileId = value;
            }
        }
 
        public string RootDumpFilePath
        {
            get
            {
                return _rootDumpFilePath;
            }
            set
            {
                _rootDumpFilePath = value;
            }

        }

        #endregion
    }

    #endregion

    #region SubversionRepositoryInfo Class

    public class SubversionRepositoryInfo
    {
        #region Member Variables

        private string _name = string.Empty;
        private string _repositoryPath = string.Empty;
        private int _repoID;

        #endregion

        #region Properties

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public int RepositoryId
        {
            get
            {
                return _repoID;
            }
            set
            {
                _repoID = value;
            }
        }

        public string RepositoryPath
        {
            get
            {
                return _repositoryPath;
            }
            set
            {
                _repositoryPath = value;
            }
        }

        #endregion
    } 

    #endregion
}
