namespace KSADiscordRichPresence;

public sealed class AssetKeys
{
    public string Key { get; }

    private AssetKeys(string key) => Key = key;

    public static readonly AssetKeys KsaSol = new AssetKeys("ksa-sol");
    public static readonly AssetKeys KsaEarth = new AssetKeys("ksa-earth");
    public static readonly AssetKeys KsaMoon = new AssetKeys("ksa-luna");
    public static readonly AssetKeys KsaMars = new AssetKeys("ksa-mars");
    public static readonly AssetKeys KsaEva = new AssetKeys("ksa-eva");
    public static readonly AssetKeys KsaCover = new AssetKeys("ksa-cover");
    public static readonly AssetKeys KsaFish = new AssetKeys("fish-black");
    public static readonly AssetKeys Default = new AssetKeys("ksa-cover");

    public override string ToString() => Key;

    public static IReadOnlyList<AssetKeys> Values { get; } =
    [
        KsaSol,
        KsaEarth,
        KsaMoon,
        KsaMars,
        KsaEva,
        KsaFish,
        KsaCover
    ];
    
    public static AssetKeys FromBodyId(string bodyId)
    {
        foreach (var assetKey in Values)
        {
            if (assetKey.Key.Contains(bodyId, StringComparison.InvariantCultureIgnoreCase))
                return assetKey;
        }
        return Default;
    }
};