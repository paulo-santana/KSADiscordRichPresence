using DiscordRPC;
using KSA;

namespace KSADiscordRichPresence;

public class DiscordRpcClientManager
{
    private DateTime _startedPlaying;
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
    
    public void InitPresence()
    {
        if (Client == null)
            Console.WriteLine("KSADiscordRichPresence - InitPresence - Client not initialized");

        _startedPlaying = DateTime.UtcNow;
        Client?.SetPresence(new RichPresence()
        {
            Details = "In Menu",
            Timestamps = new Timestamps(_startedPlaying),
            Assets = new Assets()
            {
                LargeImageKey = AssetKeys.Default.Key,
                SmallImageKey = AssetKeys.KsaFish.Key,
            }
        });
    }

    public void SetPresence(Vehicle vehicle)
    {
        if (Client == null)
            Console.WriteLine("KSADiscordRichPresence - SetPresence - Client not initialized");

        Client?.SetPresence(new RichPresence()
        {
            Details = GetDetails(vehicle),
            State = GetState(vehicle),
            Timestamps = new Timestamps(_startedPlaying),
            Assets = new Assets()
            {
                LargeImageKey = AssetKeys.FromBodyId(vehicle.Parent.Id).Key,
                SmallImageKey = AssetKeys.KsaFish.Key,
            }
        });
    }

    private static string GetState(Vehicle vehicle)
    {
        var body = vehicle.Parent.Id;
        var doing = vehicle.LastKinematicStates.Situation switch
        {
            Situation.Landed => "Landed on",
            Situation.Freefall => "Orbiting",
            Situation.Sailing => "Splashed down on",
            _ => "Fooling around on"
        };

        return $"{doing} {body}";
    }

    private static string GetDetails(Vehicle vehicle)
    {
        return $"Flying {vehicle.Id}";
    }

    public void Cleanup()
    {
        if (Client == null)
            Console.WriteLine("KSADiscordRichPresence - Cleanup - Client not initialized");

        Client?.Dispose();
    }
}