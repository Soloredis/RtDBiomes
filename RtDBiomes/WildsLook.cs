using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BepInEx.Configuration;
using Jotunn.Entities;
using Jotunn.Managers;
using UnityEngine;
using static Heightmap;

namespace RtDBiomes
{
    internal partial class RtDBiomes
    {
        private ConfigEntry<bool> WildsVegetationEnable;
        private ConfigEntry<bool> WildsGrassEnable;

        private const Biome WildsLandBiomes =
            Biome.Meadows | Biome.BlackForest | Biome.Swamp | Biome.Mountain |
            Biome.Plains | Biome.AshLands | Biome.DeepNorth | Biome.Mistlands;

        private ConfigEntry<bool> WildsKeepVanillaResources;

        internal static readonly HashSet<string> WildsKeepVanillaPrefabs = new HashSet<string>
        {
            "MineRock_Tin", "rock4_copper", "silvervein", "MineRock_Obsidian", "Pickable_Ashstone",
            "giant_helmet1", "giant_helmet2", "giant_sword1", "giant_sword2", "giant_ribs",
            "Pickable_Branch", "Pickable_Branch_Snow", "Pickable_Dandelion", "Pickable_Flint",
            "Pickable_Mushroom", "Pickable_Mushroom_JotunPuffs", "Pickable_Mushroom_Magecap",
            "Pickable_SeedCarrot", "Pickable_SeedKale", "Pickable_SeedTurnip", "Pickable_SmokePuff",
            "Pickable_Stone", "Pickable_StoneRock", "Pickable_Thistle", "Pickable_Charredskull",
            "Pickable_Pot_Shard", "Pickable_Snowball",
            "RaspberryBush", "BlueberryBush", "CloudberryBush", "LingonberryBush"
        };

        internal static readonly HashSet<string> WildsMistlandsRockPrefabs = new HashSet<string>
        {
            "cliff_mistlands1", "cliff_mistlands2", "rock_mistlands1"
        };

        internal static readonly HashSet<string> WildsMistlandsShootPrefabs = new HashSet<string>
        {
            "YggaShoot1", "YggaShoot2", "YggaShoot3"
        };

        private ConfigEntry<float> WildsMistlandsRockAmount;
        private ConfigEntry<float> WildsMistlandsShootAmount;

        private ConfigEntry<float> WildsMistlandsDensity;
        private ConfigEntry<float> WildsMistlandsMaxSlope;
        private ConfigEntry<float> WildsMistlandsMaxTerrainDelta;
        private ConfigEntry<float> WildsMistlandsTreeScale;
        private ConfigEntry<float> WildsMistlandsBigTreeScaleMin;
        private ConfigEntry<float> WildsMistlandsBigTreeScaleMax;
        private ConfigEntry<float> WildsMistlandsMagicTreeScaleMin;
        private ConfigEntry<float> WildsMistlandsMagicTreeScaleMax;

        internal static readonly HashSet<string> WildsMistlandsMagicTreePrefabs = new HashSet<string>
        {
            "MagicTree1_RtD"
        };
        private ConfigEntry<float> WildsMistlandsExtraGrass;

        private class WildsBiomeSettings
        {
            public Biome Biome;
            public ConfigEntry<float> Density;
            public ConfigEntry<float> TreeScaleMin;
            public ConfigEntry<float> TreeScaleMax;
            public ConfigEntry<float> MaxSlope;
            public ConfigEntry<float> MaxTerrainDelta;
            public ConfigEntry<float> GrassAmount;
        }

        private static readonly Biome[] WildsTunableBiomes =
        {
            Biome.Meadows, Biome.BlackForest, Biome.Swamp, Biome.Mountain, Biome.Plains, Biome.AshLands, Biome.DeepNorth
        };

        private readonly List<WildsBiomeSettings> wildsBiomeSettings = new List<WildsBiomeSettings>();

        private readonly Dictionary<ZoneSystem.ZoneVegetation, Vector2> wildsOriginalLimits =
            new Dictionary<ZoneSystem.ZoneVegetation, Vector2>();

        internal static readonly HashSet<string> WildsTreePrefabs = new HashSet<string>
        {
            "Beech1", "Beech_small1", "Beech_small2", "Birch1", "Birch2", "Oak1",
            "FirTree", "FirTree_small", "FirTree_small_dead", "Pinetree_01", "SwampTree1",
            "AshlandsTree1", "AshlandsTree3", "AshlandsTree6",
            "Pinetree_Snow", "Pinetree_Snow_dead", "SnowFirTree", "SnowFirTree 2", "SnowFirTree_small",
            "ForestTree1_RtD", "Oak1_RtD", "Oak2_RtD",
            "RedPine_RtD", "RedPine1_RtD", "RedPine2_RtD", "RedPine3_RtD", "RedPine4_RtD",
            "WinterPine3_RtD", "WinterPine4_RtD", "WinterPine5_RtD", "ThinPine1_RtD", "ThinPine2_RtD",
            "SwampTree1_RtD", "SwampTree2_RtD", "SwampTree3_RtD", "SwampTree4_RtD", "SwampTree5_RtD", "SwampTree6_RtD",
            "MagicTree2_RtD", "MagicTree3_RtD", "MagicTree4_RtD", "MagicTree5_RtD", "MagicTree6_RtD",
            "MagicTree7_RtD", "MagicTree8_RtD", "MagicTree9_RtD", "MagicTree10_RtD",
            "Acacia1_RtD", "Acacia2_RtD", "Acacia3_RtD", "Acacia4_RtD", "PalmTree1_RtD", "PalmTree2_RtD",
            "DeadTree1_RtD", "DeadTree2_RtD", "DeadTree3_RtD", "DeadTree4_RtD", "DeadTree5_RtD",
            "DeadTree6_RtD", "DeadTree7_RtD", "DeadTree8_RtD", "DeadTree9_RtD",
            "Blossom1_RtD", "Blossom2_RtD", "Blossom3_RtD", "Blossom4_RtD", "Blossom5_RtD",
            "WillowTree1_RtD", "WillowTree2_RtD", "CottonWood1_RtD", "CottonWood2_RtD"
        };

        internal static readonly HashSet<string> WildsMistlandsExtraGrassPrefabs = new HashSet<string>
        {
            "instanced_meadows_grass_short", "instanced_ormbunke", "instanced_forest_groundcover"
        };

        internal static readonly HashSet<string> WildsMistlandsRemovedPrefabs = new HashSet<string>
        {
            "SwampTree1"
        };

        internal static readonly HashSet<string> WildsMistlandsTreePrefabs = new HashSet<string>
        {
            "Beech1", "Oak1", "Birch1",
            "WillowTree1_RtD", "WillowTree2_RtD", "Oak1_RtD", "Oak2_RtD", "ForestTree1_RtD",
            "Blossom1_RtD", "Blossom2_RtD", "Blossom3_RtD", "Blossom4_RtD", "Blossom5_RtD"
        };

        private readonly Dictionary<ZoneSystem.ZoneVegetation, Vector2> wildsOriginalTreeScale =
            new Dictionary<ZoneSystem.ZoneVegetation, Vector2>();

        private const string WildsClutterSuffix = "_RtDWilds";

        private readonly List<ZoneSystem.ZoneVegetation> vanillaVegetationSnapshot = new List<ZoneSystem.ZoneVegetation>();

        private void SetupWildsLook()
        {
            WildsVegetationEnable = Config.Bind("Wilds Look", "Wilds Vegetation", true, new ConfigDescription(
                "Replace vanilla trees, rocks and pickables in the land biomes with the Expand World Wilds versions. " +
                "Only affects newly generated areas. Every player should use the same setting.", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));

            WildsKeepVanillaResources = Config.Bind("Wilds Look", "Keep Vanilla Resources", true, new ConfigDescription(
                "With Wilds Vegetation on: keep ores, pickables, berry bushes and giant remains " +
                "at vanilla amounts. Turn off for an exact copy of the Wilds biomes (resources become scarce).", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));

            WildsMistlandsRockAmount = Config.Bind("Wilds Look", "Mistlands Rock Amount", 0.25f, new ConfigDescription(
                "With Wilds Vegetation on: how many of the vanilla Mistlands rocks and cliffs to keep. " +
                "0 = none (exact Wilds), 0.25 = a light amount, 1 = vanilla.", new AcceptableValueRange<float>(0f, 1f),
                new ConfigurationManagerAttributes { IsAdminOnly = true }));

            WildsMistlandsShootAmount = Config.Bind("Wilds Look", "Mistlands Yggdrasil Amount", 0.5f, new ConfigDescription(
                "With Wilds Vegetation on: how many of the big vanilla Yggdrasil shoots to keep (the source of Yggdrasil wood). " +
                "0 = none (exact Wilds), 1 = vanilla.", new AcceptableValueRange<float>(0f, 1f),
                new ConfigurationManagerAttributes { IsAdminOnly = true }));

            WildsMistlandsDensity = Config.Bind("Wilds Look", "Mistlands Density", 1.5f, new ConfigDescription(
                "With Wilds Vegetation on: multiplies the Wilds Mistlands trees, bushes and fireflies (1 = same as your Wilds files).",
                new AcceptableValueRange<float>(0.25f, 4f), new ConfigurationManagerAttributes { IsAdminOnly = true }));

            WildsMistlandsMaxSlope = Config.Bind("Wilds Look", "Mistlands Max Slope", 40f, new ConfigDescription(
                "With Wilds Vegetation on: Mistlands trees, bushes and grass may grow on slopes up to this angle " +
                "(the Wilds files use 20-30, made for flatter ground).", new AcceptableValueRange<float>(0f, 90f),
                new ConfigurationManagerAttributes { IsAdminOnly = true }));

            WildsMistlandsMaxTerrainDelta = Config.Bind("Wilds Look", "Mistlands Max Terrain Delta", 6f, new ConfigDescription(
                "With Wilds Vegetation on: how bumpy the ground under Mistlands trees and bushes may be " +
                "(the Wilds files use 2-3).", new AcceptableValueRange<float>(0f, 20f),
                new ConfigurationManagerAttributes { IsAdminOnly = true }));

            WildsMistlandsTreeScale = Config.Bind("Wilds Look", "Mistlands Tree Scale", 1.3f, new ConfigDescription(
                "With Wilds Vegetation on: size multiplier for the Mistlands trees (beech, oak, birch, willow, RtD trees). 1 = normal size.",
                new AcceptableValueRange<float>(0.5f, 3f), new ConfigurationManagerAttributes { IsAdminOnly = true }));

            WildsMistlandsBigTreeScaleMin = Config.Bind("Wilds Look", "Mistlands Big Tree Scale Min", 1.30f, new ConfigDescription(
                "With Wilds Vegetation on: smallest size of the big Yggdrasil shoots, " +
                "compared to their normal size (1.30 = 30% bigger).", new AcceptableValueRange<float>(0.5f, 3f),
                new ConfigurationManagerAttributes { IsAdminOnly = true }));

            WildsMistlandsBigTreeScaleMax = Config.Bind("Wilds Look", "Mistlands Big Tree Scale Max", 1.42f, new ConfigDescription(
                "With Wilds Vegetation on: largest size of the big Yggdrasil shoots, " +
                "compared to their normal size (1.42 = 42% bigger). Each tree gets a random size between Min and Max.",
                new AcceptableValueRange<float>(0.5f, 3f), new ConfigurationManagerAttributes { IsAdminOnly = true }));

            WildsMistlandsMagicTreeScaleMin = Config.Bind("Wilds Look", "Mistlands Magic Tree Scale Min", 1.25f, new ConfigDescription(
                "With Wilds Vegetation on: smallest size of the Mistlands magic trees compared to their normal size (1.25 = 25% bigger).",
                new AcceptableValueRange<float>(0.5f, 3f), new ConfigurationManagerAttributes { IsAdminOnly = true }));

            WildsMistlandsMagicTreeScaleMax = Config.Bind("Wilds Look", "Mistlands Magic Tree Scale Max", 1.42f, new ConfigDescription(
                "With Wilds Vegetation on: largest size of the Mistlands magic trees compared to their normal size (1.42 = 42% bigger).",
                new AcceptableValueRange<float>(0.5f, 3f), new ConfigurationManagerAttributes { IsAdminOnly = true }));

            WildsMistlandsExtraGrass = Config.Bind("Wilds Look", "Mistlands Extra Grass Amount", 0.75f, new ConfigDescription(
                "With Wilds Grass on: amount of the extra Wilds grass in Mistlands (meadow grass, ferns, forest ground cover). " +
                "1 = same as your Wilds files. Visual only, applies on next world load.", new AcceptableValueRange<float>(0f, 2f),
                new ConfigurationManagerAttributes { IsAdminOnly = false }));

            foreach (var biome in WildsTunableBiomes)
            {
                string section = "Wilds Look - " + biome;
                wildsBiomeSettings.Add(new WildsBiomeSettings
                {
                    Biome = biome,
                    Density = Config.Bind(section, "Density", 1f, new ConfigDescription(
                        $"With Wilds Vegetation on: multiplies how many Wilds trees, bushes and rocks spawn in {biome}. " +
                        "Ores and pickables kept by Keep Vanilla Resources and the RtD plants from Biomes.cs are not affected. 1 = unchanged.",
                        new AcceptableValueRange<float>(0f, 4f), new ConfigurationManagerAttributes { IsAdminOnly = true })),
                    TreeScaleMin = Config.Bind(section, "Tree Scale Min", 1f, new ConfigDescription(
                        $"With Wilds Vegetation on: smallest size of the trees in {biome} (Wilds and RtD trees), compared to their normal size. 1 = unchanged.",
                        new AcceptableValueRange<float>(0.25f, 4f), new ConfigurationManagerAttributes { IsAdminOnly = true })),
                    TreeScaleMax = Config.Bind(section, "Tree Scale Max", 1f, new ConfigDescription(
                        $"With Wilds Vegetation on: largest size of the trees in {biome} (Wilds and RtD trees), compared to their normal size. 1 = unchanged.",
                        new AcceptableValueRange<float>(0.25f, 4f), new ConfigurationManagerAttributes { IsAdminOnly = true })),
                    MaxSlope = Config.Bind(section, "Max Slope", 0f, new ConfigDescription(
                        $"With Wilds Vegetation on: lets plants in {biome} grow on slopes up to this angle. 0 = unchanged.",
                        new AcceptableValueRange<float>(0f, 90f), new ConfigurationManagerAttributes { IsAdminOnly = true })),
                    MaxTerrainDelta = Config.Bind(section, "Max Terrain Delta", 0f, new ConfigDescription(
                        $"With Wilds Vegetation on: lets plants in {biome} grow on bumpier ground, up to this value. 0 = unchanged.",
                        new AcceptableValueRange<float>(0f, 20f), new ConfigurationManagerAttributes { IsAdminOnly = true })),
                    GrassAmount = Config.Bind(section, "Grass Amount", 1f, new ConfigDescription(
                        $"With Wilds Grass on: multiplies the Wilds grass and ground cover in {biome}. Visual only, applies instantly. 1 = unchanged.",
                        new AcceptableValueRange<float>(0f, 3f), new ConfigurationManagerAttributes { IsAdminOnly = false }))
                });
            }

            WildsGrassEnable = Config.Bind("Wilds Look", "Wilds Grass", true, new ConfigDescription(
                "Replace vanilla grass and ground cover in the land biomes with the Expand World Wilds versions. " +
                "Visual only, takes effect on next world load.", null,
                new ConfigurationManagerAttributes { IsAdminOnly = false }));

            EventHandler regrass = (s, e) => { if (ClutterSystem.instance) ApplyWildsGrass("config", rebuild: true); };
            WildsMistlandsExtraGrass.SettingChanged += regrass;
            foreach (var settings in wildsBiomeSettings)
                settings.GrassAmount.SettingChanged += regrass;

            ZoneManager.OnVanillaVegetationAvailable += CaptureVanillaVegetation;
            ZoneManager.OnVegetationRegistered += ApplyWildsVegetation;
            ZoneManager.OnVanillaClutterAvailable += ApplyWildsClutter;
            ZoneManager.OnClutterRegistered += CaptureModClutter;

            StartCoroutine(WildsGrassWatcher());

            wildsPluginInstance = this;
            CommandManager.Instance.AddConsoleCommand(new WildsGrassCommand());
        }

