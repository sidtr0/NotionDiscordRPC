using System.Diagnostics;
using NetDiscordRpc;
using NetDiscordRpc.Core.Logger;
using NetDiscordRpc.RPC;

class NotionWindow
{
    public static string PageName = "";

    public static string GetPageName()
    {

        // Get MainWindowTitle and assign it to PageName
        Process[] processlist = Process.GetProcesses();
        foreach (Process process in processlist)
        {
            if (!String.IsNullOrEmpty(process.MainWindowTitle) && process.ProcessName == "Notion")
            {
                PageName = process.MainWindowTitle;
            }
        }
        return PageName;
    }
}

class RPC
{
    public static DiscordRPC DiscordRpc;

    static void Main()
    {
        DiscordRpc = new DiscordRPC("934687905971052545");
        DiscordRpc.Logger = new ConsoleLogger();
        DiscordRpc.Initialize();

        DiscordRpc.SetPresence(new RichPresence()
        {
            Details = NotionWindow.GetPageName(),
            Assets = new Assets()
            {
                LargeImageKey = "notion_app_logo",
                LargeImageText = "Notion"
            },
            Timestamps = Timestamps.Now
        });

        DiscordRpc.Invoke();

        Console.ReadKey(true);
    }
}