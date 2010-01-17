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
            var sb = new StringBuilder();
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
            sb.Append("[Revisions] VARCHAR(50)  NULL,");
            sb.Append(Environment.NewLine);
            sb.Append("[RootDumpFilePath] VARCHAR(255)  NOT NULL");
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

            var cmd = new SQLiteCommand(sb.ToString());

            conn.Open();
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
        }

        public void LoadProfileNames()
        {
            SQLiteConnection conn = GetDatabaseConnection();
            var cmd = new SQLiteCommand("SELECT * FROM Profiles");

            conn.Open();
            cmd.Connection = conn;
            SQLiteDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                var p = new Profile();
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
            var cmd = new SQLiteCommand(sql);
            var param = new SQLiteParameter("ProfileId", profileId);
            cmd.Parameters.Add(param);
            SQLiteDataReader dr;

            conn.Open();
            cmd.Connection = conn;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                det = new ProfileDetails
                          {
                              DumpDirectory = dr["DumpDirectory"].ToString(),
                              Repository = dr["Repository"].ToString(),
                              FilePattern = dr["FilePattern"].ToString(),
                              Incremental = Convert.ToBoolean(dr["Incremental"])
                          };

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
            var sbSQL = new StringBuilder();
            SQLiteConnection conn = GetDatabaseConnection();

            sbSQL.Append("UPDATE Details ");
            sbSQL.Append("SET Repository = @Repository, ");
            sbSQL.Append("DumpDirectory = @DumpDirectory, ");
            sbSQL.Append("FilePattern = @FilePattern, ");
            sbSQL.Append("Incremental = @Incremental, ");
            sbSQL.Append("Revisions = @Revisions, ");
            sbSQL.Append("RootDumpFilePath = @RootDumpFilePath ");
            sbSQL.Append("WHERE ProfileID = @ProfileId");

            var cmd = new SQLiteCommand(sbSQL.ToString());
            var param = new SQLiteParameter("Repository", details.Repository);
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
            var sbSQL = new StringBuilder();
            SQLiteConnection conn = GetDatabaseConnection();

            sbSQL.Append("DELETE FROM Profiles ");
            sbSQL.Append("WHERE ID = @ProfileId");

            var cmd = new SQLiteCommand(sbSQL.ToString());
            var param = new SQLiteParameter("ProfileId", profileId);
            cmd.Parameters.Add(param);

            conn.Open();
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();

            conn.Close();

            DeleteProfileDetails(profileId);
        }

        public int GetProfileId(string profileName)
        {
            var sbSQL = new StringBuilder();
            SQLiteConnection conn = GetDatabaseConnection();

            sbSQL.Append("SELECT ID FROM Profiles ");
            sbSQL.Append("WHERE ProfileName COLLATE nocase = @Name");

            var cmd = new SQLiteCommand(sbSQL.ToString());
            var param = new SQLiteParameter("Name", profileName);
            cmd.Parameters.Add(param);

            conn.Open();
            cmd.Connection = conn;
            object obj = cmd.ExecuteScalar();
            int profileId = Convert.ToInt32(obj);

            conn.Close();

            return profileId;
        }

        public List<SubversionRepositoryInfo> LoadRepositories()
        {
            SQLiteConnection conn = GetDatabaseConnection();
            var cmd = new SQLiteCommand("SELECT * FROM Repositories");

            conn.Open();
            cmd.Connection = conn;
            SQLiteDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                var r = new SubversionRepositoryInfo
                            {
                                RepositoryId = Convert.ToInt32(dr["RepoID"]),
                                Name = dr["RepoName"].ToString(),
                                RepositoryPath = dr["RepoPath"].ToString()
                            };
                _repositories.Add(r);
            }

            dr.Close();
            conn.Close();

            return _repositories;
        }

        public void DeleteRepository(int RepositoryId)
        {
            var sbSQL = new StringBuilder();
            SQLiteConnection conn = GetDatabaseConnection();

            sbSQL.Append("DELETE FROM Repositories ");
            sbSQL.Append("WHERE RepoID = @RepoId");

            var cmd = new SQLiteCommand(sbSQL.ToString());
            var param = new SQLiteParameter("RepoId", RepositoryId);
            cmd.Parameters.Add(param);

            conn.Open();
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public int AddRepository(string RepositoryName, string RepositoryPath)
        {
            var sbSQL = new StringBuilder();
            SQLiteConnection conn = GetDatabaseConnection();

            sbSQL.Append("INSERT INTO Repositories (RepoName,RepoPath) ");
            sbSQL.Append("VALUES (@RepoName,@RepoPath); ");
            sbSQL.Append("SELECT last_insert_rowid() As RepositoryID;");

            var cmd = new SQLiteCommand(sbSQL.ToString());
            var param = new SQLiteParameter("RepoName", RepositoryName);
            cmd.Parameters.Add(param);
            param = new SQLiteParameter("RepoPath", RepositoryPath);
            cmd.Parameters.Add(param);

            conn.Open();
            cmd.Connection = conn;
            object obj = cmd.ExecuteScalar();
            int newRepoId = Convert.ToInt32(obj);

            conn.Close();

            return newRepoId;
        }

        public int GetRepositoryId(string RepositoryName)
        {
            var sbSQL = new StringBuilder();
            SQLiteConnection conn = GetDatabaseConnection();

            sbSQL.Append("SELECT RepoID FROM Repositories ");
            sbSQL.Append("WHERE RepoName COLLATE nocase = @Name");

            var cmd = new SQLiteCommand(sbSQL.ToString());
            var param = new SQLiteParameter("Name", RepositoryName);
            cmd.Parameters.Add(param);

            conn.Open();
            cmd.Connection = conn;
            object obj = cmd.ExecuteScalar();
            int profileId = Convert.ToInt32(obj);

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
            var sbSQL = new StringBuilder();
            SQLiteConnection conn = GetDatabaseConnection();

            sbSQL.Append("INSERT INTO Profiles (ProfileName) ");
            sbSQL.Append("VALUES (@ProfileName); ");
            sbSQL.Append("SELECT last_insert_rowid() As ProfileID;");

            var cmd = new SQLiteCommand(sbSQL.ToString());
            var param = new SQLiteParameter("ProfileName", profileName);
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
            var sbSQL = new StringBuilder();
            SQLiteConnection conn = GetDatabaseConnection();

            sbSQL.Append("INSERT INTO Details ");
            sbSQL.Append("(ProfileID,Repository,DumpDirectory,FilePattern,Incremental,Revisions,RootDumpFilePath) ");
            sbSQL.Append("VALUES ");
            sbSQL.Append("(@ProfileId,@Repository,@DumpDirectory,@FilePattern,@Incremental,@Revisions,@RootDumpFilePath)");

            var cmd = new SQLiteCommand(sbSQL.ToString());
            var param = new SQLiteParameter("Repository", details.Repository);
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
            var sbSQL = new StringBuilder();
            SQLiteConnection conn = GetDatabaseConnection();

            sbSQL.Append("DELETE FROM Details ");
            sbSQL.Append("WHERE ProfileID = @ProfileId");

            var cmd = new SQLiteCommand(sbSQL.ToString());
            var param = new SQLiteParameter("ProfileId", profileId);
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
        public int ID { get; set; }

        public string Name { get; set; }
    } 

    #endregion

    #region ProfileDetails Class

    public class ProfileDetails
    {
        #region Properties

        public string Repository { get; set; }

        public string DumpDirectory { get; set; }

        public string FilePattern { get; set; }

        public bool Incremental { get; set; }

        public string Revisions { get; set; }

        public int ProfileID { get; set; }

        public string RootDumpFilePath { get; set; }

        #endregion
    }

    #endregion

    #region SubversionRepositoryInfo Class

    public class SubversionRepositoryInfo
    {
        #region Member Variables

        private string _name = string.Empty;
        private string _repositoryPath = string.Empty;

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

        public int RepositoryId { get; set; }

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
