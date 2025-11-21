using StarMap.API;
using KSA;

namespace KSADiscordRichPresence;

[StarMapMod]
public class KsaDiscordRichPresence
{
    private DiscordRpcClientManager? DiscordRpcClientManager { get; set; }

    [StarMapImmediateLoad]
    public void Init(Mod definingMod)
    {
        DiscordRpcClientManager = new DiscordRpcClientManager();
        DiscordRpcClientManager?.Setup();
        // TODO: Hook into KSA events to update presence based on player activity
        DiscordRpcClientManager?.SetPresence("Orbiting something");
    }
}