        private static RtDBiomes wildsPluginInstance;
        private int wildsGrassLastFixedInstance;
        private int wildsGrassWarnedInstance;

        private IEnumerator WildsGrassWatcher()
        {
            var wait = new WaitForSecondsRealtime(3f);
            while (true)
            {
                yield return wait;
                try
                {
                    if (!WildsGrassEnable.Value || !Player.m_localPlayer || !ClutterSystem.instance) continue;
                    ApplyWildsGrass("watcher");
                }
                catch (Exception ex)
                {
                    Logger.LogWarning($"Exception caught in Wilds grass watcher: {ex}");
                }
            }
        }

        private WildsBiomeSettings[] WildsSettingsFor(Biome biome) =>
            wildsBiomeSettings.Where(s => (biome & s.Biome) != 0).ToArray();

        private static bool IsWildsGrass(ClutterSystem.Clutter c) =>
            c != null && c.m_name != null && c.m_name.EndsWith(WildsClutterSuffix);

        private static readonly HashSet<ClutterSystem.Clutter> wildsClutterBeforeMods = new HashSet<ClutterSystem.Clutter>();
        private static readonly HashSet<ClutterSystem.Clutter> wildsModClutter = new HashSet<ClutterSystem.Clutter>();

        private static bool IsModClutter(ClutterSystem.Clutter c) => c != null && wildsModClutter.Contains(c);

        private void CaptureModClutter()
        {
            var cs = ClutterSystem.instance;
            if (!cs) return;
            wildsModClutter.Clear();
            foreach (var c in cs.m_clutter)
                if (c != null && !IsWildsGrass(c) && !wildsClutterBeforeMods.Contains(c))
                    wildsModClutter.Add(c);
        }

        private void ApplyWildsClutter()
        {
            ApplyWildsGrass("startup");
            wildsClutterBeforeMods.Clear();
            if (ClutterSystem.instance)
                wildsClutterBeforeMods.UnionWith(ClutterSystem.instance.m_clutter);
        }

        private string ApplyWildsGrass(string reason, bool rebuild = false)
        {
            try
            {
                var cs = ClutterSystem.instance;
                if (!cs) return "no ClutterSystem yet";
                if (SystemInfo.graphicsDeviceType == UnityEngine.Rendering.GraphicsDeviceType.Null) return "dedicated server, grass is only drawn on clients";
                if (!WildsGrassEnable.Value) return "Wilds Grass is off in the config";
                var clutterList = cs.m_clutter;
                int rebuilt = rebuild ? clutterList.RemoveAll(IsWildsGrass) : 0;

                var prefabs = new Dictionary<string, GameObject>();
                foreach (var c in clutterList)
                    if (c != null && c.m_prefab && !prefabs.ContainsKey(c.m_prefab.name))
                        prefabs[c.m_prefab.name] = c.m_prefab;

                int stripped = 0;
                foreach (var c in clutterList)
                {
                    if (c == null || IsWildsGrass(c) || IsModClutter(c) || (c.m_biome & WildsLandBiomes) == 0) continue;
                    c.m_biome &= ~WildsLandBiomes;
                    if (c.m_biome == Biome.None) c.m_enabled = false;
                    stripped++;
                }

                int added = 0;
                var missing = new HashSet<string>();
                if (!clutterList.Exists(IsWildsGrass))
                {
                    float slope = WildsMistlandsMaxSlope.Value;
                    foreach (var data in WildsClutterList)
                    {
                        if (!prefabs.TryGetValue(data.Prefab, out var prefab) || !prefab)
                        {
                            prefab = PrefabManager.Cache.GetPrefab<GameObject>(data.Prefab);
                            if (prefab) prefabs[data.Prefab] = prefab;
                        }
                        if (!prefab)
                        {
                            missing.Add(data.Prefab);
                            continue;
                        }
                        var clutter = data.Create(prefab);
                        if (clutter.m_biome == Biome.Mistlands)
                        {
                            clutter.m_maxTilt = Mathf.Max(clutter.m_maxTilt, slope + 5f);
                            if (WildsMistlandsExtraGrassPrefabs.Contains(data.Prefab))
                                clutter.m_amount = Mathf.RoundToInt(clutter.m_amount * WildsMistlandsExtraGrass.Value);
                        }
                        else
                        {
                            var biomeSettings = WildsSettingsFor(clutter.m_biome);
                            if (biomeSettings.Length > 0)
                            {
                                float grassAmount = biomeSettings.Max(b => b.GrassAmount.Value);
                                if (grassAmount != 1f)
                                    clutter.m_amount = Mathf.RoundToInt(clutter.m_amount * grassAmount);
                                float grassSlope = biomeSettings.Max(b => b.MaxSlope.Value);
                                if (grassSlope > 0f)
                                    clutter.m_maxTilt = Mathf.Max(clutter.m_maxTilt, grassSlope + 5f);
                            }
                        }
                        clutterList.Add(clutter);
                        added++;
                    }
                }

                if (missing.Count > 0)
                    Logger.LogWarning("Wilds grass: skipped grass that is not loaded yet: " + string.Join(", ", missing));

                if (stripped == 0 && added == 0) return "already applied, nothing to change";

                if (reason != "startup") cs.ClearAll();

                string summary = $"Wilds grass ({reason}): turned off {stripped} vanilla grass entries in land biomes, " +
                                 $"added {added} Wilds entries{(rebuild ? $" (rebuilt {rebuilt})" : "")} (ClutterSystem #{cs.GetInstanceID()}, {clutterList.Count} entries total).";
                int id = cs.GetInstanceID();
                if (reason == "watcher" && wildsGrassLastFixedInstance == id)
                {
                    if (wildsGrassWarnedInstance != id)
                        Logger.LogWarning(summary + " Something keeps resetting the grass list (another mod?).");
                    wildsGrassWarnedInstance = id;
                }
                else
                    Logger.LogInfo(summary);
                if (reason == "watcher") wildsGrassLastFixedInstance = id;
                return summary;
            }
            catch (Exception ex)
            {
                Logger.LogWarning($"Exception caught while applying Wilds grass: {ex}");
                return "error: " + ex.Message;
            }
        }

        private static string WildsGrassStatus()
        {
            var cs = ClutterSystem.instance;
            if (!cs) return "No ClutterSystem right now.";
            var list = cs.m_clutter;
            int wilds = list.Count(IsWildsGrass);
            var vanillaLand = list.Where(c => c != null && !IsWildsGrass(c) && !IsModClutter(c) && c.m_enabled && (c.m_biome & WildsLandBiomes) != 0)
                                  .Select(c => (c.m_prefab ? c.m_prefab.name : c.m_name) + " [" + c.m_biome + "]").ToList();
            string status = $"ClutterSystem #{cs.GetInstanceID()}: {list.Count} entries, {wilds} Wilds entries, " +
                   $"{vanillaLand.Count} vanilla entries still active in land biomes" +
                   (vanillaLand.Count > 0 ? ": " + string.Join(", ", vanillaLand) : ".") +
                   $" Wilds Grass config = {wildsPluginInstance?.WildsGrassEnable?.Value}.";

            if (Player.m_localPlayer && WorldGenerator.instance != null)
            {
                Vector3 pos = Player.m_localPlayer.transform.position;
                Biome here = WorldGenerator.instance.GetBiome(pos);
                var matching = list.Where(c => c != null && c.m_enabled && (c.m_biome & here) != 0)
                                   .Select(c => $"{(c.m_prefab ? c.m_prefab.name : c.m_name)}(amount {c.m_amount}, " +
                                                $"alt {c.m_minAlt}-{c.m_maxAlt}, tilt<={c.m_maxTilt}{(IsWildsGrass(c) ? ", Wilds" : "")})")
                                   .ToList();
                status += $" You are in {here} at height {pos.y:0}. Grass allowed here: " +
                          (matching.Count > 0 ? string.Join(", ", matching) : "none") + ".";
            }
            return status;
        }

        private class WildsGrassCommand : ConsoleCommand
        {
            public override string Name => "rtd_grass";
            public override string Help => "RtDBiomes: show the Wilds grass status. 'rtd_grass fix' re-applies it and redraws the grass. " +
                                           "'rtd_grass prefabs' lists all grass prefabs.";

            public override void Run(string[] args, Terminal context)
            {
                var plugin = wildsPluginInstance;
                if (plugin == null) return;
                if (args.Length > 0 && args[0] == "prefabs")
                {
                    var names = ClutterSystem.instance
                        ? ClutterSystem.instance.m_clutter.Where(c => c != null && c.m_prefab).Select(c => c.m_prefab.name).Distinct().OrderBy(n => n).ToList()
                        : new List<string>();
                    context?.AddString("Grass prefabs: " + string.Join(", ", names));
                    return;
                }
                if (args.Length > 0 && args[0] == "fix")
                {
                    string result = plugin.ApplyWildsGrass("command", rebuild: true);
                    if (ClutterSystem.instance) ClutterSystem.instance.ClearAll();
                    context?.AddString(result);
                }
                string status = WildsGrassStatus();
                context?.AddString(status);
                plugin.Logger.LogInfo(status);
            }
        }

        private void CaptureVanillaVegetation()
        {
            vanillaVegetationSnapshot.Clear();
            if (ZoneSystem.instance)
                vanillaVegetationSnapshot.AddRange(ZoneSystem.instance.m_vegetation);
        }

