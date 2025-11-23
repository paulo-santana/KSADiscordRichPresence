using System.Reflection;
using HarmonyLib;

namespace KSADiscordRichPresence;

[HarmonyPatch]
internal static class Patcher
{
    private static readonly Harmony? HarmonyInstance = new("KSADiscordRichPresence");
    
    
    public static void ApplyPatches()
    {
        HarmonyInstance?.PatchAll(Assembly.GetExecutingAssembly());
    }
    
    public static void RemovePatches()
    {
        HarmonyInstance?.UnpatchAll(HarmonyInstance.Id);
    }
    
    
}