using HarmonyLib;

namespace BetterJewelry
{
    public static class PInfo
    {
        // each loaded plugin needs to have a unique GUID. usually author+generalCategory+Name is good enough
        public const string GUID = "alexi.lbol.betterjewelry";
        public const string Name = "BetterJewelry";
        public const string version = "1.0.0";
        public static readonly Harmony harmony = new Harmony(GUID);

    }
}