        private void ApplyWildsVegetation()
        {
            try
            {
                if (!WildsVegetationEnable.Value || !ZoneSystem.instance) return;

                bool keepResources = WildsKeepVanillaResources.Value;
                float rockAmount = Mathf.Clamp01(WildsMistlandsRockAmount.Value);
                float shootAmount = Mathf.Clamp01(WildsMistlandsShootAmount.Value);

                int stripped = 0, lightened = 0;
                foreach (var veg in vanillaVegetationSnapshot)
                {
                    if (veg == null || (veg.m_biome & WildsLandBiomes) == 0) continue;
                    string name = veg.m_prefab ? veg.m_prefab.name : veg.m_name;

                    float lightAmount = WildsMistlandsRockPrefabs.Contains(name) ? rockAmount
                                      : WildsMistlandsShootPrefabs.Contains(name) ? shootAmount : -1f;
                    if (lightAmount > 0f && (veg.m_biome & Biome.Mistlands) != 0)
                    {
                        veg.m_biome = (veg.m_biome & ~WildsLandBiomes) | Biome.Mistlands;
                        veg.m_min *= lightAmount;
                        veg.m_max *= lightAmount;
                        if (WildsMistlandsShootPrefabs.Contains(name))
                        {
                            veg.m_scaleMin *= WildsMistlandsBigTreeScaleMin.Value;
                            veg.m_scaleMax *= WildsMistlandsBigTreeScaleMax.Value;
                        }
                        lightened++;
                        continue;
                    }

                    if (keepResources && WildsKeepVanillaPrefabs.Contains(name)) continue;
                    veg.m_biome &= ~WildsLandBiomes;
                    if (veg.m_biome == Biome.None) veg.m_enable = false;
                    stripped++;
                }

                float density = WildsMistlandsDensity.Value;
                float slope = WildsMistlandsMaxSlope.Value;
                float delta = WildsMistlandsMaxTerrainDelta.Value;
                int added = 0, removedFromMistlands = 0;
                foreach (var data in WildsVegetationList)
                {
                    if (keepResources && WildsKeepVanillaPrefabs.Contains(data.Prefab)) continue;
                    GameObject prefab = FindPrefab(data.Prefab);
                    if (!prefab)
                    {
                        Logger.LogWarning("Wilds vegetation: prefab not found: " + data.Prefab);
                        continue;
                    }
                    var veg = data.Create(prefab);
                    if (veg.m_biome == Biome.Mistlands && WildsMistlandsRemovedPrefabs.Contains(data.Prefab)) { removedFromMistlands++; continue; }
                    if (veg.m_biome == Biome.Mistlands && !WildsKeepVanillaPrefabs.Contains(data.Prefab))
                    {
                        veg.m_min *= density;
                        veg.m_max *= density;
                    }
                    else if (!WildsKeepVanillaPrefabs.Contains(data.Prefab))
                    {
                        var biomeSettings = WildsSettingsFor(veg.m_biome);
                        if (biomeSettings.Length > 0)
                        {
                            float biomeDensity = biomeSettings.Max(b => b.Density.Value);
                            veg.m_min *= biomeDensity;
                            veg.m_max *= biomeDensity;
                        }
                    }
                    ZoneSystem.instance.m_vegetation.Add(veg);
                    added++;
                }

                float treeScale = WildsMistlandsTreeScale.Value;
                int relaxed = 0, scaled = 0;
                foreach (var veg in ZoneSystem.instance.m_vegetation)
                {
                    if (veg == null || !veg.m_enable || (veg.m_biome & WildsLandBiomes) != Biome.Mistlands) continue;
                    string name = veg.m_prefab ? veg.m_prefab.name : veg.m_name;
                    if (WildsMistlandsRockPrefabs.Contains(name) || WildsMistlandsShootPrefabs.Contains(name) ||
                        WildsKeepVanillaPrefabs.Contains(name) || name.StartsWith("giant_") || name == "MistArea" || name == "MistArea_edge") continue;
                    veg.m_maxTilt = Mathf.Max(veg.m_maxTilt, slope);
                    veg.m_maxTerrainDelta = Mathf.Max(veg.m_maxTerrainDelta, delta);
                    relaxed++;

                    if (WildsMistlandsMagicTreePrefabs.Contains(name))
                    {
                        if (!wildsOriginalTreeScale.TryGetValue(veg, out var original))
                        {
                            original = new Vector2(veg.m_scaleMin, veg.m_scaleMax);
                            wildsOriginalTreeScale[veg] = original;
                        }
                        veg.m_scaleMin = original.x * WildsMistlandsMagicTreeScaleMin.Value;
                        veg.m_scaleMax = original.y * WildsMistlandsMagicTreeScaleMax.Value;
                        scaled++;
                    }
                    else if (WildsMistlandsTreePrefabs.Contains(name))
                    {
                        if (!wildsOriginalTreeScale.TryGetValue(veg, out var original))
                        {
                            original = new Vector2(veg.m_scaleMin, veg.m_scaleMax);
                            wildsOriginalTreeScale[veg] = original;
                        }
                        veg.m_scaleMin = original.x * treeScale;
                        veg.m_scaleMax = original.y * treeScale;
                        scaled++;
                    }
                }

                int biomeRelaxed = 0, biomeScaled = 0;
                foreach (var veg in ZoneSystem.instance.m_vegetation)
                {
                    if (veg == null || !veg.m_enable) continue;
                    var land = veg.m_biome & WildsLandBiomes;
                    if (land == 0 || land == Biome.Mistlands) continue;
                    var biomeSettings = WildsSettingsFor(land);
                    if (biomeSettings.Length == 0) continue;
                    string name = veg.m_prefab ? veg.m_prefab.name : veg.m_name;
                    if (WildsKeepVanillaPrefabs.Contains(name)) continue;

                    if (!wildsOriginalLimits.TryGetValue(veg, out var limits))
                    {
                        limits = new Vector2(veg.m_maxTilt, veg.m_maxTerrainDelta);
                        wildsOriginalLimits[veg] = limits;
                    }
                    float biomeSlope = biomeSettings.Max(b => b.MaxSlope.Value);
                    float biomeDelta = biomeSettings.Max(b => b.MaxTerrainDelta.Value);
                    veg.m_maxTilt = Mathf.Max(limits.x, biomeSlope);
                    veg.m_maxTerrainDelta = Mathf.Max(limits.y, biomeDelta);
                    if (biomeSlope > limits.x || biomeDelta > limits.y) biomeRelaxed++;

                    if (WildsTreePrefabs.Contains(name))
                    {
                        if (!wildsOriginalTreeScale.TryGetValue(veg, out var original))
                        {
                            original = new Vector2(veg.m_scaleMin, veg.m_scaleMax);
                            wildsOriginalTreeScale[veg] = original;
                        }
                        float scaleMin = biomeSettings.Max(b => b.TreeScaleMin.Value);
                        float scaleMax = biomeSettings.Max(b => b.TreeScaleMax.Value);
                        veg.m_scaleMin = original.x * scaleMin;
                        veg.m_scaleMax = original.y * scaleMax;
                        if (scaleMin != 1f || scaleMax != 1f) biomeScaled++;
                    }
                }

                var changedBiomes = wildsBiomeSettings
                    .Where(b => b.Density.Value != 1f || b.TreeScaleMin.Value != 1f || b.TreeScaleMax.Value != 1f || b.MaxSlope.Value > 0f || b.MaxTerrainDelta.Value > 0f)
                    .Select(b => $"{b.Biome} (density {b.Density.Value}, trees {b.TreeScaleMin.Value}-{b.TreeScaleMax.Value}x, slope {b.MaxSlope.Value}, delta {b.MaxTerrainDelta.Value})")
                    .ToList();
                Logger.LogInfo("Wilds biome settings: " + (changedBiomes.Count > 0 ? string.Join("; ", changedBiomes) : "all at default") +
                               $". Resized {biomeScaled} tree entries, loosened slope limits on {biomeRelaxed} entries.");

                Logger.LogInfo($"Wilds vegetation: removed {stripped} vanilla entries from land biomes, " +
                               $"kept {lightened} Mistlands rock/shoot entries at a lighter amount, added {added} Wilds entries, " +
                               $"loosened slope limits on {relaxed} Mistlands entries, made {scaled} Mistlands trees {treeScale}x bigger.");

                var shoots = ZoneSystem.instance.m_vegetation.Where(v => v != null && v.m_enable && (v.m_biome & Biome.Mistlands) != 0 &&
                                                                          v.m_prefab && WildsMistlandsShootPrefabs.Contains(v.m_prefab.name)).ToList();
                var magic = ZoneSystem.instance.m_vegetation.FirstOrDefault(v => v != null && v.m_enable && v.m_prefab &&
                                                                          WildsMistlandsMagicTreePrefabs.Contains(v.m_prefab.name));
                Logger.LogInfo($"Wilds Mistlands check: swamp trees removed = {removedFromMistlands > 0}; " +
                               $"big Yggdrasil entries = {shoots.Count}, about {shoots.Sum(v => (v.m_min + v.m_max) / 2f):0.#} per zone " +
                               $"(Yggdrasil Amount = {shootAmount}), sizes {(shoots.Count > 0 ? shoots.Min(v => v.m_scaleMin) : 0):0.##}-{(shoots.Count > 0 ? shoots.Max(v => v.m_scaleMax) : 0):0.##}; " +
                               $"magic tree size {(magic != null ? $"{magic.m_scaleMin:0.##}-{magic.m_scaleMax:0.##}" : "not found")}.");
            }
            catch (Exception ex)
            {
                Logger.LogWarning($"Exception caught while applying Wilds vegetation: {ex}");
            }
            finally
            {
                vanillaVegetationSnapshot.Clear();
            }
        }

        private static GameObject FindPrefab(string name)
        {
            GameObject prefab = ZNetScene.instance ? ZNetScene.instance.GetPrefab(name) : null;
            if (!prefab) prefab = PrefabManager.Cache.GetPrefab<GameObject>(name);
            return prefab;
        }

        internal class WildsVegetation
        {
            public string Prefab;
            public bool Enabled = true;
            public float Min = 1f;
            public float Max = 1f;
            public bool ForcePlacement;
            public float ScaleMin = 1f;
            public float ScaleMax = 1f;
            public float RandTilt;
            public float ChanceToUseGroundTilt;
            public Biome Biome;
            public BiomeArea BiomeArea = BiomeArea.Edge | BiomeArea.Median;
            public bool BlockCheck = true;
            public float MinAltitude = 0f;
            public float MaxAltitude = 10000f;
            public float MinOceanDepth;
            public float MaxOceanDepth;
            public float MaxVegetation;
            public float MinTilt;
            public float MaxTilt = 90f;
            public float TerrainDeltaRadius;
            public float MinTerrainDelta;
            public float MaxTerrainDelta = 10f;
            public bool SnapToWater;
            public bool SnapToStaticSolid;
            public float GroundOffset;
            public int GroupSizeMin = 1;
            public int GroupSizeMax = 1;
            public float GroupRadius;
            public bool InForest;
            public float ForestThresholdMin = 0f;
            public float ForestThresholdMax = 1f;
            public float MinDistanceFromCenter;

            public ZoneSystem.ZoneVegetation Create(GameObject prefab) => new ZoneSystem.ZoneVegetation
            {
                m_name = Prefab,
                m_prefab = prefab,
                m_enable = Enabled,
                m_min = Min,
                m_max = Max,
                m_forcePlacement = ForcePlacement,
                m_scaleMin = ScaleMin,
                m_scaleMax = ScaleMax,
                m_randTilt = RandTilt,
                m_chanceToUseGroundTilt = ChanceToUseGroundTilt,
                m_biome = Biome,
                m_biomeArea = BiomeArea,
                m_blockCheck = BlockCheck,
                m_minAltitude = MinAltitude,
                m_maxAltitude = MaxAltitude,
                m_minOceanDepth = MinOceanDepth,
                m_maxOceanDepth = MaxOceanDepth,
                m_maxVegetation = MaxVegetation,
                m_minTilt = MinTilt,
                m_maxTilt = MaxTilt,
                m_terrainDeltaRadius = TerrainDeltaRadius,
                m_minTerrainDelta = MinTerrainDelta,
                m_maxTerrainDelta = MaxTerrainDelta,
                m_snapToWater = SnapToWater,
                m_snapToStaticSolid = SnapToStaticSolid,
                m_groundOffset = GroundOffset,
                m_groupSizeMin = GroupSizeMin,
                m_groupSizeMax = GroupSizeMax,
                m_groupRadius = GroupRadius,
                m_inForest = InForest,
                m_forestTresholdMin = ForestThresholdMin,
                m_forestTresholdMax = ForestThresholdMax,
                m_minDistanceFromCenter = MinDistanceFromCenter
            };
        }

        internal class WildsClutter
        {
            public string Prefab;
            public bool Enabled = true;
            public int Amount = 80;
            public Biome Biome;
            public bool Instanced;
            public bool OnUncleared = true;
            public bool OnCleared;
            public float ScaleMin = 1f;
            public float ScaleMax = 1f;
            public float MaxTilt = 10f;
            public float MinAltitude = -1000f;
            public float MaxAltitude = 10000f;
            public float MaxVegetation;
            public bool SnapToWater;
            public bool TerrainTilt;
            public float RandomOffset;
            public float MaxOceanDepth;
            public bool InForest;
            public float ForestThresholdMin = 0f;
            public float ForestThresholdMax = 1f;
            public float FractalScale;
            public float FractalThresholdMin;
            public float FractalThresholdMax = 1f;

            public ClutterSystem.Clutter Create(GameObject prefab) => new ClutterSystem.Clutter
            {
                m_name = Prefab + WildsClutterSuffix,
                m_prefab = prefab,
                m_enabled = Enabled,
                m_amount = Amount,
                m_biome = Biome,
                m_instanced = Instanced,
                m_onUncleared = OnUncleared,
                m_onCleared = OnCleared,
                m_scaleMin = ScaleMin,
                m_scaleMax = ScaleMax,
                m_maxTilt = MaxTilt,
                m_minAlt = MinAltitude,
                m_maxAlt = MaxAltitude,
                m_maxVegetation = MaxVegetation,
                m_snapToWater = SnapToWater,
                m_terrainTilt = TerrainTilt,
                m_randomOffset = RandomOffset,
                m_maxOceanDepth = MaxOceanDepth,
                m_inForest = InForest,
                m_forestTresholdMin = ForestThresholdMin,
                m_forestTresholdMax = ForestThresholdMax,
                m_fractalScale = FractalScale,
                m_fractalTresholdMin = FractalThresholdMin,
                m_fractalTresholdMax = FractalThresholdMax
            };
        }

        internal static readonly WildsVegetation[] WildsVegetationList = new WildsVegetation[]
        {
            new WildsVegetation { Prefab = "rock4_coast", Enabled = true, Min = 3f, Max = 5f, ScaleMin = 0.6f, ScaleMax = 1.2f, RandTilt = 15f, Biome = Biome.DeepNorth, BlockCheck = false, MinAltitude = -2f, MaxAltitude = -0.5f, MinOceanDepth = 2f, MaxOceanDepth = 30f, MaxTerrainDelta = 2f, GroupSizeMin = 3, GroupSizeMax = 3, GroupRadius = 20f },
            new WildsVegetation { Prefab = "rock4_heath", Enabled = true, Min = 1f, Max = 2.5f, ScaleMin = 0.8f, RandTilt = 5f, Biome = Biome.Plains, MinAltitude = 4f, MaxAltitude = 1000f, MinTilt = 15f, MaxTilt = 45f, MaxTerrainDelta = 2f, GroundOffset = -3f },
            new WildsVegetation { Prefab = "rock2_heath", Enabled = true, Min = 0f, Max = 0.25f, ScaleMax = 1.5f, RandTilt = 20f, Biome = Biome.Plains, MaxAltitude = 1000f, MaxTilt = 20f, MaxTerrainDelta = 2f, ForestThresholdMax = 1.1f },
            new WildsVegetation { Prefab = "rock3_mountain", Enabled = true, Min = 0f, Max = 0.5f, ScaleMax = 1.5f, Biome = Biome.Mountain, BiomeArea = BiomeArea.Median, MinAltitude = -1000f, MaxAltitude = 1000f, MinTilt = 10f, MaxTilt = 50f, MaxTerrainDelta = 2f, GroundOffset = -5f },
            new WildsVegetation { Prefab = "silvervein", Enabled = true, Min = 0.25f, Max = 0.25f, ForcePlacement = true, Biome = Biome.Mountain, BiomeArea = BiomeArea.Median, MinAltitude = 120f, MaxAltitude = 1000f, MaxTilt = 30f, TerrainDeltaRadius = 9f, MaxTerrainDelta = 3f, GroundOffset = -4f },
            new WildsVegetation { Prefab = "rock1_mountain", Enabled = true, Min = 1.25f, Max = 2f, ScaleMax = 1.5f, Biome = Biome.Mountain, BiomeArea = BiomeArea.Median, MinAltitude = -1000f, MaxAltitude = 1000f, MinTilt = 30f, MaxTilt = 80f, MaxTerrainDelta = 2f, GroundOffset = -6f },
            new WildsVegetation { Prefab = "rock2_mountain", Enabled = true, Min = 1.25f, Max = 2f, ScaleMax = 1.5f, Biome = Biome.Mountain, BiomeArea = BiomeArea.Median, MinAltitude = -1000f, MaxAltitude = 1000f, MinTilt = 30f, MaxTilt = 80f, MaxTerrainDelta = 2f, GroundOffset = -5f },
            new WildsVegetation { Prefab = "Rock_4", Enabled = true, Min = 0f, Max = 5f, ScaleMax = 2f, Biome = Biome.Swamp, MinAltitude = -1000f, MaxAltitude = 1000f, MaxTerrainDelta = 2f },
            new WildsVegetation { Prefab = "mudpile_beacon", Enabled = true, Min = 0f, Max = 1.25f, ScaleMax = 2f, Biome = Biome.Swamp, MinAltitude = 0.5f, MaxAltitude = 1000f, MaxTerrainDelta = 2f, GroundOffset = -3f },
            new WildsVegetation { Prefab = "Rock_4", Enabled = true, Min = 2.5f, Max = 10f, ScaleMax = 2f, ChanceToUseGroundTilt = 1f, Biome = Biome.Meadows | Biome.Mountain, MinAltitude = -10f, MaxAltitude = 1000f, MaxTerrainDelta = 2f },
            new WildsVegetation { Prefab = "Rock_4_plains", Enabled = true, Min = 1.25f, Max = 7.5f, ScaleMax = 2f, ChanceToUseGroundTilt = 1f, Biome = Biome.Plains, MinAltitude = -10f, MaxAltitude = 1000f, MaxTerrainDelta = 2f },
            new WildsVegetation { Prefab = "Rock_3", Enabled = true, Min = 0f, Max = 3.75f, ScaleMin = 2f, ScaleMax = 4f, ChanceToUseGroundTilt = 1f, Biome = Biome.Meadows | Biome.Mountain, MinAltitude = -1000f, MaxAltitude = 1000f, MaxTerrainDelta = 2f, GroundOffset = -0.5f },
            new WildsVegetation { Prefab = "rock4_forest", Enabled = true, Min = 0.25f, Max = 0.5f, ScaleMin = 0.8f, RandTilt = 5f, Biome = Biome.BlackForest, MinAltitude = 4f, MaxAltitude = 1000f, MinTilt = 5f, MaxTilt = 45f, MaxTerrainDelta = 2f, GroundOffset = -2f },
            new WildsVegetation { Prefab = "rock4_copper", Enabled = true, Min = 0f, Max = 0.25f, RandTilt = 5f, Biome = Biome.BlackForest, MinAltitude = 4f, MaxAltitude = 1000f, MinTilt = 5f, MaxTilt = 45f, MaxTerrainDelta = 2f, GroundOffset = -2f },
            new WildsVegetation { Prefab = "MineRock_Tin", Enabled = true, Min = 5f, Max = 5f, ChanceToUseGroundTilt = 1f, Biome = Biome.BlackForest, MinAltitude = -0.6f, MaxAltitude = 1.5f, MaxTerrainDelta = 2f, GroundOffset = -0.5f },
            new WildsVegetation { Prefab = "Rock_4", Enabled = true, Min = 5f, Max = 5f, ScaleMax = 3f, ChanceToUseGroundTilt = 1f, Biome = Biome.BlackForest, MinAltitude = -1000f, MaxAltitude = 1000f, MaxTilt = 45f, MaxTerrainDelta = 2f },
            new WildsVegetation { Prefab = "Rock_3", Enabled = true, Min = 1.25f, Max = 3.75f, ScaleMin = 3f, ScaleMax = 6f, Biome = Biome.BlackForest, MinAltitude = -1000f, MaxAltitude = 1000f, MaxTilt = 25f, MaxTerrainDelta = 2f },
            new WildsVegetation { Prefab = "vfx_swamp_mist", Enabled = true, Min = 10f, Max = 10f, Biome = Biome.Swamp, MinAltitude = -5f, MaxAltitude = 5f, MaxTerrainDelta = 2f, SnapToWater = true, ForestThresholdMax = 1.1f },
            new WildsVegetation { Prefab = "Beech1", Enabled = true, Min = 4.5f, Max = 5.5f, ScaleMin = 0.8f, ScaleMax = 1.5f, RandTilt = 4f, ChanceToUseGroundTilt = 0.1f, Biome = Biome.Meadows, MinAltitude = 0.2f, MaxAltitude = 1000f, MaxOceanDepth = 2f, MaxTilt = 30f, MaxTerrainDelta = 2f, InForest = true, ForestThresholdMax = 1.15f },
            new WildsVegetation { Prefab = "Birch1", Enabled = true, Min = 1.75f, Max = 2f, ScaleMin = 0.5f, RandTilt = 4f, ChanceToUseGroundTilt = 0.05f, Biome = Biome.Meadows, MinAltitude = 0.2f, MaxAltitude = 1000f, MaxOceanDepth = 2f, MaxTilt = 30f, MaxTerrainDelta = 2f, InForest = true, ForestThresholdMax = 1.15f },
            new WildsVegetation { Prefab = "Birch2", Enabled = true, Min = 0f, Max = 0.75f, ScaleMin = 0.5f, RandTilt = 4f, ChanceToUseGroundTilt = 0.05f, Biome = Biome.Meadows, MinAltitude = 0.2f, MaxAltitude = 1000f, MaxOceanDepth = 2f, MaxTilt = 30f, MaxTerrainDelta = 2f, InForest = true, ForestThresholdMax = 1.15f },
            new WildsVegetation { Prefab = "Oak1", Enabled = true, Min = 0f, Max = 0.25f, ScaleMin = 0.8f, RandTilt = 4f, Biome = Biome.Meadows, MinAltitude = 0.5f, MaxAltitude = 1000f, MaxOceanDepth = 2f, MaxTilt = 20f, MaxTerrainDelta = 2f, InForest = true, ForestThresholdMin = 1f, ForestThresholdMax = 3f },
            new WildsVegetation { Prefab = "FirTree", Enabled = true, Min = 0.25f, Max = 0.25f, ScaleMin = 2f, ScaleMax = 2.5f, RandTilt = 4f, Biome = Biome.Mountain | Biome.BlackForest, MinAltitude = 0.1f, MaxAltitude = 1000f, MaxOceanDepth = 2f, MaxTilt = 30f, MaxTerrainDelta = 2f, ForestThresholdMax = 1.1f },
            new WildsVegetation { Prefab = "FirTree", Enabled = true, Min = 10f, Max = 10f, ScaleMin = 2f, ScaleMax = 2.5f, RandTilt = 4f, Biome = Biome.BlackForest, BiomeArea = BiomeArea.Edge, MinAltitude = 0.1f, MaxAltitude = 1000f, MaxOceanDepth = 2f, MaxTilt = 30f, MaxTerrainDelta = 2f, ForestThresholdMax = 1.1f },
            new WildsVegetation { Prefab = "Pinetree_01", Enabled = true, Min = 8.5f, Max = 9f, ScaleMax = 2.5f, RandTilt = 4f, ChanceToUseGroundTilt = 0.05f, Biome = Biome.BlackForest, BiomeArea = BiomeArea.Median, MinAltitude = 0.1f, MaxAltitude = 1000f, MaxOceanDepth = 1.5f, MaxTilt = 30f, MaxTerrainDelta = 2f },
            new WildsVegetation { Prefab = "Beech_small1", Enabled = true, Min = 0.25f, Max = 0.5f, ScaleMax = 1.5f, RandTilt = 10f, Biome = Biome.Meadows, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 30f, MaxTerrainDelta = 2f, GroupSizeMax = 3, InForest = true, ForestThresholdMin = 1.1f, ForestThresholdMax = 1.15f },
            new WildsVegetation { Prefab = "Beech_small2", Enabled = true, Min = 0.25f, Max = 0.5f, ScaleMax = 2f, RandTilt = 10f, Biome = Biome.Meadows, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 30f, MaxTerrainDelta = 2f, GroupSizeMax = 4, InForest = true, ForestThresholdMin = 1.1f, ForestThresholdMax = 1.15f },
            new WildsVegetation { Prefab = "Beech_small1", Enabled = true, Min = 20f, Max = 20f, ScaleMax = 1.5f, RandTilt = 10f, Biome = Biome.Meadows, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 30f, MaxTerrainDelta = 2f, InForest = true },
            new WildsVegetation { Prefab = "Beech_small2", Enabled = true, Min = 20f, Max = 20f, ScaleMax = 2f, RandTilt = 10f, Biome = Biome.Meadows, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 30f, MaxTerrainDelta = 2f, InForest = true },
            new WildsVegetation { Prefab = "Bush02_en", Enabled = true, Min = 0.25f, Max = 0.75f, ScaleMin = 0.5f, ScaleMax = 1.5f, Biome = Biome.Plains, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 30f, MaxTerrainDelta = 2f, GroupSizeMin = 8, GroupSizeMax = 20, GroupRadius = 15f },
            new WildsVegetation { Prefab = "CloudberryBush", Enabled = true, Min = 0.25f, Max = 0.75f, ChanceToUseGroundTilt = 1f, Biome = Biome.Plains, MinAltitude = 2f, MaxAltitude = 50f, MaxTilt = 30f, MaxTerrainDelta = 2f, GroupSizeMin = 15, GroupSizeMax = 20, GroupRadius = 6f },
            new WildsVegetation { Prefab = "FirTree_small_dead", Enabled = true, Min = 15f, Max = 15f, ScaleMin = 0.3f, ScaleMax = 0.8f, RandTilt = 5f, ChanceToUseGroundTilt = 0.2f, Biome = Biome.Swamp, MinAltitude = 0.5f, MaxAltitude = 1000f, MaxTilt = 25f, MaxTerrainDelta = 2f, ForestThresholdMin = 1.1f, ForestThresholdMax = 1.2f },
            new WildsVegetation { Prefab = "SwampTree1", Enabled = true, Min = 6f, Max = 6.5f, ScaleMin = 0.7f, ScaleMax = 1.3f, RandTilt = 10f, ChanceToUseGroundTilt = 0.2f, Biome = Biome.Swamp, MinAltitude = -0.5f, MaxAltitude = 1000f, MaxOceanDepth = 2f, MaxTilt = 30f, MaxTerrainDelta = 2f },
            new WildsVegetation { Prefab = "Flies", Enabled = true, Min = 20f, Max = 20f, ScaleMin = 0.5f, ScaleMax = 1.5f, Biome = Biome.Swamp, MaxAltitude = 1000f, MaxTilt = 25f, MaxTerrainDelta = 2f },
            new WildsVegetation { Prefab = "FirTree_small", Enabled = true, Min = 7.5f, Max = 7.5f, ScaleMin = 0.3f, ScaleMax = 0.7f, Biome = Biome.BlackForest, MinAltitude = 0.5f, MaxAltitude = 1000f, MaxTilt = 30f, MaxTerrainDelta = 2f, ForestThresholdMin = 1.05f, ForestThresholdMax = 1.15f },
            new WildsVegetation { Prefab = "FirTree_small", Enabled = true, Min = 7.5f, Max = 7.5f, ScaleMin = 0.3f, ScaleMax = 0.7f, Biome = Biome.Mountain, MaxAltitude = 280f, MaxTilt = 30f, MaxTerrainDelta = 2f, ForestThresholdMin = 1.05f, ForestThresholdMax = 1.15f },
            new WildsVegetation { Prefab = "FirTree_small", Enabled = true, Min = 15f, Max = 15f, ScaleMin = 0.3f, ScaleMax = 0.7f, Biome = Biome.BlackForest, BiomeArea = BiomeArea.Edge, MinAltitude = 0.5f, MaxAltitude = 1000f, MaxTilt = 30f, MaxTerrainDelta = 2f, ForestThresholdMin = 1.05f, ForestThresholdMax = 1.15f },
            new WildsVegetation { Prefab = "FirTree_oldLog", Enabled = true, Min = 1.5f, Max = 1.5f, ScaleMin = 0.9f, ScaleMax = 1.3f, ChanceToUseGroundTilt = 1f, Biome = Biome.BlackForest, MaxAltitude = 1000f, MaxTilt = 25f, MaxTerrainDelta = 2f, ForestThresholdMin = 1.05f, ForestThresholdMax = 1.15f },
            new WildsVegetation { Prefab = "stubbe", Enabled = true, Min = 0.25f, Max = 0.75f, ScaleMin = 0.8f, ScaleMax = 1.2f, ChanceToUseGroundTilt = 1f, Biome = Biome.Meadows, MaxAltitude = 1000f, MaxOceanDepth = 2f, MaxTilt = 20f, MaxTerrainDelta = 2f },
            new WildsVegetation { Prefab = "stubbe", Enabled = true, Min = 1f, Max = 1f, ScaleMax = 2f, ChanceToUseGroundTilt = 1f, Biome = Biome.Swamp, MaxAltitude = 1000f, MaxOceanDepth = 2f, MaxTilt = 20f, MaxTerrainDelta = 2f },
            new WildsVegetation { Prefab = "StatueEvil", Enabled = true, Min = 0.5f, Max = 0.5f, Biome = Biome.Swamp, MaxAltitude = 1000f, MaxTilt = 20f, MaxTerrainDelta = 2f },
            new WildsVegetation { Prefab = "FirTree_oldLog", Enabled = true, Min = 0.25f, Max = 1f, ScaleMax = 1.2f, ChanceToUseGroundTilt = 1f, Biome = Biome.Meadows, MinAltitude = -1000f, MaxAltitude = 1000f, MaxTilt = 20f, MaxTerrainDelta = 2f },
            new WildsVegetation { Prefab = "FirTree_oldLog", Enabled = true, Min = 1.5f, Max = 1.5f, ScaleMax = 1.2f, ChanceToUseGroundTilt = 1f, Biome = Biome.Swamp, MinAltitude = -1f, MaxAltitude = 1000f, MaxTilt = 20f, MaxTerrainDelta = 2f },
            new WildsVegetation { Prefab = "stubbe", Enabled = true, Min = 3.75f, Max = 3.75f, ScaleMin = 0.8f, ScaleMax = 1.4f, ChanceToUseGroundTilt = 1f, Biome = Biome.BlackForest, MaxAltitude = 1000f, MaxOceanDepth = 2f, MaxTilt = 20f, MaxTerrainDelta = 2f },
            new WildsVegetation { Prefab = "Bush01", Enabled = true, Min = 15f, Max = 20f, ScaleMax = 1.5f, Biome = Biome.Meadows, MinAltitude = 1f, MaxAltitude = 1000f, MaxTerrainDelta = 2f, InForest = true, ForestThresholdMin = 1f, ForestThresholdMax = 1.15f },
            new WildsVegetation { Prefab = "Bush01_heath", Enabled = true, Min = 0.5f, Max = 1f, Biome = Biome.Plains, MaxAltitude = 1000f, MaxTerrainDelta = 2f, InForest = true, ForestThresholdMin = 1f, ForestThresholdMax = 1.15f },
            new WildsVegetation { Prefab = "shrub_2_heath", Enabled = true, Min = 5f, Max = 5f, ScaleMin = 0.5f, Biome = Biome.Swamp, MaxAltitude = 1000f, MaxOceanDepth = 2f, MaxTerrainDelta = 2f, ForestThresholdMin = 1f, ForestThresholdMax = 1.15f },
            new WildsVegetation { Prefab = "Pickable_Thistle", Enabled = true, Min = 0.25f, Max = 0.5f, ScaleMin = 0.5f, RandTilt = 20f, Biome = Biome.Swamp | Biome.BlackForest, BiomeArea = BiomeArea.Median, MaxAltitude = 1000f, MaxTilt = 20f, MaxTerrainDelta = 2f, GroupSizeMin = 2, GroupSizeMax = 5, GroupRadius = 4f, ForestThresholdMin = 1f, ForestThresholdMax = 1.15f },
            new WildsVegetation { Prefab = "shrub_2", Enabled = true, Min = 25f, Max = 25f, ScaleMin = 0.5f, Biome = Biome.BlackForest, MinAltitude = 1f, MaxAltitude = 1000f, MaxTerrainDelta = 2f, ForestThresholdMin = 1f, ForestThresholdMax = 1.1f },
            new WildsVegetation { Prefab = "BlueberryBush", Enabled = true, Min = 0.25f, Max = 0.25f, Biome = Biome.BlackForest, BiomeArea = BiomeArea.Median, MinAltitude = 1f, MaxAltitude = 1000f, MaxOceanDepth = 2f, MaxTerrainDelta = 2f, GroupSizeMax = 8, GroupRadius = 8f, ForestThresholdMin = 1f, ForestThresholdMax = 1.1f },
            new WildsVegetation { Prefab = "RaspberryBush", Enabled = true, Min = 0.25f, Max = 0.5f, Biome = Biome.Meadows, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 45f, MaxTerrainDelta = 2f, GroupSizeMin = 3, GroupSizeMax = 8, GroupRadius = 8f, InForest = true, ForestThresholdMin = 1f, ForestThresholdMax = 1.2f },
            new WildsVegetation { Prefab = "Pickable_Mushroom", Enabled = true, Min = 0.25f, Max = 0.5f, ScaleMax = 1.5f, Biome = Biome.Meadows | Biome.Swamp | Biome.BlackForest, MinAltitude = 1f, MaxAltitude = 1000f, MaxOceanDepth = 2f, MaxTilt = 25f, MaxTerrainDelta = 2f, GroupSizeMin = 3, GroupSizeMax = 6, GroupRadius = 5f, InForest = true },
            new WildsVegetation { Prefab = "Pickable_Dandelion", Enabled = true, Min = 2f, Max = 2.5f, Biome = Biome.Meadows, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 15f, MaxTerrainDelta = 2f, GroupSizeMax = 3, GroupRadius = 3f, ForestThresholdMin = 1.1f, ForestThresholdMax = 5f },
            new WildsVegetation { Prefab = "Pickable_Flint", Enabled = true, Min = 7.5f, Max = 7.5f, Biome = Biome.Meadows, MinAltitude = -2f, MaxAltitude = 1f, MaxTerrainDelta = 2f },
            new WildsVegetation { Prefab = "Pickable_Branch", Enabled = true, Min = 3.75f, Max = 3.75f, ChanceToUseGroundTilt = 1f, Biome = Biome.Meadows | Biome.Swamp | Biome.BlackForest, MaxAltitude = 1000f, MaxTerrainDelta = 2f, InForest = true, ForestThresholdMax = 1.1f },
            new WildsVegetation { Prefab = "Pickable_Stone", Enabled = true, Min = 7.5f, Max = 7.5f, ChanceToUseGroundTilt = 1f, Biome = Biome.Meadows | Biome.Swamp | Biome.BlackForest | Biome.Plains, MaxAltitude = 1000f, MinTilt = 22f, MaxTerrainDelta = 2f, GroupSizeMin = 2, GroupSizeMax = 3, GroupRadius = 2f },
            new WildsVegetation { Prefab = "Pickable_Stone", Enabled = true, Min = 1.25f, Max = 1.25f, ChanceToUseGroundTilt = 1f, Biome = Biome.Meadows | Biome.Swamp, MinAltitude = -3f, MaxAltitude = 1000f, MaxTerrainDelta = 2f, GroupRadius = 1f },
            new WildsVegetation { Prefab = "Pickable_StoneRock", Enabled = true, Min = 0f, Max = 0.25f, ChanceToUseGroundTilt = 1f, Biome = Biome.Meadows | Biome.Swamp | Biome.Mountain | Biome.BlackForest, BiomeArea = BiomeArea.Median, MinAltitude = 5f, MaxAltitude = 20f, MaxTerrainDelta = 2f, GroupRadius = 1f, InForest = true, MinDistanceFromCenter = 1000f },
            new WildsVegetation { Prefab = "FirTree", Enabled = true, Min = 1.25f, Max = 5f, ScaleMin = 1.5f, ScaleMax = 3f, Biome = Biome.Mountain, MinAltitude = 2f, MaxAltitude = 280f, MaxTilt = 30f, MaxTerrainDelta = 2f, ForestThresholdMax = 1.15f },
            new WildsVegetation { Prefab = "ice1", Enabled = true, Min = 10f, Max = 20f, Biome = Biome.DeepNorth, MinAltitude = -1000f, MaxAltitude = -1f, MaxTerrainDelta = 2f, SnapToWater = true, InForest = true },
            new WildsVegetation { Prefab = "ice_rock1", Enabled = true, Min = 0f, Max = 1f, Biome = Biome.DeepNorth, MinAltitude = -1000f, MaxAltitude = -1f, MaxTerrainDelta = 2f, SnapToWater = true, GroundOffset = -2f },
            new WildsVegetation { Prefab = "MineRock_Obsidian", Enabled = true, Min = 2.5f, Max = 3.75f, ScaleMin = 0.9f, ChanceToUseGroundTilt = 1f, Biome = Biome.Mountain, MinAltitude = 100f, MaxAltitude = 1000f, MaxTerrainDelta = 2f, GroupRadius = 1f },
            new WildsVegetation { Prefab = "Pickable_SeedTurnip", Enabled = true, Min = 0f, Max = 0.12f, ScaleMax = 1.5f, Biome = Biome.Swamp, MaxAltitude = 1000f, MaxTilt = 25f, MaxTerrainDelta = 2f, GroupSizeMax = 2, GroupRadius = 5f },
            new WildsVegetation { Prefab = "Pickable_SeedCarrot", Enabled = true, Min = 0f, Max = 0.12f, ScaleMax = 1.5f, Biome = Biome.BlackForest, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 25f, MaxTerrainDelta = 2f, GroupSizeMax = 2, GroupRadius = 5f },
            new WildsVegetation { Prefab = "rock4_coast", Enabled = true, Min = 3f, Max = 3f, ScaleMin = 0.6f, ScaleMax = 1.2f, RandTilt = 15f, Biome = Biome.Meadows | Biome.BlackForest | Biome.Mistlands, BlockCheck = false, MinAltitude = -2f, MaxAltitude = -0.5f, MinOceanDepth = 2f, MaxOceanDepth = 30f, MaxTerrainDelta = 2f, GroupSizeMin = 3, GroupSizeMax = 3, GroupRadius = 20f },
            new WildsVegetation { Prefab = "giant_helmet1", Enabled = true, Min = 0.25f, Max = 0.5f, RandTilt = 33f, Biome = Biome.Mistlands, BiomeArea = BiomeArea.Median, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 30f, TerrainDeltaRadius = 5f, MaxTerrainDelta = 3f, ForestThresholdMax = 0f },
            new WildsVegetation { Prefab = "giant_helmet2", Enabled = true, Min = 0.25f, Max = 0.5f, RandTilt = 33f, Biome = Biome.Mistlands, BiomeArea = BiomeArea.Median, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 30f, TerrainDeltaRadius = 5f, MaxTerrainDelta = 3f, GroundOffset = -1f, ForestThresholdMax = 0f },
            new WildsVegetation { Prefab = "giant_sword1", Enabled = true, Min = 0.25f, Max = 0.5f, RandTilt = 60f, Biome = Biome.Mistlands, BiomeArea = BiomeArea.Median, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 30f, TerrainDeltaRadius = 5f, MaxTerrainDelta = 3f, ForestThresholdMax = 0f },
            new WildsVegetation { Prefab = "giant_sword2", Enabled = true, Min = 0.25f, Max = 0.5f, RandTilt = 60f, Biome = Biome.Mistlands, BiomeArea = BiomeArea.Median, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 30f, TerrainDeltaRadius = 5f, MaxTerrainDelta = 3f, ForestThresholdMax = 0f },
            new WildsVegetation { Prefab = "cliff_ashlands2", Enabled = true, Min = 0f, Max = 0.1f, ScaleMin = 0.5f, ScaleMax = 1.5f, ChanceToUseGroundTilt = 1f, Biome = Biome.AshLands, BlockCheck = false, MinAltitude = 1f, MaxAltitude = 15f, MaxVegetation = 0.5f, MaxTilt = 99f, MaxTerrainDelta = 0f, ForestThresholdMax = 0f },
            new WildsVegetation { Prefab = "cliff_ashlands3_Arch_1", Enabled = true, Min = 0.2f, Max = 0.2f, ScaleMax = 2f, Biome = Biome.AshLands, MaxAltitude = 40f, MaxVegetation = 0.5f, MinTilt = 10f, MaxTilt = 40f, MaxTerrainDelta = 0f, GroupRadius = 10f, ForestThresholdMax = 0f },
            new WildsVegetation { Prefab = "cliff_ashlands5", Enabled = true, Min = 0.1f, Max = 0.3f, ScaleMin = 0.2f, ScaleMax = 1.5f, Biome = Biome.AshLands, MaxAltitude = 100f, MaxVegetation = 0.5f, MaxTilt = 60f, MaxTerrainDelta = 0f, GroupRadius = 10f, ForestThresholdMax = 0f },
            new WildsVegetation { Prefab = "cliff_ashlands5", Enabled = true, Min = 0.3f, Max = 0.5f, ScaleMin = 0.8f, ScaleMax = 1.2f, Biome = Biome.AshLands, MinAltitude = -2f, MaxAltitude = 1f, MaxVegetation = 1f, MaxTilt = 60f, MaxTerrainDelta = 0f, GroupRadius = 20f, ForestThresholdMax = 0f },
            new WildsVegetation { Prefab = "cliff_ashlands6", Enabled = true, Min = 0.3f, Max = 10f, ScaleMin = 0.5f, ScaleMax = 0.9f, Biome = Biome.AshLands, MinAltitude = -5f, MaxAltitude = 10f, MaxVegetation = 0.5f, MinTilt = 10f, MaxTilt = 40f, MaxTerrainDelta = 0f, GroupRadius = 10f, ForestThresholdMax = 0f },
            new WildsVegetation { Prefab = "cliff_ashlands4", Enabled = true, Min = 0.1f, Max = 0.1f, ScaleMin = 0.6f, ScaleMax = 0.8f, RandTilt = 20f, Biome = Biome.AshLands, MinAltitude = -10f, MaxAltitude = 0.1f, MaxVegetation = 1f, MaxTilt = 20f, MaxTerrainDelta = 0f, GroundOffset = -2f, GroupSizeMax = 2, GroupRadius = 30f, ForestThresholdMax = 0f },
            new WildsVegetation { Prefab = "cliff_ashlands4", Enabled = true, Min = 0.1f, Max = 0.1f, ScaleMin = 0.9f, ScaleMax = 1.1f, RandTilt = 20f, Biome = Biome.AshLands, MinAltitude = -25f, MaxAltitude = -11f, MaxVegetation = 1f, MaxTilt = 20f, MaxTerrainDelta = 0f, GroundOffset = -1f, GroupSizeMax = 3, GroupRadius = 30f, ForestThresholdMax = 0f },
            new WildsVegetation { Prefab = "AshlandsTree1", Enabled = true, Min = 1.5f, Max = 1.5f, ScaleMin = 0.7f, ScaleMax = 1.4f, RandTilt = 4f, ChanceToUseGroundTilt = 0.5f, Biome = Biome.AshLands, MinAltitude = 2f, MaxAltitude = 12f, MaxVegetation = 0.2f, MaxTilt = 30f, MaxTerrainDelta = 0f, GroupSizeMin = 4, GroupSizeMax = 8, GroupRadius = 40f, ForestThresholdMax = 0f },
            new WildsVegetation { Prefab = "AshlandsTree1", Enabled = true, Min = 1.25f, Max = 2f, RandTilt = 10f, ChanceToUseGroundTilt = 0.5f, Biome = Biome.AshLands, MinAltitude = 1f, MaxAltitude = 12f, MaxVegetation = 0.2f, MaxTilt = 30f, MaxTerrainDelta = 0f, GroupSizeMin = 2, GroupSizeMax = 4, GroupRadius = 40f, ForestThresholdMax = 0f },
            new WildsVegetation { Prefab = "AshlandsTree3", Enabled = true, Min = 1f, Max = 1.5f, ScaleMax = 2f, RandTilt = 10f, ChanceToUseGroundTilt = 0.5f, Biome = Biome.AshLands, MinAltitude = 1f, MaxAltitude = 12f, MaxVegetation = 0.2f, MaxTilt = 30f, MaxTerrainDelta = 0f, GroupSizeMin = 3, GroupSizeMax = 5, GroupRadius = 50f, ForestThresholdMax = 0f },
            new WildsVegetation { Prefab = "AshlandsTree6", Enabled = true, Min = 0.5f, Max = 0.5f, ScaleMin = 1.5f, ScaleMax = 2.5f, RandTilt = 10f, ChanceToUseGroundTilt = 0.5f, Biome = Biome.AshLands, MinAltitude = 1f, MaxAltitude = 12f, MaxVegetation = 0.2f, MaxTilt = 10f, MaxTerrainDelta = 0f, ForestThresholdMax = 0f },
            new WildsVegetation { Prefab = "Ashlands_rock2", Enabled = true, Min = 0.25f, Max = 0.25f, ScaleMin = 0.8f, RandTilt = 5f, Biome = Biome.AshLands, MinAltitude = 4f, MaxAltitude = 1000f, MaxVegetation = 0.5f, MaxTilt = 25f, MaxTerrainDelta = 0f, ForestThresholdMax = 0f },
            new WildsVegetation { Prefab = "cliff_ashlands6", Enabled = true, Min = 9.2f, Max = 19.6f, ScaleMin = 0.2f, ScaleMax = 0.9f, RandTilt = 99f, Biome = Biome.AshLands, MinAltitude = 9f, MaxAltitude = 1000f, MaxVegetation = 0.5f, MaxTilt = 99f, MaxTerrainDelta = 0f, ForestThresholdMax = 0f },
            new WildsVegetation { Prefab = "AshlandsBranch1", Enabled = true, Min = 1f, Max = 0.75f, ScaleMax = 3f, RandTilt = 5f, Biome = Biome.AshLands, MinAltitude = 1f, MaxAltitude = 6f, MaxVegetation = 0.5f, MaxTilt = 99f, MaxTerrainDelta = 0f, GroupSizeMin = 3, GroupSizeMax = 5, GroupRadius = 30f, ForestThresholdMax = 0f },
            new WildsVegetation { Prefab = "AshlandsBranch2", Enabled = true, Min = 0.5f, Max = 0.5f, ScaleMin = 0.8f, RandTilt = 5f, Biome = Biome.AshLands, MinAltitude = 1f, MaxAltitude = 7f, MaxVegetation = 0.5f, MaxTilt = 99f, MaxTerrainDelta = 0f, ForestThresholdMax = 0f },
            new WildsVegetation { Prefab = "AshlandsBranch3", Enabled = true, Min = 0.5f, Max = 0.5f, ScaleMin = 0.8f, RandTilt = 5f, Biome = Biome.AshLands, MinAltitude = 1f, MaxAltitude = 6f, MaxVegetation = 0.5f, MaxTilt = 99f, MaxTerrainDelta = 0f, GroupSizeMin = 2, GroupSizeMax = 4, GroupRadius = 30f, ForestThresholdMax = 0f },
            new WildsVegetation { Prefab = "AshlandsBush1", Enabled = true, Min = 1.5f, Max = 1.5f, ScaleMax = 3f, RandTilt = 5f, Biome = Biome.AshLands, MinAltitude = 1f, MaxAltitude = 6f, MaxVegetation = 0.15f, MaxTilt = 99f, MaxTerrainDelta = 0f, GroupSizeMin = 2, GroupSizeMax = 4, ForestThresholdMax = 0f },
            new WildsVegetation { Prefab = "Pickable_Charredskull", Enabled = true, Min = 5f, Max = 6.25f, ScaleMin = 1.3f, ScaleMax = 1.4f, RandTilt = 5f, Biome = Biome.AshLands, MinAltitude = 11f, MaxAltitude = 1000f, MaxVegetation = 0.15f, MaxTilt = 99f, MaxTerrainDelta = 0f, GroundOffset = 0.2f, GroupSizeMin = 2, GroupSizeMax = 3, GroupRadius = 2f, ForestThresholdMax = 0f },
            new WildsVegetation { Prefab = "Pickable_Pot_Shard", Enabled = true, Min = 1f, Max = 1f, RandTilt = 15f, Biome = Biome.AshLands, BiomeArea = BiomeArea.Median, MinAltitude = 11f, MaxAltitude = 1000f, MaxVegetation = 0.15f, MaxTilt = 99f, MaxTerrainDelta = 0f, GroundOffset = 0.75f, GroupSizeMin = 4, GroupSizeMax = 6, GroupRadius = 20f, ForestThresholdMax = 0f },
            new WildsVegetation { Prefab = "Pickable_Ashstone", Enabled = true, Min = 1.75f, Max = 2.25f, RandTilt = 180f, ChanceToUseGroundTilt = 20f, Biome = Biome.AshLands, BiomeArea = BiomeArea.Median, MinAltitude = 30f, MaxAltitude = 1000f, MaxVegetation = 0.15f, MaxTilt = 99f, MaxTerrainDelta = 0f, GroundOffset = 0.1f, GroupSizeMin = 10, GroupSizeMax = 20, GroupRadius = 40f, ForestThresholdMax = 0f },
            new WildsVegetation { Prefab = "ashland_pot2_red", Enabled = true, Min = 0.25f, Max = 0.5f, RandTilt = 45f, Biome = Biome.AshLands, MinAltitude = 11f, MaxAltitude = 1000f, MaxVegetation = 0.15f, MaxTilt = 99f, MaxTerrainDelta = 0f, GroundOffset = -0.5f, GroupSizeMax = 3, GroupRadius = 20f, ForestThresholdMax = 0f },
            new WildsVegetation { Prefab = "UnstableLavaRock", Enabled = true, Min = 0.25f, Max = 0.25f, ScaleMin = 0.7f, ScaleMax = 1.2f, RandTilt = 30f, ChanceToUseGroundTilt = 1f, Biome = Biome.AshLands, BlockCheck = false, MinAltitude = 1f, MaxAltitude = 2000f, MaxVegetation = 1f, MaxTilt = 40f, MaxTerrainDelta = 0f, SnapToStaticSolid = true, GroupRadius = 10f, ForestThresholdMax = 0f },
            new WildsVegetation { Prefab = "Pickable_SmokePuff", Enabled = true, Min = 0.5f, Max = 0.5f, ChanceToUseGroundTilt = 1f, Biome = Biome.AshLands, BlockCheck = false, MinAltitude = 2f, MaxAltitude = 2000f, MaxVegetation = 0.2f, MaxTilt = 60f, MaxTerrainDelta = 0f, SnapToStaticSolid = true, GroupSizeMax = 3, GroupRadius = 5f, ForestThresholdMax = 0f },
            new WildsVegetation { Prefab = "GraveStone_Broken_World", Enabled = true, Min = 1f, Max = 1f, RandTilt = 30f, ChanceToUseGroundTilt = 10f, Biome = Biome.AshLands, MinAltitude = 11f, MaxAltitude = 1000f, MaxVegetation = 0.1f, MaxTilt = 100f, MaxTerrainDelta = 2f, GroupSizeMin = 2, GroupSizeMax = 6, GroupRadius = 10f },
            new WildsVegetation { Prefab = "Ashlands_ArchRoofDamaged", Enabled = true, Min = 0.5f, Max = 0.75f, ChanceToUseGroundTilt = 50f, Biome = Biome.AshLands, MinAltitude = 11f, MaxAltitude = 1000f, MaxVegetation = 0.1f, MaxTilt = 40f, MaxTerrainDelta = 2f },
            new WildsVegetation { Prefab = "Ashlands_Pillar4", Enabled = true, Min = 0.75f, Max = 0.75f, RandTilt = 90f, Biome = Biome.AshLands, MinAltitude = 11f, MaxAltitude = 1000f, MaxVegetation = 0.1f, MaxTilt = 40f, MaxTerrainDelta = 2f, GroundOffset = -1f, GroupSizeMin = 2, GroupSizeMax = 3, GroupRadius = 20f },
            new WildsVegetation { Prefab = "Ashlands_Ruins_Wall_Windows_Broken_4x6", Enabled = true, Min = 0.5f, Max = 0.75f, RandTilt = 90f, Biome = Biome.AshLands, MinAltitude = 11f, MaxAltitude = 1000f, MaxVegetation = 0.1f, MaxTilt = 40f, MaxTerrainDelta = 2f, GroupSizeMin = 2, GroupSizeMax = 3, GroupRadius = 20f },
            new WildsVegetation { Prefab = "Rock_4_deepnorth", Enabled = true, Min = 0.5f, Max = 1f, ScaleMin = 4f, ScaleMax = 6f, ChanceToUseGroundTilt = 1f, Biome = Biome.DeepNorth, MinAltitude = -10f, MaxAltitude = 1000f, MaxTerrainDelta = 2f },
            new WildsVegetation { Prefab = "Rock_3_deepnorth", Enabled = true, Min = 0.25f, Max = 0.75f, ScaleMin = 2f, ScaleMax = 8f, ChanceToUseGroundTilt = 1f, Biome = Biome.DeepNorth, MinAltitude = -10f, MaxAltitude = 1000f, MaxTerrainDelta = 2f, GroundOffset = -0.5f, InForest = true },
            new WildsVegetation { Prefab = "Rock_7_deepnorth", Enabled = true, Min = 0f, Max = 0.25f, ScaleMin = 1.5f, ScaleMax = 2f, RandTilt = 20f, ChanceToUseGroundTilt = 0.75f, Biome = Biome.DeepNorth, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 45f, MaxTerrainDelta = 4f, GroundOffset = -0.5f, GroupSizeMin = 2, GroupSizeMax = 3, GroupRadius = 20f },
            new WildsVegetation { Prefab = "SnowFirTree", Enabled = true, Min = 0.75f, Max = 1.25f, ScaleMin = 0.5f, RandTilt = 4f, ChanceToUseGroundTilt = 0.1f, Biome = Biome.DeepNorth, MinAltitude = 0.2f, MaxAltitude = 1000f, MaxOceanDepth = 2f, MaxTilt = 30f, MaxTerrainDelta = 2f, InForest = true, ForestThresholdMax = 1.15f },
            new WildsVegetation { Prefab = "SnowFirTree 2", Enabled = true, Min = 3.75f, Max = 5f, ScaleMin = 0.5f, RandTilt = 4f, ChanceToUseGroundTilt = 0.1f, Biome = Biome.DeepNorth, MinAltitude = 0.2f, MaxAltitude = 1000f, MaxOceanDepth = 2f, MaxTilt = 30f, MaxTerrainDelta = 2f, InForest = true, ForestThresholdMax = 1.15f },
            new WildsVegetation { Prefab = "Pinetree_Snow", Enabled = true, Min = 2.5f, Max = 3.75f, ScaleMax = 2f, RandTilt = 4f, ChanceToUseGroundTilt = 0.05f, Biome = Biome.DeepNorth, MinAltitude = 0.2f, MaxAltitude = 1000f, MaxOceanDepth = 2f, MaxTilt = 30f, MaxTerrainDelta = 2f, InForest = true, ForestThresholdMax = 1.15f },
            new WildsVegetation { Prefab = "Pinetree_Snow_dead", Enabled = true, Min = 3.75f, Max = 6f, ScaleMin = 0.5f, ScaleMax = 1.5f, RandTilt = 4f, ChanceToUseGroundTilt = 0.2f, Biome = Biome.DeepNorth, MinAltitude = 0.2f, MaxAltitude = 1000f, MaxOceanDepth = 2f, MaxTilt = 30f, MaxTerrainDelta = 2f, InForest = true, ForestThresholdMax = 1.15f },
            new WildsVegetation { Prefab = "Pinetree_Snow", Enabled = true, Min = 3.75f, Max = 5f, ScaleMax = 2f, RandTilt = 10f, Biome = Biome.DeepNorth, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 30f, MaxTerrainDelta = 2f, InForest = true, ForestThresholdMin = 1.1f, ForestThresholdMax = 1.15f },
            new WildsVegetation { Prefab = "SnowFirTree_small", Enabled = true, Min = 6.25f, Max = 3f, ScaleMax = 2f, RandTilt = 10f, ChanceToUseGroundTilt = 0.5f, Biome = Biome.DeepNorth, MinAltitude = 0.2f, MaxAltitude = 1000f, MaxTilt = 30f, MaxTerrainDelta = 2f, InForest = true, ForestThresholdMax = 1.15f },
            new WildsVegetation { Prefab = "SnowFirTree_small", Enabled = true, Min = 1.25f, Max = 2.5f, ScaleMax = 2f, RandTilt = 10f, ChanceToUseGroundTilt = 0.5f, Biome = Biome.DeepNorth, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 30f, MaxTerrainDelta = 2f, InForest = true, ForestThresholdMin = 1f, ForestThresholdMax = 2f },
            new WildsVegetation { Prefab = "stubbe_deepnorth", Enabled = true, Min = 0.25f, Max = 0.5f, ScaleMin = 0.8f, ScaleMax = 1.2f, RandTilt = 10f, ChanceToUseGroundTilt = 0.9f, Biome = Biome.DeepNorth, MaxAltitude = 1000f, MaxOceanDepth = 2f, MaxTilt = 20f, MaxTerrainDelta = 2f, GroundOffset = -0.2f, GroupSizeMin = 0 },
            new WildsVegetation { Prefab = "FirTree_oldLog_deepnorth", Enabled = true, Min = 0.25f, Max = 0.5f, ScaleMax = 1.2f, RandTilt = 10f, ChanceToUseGroundTilt = 0.9f, Biome = Biome.DeepNorth, MaxAltitude = 1000f, MaxTilt = 20f, MaxTerrainDelta = 2f },
            new WildsVegetation { Prefab = "Pickable_Branch_Snow", Enabled = true, Min = 3.75f, Max = 3f, ChanceToUseGroundTilt = 1f, Biome = Biome.DeepNorth, MaxAltitude = 1000f, MaxTerrainDelta = 2f, InForest = true, ForestThresholdMax = 1.1f },
            new WildsVegetation { Prefab = "Pickable_Snowball", Enabled = true, Min = 0.5f, Max = 1.25f, ChanceToUseGroundTilt = 1f, Biome = Biome.DeepNorth, MaxAltitude = 1000f, MaxTerrainDelta = 2f, GroupRadius = 1f },
            new WildsVegetation { Prefab = "ice_rock1", Enabled = true, Min = 0f, Max = 1f, Biome = Biome.DeepNorth, MinAltitude = -1000f, MaxAltitude = -1f, MaxTerrainDelta = 2f, SnapToWater = true, GroundOffset = -2f },
            new WildsVegetation { Prefab = "rock4_coast", Enabled = true, Min = 4f, Max = 6f, ScaleMin = 0.6f, ScaleMax = 1.2f, RandTilt = 15f, Biome = Biome.DeepNorth, BlockCheck = false, MinAltitude = -2f, MaxAltitude = -0.5f, MinOceanDepth = 2f, MaxOceanDepth = 30f, MaxTerrainDelta = 2f, GroupSizeMin = 3, GroupSizeMax = 3, GroupRadius = 20f },
            new WildsVegetation { Prefab = "LingonberryBush", Enabled = true, Min = 0.25f, Max = 0.5f, Biome = Biome.DeepNorth, BiomeArea = BiomeArea.Median, MinAltitude = 1f, MaxAltitude = 1000f, MaxOceanDepth = 2f, MaxTerrainDelta = 2f, GroupSizeMin = 3, GroupSizeMax = 6, GroupRadius = 8f, InForest = true },
            new WildsVegetation { Prefab = "FrozenGD", Enabled = true, Min = 0f, Max = 0.5f, ScaleMin = 0.5f, ChanceToUseGroundTilt = 1f, Biome = Biome.DeepNorth, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 40f, MaxTerrainDelta = 2f, GroupRadius = 1f },
            new WildsVegetation { Prefab = "FrozenSkeleton_Pose1", Enabled = true, Min = 0f, Max = 1f, ScaleMax = 1.2f, ChanceToUseGroundTilt = 1f, Biome = Biome.DeepNorth, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 40f, MaxTerrainDelta = 2f, GroupRadius = 1f },
            new WildsVegetation { Prefab = "FrozenSkeleton_Pose2", Enabled = true, Min = 0f, Max = 1f, ScaleMax = 1.2f, ChanceToUseGroundTilt = 1f, Biome = Biome.DeepNorth, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 40f, MaxTerrainDelta = 2f, GroupRadius = 1f },
            new WildsVegetation { Prefab = "Bush01_deepnorth", Enabled = true, Min = 0.25f, Max = 0.5f, ScaleMax = 1.75f, Biome = Biome.DeepNorth, MinAltitude = 1f, MaxAltitude = 1000f, MaxTerrainDelta = 2f, GroundOffset = -0.1f, GroupSizeMin = 5, GroupSizeMax = 10, GroupRadius = 20f, ForestThresholdMin = 1f, ForestThresholdMax = 1.15f },
            new WildsVegetation { Prefab = "StumpHut", Enabled = true, Min = 0f, Max = 0.25f, ScaleMin = 0.75f, ChanceToUseGroundTilt = 1f, Biome = Biome.DeepNorth, MinAltitude = 1f, MaxAltitude = 1000f, MaxOceanDepth = 2f, MaxTilt = 20f, MaxTerrainDelta = 2f, GroupSizeMin = 0, InForest = true },
            new WildsVegetation { Prefab = "StumpHole", Enabled = true, Min = 0f, Max = 0.25f, ScaleMin = 0.4f, ScaleMax = 0.7f, ChanceToUseGroundTilt = 1f, Biome = Biome.DeepNorth, MinAltitude = 1f, MaxAltitude = 1000f, MaxOceanDepth = 2f, MaxTilt = 20f, MaxTerrainDelta = 2f, GroupSizeMax = 2, GroupRadius = 24f },
            new WildsVegetation { Prefab = "StumpLog", Enabled = true, Min = 0f, Max = 0.25f, ScaleMin = 0.66f, RandTilt = 180f, Biome = Biome.DeepNorth, MinAltitude = 1f, MaxAltitude = 1000f, MaxOceanDepth = 2f, MaxTilt = 20f, MaxTerrainDelta = 2f },
            new WildsVegetation { Prefab = "ice1", Enabled = true, Min = 7f, Max = 13f, Biome = Biome.DeepNorth, MinAltitude = -1000f, MaxAltitude = -19f, MaxTerrainDelta = 2f, SnapToWater = true },
            new WildsVegetation { Prefab = "IceShore_1", Enabled = true, Min = 5f, Max = 10f, Biome = Biome.DeepNorth, MinAltitude = -20f, MaxAltitude = 0.5f, MaxTerrainDelta = 2f, SnapToWater = true, GroundOffset = -0.9f, GroupRadius = 1f },
            new WildsVegetation { Prefab = "IceShore_1", Enabled = true, Min = 5f, Max = 10f, Biome = Biome.DeepNorth, MinAltitude = -20f, MaxAltitude = 0.5f, MaxTerrainDelta = 2f, SnapToWater = true, GroundOffset = -0.6f, GroupRadius = 1f },
            new WildsVegetation { Prefab = "Pickable_SeedKale", Enabled = true, Min = 0f, Max = 0.12f, ScaleMax = 1.5f, Biome = Biome.DeepNorth, MaxAltitude = 1000f, MaxTilt = 25f, MaxTerrainDelta = 2f, GroupSizeMax = 2, GroupRadius = 5f },
            new WildsVegetation { Prefab = "rock4_copper", Enabled = true, Min = 0f, Max = 0.25f, RandTilt = 5f, Biome = Biome.Meadows, MinAltitude = 4f, MaxAltitude = 1000f, MinTilt = 5f, MaxTilt = 45f, MaxTerrainDelta = 2f, GroundOffset = -2f },
            new WildsVegetation { Prefab = "RedPineSmall1_RtD", Enabled = true, Min = 1.5f, Max = 2.7f, ScaleMin = 1.1f, ScaleMax = 1.85f, Biome = Biome.Mountain, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 40f, MaxTerrainDelta = 3f, GroupSizeMax = 2 },
            new WildsVegetation { Prefab = "Blossom1_RtD", Enabled = true, Min = 0.75f, Max = 1f, ScaleMin = 1.1f, ScaleMax = 1.25f, Biome = Biome.DeepNorth, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 25f, MaxTerrainDelta = 2f, GroupSizeMax = 1 },
            new WildsVegetation { Prefab = "Blossom2_RtD", Enabled = true, Min = 0.75f, Max = 1f, ScaleMin = 1.1f, ScaleMax = 1.25f, Biome = Biome.DeepNorth, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 25f, MaxTerrainDelta = 2f, GroupSizeMax = 1 },
            new WildsVegetation { Prefab = "Blossom3_RtD", Enabled = true, Min = 0.75f, Max = 1f, ScaleMin = 1.1f, ScaleMax = 1.25f, Biome = Biome.DeepNorth, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 25f, MaxTerrainDelta = 2f, GroupSizeMax = 1 },
            new WildsVegetation { Prefab = "Blossom4_RtD", Enabled = true, Min = 0.75f, Max = 1f, ScaleMin = 1.1f, ScaleMax = 1.25f, Biome = Biome.DeepNorth, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 25f, MaxTerrainDelta = 2f, GroupSizeMax = 1 },
            new WildsVegetation { Prefab = "Blossom5_RtD", Enabled = true, Min = 0.75f, Max = 1f, ScaleMin = 1.1f, ScaleMax = 1.25f, Biome = Biome.DeepNorth, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 25f, MaxTerrainDelta = 2f, GroupSizeMax = 1 },
            new WildsVegetation { Prefab = "MeadowsBush1_RtD", Enabled = true, Min = 0.5f, Max = 1f, ScaleMin = 1.1f, ScaleMax = 1.85f, Biome = Biome.DeepNorth, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 30f, MaxTerrainDelta = 3f, GroupSizeMax = 2 },
            new WildsVegetation { Prefab = "WillowTree1_RtD", Enabled = true, Min = 1f, Max = 1.5f, ScaleMin = 1.7f, ScaleMax = 2.3f, Biome = Biome.Mistlands, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 20f, MinTerrainDelta = 0f, MaxTerrainDelta = 3f },
            new WildsVegetation { Prefab = "WillowTree2_RtD", Enabled = true, Min = 1f, Max = 1.5f, ScaleMin = 1.9f, ScaleMax = 3.8f, Biome = Biome.Mistlands, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 20f, MinTerrainDelta = 0f, MaxTerrainDelta = 3f },
            new WildsVegetation { Prefab = "Oak1_RtD", Enabled = true, Min = 0.8f, Max = 1.2f, ScaleMin = 1.1f, ScaleMax = 1.35f, Biome = Biome.Mistlands, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 20f, MaxTerrainDelta = 3f, GroupSizeMax = 2 },
            new WildsVegetation { Prefab = "Oak2_RtD", Enabled = true, Min = 0.8f, Max = 1.2f, ScaleMin = 1.1f, ScaleMax = 1.35f, Biome = Biome.Mistlands, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 20f, MaxTerrainDelta = 3f, GroupSizeMax = 2 },
            new WildsVegetation { Prefab = "ForestTree1_RtD", Enabled = true, Min = 0.8f, Max = 1.2f, ScaleMin = 1.1f, ScaleMax = 1.35f, Biome = Biome.Mistlands, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 20f, MaxTerrainDelta = 3f, GroupSizeMax = 2 },
            new WildsVegetation { Prefab = "ForestGreen1_RtD", Enabled = true, Min = 1f, Max = 1.5f, ScaleMin = 1.1f, ScaleMax = 1.85f, Biome = Biome.Mistlands, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 30f, MaxTerrainDelta = 3f, GroupSizeMax = 2 },
            new WildsVegetation { Prefab = "ForestGreen2_RtD", Enabled = true, Min = 1f, Max = 1.5f, ScaleMin = 1.1f, ScaleMax = 1.85f, Biome = Biome.Mistlands, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 30f, MaxTerrainDelta = 3f, GroupSizeMax = 2 },
            new WildsVegetation { Prefab = "ForestGreen3_RtD", Enabled = true, Min = 1f, Max = 1.5f, ScaleMin = 1.1f, ScaleMax = 1.85f, Biome = Biome.Mistlands, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 30f, MaxTerrainDelta = 3f, GroupSizeMax = 2 },
            new WildsVegetation { Prefab = "ForestGreen4_RtD", Enabled = true, Min = 1f, Max = 1.5f, ScaleMin = 1.1f, ScaleMax = 1.85f, Biome = Biome.Mistlands, MinAltitude = 1f, MaxAltitude = 1000f, MaxTilt = 30f, MaxTerrainDelta = 3f, GroupSizeMax = 2 },
            new WildsVegetation { Prefab = "SwampTree1", Enabled = true, Min = 2f, Max = 3f, Biome = Biome.Mistlands, MaxAltitude = 1000f, MaxTilt = 25f, MaxTerrainDelta = 2f, ScaleMin = 0.9f, ScaleMax = 1.3f, RandTilt = 6f, ChanceToUseGroundTilt = 0.2f, MinAltitude = 1f },
            new WildsVegetation { Prefab = "Beech1", Enabled = true, Min = 2f, Max = 3f, Biome = Biome.Mistlands, MaxAltitude = 1000f, MaxTilt = 30f, MaxTerrainDelta = 2f, ScaleMin = 1f, ScaleMax = 1.5f, RandTilt = 4f, ChanceToUseGroundTilt = 0.1f, MinAltitude = 1f },
            new WildsVegetation { Prefab = "Oak1", Enabled = true, Min = 0.3f, Max = 0.6f, Biome = Biome.Mistlands, MaxAltitude = 1000f, MaxTilt = 20f, MaxTerrainDelta = 2f, ScaleMin = 1f, ScaleMax = 1.4f, RandTilt = 4f, MinAltitude = 1f },
            new WildsVegetation { Prefab = "Birch1", Enabled = true, Min = 0.5f, Max = 1f, Biome = Biome.Mistlands, MaxAltitude = 1000f, MaxTilt = 25f, MaxTerrainDelta = 2f, ScaleMin = 0.8f, ScaleMax = 1.2f, RandTilt = 4f, MinAltitude = 1f },
            new WildsVegetation { Prefab = "shrub_2", Enabled = true, Min = 8f, Max = 12f, Biome = Biome.Mistlands, MaxAltitude = 1000f, MaxTilt = 35f, MaxTerrainDelta = 2f, ScaleMin = 0.5f, MinAltitude = 1f },
            new WildsVegetation { Prefab = "Bush01", Enabled = true, Min = 4f, Max = 6f, Biome = Biome.Mistlands, MaxAltitude = 1000f, MaxTilt = 30f, MaxTerrainDelta = 2f, ScaleMax = 1.4f, MinAltitude = 1f },
            new WildsVegetation { Prefab = "Pickable_Mushroom_JotunPuffs", Enabled = true, Min = 2f, Max = 3f, Biome = Biome.Mistlands, MaxAltitude = 1000f, MaxTilt = 40f, MaxTerrainDelta = 2f, ChanceToUseGroundTilt = 1f, MinAltitude = 1f, GroupSizeMax = 3, GroupRadius = 5f },
            new WildsVegetation { Prefab = "Pickable_Mushroom_Magecap", Enabled = true, Min = 1f, Max = 2f, Biome = Biome.Mistlands, MaxAltitude = 1000f, MaxTilt = 40f, MaxTerrainDelta = 2f, ChanceToUseGroundTilt = 1f, MinAltitude = 1f, GroupSizeMax = 3, GroupRadius = 5f },
            new WildsVegetation { Prefab = "Pickable_Mushroom", Enabled = true, Min = 1f, Max = 2f, Biome = Biome.Mistlands, MaxAltitude = 1000f, MaxTilt = 25f, MaxTerrainDelta = 2f, ScaleMax = 1.5f, MinAltitude = 1f, GroupSizeMin = 3, GroupSizeMax = 5, GroupRadius = 5f },
            new WildsVegetation { Prefab = "Pickable_Thistle", Enabled = true, Min = 0.5f, Max = 1f, Biome = Biome.Mistlands, MaxAltitude = 1000f, MaxTilt = 20f, MaxTerrainDelta = 2f, ScaleMin = 0.5f, RandTilt = 20f, MinAltitude = 1f, GroupSizeMin = 2, GroupSizeMax = 3, GroupRadius = 4f },
            new WildsVegetation { Prefab = "FireFlies", Enabled = true, Min = 6f, Max = 8f, Biome = Biome.Mistlands, MaxAltitude = 1000f, MaxTilt = 25f, MaxTerrainDelta = 2f, MinAltitude = 1f, GroundOffset = 1f },
            new WildsVegetation { Prefab = "FirTree_small_dead", Enabled = true, Min = 20f, Max = 30f, Biome = Biome.AshLands, MaxAltitude = 80f, MaxTilt = 30f, MaxTerrainDelta = 2f, ScaleMin = 0.6f, ScaleMax = 1.4f, RandTilt = 8f, ChanceToUseGroundTilt = 0.2f, MinAltitude = 1f, MaxVegetation = 0.6f },
            new WildsVegetation { Prefab = "Pinetree_01_Stub", Enabled = true, Min = 6f, Max = 10f, Biome = Biome.AshLands, MaxAltitude = 80f, MaxTilt = 20f, MaxTerrainDelta = 2f, ScaleMin = 0.8f, ScaleMax = 1.4f, ChanceToUseGroundTilt = 1f, MinAltitude = 1f, MaxVegetation = 0.6f },
            new WildsVegetation { Prefab = "stubbe", Enabled = true, Min = 4f, Max = 6f, Biome = Biome.AshLands, MaxAltitude = 80f, MaxTilt = 20f, MaxTerrainDelta = 2f, ScaleMin = 0.8f, ScaleMax = 1.4f, ChanceToUseGroundTilt = 1f, MinAltitude = 1f, MaxVegetation = 0.6f },
            new WildsVegetation { Prefab = "FirTree_oldLog", Enabled = true, Min = 3f, Max = 5f, Biome = Biome.AshLands, MaxAltitude = 80f, MaxTilt = 25f, MaxTerrainDelta = 2f, ScaleMin = 0.9f, ScaleMax = 1.3f, ChanceToUseGroundTilt = 1f, MinAltitude = 1f, MaxVegetation = 0.6f },
            new WildsVegetation { Prefab = "SwampTree2_log", Enabled = true, Min = 1f, Max = 2f, Biome = Biome.AshLands, MaxAltitude = 80f, MaxTilt = 35f, MaxTerrainDelta = 2f, ScaleMin = 1.5f, ScaleMax = 2f, RandTilt = 20f, MinAltitude = 1f, MaxVegetation = 0.6f },
            new WildsVegetation { Prefab = "Rock_3", Enabled = true, Min = 1f, Max = 3f, Biome = Biome.AshLands, MaxAltitude = 80f, MaxTilt = 30f, MaxTerrainDelta = 2f, ScaleMin = 2f, ScaleMax = 4f, ChanceToUseGroundTilt = 1f, GroundOffset = -0.5f, MinAltitude = 1f, MaxVegetation = 0.6f },
            new WildsVegetation { Prefab = "LargeBone", Enabled = true, Min = 1f, Max = 2f, Biome = Biome.AshLands, MaxAltitude = 80f, MaxTilt = 40f, MaxTerrainDelta = 2f, ScaleMin = 1.2f, ScaleMax = 1.5f, RandTilt = 180f, ChanceToUseGroundTilt = 0.1f, GroundOffset = -0.1f, MinAltitude = 1f, MaxVegetation = 0.6f },
            new WildsVegetation { Prefab = "LargeBone_half01", Enabled = true, Min = 1f, Max = 2f, Biome = Biome.AshLands, MaxAltitude = 80f, MaxTilt = 40f, MaxTerrainDelta = 2f, ScaleMin = 1.2f, ScaleMax = 1.5f, RandTilt = 180f, ChanceToUseGroundTilt = 0.1f, GroundOffset = -0.1f, MinAltitude = 1f, MaxVegetation = 0.6f },
            new WildsVegetation { Prefab = "LargeBone_half02", Enabled = true, Min = 1f, Max = 2f, Biome = Biome.AshLands, MaxAltitude = 80f, MaxTilt = 40f, MaxTerrainDelta = 2f, ScaleMin = 1.2f, ScaleMax = 1.5f, RandTilt = 180f, ChanceToUseGroundTilt = 0.1f, GroundOffset = -0.1f, MinAltitude = 1f, MaxVegetation = 0.6f },
            new WildsVegetation { Prefab = "asksvin_carrion", Enabled = true, Min = 0.5f, Max = 1f, Biome = Biome.AshLands, MaxAltitude = 80f, MaxTilt = 30f, MaxTerrainDelta = 2f, ChanceToUseGroundTilt = 1f, MinAltitude = 1f, MaxVegetation = 0.6f },
            new WildsVegetation { Prefab = "asksvin_carrion2", Enabled = true, Min = 0.5f, Max = 1f, Biome = Biome.AshLands, MaxAltitude = 80f, MaxTilt = 30f, MaxTerrainDelta = 2f, ChanceToUseGroundTilt = 1f, MinAltitude = 1f, MaxVegetation = 0.6f },
            new WildsVegetation { Prefab = "DeadTree1_RtD", Enabled = true, Min = 0.2f, Max = 0.6f, ScaleMin = 1.1f, ScaleMax = 1.25f, Biome = Biome.AshLands, MinAltitude = 10f, MaxAltitude = 80f, MaxTilt = 30f, MaxTerrainDelta = 3f, GroupSizeMax = 2, MaxVegetation = 0.6f },
            new WildsVegetation { Prefab = "DeadTree2_RtD", Enabled = true, Min = 0.2f, Max = 0.6f, ScaleMin = 1.1f, ScaleMax = 1.25f, Biome = Biome.AshLands, MinAltitude = 10f, MaxAltitude = 80f, MaxTilt = 30f, MaxTerrainDelta = 3f, GroupSizeMax = 2, MaxVegetation = 0.6f },
            new WildsVegetation { Prefab = "DeadTree3_RtD", Enabled = true, Min = 0.2f, Max = 0.6f, ScaleMin = 1.1f, ScaleMax = 1.25f, Biome = Biome.AshLands, MinAltitude = 10f, MaxAltitude = 80f, MaxTilt = 30f, MaxTerrainDelta = 3f, GroupSizeMax = 2, MaxVegetation = 0.6f },
            new WildsVegetation { Prefab = "DeadTree4_RtD", Enabled = true, Min = 0.2f, Max = 0.6f, ScaleMin = 1.1f, ScaleMax = 1.25f, Biome = Biome.AshLands, MinAltitude = 10f, MaxAltitude = 80f, MaxTilt = 30f, MaxTerrainDelta = 3f, GroupSizeMax = 2, MaxVegetation = 0.6f },
            new WildsVegetation { Prefab = "DeadTree5_RtD", Enabled = true, Min = 0.2f, Max = 0.6f, ScaleMin = 1.1f, ScaleMax = 1.25f, Biome = Biome.AshLands, MinAltitude = 10f, MaxAltitude = 80f, MaxTilt = 30f, MaxTerrainDelta = 3f, GroupSizeMax = 2, MaxVegetation = 0.6f },
            new WildsVegetation { Prefab = "DeadTree6_RtD", Enabled = true, Min = 0.2f, Max = 0.6f, ScaleMin = 1.1f, ScaleMax = 1.25f, Biome = Biome.AshLands, MinAltitude = 10f, MaxAltitude = 80f, MaxTilt = 30f, MaxTerrainDelta = 3f, GroupSizeMax = 2, MaxVegetation = 0.6f },
            new WildsVegetation { Prefab = "DeadTree7_RtD", Enabled = true, Min = 0.2f, Max = 0.6f, ScaleMin = 1.1f, ScaleMax = 1.25f, Biome = Biome.AshLands, MinAltitude = 10f, MaxAltitude = 80f, MaxTilt = 30f, MaxTerrainDelta = 3f, GroupSizeMax = 2, MaxVegetation = 0.6f },
            new WildsVegetation { Prefab = "DeadTree8_RtD", Enabled = true, Min = 0.2f, Max = 0.6f, ScaleMin = 1.1f, ScaleMax = 1.25f, Biome = Biome.AshLands, MinAltitude = 10f, MaxAltitude = 80f, MaxTilt = 30f, MaxTerrainDelta = 3f, GroupSizeMax = 2, MaxVegetation = 0.6f },
            new WildsVegetation { Prefab = "DeadTree9_RtD", Enabled = true, Min = 0.2f, Max = 0.6f, ScaleMin = 1.1f, ScaleMax = 1.25f, Biome = Biome.AshLands, MinAltitude = 10f, MaxAltitude = 80f, MaxTilt = 30f, MaxTerrainDelta = 3f, GroupSizeMax = 2, MaxVegetation = 0.6f },
            new WildsVegetation { Prefab = "HeathRockPillar", Enabled = true, Min = 0.6f, Max = 1.5f, Biome = Biome.Plains, MaxAltitude = 1000f, MaxTilt = 12f, MaxTerrainDelta = 1.5f, ScaleMin = 1f, ScaleMax = 2f, RandTilt = 5f, GroundOffset = -4f, MinAltitude = 2f, TerrainDeltaRadius = 4f },
            new WildsVegetation { Prefab = "rock4_heath", Enabled = true, Min = 8f, Max = 15f, Biome = Biome.Plains, MaxAltitude = 1000f, MaxTilt = 45f, MaxTerrainDelta = 2f, ScaleMin = 0.8f, RandTilt = 5f, MinAltitude = 4f, MinTilt = 15f, GroundOffset = -3f },
            new WildsVegetation { Prefab = "rock2_heath", Enabled = true, Min = 1f, Max = 2f, Biome = Biome.Plains, MaxAltitude = 1000f, MaxTilt = 20f, MaxTerrainDelta = 2f, ScaleMax = 1.8f, RandTilt = 20f, MinAltitude = 1f },
            new WildsVegetation { Prefab = "Rock_4_plains", Enabled = true, Min = 8f, Max = 15f, Biome = Biome.Plains, MaxAltitude = 1000f, MaxTilt = 30f, MaxTerrainDelta = 2f, ScaleMax = 2f, ChanceToUseGroundTilt = 1f, MinAltitude = 1f },
            new WildsVegetation { Prefab = "Rock_7_meadows", Enabled = true, Min = 0.5f, Max = 1f, Biome = Biome.Plains, MaxAltitude = 1000f, MaxTilt = 40f, MaxTerrainDelta = 2f, ScaleMin = 1.5f, ScaleMax = 2.5f, RandTilt = 30f, ChanceToUseGroundTilt = 0.5f, GroundOffset = -0.5f, MinAltitude = 1f },
            new WildsVegetation { Prefab = "LargeBone", Enabled = true, Min = 0.4f, Max = 0.8f, Biome = Biome.Plains, MaxAltitude = 1000f, MaxTilt = 40f, MaxTerrainDelta = 2f, ScaleMin = 1.2f, ScaleMax = 1.5f, RandTilt = 180f, ChanceToUseGroundTilt = 0.1f, GroundOffset = -0.1f, MinAltitude = 1f },
            new WildsVegetation { Prefab = "LargeBone_half01", Enabled = true, Min = 0.4f, Max = 0.8f, Biome = Biome.Plains, MaxAltitude = 1000f, MaxTilt = 40f, MaxTerrainDelta = 2f, ScaleMin = 1.2f, ScaleMax = 1.5f, RandTilt = 180f, ChanceToUseGroundTilt = 0.1f, GroundOffset = -0.1f, MinAltitude = 1f },
            new WildsVegetation { Prefab = "LargeBone_half02", Enabled = true, Min = 0.4f, Max = 0.8f, Biome = Biome.Plains, MaxAltitude = 1000f, MaxTilt = 40f, MaxTerrainDelta = 2f, ScaleMin = 1.2f, ScaleMax = 1.5f, RandTilt = 180f, ChanceToUseGroundTilt = 0.1f, GroundOffset = -0.1f, MinAltitude = 1f },
            new WildsVegetation { Prefab = "asksvin_carrion", Enabled = true, Min = 0.3f, Max = 0.6f, Biome = Biome.Plains, MaxAltitude = 1000f, MaxTilt = 30f, MaxTerrainDelta = 2f, ChanceToUseGroundTilt = 1f, MinAltitude = 1f },
            new WildsVegetation { Prefab = "asksvin_carrion2", Enabled = true, Min = 0.3f, Max = 0.6f, Biome = Biome.Plains, MaxAltitude = 1000f, MaxTilt = 30f, MaxTerrainDelta = 2f, ChanceToUseGroundTilt = 1f, MinAltitude = 1f },
        };

        internal static readonly WildsClutter[] WildsClutterList = new WildsClutter[]
        {
            new WildsClutter { Prefab = "instanced_meadows_grass", Amount = 60, Biome = Biome.Meadows, Instanced = true, ScaleMax = 2.3f, MaxTilt = 25f, MinAltitude = 0.4f, MaxAltitude = 1000f, TerrainTilt = true, FractalScale = 5f },
            new WildsClutter { Prefab = "instanced_shrub", Amount = 8, Biome = Biome.Meadows, Instanced = true, ScaleMax = 1.5f, MaxTilt = 30f, MinAltitude = 1f, MaxAltitude = 1000f, InForest = true, ForestThresholdMax = 1.15f, FractalThresholdMin = 0.5f },
            new WildsClutter { Prefab = "instanced_forest_groundcover_brown", Amount = 80, Biome = Biome.BlackForest, Instanced = true, MaxTilt = 25f, MinAltitude = 0.5f, MaxAltitude = 1000f, TerrainTilt = true, FractalThresholdMin = 0.5f },
            new WildsClutter { Prefab = "instanced_forest_groundcover", Amount = 50, Biome = Biome.BlackForest, Instanced = true, MaxTilt = 25f, MinAltitude = 0.5f, MaxAltitude = 1000f, TerrainTilt = true, FractalThresholdMin = 0.5f },
            new WildsClutter { Prefab = "instanced_swamp_grass", Amount = 150, Biome = Biome.Swamp, Instanced = true, ScaleMin = 0.8f, MaxTilt = 25f, MinAltitude = 0f, MaxAltitude = 1000f, TerrainTilt = true, FractalThresholdMin = 0.5f },
            new WildsClutter { Prefab = "instanced_meadows_grass_short", Amount = 175, Biome = Biome.Meadows, Instanced = true, ScaleMax = 2f, MaxTilt = 25f, MinAltitude = 0.3f, MaxAltitude = 1000f, TerrainTilt = true, FractalScale = 5f, FractalThresholdMin = 1f, FractalThresholdMax = 3f },
            new WildsClutter { Prefab = "instanced_small_rock1", Amount = 15, Biome = Biome.Meadows, Instanced = true, OnUncleared = false, OnCleared = true, ScaleMax = 2f, MaxTilt = 45f, MinAltitude = 0f, MaxAltitude = 1000f, TerrainTilt = true, FractalThresholdMax = 0f },
            new WildsClutter { Prefab = "instanced_small_rock1", Amount = 15, Biome = Biome.Swamp, Instanced = true, OnUncleared = false, OnCleared = true, ScaleMax = 2f, MaxTilt = 45f, MinAltitude = 0f, MaxAltitude = 1000f, TerrainTilt = true, FractalThresholdMax = 0f },
            new WildsClutter { Prefab = "instanced_small_rock1", Amount = 15, Biome = Biome.Mountain, Instanced = true, OnUncleared = false, OnCleared = true, ScaleMax = 2f, MaxTilt = 45f, MinAltitude = 0f, MaxAltitude = 1000f, TerrainTilt = true, FractalThresholdMax = 0f },
            new WildsClutter { Prefab = "instanced_small_rock1", Amount = 15, Biome = Biome.BlackForest, Instanced = true, OnUncleared = false, OnCleared = true, ScaleMax = 2f, MaxTilt = 45f, MinAltitude = 0f, MaxAltitude = 1000f, TerrainTilt = true, FractalThresholdMax = 0f },
            new WildsClutter { Prefab = "instanced_small_rock1", Amount = 15, Biome = Biome.Plains, Instanced = true, OnUncleared = false, OnCleared = true, ScaleMax = 2f, MaxTilt = 45f, MinAltitude = 0f, MaxAltitude = 1000f, TerrainTilt = true, FractalThresholdMax = 0f },
            new WildsClutter { Prefab = "instanced_small_rock1", Amount = 15, Biome = Biome.AshLands, Instanced = true, OnUncleared = false, OnCleared = true, ScaleMax = 2f, MaxTilt = 45f, MinAltitude = 0f, MaxAltitude = 1000f, TerrainTilt = true, FractalThresholdMax = 0f },
            new WildsClutter { Prefab = "instanced_small_rock1", Amount = 15, Biome = Biome.DeepNorth, Instanced = true, OnUncleared = false, OnCleared = true, ScaleMax = 2f, MaxTilt = 45f, MinAltitude = 0f, MaxAltitude = 1000f, TerrainTilt = true, FractalThresholdMax = 0f },
            new WildsClutter { Prefab = "instanced_swamp_ormbunke", Amount = 4, Biome = Biome.Swamp, Instanced = true, ScaleMin = 0.5f, MaxTilt = 18f, MinAltitude = 0f, MaxAltitude = 1000f, TerrainTilt = true, FractalThresholdMin = 0.5f },
            new WildsClutter { Prefab = "instanced_ormbunke", Amount = 30, Biome = Biome.Meadows, Instanced = true, MaxTilt = 18f, MinAltitude = 1f, MaxAltitude = 4f, TerrainTilt = true, InForest = true, FractalThresholdMin = 0.5f },
            new WildsClutter { Prefab = "instanced_ormbunke", Amount = 10, Biome = Biome.BlackForest, Instanced = true, MaxTilt = 18f, MinAltitude = 1f, MaxAltitude = 1000f, TerrainTilt = true, MaxOceanDepth = 2f, FractalThresholdMin = 0.5f },
            new WildsClutter { Prefab = "instanced_vass", Amount = 30, Biome = Biome.Meadows, Instanced = true, ScaleMax = 1.3f, MaxTilt = 90f, MinAltitude = -1f, MaxAltitude = -0.1f, SnapToWater = true, FractalScale = 5f },
            new WildsClutter { Prefab = "instanced_vass", Amount = 30, Biome = Biome.Swamp, Instanced = true, ScaleMax = 1.3f, MaxTilt = 90f, MinAltitude = -1f, MaxAltitude = -0.1f, SnapToWater = true, FractalScale = 5f },
            new WildsClutter { Prefab = "instanced_vass", Amount = 30, Biome = Biome.Mountain, Instanced = true, ScaleMax = 1.3f, MaxTilt = 90f, MinAltitude = -1f, MaxAltitude = -0.1f, SnapToWater = true, FractalScale = 5f },
            new WildsClutter { Prefab = "instanced_vass", Amount = 30, Biome = Biome.BlackForest, Instanced = true, ScaleMax = 1.3f, MaxTilt = 90f, MinAltitude = -1f, MaxAltitude = -0.1f, SnapToWater = true, FractalScale = 5f },
            new WildsClutter { Prefab = "instanced_vass", Amount = 30, Biome = Biome.Plains, Instanced = true, ScaleMax = 1.3f, MaxTilt = 90f, MinAltitude = -1f, MaxAltitude = -0.1f, SnapToWater = true, FractalScale = 5f },
            new WildsClutter { Prefab = "instanced_waterlilies", Amount = 40, Biome = Biome.Meadows, Instanced = true, ScaleMin = 0.4f, ScaleMax = 0.6f, MaxTilt = 90f, MinAltitude = -1.5f, MaxAltitude = -0.2f, SnapToWater = true, RandomOffset = 0.1f, MaxOceanDepth = 1f, FractalScale = 2f },
            new WildsClutter { Prefab = "instanced_waterlilies", Amount = 40, Biome = Biome.BlackForest, Instanced = true, ScaleMin = 0.4f, ScaleMax = 0.6f, MaxTilt = 90f, MinAltitude = -1.5f, MaxAltitude = -0.2f, SnapToWater = true, RandomOffset = 0.1f, MaxOceanDepth = 1f, FractalScale = 2f },
            new WildsClutter { Prefab = "instanced_ashlands_grass_short", Amount = 15, Biome = Biome.AshLands, Instanced = true, ScaleMin = 2f, ScaleMax = 2f, MaxTilt = 30f, MinAltitude = 1f, MaxAltitude = 15f, MaxVegetation = 0.15f, FractalScale = 4f, FractalThresholdMax = 0.6f },
            new WildsClutter { Prefab = "instanced_ashlands_grass_long", Amount = 15, Biome = Biome.AshLands, Instanced = true, ScaleMin = 2f, ScaleMax = 2f, MaxTilt = 30f, MinAltitude = 1f, MaxAltitude = 15f, MaxVegetation = 0.15f, FractalScale = 3f },
            new WildsClutter { Prefab = "instanced_forest_groundcover_snow", Amount = 30, Biome = Biome.DeepNorth, Instanced = true, ScaleMin = 0.7f, ScaleMax = 2f, MaxTilt = 60f, MinAltitude = 1f, MaxAltitude = 1000f, MaxVegetation = 1f, InForest = true, FractalScale = 2f, FractalThresholdMax = 2f },
            new WildsClutter { Prefab = "instanced_forest_groundcover_snow", Amount = 50, Biome = Biome.DeepNorth, Instanced = true, ScaleMin = 0.7f, ScaleMax = 2f, MaxTilt = 60f, MinAltitude = 1f, MaxAltitude = 1000f, MaxVegetation = 1f, FractalScale = 1f },
            new WildsClutter { Prefab = "instanced_mistlands_grass_short", Amount = 140, Biome = Biome.DeepNorth, Instanced = true, ScaleMin = 2f, ScaleMax = 2f, MaxTilt = 35f, MinAltitude = 0.3f, MaxAltitude = 1000f, TerrainTilt = true },
            new WildsClutter { Prefab = "instanced_mistlands_grass_short", Amount = 250, Biome = Biome.Mistlands, Instanced = true, ScaleMin = 2f, ScaleMax = 2f, MaxTilt = 35f, MinAltitude = 0.3f, MaxAltitude = 1000f, TerrainTilt = true },
            new WildsClutter { Prefab = "instanced_meadows_grass_short", Amount = 60, Biome = Biome.Mistlands, Instanced = true, ScaleMax = 2f, MaxTilt = 25f, MinAltitude = 1f, MaxAltitude = 1000f, TerrainTilt = true, FractalScale = 5f, FractalThresholdMin = 1f, FractalThresholdMax = 3f },
            new WildsClutter { Prefab = "instanced_ormbunke", Amount = 30, Biome = Biome.Mistlands, Instanced = true, MaxTilt = 18f, MinAltitude = 1f, MaxAltitude = 1000f, TerrainTilt = true, InForest = false, FractalThresholdMin = 0.5f },
            new WildsClutter { Prefab = "instanced_forest_groundcover", Amount = 40, Biome = Biome.Mistlands, Instanced = true, MaxTilt = 25f, MinAltitude = 1f, MaxAltitude = 1000f, TerrainTilt = true, FractalThresholdMin = 0.5f },
            new WildsClutter { Prefab = "instanced_small_rock1", Amount = 8, Biome = Biome.Mistlands, Instanced = true, OnUncleared = false, OnCleared = true, ScaleMax = 2f, MaxTilt = 45f, MinAltitude = 0f, MaxAltitude = 1000f, TerrainTilt = true, FractalThresholdMax = 0f },
            new WildsClutter { Prefab = "instanced_heathgrass", Amount = 40, Biome = Biome.AshLands, Instanced = true, ScaleMin = 0.6f, ScaleMax = 1.1f, MaxTilt = 30f, MinAltitude = 1f, MaxAltitude = 60f, TerrainTilt = true, FractalThresholdMax = 0.8f, MaxVegetation = 0.15f },
            new WildsClutter { Prefab = "instanced_heathgrass", Amount = 25, Biome = Biome.Plains, Instanced = true, ScaleMin = 0.5f, ScaleMax = 1f, MaxTilt = 30f, MinAltitude = 0.5f, MaxAltitude = 1000f, TerrainTilt = true, FractalThresholdMax = 0.8f, FractalThresholdMin = 0.6f },
            new WildsClutter { Prefab = "instanced_ashlands_grass_short", Amount = 20, Biome = Biome.Plains, Instanced = true, ScaleMin = 1f, ScaleMax = 1.5f, MaxTilt = 30f, MinAltitude = 1f, MaxAltitude = 1000f, MaxVegetation = 1f, FractalScale = 4f },
            new WildsClutter { Prefab = "instanced_small_rock1", Amount = 30, Biome = Biome.Plains, Instanced = true, OnUncleared = false, OnCleared = true, ScaleMax = 2f, MaxTilt = 45f, MinAltitude = 0f, MaxAltitude = 1000f, TerrainTilt = true },
        };
    }
}