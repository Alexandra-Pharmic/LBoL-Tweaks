﻿using HarmonyLib;

namespace WhiteButterfly
{
    public static class PInfo
    {
        // each loaded plugin needs to have a unique GUID. usually author+generalCategory+Name is good enough
        public const string GUID = "alexi.lbol.whitebutterfly";
        public const string Name = "WhiteButterfly";
        public const string version = "1.0.0";
        public static readonly Harmony harmony = new Harmony(GUID);

    }
}
