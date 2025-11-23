using HarmonyLib;
using KSA; // namespace do jogo

namespace KSADiscordRichPresence;

public static class VehicleEvents
{
    // assine: VehicleEvents.StateChanged += (veh, reason) => { ... };
    public static event Action<Vehicle>? StateChanged;

    public static void OnStateChanged(Vehicle vehicle)
    {
        StateChanged?.Invoke(vehicle);
    }
}

[HarmonyPatch(typeof(Vehicle), nameof(Vehicle.SetFlightPlan))]
static class Patch_Vehicle_SetFlightPlan
{
    static void Postfix(Vehicle __instance)
    {
        VehicleEvents.OnStateChanged(__instance);
    }
}