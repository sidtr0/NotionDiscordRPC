using System.Diagnostics;
using NetDiscordRpc;
using NetDiscordRpc.Core.Logger;
using NetDiscordRpc.RPC;

class NotionWindow
{
    public static string PageName = "";

    public static string GetPageName()
    {
        Process[] notionProcesses = Process.GetProcessesByName("notion");
        if (notionProcesses.Length == 0)
        {
            Environment.Exit(0);
        }
        PageName = notionProcesses[0].MainWindowTitle;
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

        Timestamps timestamp = Timestamps.Now;

        while (true)
        {
            DiscordRpc.SetPresence(new RichPresence()
            {
                Details = $"Editing {NotionWindow.GetPageName()}",
                Assets = new Assets()
                {
                    LargeImageKey = "notion_app_logo",
                    LargeImageText = "Notion"
                },
                Timestamps = timestamp
            });

            DiscordRpc.Invoke();

            Task.Delay(5000).Wait();
        }
    }
} 