using DiscordRPC;

namespace KSADiscordRichPresence;

public class DiscordRpcClientManager
{
    private const string DiscordClientId = "1441119568339664977";

    private DiscordRpcClient? Client { get; set; }

    public void Setup()
    {
        if (Client != null) return;

        Client = new DiscordRpcClient(DiscordClientId)
        {
#if DEBUG
            Logger = new DiscordRPC.Logging.ConsoleLogger(DiscordRPC.Logging.LogLevel.Trace, true)
#endif
        };
        Client.Initialize();
    }

    public void SetPresence(string details)
    {
        if (Client == null)
            Console.WriteLine("KSADiscordRichPresence - SetPresence - Client not initialized");

        Client?.SetPresence(new RichPresence()
        {
            Details = details,
            Assets = new Assets()
            {
                LargeImageKey = AssetKeys.Default.Key,
                SmallImageKey = AssetKeys.KsaFish.Key,
            }
        });
    }

    public void Cleanup()
    {
        if (Client == null)
            Console.WriteLine("KSADiscordRichPresence - Cleanup - Client not initialized");

        Client?.Dispose();
    }
}