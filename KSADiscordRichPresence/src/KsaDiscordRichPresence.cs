using StarMap.API;
using KSA;

namespace KSADiscordRichPresence;

[StarMapMod]
public class KsaDiscordRichPresence
{
    private DiscordRpcClientManager? DiscordRpcClientManager { get; set; }

    private string lastVehicleClass = string.Empty;
    private string lastVehicleSituation = string.Empty;
    private string lastVehicleLocation = string.Empty;
    private string lastVehicleId = string.Empty;

    [StarMapImmediateLoad]
    public void Init(Mod definingMod)
    {
        DiscordRpcClientManager = new DiscordRpcClientManager();
        DiscordRpcClientManager?.Setup();
        
        DiscordRpcClientManager?.InitPresence();

        VehicleEvents.StateChanged += (vehicle) =>
        {
            var id = Program.ControlledVehicle?.Id;
            if (vehicle.Id != id) return;

            if (!DetectRelevateChange(vehicle)) return;

            DiscordRpcClientManager?.SetPresence(vehicle);
        };
    }

    private bool DetectRelevateChange(Vehicle veh)
    {
        var changed = false;
        if (lastVehicleId != veh.Id)
        {
            lastVehicleId = veh.Id;
            changed = true;
        }

        if (lastVehicleClass != veh.Class)
        {
            lastVehicleClass = veh.Class;
            changed = true;
        }

        var situation = veh.LastKinematicStates.Situation;
        if (situation != Situation.Maneuvering && lastVehicleSituation != situation.ToString())
        {
            lastVehicleSituation = situation.ToString();
            changed = true;
        }

        var location = veh.Parent.Id;
        if (lastVehicleLocation != location)
        {
            lastVehicleLocation = location;
            changed = true;
        }

        return changed;
    }

    [StarMapAllModsLoaded]
    public void OnAllModsLoaded()
    {
        Patcher.ApplyPatches();
    }

    [StarMapUnload]
    public void OnModUnload()
    {
        Patcher.RemovePatches();
        DiscordRpcClientManager?.Cleanup();
    }
}