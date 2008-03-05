using System;
using System.Windows.Forms;

namespace SVN_Backup_Widget
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.GetUpperBound(0) >= 0)
            {
                SvnCommands cmd = new SvnCommands();
                Arguments cmdargs = new Arguments(args);
                string param = cmdargs[0].ToLower();

                switch(param)
                {
                    case "?":
                    case "help":
                        Console.WriteLine(Environment.NewLine);
                        Console.WriteLine("Usage: svnbackupwidget " + (char)34 + "profile name" + (char)34);
                        Console.WriteLine(Environment.NewLine);
                        break;
                    default:
                        string profileName;
                        profileName = param;
                        cmd.RunDump(profileName);
                        break;
                }
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());
            }
        }
    }
}