using System.Reflection;
using System;
using BepInEx;
using BepInEx.Configuration;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using UnityEngine;
using static Heightmap;

namespace RtDBiomes
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Major)]
    [BepInDependency("com.jotunn.jotunn", BepInDependency.DependencyFlags.HardDependency)]

    internal partial class RtDBiomes : BaseUnityPlugin
    {
        public const string PluginGUID = "soloredis.rtdbiomes";

        public const string PluginName = "RtDBiomes";

        public const string PluginVersion = "3.1.49";

        private AssetBundle MyAssets;

        private ConfigEntry<bool> LoggingEnable;

        private void Awake()
        {
            LoadBundle();
            CreateConfigs();
            SetupWildsLook();
            Localizations();
            JSONSupport();
            AddItems();
            AddPrefabs();
            MeadowsBushConfig();
            BlackForestBushConfig();
            SwampBushConfig();
            MountainBushConfig();
            PlainsBushConfig();
            MistlandsBushConfig();
            MistlandsShroomConfig();
            AshLandsBushConfig();
            DeepNorthBushConfig();
            MeadowsTreeConfig();
            BlackForestTreeConfig();
            SwampTreeConfig();
            PlainsTreeConfig();
            PlainsPalmConfig();
            MistlandsTreeConfig();
            MistlandsBlossomConfig();
            AshLandsTreeConfig();
            DeepNorthTreeConfig();
            VariableTreeList();
            PlainsRockConfig();
            StaticVegetationList();
            AddSaplings();
            CreateRecipes();

            // Vegetation
            ZoneManager.OnVanillaVegetationAvailable += AdjustVanillaVegetation;

            // Locations
            ZoneManager.OnVanillaLocationsAvailable += AdjustVanillaLocation;

            if (LoggingEnable.Value)
                Logger.LogWarning("Logging is enabled in the config.");
        }

        private void LoadBundle()
        {
            if (MyAssets != null) return;

            try
            {
                MyAssets = AssetUtils.LoadAssetBundleFromResources("rtdbiomes", Assembly.GetExecutingAssembly());

                if (MyAssets == null)
                {
                    Logger.LogError("Failed to load AssetBundle. Disabling mod.");
                    enabled = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                Logger.LogWarning($"Exception caught while loading bundle: {ex}");
            }
        }

        private void CreateConfigs()
        {
            try
            {
                Config.SaveOnConfigSet = true;

                LoggingEnable = Config.Bind("Logging", "Enable", false, new ConfigDescription("Enables logging.", null, new ConfigurationManagerAttributes
                {
                    IsAdminOnly = false
                }));
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding configuration values: {arg}");
            }
        }

        // Prefab List

        public string[] PrefabList = new string[]
        {
          "VanillaSwampLog_RtD",
          "VanillaSwampStump_RtD",
          "DeepNorthRock4_frac_RtD",
          "DeepNorthRock5_frac_RtD",
          "fx_leviathan_leave_RtD",
          "vfx_greydwarf_shaman_pray_RtD",
          "fx_goblinking_meteor_hit_RtD",
          "fx_goblinking_nova_RtD",
          "ThinPineStump",
          "PineWoodHalf",
          "PineWoodLog",
          "CottonWoodStump",
          "CottonWoodHalf",
          "CottonWoodLog",
          "AcaciaLogHalf",
          "AcaciaStump",
          "AcaciaLog",
          "OakWoodStump",
          "OakWoodHalf",
          "OakWoodLog",
          "BlossomStump",
          "BlossomLogHalf",
          "BlossomLog",
          "RedPineStump",
          "PineWoodLog1",
          "PineWoodHalf1",
          "MagicStump1",
          "MagicLog1Half",
          "MagicLog1",
          "MagicStump2",
          "MagicLog2Half",
          "MagicLog2",
          "MagicStump3",
          "MagicLog3Half",
          "MagicLog3",
          "MagicStump4",
          "MagicLog4Half",
          "MagicLog4",
          "MagicStump5",
          "MagicLog5Half",
          "MagicLog5",
          "MagicStump6",
          "MagicLog6Half",
          "MagicLog6",
          "MagicStump9",
          "MagicLog9Half",
          "MagicLog9",
          "MagicStump10",
          "MagicLog10Half",
          "MagicLog10",
          "PalmStump",
          "PalmLogHalf",
          "PalmLog",
          "DeadWoodStump",
          "DeadWoodHalf",
          "DeadWoodLog",
          "WillowLogHalf",
          "WillowStump",
          "WillowLog",
          "AcaciaLog4",
          "AcaciaStump4",
          "ShootStump_RtD",
          "YggaShoot_Log_RtD",
          "YggaShoot_LogHalf_RtD",
          "SwampWoodHalf",
          "SwampWoodHalfFix",
          "SwampWoodStump",
          "SwampWoodLog",
          "WinterPineStumpWhite",
          "WinterPineStumpRed",
          "MagicLog7",
          "MagicLog7Half",
          "MagicLog8",
          "MagicLog8Half",
          "MagicStump7",
          "MagicStump8"
        };

        // Items

        public string[] ItemList = new string[]
        {
          "AcaciaSeeds_RtD",
          "BlossomSeeds_RtD",
          "CottonWoodSeeds_RtD",
          "OakWoodSeeds_RtD",
          "PalmTreeSeeds_RtD",
          "RedPineSeeds_RtD",
          "ThinPineSeeds_RtD",
          "WillowSeeds_RtD",
          "PlantSeedSwamp_RtD",
          "PlantSeedPlains_RtD",
          "PlantSeedMountain_RtD",
          "PlantSeedMistlands_RtD",
          "PlantSeedMeadows_RtD",
          "PlantSeedDeepNorth_RtD",
          "PlantSeedBlackForest_RtD",
          "PlantSeedAshLands_RtD",
          "AshLandsSeed2_RtD",
          "MapleSeed_RtD",
          "WinterPineSeeds2_RtD",
          "WinterPineSeeds1_RtD",
          "FaeSeed_RtD",
          "AshLandsSeed1_RtD"
        };

        // Static None

        public string[] StaticNoneList = new string[]
        {
             "SandRock1_RtD",
             "SandRock2_RtD",
             "SandRock3_RtD",
             "SandRock4_RtD",
             "SandRock5_RtD",
             "MountainBush1_RtD",
             "MountainBush2_RtD",
             "MountainBush3_RtD",
             "MeadowsBush2_RtD",
             "MeadowsBush3_RtD",
             "MeadowsBush4_RtD",
             "MeadowsBush5_RtD",
             "DeepNorthRock4_RtD",
             "DeepNorthRock5_RtD",
             "DeepNorthRock6_RtD",
             "SmallBush_RtD",
             "MeadowsBush04_RtD",
             "MeadowsBush05_RtD",
             "MeadowsBush06_RtD",
             "AshLandsRock1_RtD",
             "AshLandsRock2_RtD",
             "AshLandsRock4_RtD",
             "AshLandsRock5_RtD",
             "AshLandsRock6_RtD",
             "DeepNorthRock1_RtD",
             "DeepNorthRock2_RtD",
             "BlackForestBush2_RtD",
             "BlackForestBush4_RtD",
             "BlackForestBush5_RtD",
             "BlackForestBush7_RtD",
             "BlackForestBush8_RtD",
             "RedPineSmall2_RtD",
             "RedPineSmall3_RtD"
        };

        public string[] MeadowsBushList = new string[]
        {
          "MeadowsShroom1_RtD",
          "MeadowsShroom2_RtD",
          "MeadowsShroom3_RtD",
          "MeadowsShroom4_RtD",
          "MeadowsBush01_RtD",
          "MeadowsBush02_RtD",
          "MeadowsBush03_RtD",
          "MeadowsBush1_RtD",
          "BlackForestBush1_RtD",
        };

        public string[] BlackForestBushList = new string[]
        {
          "BlackShroom1_RtD",
          "BlackShroom2_RtD",
          "BlackShroom3_RtD",
          "BlackShroom4_RtD",
          "BlackForestBush3_RtD",
          "BlackForestBush6_RtD",
          "ForestGreen1_RtD",
          "ForestGreen2_RtD",
          "RedPineSmall1_RtD"
        };

        public string[] SwampBushList = new string[]
        {
          "GreenShroom1_RtD",
          "GreenShroom2_RtD",
          "GreenShroom3_RtD",
          "GreenShroom4_RtD",
          "SwampBush1_RtD",
          "SwampBush2_RtD",
          "SwampBush3_RtD",
          "SwampBush4_RtD",
          "SwampBush5_RtD",
          "SwampBush6_RtD",
          "SwampBush7_RtD",
          "SwampBush8_RtD",
          "SwampBush9_RtD",
          "SwampBush10_RtD",
          "SwampBush11_RtD",
          "DeadIvy1_RtD",
          "DeadIvy2_RtD",
          "SwampBush12_RtD",
          "SwampBush13_RtD",
          "SwampBush14_RtD"
        };

        public string[] MountainBushList = new string[]
        {
            "EverGreen1_RtD",
            "EverGreen2_RtD",
            "EverGreen3_RtD",
            "EverGreen4_RtD",
            "ForestGreen3_RtD",
            "ForestGreen4_RtD",
        };

        public string[] PlainsBushList = new string[]
        {
          "PlainsBush1_RtD",
          "PlainsBush2_RtD",
          "PlainsBush3_RtD",

          "AshLandsBush3_RtD",
          "AshLandsBush4_RtD",

          "PlainsBush4_RtD",
          "PlainsBush5_RtD",
          "PlainsBush6_RtD",
          "PlainsBush7_RtD",
          "PlainsBush8_RtD"
        };

        public string[] MistlandsShroomList = new string[]
        {
          "BlueShroom1_RtD",
          "BlueShroom2_RtD",
          "BlueShroom3_RtD",
          "BlueShroom4_RtD",
          "YellowShroom1_RtD",
          "YellowShroom2_RtD",
          "YellowShroom3_RtD",
          "YellowShroom4_RtD"
        };

        public string[] MistlandsBushList = new string[]
        {
          "MistLandsBush1_RtD",
          "MistLandsBush2_RtD",
          "MistLandsBush3_RtD",
          "MistLandsBush4_RtD",
          "MistLandsBush5_RtD",
          "MistLandsBush6_RtD",
          "MistLandsBush7_RtD"
        };

        public string[] AshLandsBushList = new string[]
        {
            "AshLandsBush1_RtD",
            "AshLandsBush2_RtD",
            "AshLandsBush5_RtD",
            "AshLandsBush6_RtD",
            "AshLandsBush11_RtD",
            "AshLandsBush12_RtD",
            "AshLandsBush13_RtD",
            "AshLandsBush14_RtD",
            "AshLandsBush15_RtD",
            "AshLandsBush16_RtD",
            "AshLandsBush17_RtD",
            "AshLandsBush18_RtD",
            "AshLandsBush19_RtD",
            "AshLandsBush20_RtD",
            "AshLandsBush21_RtD",
            "AshLandsBush22_RtD",
            "AshLandsBush23_RtD",
            "AshLandsBush24_RtD",
            "AshLandsBush25_RtD",
            "AshLandsBush26_RtD",
            "RedShroom1_RtD",
            "RedShroom2_RtD",
            "RedShroom3_RtD",
            "RedShroom4_RtD"
        };

        public string[] DeepNorthBushList = new string[]
        {
          "MountainShroom1_RtD",
          "MountainShroom2_RtD",
          "MountainShroom3_RtD",
          "MountainShroom4_RtD"
        };

        public string[] MeadowsTreeList = new string[]
        {
          "ForestTree1_RtD",
          "Oak1_RtD",
          "Oak2_RtD"
        };

        public string[] BlackForestTreeList = new string[]
        {
          "RedPine1_RtD",
          "RedPine2_RtD",
          "RedPine3_RtD",
          "RedPine4_RtD",
          "RedPine_RtD",
          "WinterPine3_RtD",
          "WinterPine4_RtD",
          "WinterPine5_RtD"
        };

        public string[] SwampTreeList = new string[]
        {
          "MagicTree6_RtD",
          "MagicTree9_RtD",
          "MagicTree10_RtD",
          "SwampTree1_RtD",
          "SwampTree2_RtD",
          "SwampTree3_RtD",
          "SwampTree4_RtD",
          "SwampTree5_RtD",
          "SwampTree6_RtD",
        };

        public string[] MountainTreeList = new string[]
        {
            "ThinPine1_RtD",
            "ThinPine2_RtD"
        };

        public string[] PlainsTreeList = new string[]
        {
          "Acacia1_RtD",
          "Acacia2_RtD",
          "Acacia3_RtD",
          "Acacia4_RtD"
        };

        public string[] PlainsPalmList = new string[]
        {
          "PalmTree1_RtD",
          "PalmTree2_RtD"
        };

        public string[] MistlandsTreeList = new string[]
        {
          "MagicTree1_RtD"
        };

        public string[] MistlandsBlossomList = new string[]
        {
          "Blossom1_RtD",
          "Blossom2_RtD",
          "Blossom3_RtD",
          "Blossom4_RtD",
          "Blossom5_RtD"
        };

        public string[] AshLandsTreeList = new string[]
        {
          "DeadTree1_RtD",
          "DeadTree2_RtD",
          "DeadTree3_RtD",
          "DeadTree4_RtD",
          "DeadTree5_RtD",
          "DeadTree6_RtD",
          "DeadTree7_RtD",
          "DeadTree8_RtD",
          "DeadTree9_RtD",
          "MagicTree7_RtD",
          "MagicTree8_RtD"
        };

        public string[] DeepNorthTreeList = new string[]
        {
          "MagicTree3_RtD",
          "MagicTree4_RtD",
          "MagicTree5_RtD"
        };

        public string[] PlainsRockList = new string[]
        {
        };

        // Static None Values

        public static VegetationConfig StaticNoneValues = new VegetationConfig
        {
            Min = 1f,
            Max = 2f,
            ScaleMin = 1.1f,
            ScaleMax = 1.25f,
            MinAltitude = 1f,
            MaxAltitude = 1000f,
            Biome = Biome.None,
            MaxTilt = 30f,
            MaxTerrainDelta = 3f,
            GroupSizeMin = 1,
            GroupSizeMax = 2,
            InForest = true,
            ForestThresholdMin = 1.1f,
            ForestThresholdMax = 1.15f
        };

        // Bush Values

        public static VegetationConfig MeadowsBushValues = new VegetationConfig
        {
            Min = 2.7f,
            Max = 4.5f,
            ScaleMin = 1.1f,
            ScaleMax = 1.85f,
            MinAltitude = 1f,
            MaxAltitude = 1000f,
            Biome = Biome.Meadows,
            MaxTilt = 30f,
            MaxTerrainDelta = 3f,
            GroupSizeMin = 1,
            GroupSizeMax = 2
        };

        public static VegetationConfig BlackForestBushValues = new VegetationConfig
        {
            Min = 1.5f,
            Max = 2.7f,
            ScaleMin = 1.1f,
            ScaleMax = 1.85f,
            MinAltitude = 1f,
            MaxAltitude = 1000f,
            Biome = Biome.BlackForest,
            MaxTilt = 40f,
            MaxTerrainDelta = 3f,
            GroupSizeMin = 1,
            GroupSizeMax = 2
        };

        public static VegetationConfig SwampBushValues = new VegetationConfig
        {
            Min = 3.3f,
            Max = 4.5f,
            ScaleMin = 2.1f,
            ScaleMax = 2.8f,
            MinAltitude = 1f,
            MaxAltitude = 1000f,
            Biome = Biome.Swamp,
            MaxTilt = 20f,
            MaxTerrainDelta = 3f,
            GroupSizeMin = 1,
            GroupSizeMax = 2
        };

        public static VegetationConfig MountainBushValues = new VegetationConfig
        {
            Min = 2.1f,
            Max = 2.7f,
            ScaleMin = 1.1f,
            ScaleMax = 1.85f,
            MinAltitude = 1f,
            MaxAltitude = 1000f,
            Biome = Biome.Mountain | Biome.DeepNorth,
            MaxTilt = 30f,
            MaxTerrainDelta = 3f,
            GroupSizeMin = 1,
            GroupSizeMax = 2
        };

        public static VegetationConfig PlainsBushValues = new VegetationConfig
        {
            Min = 0.7f,
            Max = 1.1f,
            ScaleMin = 3.1f,
            ScaleMax = 3.85f,
            MinAltitude = 1f,
            MaxAltitude = 1000f,
            Biome = Biome.Plains,
            MaxTilt = 18f,
            MaxTerrainDelta = 3f,
            GroupSizeMin = 1,
            GroupSizeMax = 2
        };

        public static VegetationConfig MistlandsShroomValues = new VegetationConfig
        {
            Min = 0.4f,
            Max = 0.7f,
            ScaleMin = 1.1f,
            ScaleMax = 1.85f,
            MinAltitude = 1f,
            MaxAltitude = 1000f,
            Biome = Biome.Mistlands,
            MaxTilt = 15f,
            MaxTerrainDelta = 1.5f,
            GroundOffset = -0.2f,
            GroupSizeMin = 1,
            GroupSizeMax = 2
        };

        public static VegetationConfig MistlandsBushValues = new VegetationConfig
        {
            Min = 0.8f,
            Max = 1.2f,
            ScaleMin = 1.1f,
            ScaleMax = 1.85f,
            MinAltitude = 1f,
            MaxAltitude = 1000f,
            Biome = Biome.Mistlands,
            MaxTilt = 30f,
            MaxTerrainDelta = 2f,
            GroupSizeMin = 1,
            GroupSizeMax = 2
        };

        public static VegetationConfig AshLandsBushValues = new VegetationConfig
        {
            Min = 0.3f,
            Max = 3f,
            ScaleMin = 1.1f,
            ScaleMax = 1.25f,
            MinAltitude = 1.0f,
            MaxAltitude = 1000f,
            Biome = Biome.AshLands,
            MaxTilt = 50f,
            MaxTerrainDelta = 3f,
            GroupSizeMin = 1,
            GroupSizeMax = 2
        };

        public static VegetationConfig DeepNorthBushValues = new VegetationConfig
        {
            Min = 1.5f,
            Max = 3f,
            ScaleMin = 1.3f,
            ScaleMax = 1.85f,
            MinAltitude = 1f,
            MaxAltitude = 1000f,
            Biome = Biome.DeepNorth,
            MaxTilt = 30f,
            MaxTerrainDelta = 3f,
            GroupSizeMin = 1,
            GroupSizeMax = 2
        };

        // Tree Values

        public static VegetationConfig MeadowsTreeValues = new VegetationConfig
        {
            Min = 2.4f,
            Max = 3.6f,
            ScaleMin = 1.1f,
            ScaleMax = 1.35f,
            MinAltitude = 1f,
            MaxAltitude = 1000f,
            Biome = Biome.Meadows,
            MaxTilt = 20f,
            MaxTerrainDelta = 3f,
            GroupSizeMin = 1,
            GroupSizeMax = 2
        };

        public static VegetationConfig BlackForestTreeValues = new VegetationConfig
        {
            Min = 4.5f,
            Max = 6f,
            ScaleMin = 1.1f,
            ScaleMax = 1.25f,
            MinAltitude = 1f,
            MaxAltitude = 1000f,
            Biome = Biome.BlackForest | Biome.Mountain,
            MaxTilt = 25f,
            MaxTerrainDelta = 3f,
            GroupSizeMin = 1,
            GroupSizeMax = 2
        };

        public static VegetationConfig SwampTreeValues = new VegetationConfig
        {
            Min = 6.8f,
            Max = 9.2f,
            ScaleMin = 1.1f,
            ScaleMax = 1.25f,
            MinAltitude = 1f,
            MaxAltitude = 1000f,
            Biome = Biome.Swamp,
            MaxTilt = 40f,
            MaxTerrainDelta = 3f,
            GroupSizeMin = 1,
            GroupSizeMax = 2
        };

        public static VegetationConfig MountainTreeValues = new VegetationConfig
        {
            Min = 1f,
            Max = 5f,
            ScaleMin = 1.1f,
            ScaleMax = 1.25f,
            MinAltitude = 1f,
            Biome = Biome.Mountain,
            MaxTilt = 30f,
            MaxTerrainDelta = 3f,
            GroupSizeMin = 1,
            GroupSizeMax = 2
        };

        public static VegetationConfig PlainsTreeValues = new VegetationConfig
        {
            Min = 0.1f,
            Max = 0.35f,
            ScaleMin = 3.875f,
            ScaleMax = 4.7f,
            MinAltitude = 1f,
            MaxAltitude = 1000f,
            Biome = Biome.Plains,
            MaxTilt = 23f,
            MaxTerrainDelta = 3f,
            GroupSizeMin = 1,
            GroupSizeMax = 2
        };

        public static VegetationConfig PlainsPalmValues = new VegetationConfig
        {
            Min = 1.2f,
            Max = 2.2f,
            ScaleMin = 2.475f,
            ScaleMax = 3.7f,
            MinAltitude = 0.3f,
            MaxAltitude = 5f,
            Biome = Biome.Plains,
            MaxTilt = 23f,
            MaxTerrainDelta = 3f,
            GroupSizeMin = 3,
            GroupSizeMax = 6,
            GroupRadius = 12f
        };

        public static VegetationConfig MistlandsTreeValues = new VegetationConfig
        {
            Min = 0.1f,
            Max = 1f,
            ScaleMin = 1.1f,
            ScaleMax = 1.25f,
            MinAltitude = 1f,
            MaxAltitude = 1000f,
            Biome = Biome.Mistlands,
            MaxTilt = 30f,
            MaxTerrainDelta = 2f,
            GroupSizeMin = 1,
            GroupSizeMax = 2
        };

        public static VegetationConfig MistlandsBlossomValues = new VegetationConfig
        {
            Min = 0.15f,
            Max = 0.35f,
            ScaleMin = 1.1f,
            ScaleMax = 1.25f,
            MinAltitude = 1f,
            MaxAltitude = 1000f,
            Biome = Biome.Mistlands,
            MaxTilt = 25f,
            MaxTerrainDelta = 2f,
            GroupSizeMin = 1,
            GroupSizeMax = 1
        };

        public static VegetationConfig AshLandsTreeValues = new VegetationConfig
        {
            Min = 0.3f,
            Max = 3f,
            ScaleMin = 1.1f,
            ScaleMax = 1.25f,
            MinAltitude = -0.5f,
            MaxAltitude = 10.1f,
            Biome = Biome.AshLands,
            MaxTilt = 30f,
            MaxTerrainDelta = 3f,
            GroupSizeMin = 1,
            GroupSizeMax = 2
        };

        public static VegetationConfig DeepNorthTreeValues = new VegetationConfig
        {
            Min = 0.3f,
            Max = 3f,
            ScaleMin = 1.65f,
            ScaleMax = 2.65f,
            MinAltitude = 1f,
            MaxAltitude = 1000f,
            Biome = Biome.DeepNorth,
            MaxTilt = 38f,
            MaxTerrainDelta = 3f,
            GroupSizeMax = 1
        };

        public static VegetationConfig PlainsRockValues = new VegetationConfig
        {
            Min = 0.9f,
            Max = 1.1f,
            ScaleMin = 0.9f,
            ScaleMax = 1.1f,
            MinAltitude = 1f,
            Biome = Biome.Plains,
            MaxTilt = 15f,
            MaxTerrainDelta = 3f,
            GroupSizeMin = 1,
            GroupSizeMax = 2
        };

        private void AdjustVanillaVegetation()
        {
            try
            {
                var BeechTree1 = ZoneManager.Instance.GetZoneVegetation("Beech1");
                BeechTree1.m_min = 18;
                BeechTree1.m_max = 22;

                var BirchTree1 = ZoneManager.Instance.GetZoneVegetation("Birch1");
                BirchTree1.m_min = 7;
                BirchTree1.m_max = 8;

                var BeechTree2 = ZoneManager.Instance.GetZoneVegetation("Beech_small1");
                BeechTree2.m_groupSizeMin = 1;
                BeechTree2.m_groupSizeMax = 3;
                BeechTree2.m_min = 1;
                BeechTree2.m_max = 2;

                var BeechTree3 = ZoneManager.Instance.GetZoneVegetation("Beech_small2");
                BeechTree3.m_groupSizeMin = 1;
                BeechTree3.m_groupSizeMax = 4;
                BeechTree3.m_min = 1;
                BeechTree3.m_max = 2;

                var PineTree1 = ZoneManager.Instance.GetZoneVegetation("Pinetree_01");
                PineTree1.m_min = 34;
                PineTree1.m_max = 36;
                PineTree1.m_biome = Heightmap.Biome.BlackForest;

                var DeadTree1 = ZoneManager.Instance.GetZoneVegetation("SwampTree2");
                DeadTree1.m_groupSizeMin = 0;
                DeadTree1.m_groupSizeMax = 0;
                DeadTree1.m_min = 0;
                DeadTree1.m_max = 0;

                var DeadTree2 = ZoneManager.Instance.GetZoneLocation("InfestedTree01");
                DeadTree2.m_enable = false;

                var DeadTree3 = ZoneManager.Instance.GetZoneVegetation("SwampTree1");
                DeadTree3.m_min = 24;
                DeadTree3.m_max = 26;

                var DeadTree4 = ZoneManager.Instance.GetZoneVegetation("SwampTree2_log");
                DeadTree4.m_enable = false;

                var PineTree2 = ZoneManager.Instance.GetZoneVegetation("FirTree");
                PineTree2.m_min = 1;
                PineTree2.m_max = 1;
                PineTree2.m_biome = Heightmap.Biome.BlackForest | Biome.Mountain;

                var rockBush1 = ZoneManager.Instance.GetZoneVegetation("rock3_mountain");
                rockBush1.m_max = 2;
                rockBush1.m_biome = Heightmap.Biome.Mountain;

                var rockBush2 = ZoneManager.Instance.GetZoneVegetation("rock1_mountain");
                rockBush2.m_min = 5;
                rockBush2.m_max = 8;
                rockBush2.m_biome = Heightmap.Biome.Mountain;

                var rockBush3 = ZoneManager.Instance.GetZoneVegetation("rock2_mountain");
                rockBush3.m_min = 5;
                rockBush3.m_max = 8;
                rockBush3.m_biome = Heightmap.Biome.Mountain;

                var blackForestBush1 = ZoneManager.Instance.GetZoneVegetation("shrub_2");
                blackForestBush1.m_min = 70;
                blackForestBush1.m_max = 80;
                blackForestBush1.m_biome = Heightmap.Biome.BlackForest;

                var PlainsBush1 = ZoneManager.Instance.GetZoneVegetation("Bush01_heath");
                PlainsBush1.m_min = 2;
                PlainsBush1.m_max = 4;
                PlainsBush1.m_biome = Heightmap.Biome.Plains;

                var PlainsBush2 = ZoneManager.Instance.GetZoneVegetation("shrub_2");
                PlainsBush2.m_min = 40;
                PlainsBush2.m_max = 45;
                PlainsBush2.m_biome = Heightmap.Biome.BlackForest;

                var MistlandsTree1 = ZoneManager.Instance.GetZoneVegetation("YggaShoot1");
                MistlandsTree1.m_max = 2;
                MistlandsTree1.m_biome = Heightmap.Biome.Mistlands;

                var MistlandsTree2 = ZoneManager.Instance.GetZoneVegetation("YggaShoot2");
                MistlandsTree2.m_max = 2;
                MistlandsTree2.m_biome = Heightmap.Biome.Mistlands;

                var MistlandsTree3 = ZoneManager.Instance.GetZoneVegetation("YggaShoot3");
                MistlandsTree3.m_max = 2;
                MistlandsTree3.m_biome = Heightmap.Biome.Mistlands;

                var AshLandsObject1 = ZoneManager.Instance.GetZoneVegetation("cliff_ashlands3_Arch_1");
                AshLandsObject1.m_max = 2;
                AshLandsObject1.m_biome = Heightmap.Biome.AshLands;

                var AshLandsObject2 = ZoneManager.Instance.GetZoneVegetation("cliff_ashlands5");
                AshLandsObject2.m_max = 3;
                AshLandsObject2.m_biome = Heightmap.Biome.AshLands;

                var AshLandsObject3 = ZoneManager.Instance.GetZoneVegetation("cliff_ashlands6");
                AshLandsObject3.m_max = 3;
                AshLandsObject3.m_biome = Heightmap.Biome.AshLands;

                var AshLandsObject4 = ZoneManager.Instance.GetZoneVegetation("cliff_ashlands4");
                AshLandsObject4.m_max = 1;
                AshLandsObject4.m_biome = Heightmap.Biome.AshLands;

                var AshLandsObject5 = ZoneManager.Instance.GetZoneVegetation("AshlandsTree1");
                AshLandsObject5.m_max = 6;
                AshLandsObject5.m_biome = Heightmap.Biome.AshLands;

                var AshLandsObject6 = ZoneManager.Instance.GetZoneVegetation("AshlandsTree3");
                AshLandsObject6.m_max = 6;
                AshLandsObject6.m_biome = Heightmap.Biome.AshLands;

                var AshLandsObject7 = ZoneManager.Instance.GetZoneVegetation("AshlandsTree6");
                AshLandsObject7.m_max = 2;
                AshLandsObject7.m_biome = Heightmap.Biome.AshLands;

                var AshLandsObject8 = ZoneManager.Instance.GetZoneVegetation("Ashlands_rock2");
                AshLandsObject8.m_max = 1;
                AshLandsObject8.m_biome = Heightmap.Biome.AshLands;

                var AshLandsObject9 = ZoneManager.Instance.GetZoneVegetation("cliff_ashlands6");
                AshLandsObject9.m_max = 100;
                AshLandsObject9.m_biome = Heightmap.Biome.AshLands;

                var AshLandsObject10 = ZoneManager.Instance.GetZoneVegetation("AshlandsBranch1");
                AshLandsObject10.m_max = 3;
                AshLandsObject10.m_biome = Heightmap.Biome.AshLands;

                var AshLandsObject11 = ZoneManager.Instance.GetZoneVegetation("AshlandsBranch2");
                AshLandsObject11.m_max = 2;
                AshLandsObject11.m_biome = Heightmap.Biome.AshLands;

                var AshLandsObject12 = ZoneManager.Instance.GetZoneVegetation("AshlandsBranch3");
                AshLandsObject12.m_max = 2;
                AshLandsObject12.m_biome = Heightmap.Biome.AshLands;

                var AshLandsObject13 = ZoneManager.Instance.GetZoneVegetation("AshlandsBush1");
                AshLandsObject13.m_max = 6;
                AshLandsObject13.m_biome = Heightmap.Biome.AshLands;

                var AshLandsObject14 = ZoneManager.Instance.GetZoneVegetation("Pickable_Charredskull");
                AshLandsObject14.m_max = 25;
                AshLandsObject14.m_biome = Heightmap.Biome.AshLands;

                var AshLandsObject15 = ZoneManager.Instance.GetZoneVegetation("Pickable_Pot_Shard");
                AshLandsObject15.m_max = 4;
                AshLandsObject15.m_biome = Heightmap.Biome.AshLands;

                var AshLandsObject16 = ZoneManager.Instance.GetZoneVegetation("Pickable_Ashstone");
                AshLandsObject16.m_max = 9;
                AshLandsObject16.m_biome = Heightmap.Biome.AshLands;

                var AshLandsObject17 = ZoneManager.Instance.GetZoneVegetation("GraveStone_Broken_World");
                AshLandsObject17.m_max = 4;
                AshLandsObject17.m_biome = Heightmap.Biome.AshLands;

                var AshLandsObject18 = ZoneManager.Instance.GetZoneVegetation("Ashlands_ArchRoofDamaged");
                AshLandsObject18.m_max = 3;
                AshLandsObject18.m_biome = Heightmap.Biome.AshLands;

                var AshLandsObject19 = ZoneManager.Instance.GetZoneVegetation("Ashlands_Pillar4");
                AshLandsObject19.m_max = 3;
                AshLandsObject19.m_biome = Heightmap.Biome.AshLands;

                var AshLandsObject20 = ZoneManager.Instance.GetZoneVegetation("Ashlands_Ruins_Wall_Windows_Broken_4x6");
                AshLandsObject20.m_max = 3;
                AshLandsObject20.m_biome = Heightmap.Biome.AshLands;

                var DeepNorthObject1 = ZoneManager.Instance.GetZoneVegetation("Rock_4_deepnorth");
                DeepNorthObject1.m_max = 4;
                DeepNorthObject1.m_biome = Heightmap.Biome.DeepNorth;

                var DeepNorthObject2 = ZoneManager.Instance.GetZoneVegetation("Rock_3_deepnorth");
                DeepNorthObject2.m_max = 3;
                DeepNorthObject2.m_biome = Heightmap.Biome.DeepNorth;

                var DeepNorthObject3 = ZoneManager.Instance.GetZoneVegetation("SnowFirTree");
                DeepNorthObject3.m_max = 5;
                DeepNorthObject3.m_biome = Heightmap.Biome.DeepNorth;

                var DeepNorthObject4 = ZoneManager.Instance.GetZoneVegetation("SnowFirTree 2");
                DeepNorthObject4.m_max = 20;
                DeepNorthObject4.m_biome = Heightmap.Biome.DeepNorth;

                var DeepNorthObject5 = ZoneManager.Instance.GetZoneVegetation("Pinetree_Snow");
                DeepNorthObject5.m_max = 15;
                DeepNorthObject5.m_biome = Heightmap.Biome.DeepNorth;

                var DeepNorthObject6 = ZoneManager.Instance.GetZoneVegetation("Pinetree_Snow_dead");
                DeepNorthObject6.m_max = 24;
                DeepNorthObject6.m_biome = Heightmap.Biome.DeepNorth;

                var DeepNorthObject7 = ZoneManager.Instance.GetZoneVegetation("Pinetree_Snow");
                DeepNorthObject7.m_max = 15;
                DeepNorthObject7.m_biome = Heightmap.Biome.DeepNorth;

                var DeepNorthObject8 = ZoneManager.Instance.GetZoneVegetation("SnowFirTree_small");
                DeepNorthObject8.m_max = 25;
                DeepNorthObject8.m_biome = Heightmap.Biome.DeepNorth;

                var DeepNorthObject9 = ZoneManager.Instance.GetZoneVegetation("SnowFirTree_small");
                DeepNorthObject9.m_max = 12;
                DeepNorthObject9.m_biome = Heightmap.Biome.DeepNorth;

                var DeepNorthObject10 = ZoneManager.Instance.GetZoneVegetation("stubbe_deepnorth");
                DeepNorthObject10.m_max = 2;
                DeepNorthObject10.m_biome = Heightmap.Biome.DeepNorth;

                var DeepNorthObject11 = ZoneManager.Instance.GetZoneVegetation("FirTree_oldLog_deepnorth");
                DeepNorthObject11.m_max = 2;
                DeepNorthObject11.m_biome = Heightmap.Biome.DeepNorth;

                var DeepNorthObject12 = ZoneManager.Instance.GetZoneVegetation("Pickable_Branch_Snow");
                DeepNorthObject12.m_max = 12;
                DeepNorthObject12.m_biome = Heightmap.Biome.DeepNorth;

                var DeepNorthObject13 = ZoneManager.Instance.GetZoneVegetation("Pickable_Snowball");
                DeepNorthObject13.m_max = 4;
                DeepNorthObject13.m_biome = Heightmap.Biome.DeepNorth;

                var DeepNorthObject14 = ZoneManager.Instance.GetZoneVegetation("rock4_coast");
                DeepNorthObject14.m_max = 5;
                DeepNorthObject14.m_biome = Heightmap.Biome.DeepNorth;
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding configuration values: {arg}");
            }
        }

        private void AdjustVanillaLocation()
        {
            try
            {
                var TormentMonument = ZoneManager.Instance.GetZoneLocation("CharredStone_Spawner");
                TormentMonument.m_enable = false;

                var FortressRuins = ZoneManager.Instance.GetZoneLocation("FortressRuins");
                FortressRuins.m_enable = true;
                FortressRuins.m_quantity = 70;

                var CharredRuins = ZoneManager.Instance.GetZoneLocation("CharredRuins1");
                CharredRuins.m_enable = true;
                CharredRuins.m_quantity = 50;

                var RunestoneAshlands = ZoneManager.Instance.GetZoneLocation("Runestone_Ashlands");
                RunestoneAshlands.m_enable = true;
                RunestoneAshlands.m_quantity = 50;

                var LeviathanLava = ZoneManager.Instance.GetZoneLocation("LeviathanLava");
                LeviathanLava.m_enable = true;
                LeviathanLava.m_quantity = 72;

                var SulfurArch = ZoneManager.Instance.GetZoneLocation("SulfurArch");
                SulfurArch.m_enable = true;
                SulfurArch.m_quantity = 70;

                var VoltureNest = ZoneManager.Instance.GetZoneLocation("VoltureNest");
                VoltureNest.m_enable = true;
                VoltureNest.m_quantity = 190;

                var AshlandRuins = ZoneManager.Instance.GetZoneLocation("AshlandRuins");
                AshlandRuins.m_enable = true;
                AshlandRuins.m_quantity = 65;

                var CharredRuins2 = ZoneManager.Instance.GetZoneLocation("CharredRuins2");
                CharredRuins2.m_enable = true;
                CharredRuins2.m_quantity = 65;

                var CharredRuins3 = ZoneManager.Instance.GetZoneLocation("CharredRuins3");
                CharredRuins3.m_enable = true;
                CharredRuins3.m_quantity = 65;

                var CharredRuins4 = ZoneManager.Instance.GetZoneLocation("CharredRuins4");
                CharredRuins4.m_enable = true;
                CharredRuins4.m_quantity = 65;
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding configuration values: {arg}");
            }
        }

        public void AddPrefabs()
        {
            try
            {
                foreach (string prefabName1 in PrefabList)
                {
                    GameObject prefab1 = MyAssets.LoadAsset<GameObject>(prefabName1);
                    if (prefab1 != null)
                    {
                        CustomPrefab customPrefab1 = new CustomPrefab(prefab1, true);
                        PrefabManager.Instance.AddPrefab(customPrefab1);

                        if (LoggingEnable.Value) { Logger.LogMessage("Added: " + prefabName1 + " to the Object database"); }
                    }
                    else
                    {
                        Logger.LogMessage("Failed to add: " + prefabName1 + " to the object database");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogWarning($"Exception caught while adding prefabs: {ex}");
            }
        }

        private void AddVegetationList(string[] prefabList, VegetationConfig values)
        {
            try
            {
                foreach (string prefabName in prefabList)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        ZoneManager.Instance.AddCustomVegetation(new CustomVegetation(prefab, true, values));
                        if (LoggingEnable.Value) { Logger.LogMessage("Added Vegetation: " + prefabName); }
                    }
                    else
                    {
                        Logger.LogMessage("Failed to add: " + prefabName + " to the object database");
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding vegetation: {arg}");
            }
        }

        private void StaticVegetationList() => AddVegetationList(StaticNoneList, StaticNoneValues);

        private void MeadowsBushConfig() => AddVegetationList(MeadowsBushList, MeadowsBushValues);

        private void BlackForestBushConfig() => AddVegetationList(BlackForestBushList, BlackForestBushValues);

        private void SwampBushConfig() => AddVegetationList(SwampBushList, SwampBushValues);

        private void MountainBushConfig() => AddVegetationList(MountainBushList, MountainBushValues);

        private void PlainsBushConfig() => AddVegetationList(PlainsBushList, PlainsBushValues);

        private void MistlandsBushConfig() => AddVegetationList(MistlandsBushList, MistlandsBushValues);

        private void MistlandsShroomConfig() => AddVegetationList(MistlandsShroomList, MistlandsShroomValues);

        private void AshLandsBushConfig() => AddVegetationList(AshLandsBushList, AshLandsBushValues);

        private void DeepNorthBushConfig() => AddVegetationList(DeepNorthBushList, DeepNorthBushValues);

        private void MeadowsTreeConfig() => AddVegetationList(MeadowsTreeList, MeadowsTreeValues);

        private void BlackForestTreeConfig() => AddVegetationList(BlackForestTreeList, BlackForestTreeValues);

        private void SwampTreeConfig() => AddVegetationList(SwampTreeList, SwampTreeValues);

        private void MountainTreeConfig() => AddVegetationList(MountainTreeList, MountainTreeValues);

        private void PlainsTreeConfig() => AddVegetationList(PlainsTreeList, PlainsTreeValues);

        private void PlainsPalmConfig() => AddVegetationList(PlainsPalmList, PlainsPalmValues);

        private void MistlandsTreeConfig() => AddVegetationList(MistlandsTreeList, MistlandsTreeValues);

        private void MistlandsBlossomConfig() => AddVegetationList(MistlandsBlossomList, MistlandsBlossomValues);

        private void AshLandsTreeConfig() => AddVegetationList(AshLandsTreeList, AshLandsTreeValues);

        private void DeepNorthTreeConfig() => AddVegetationList(DeepNorthTreeList, DeepNorthTreeValues);

        private void PlainsRockConfig() => AddVegetationList(PlainsRockList, PlainsRockValues);

        private void VariableTreeList()
        {
            try
            {
                // Swamp Log
                GameObject Log1 = MyAssets.LoadAsset<GameObject>("SwampTree2_log_RtD");
                CustomVegetation CustomLog1 = new(Log1, true, new VegetationConfig
                {
                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.BlackForest, Heightmap.Biome.Swamp),
                    Min = 0,
                    Max = 3,
                    ScaleMin = 1.9f,
                    ScaleMax = 3.0f,
                    MinAltitude = -0.5f,
                    MaxAltitude = 1000f,
                    MaxTilt = 15f,
                    MinTerrainDelta = 1,
                    MaxTerrainDelta = 3,
                });
                ZoneManager.Instance.AddCustomVegetation(CustomLog1);

                GameObject Log2 = MyAssets.LoadAsset<GameObject>("MagicTree2_RtD");
                CustomVegetation CustomLog2 = new(Log2, true, new VegetationConfig
                {
                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.Meadows, Heightmap.Biome.BlackForest, Heightmap.Biome.Swamp),
                    Min = 0,
                    Max = 3,
                    ScaleMin = 1.9f,
                    ScaleMax = 3.0f,
                    MinAltitude = -0.5f,
                    MaxAltitude = 1000f,
                    MaxTilt = 30f,
                    MinTerrainDelta = 1,
                    MaxTerrainDelta = 3,
                });
                ZoneManager.Instance.AddCustomVegetation(CustomLog2);

                GameObject Log3 = MyAssets.LoadAsset<GameObject>("WillowTree1_RtD");
                CustomVegetation CustomLog3 = new(Log3, true, new VegetationConfig
                {
                    Biome = ZoneManager.AnyBiomeOf( Heightmap.Biome.Meadows, Heightmap.Biome.Swamp),
                    Min = 0,
                    Max = 3,
                    ScaleMin = 1.7f,
                    ScaleMax = 2.3f,
                    MinAltitude = -0.5f,
                    MaxAltitude = 75f,
                    MaxTilt = 20f,
                    MinTerrainDelta = 1,
                    MaxTerrainDelta = 3,
                });
                ZoneManager.Instance.AddCustomVegetation(CustomLog3);

                GameObject Log4 = MyAssets.LoadAsset<GameObject>("WillowTree2_RtD");
                CustomVegetation CustomLog4 = new(Log4, true, new VegetationConfig
                {
                    Biome = ZoneManager.AnyBiomeOf( Heightmap.Biome.Meadows, Heightmap.Biome.Swamp),
                    Min = 0,
                    Max = 3,
                    ScaleMin = 1.9f,
                    ScaleMax = 3.8f,
                    MinAltitude = -0.5f,
                    MaxAltitude = 75f,
                    MaxTilt = 15f,
                    MinTerrainDelta = 1,
                    MaxTerrainDelta = 3,
                });
                ZoneManager.Instance.AddCustomVegetation(CustomLog4);

                GameObject Log5 = MyAssets.LoadAsset<GameObject>("CottonWood1_RtD");
                CustomVegetation CustomLog5 = new(Log5, true, new VegetationConfig
                {
                    Biome = ZoneManager.AnyBiomeOf( Heightmap.Biome.Meadows, Heightmap.Biome.Swamp),
                    Min = 0,
                    Max = 3,
                    ScaleMin = 1.3f,
                    ScaleMax = 1.9f,
                    MinAltitude = -0.5f,
                    MaxAltitude = 500f,
                    MaxTilt = 35f,
                    MinTerrainDelta = 1,
                    MaxTerrainDelta = 3,
                });
                ZoneManager.Instance.AddCustomVegetation(CustomLog5);

                GameObject Log6 = MyAssets.LoadAsset<GameObject>("CottonWood2_RtD");
                CustomVegetation CustomLog6 = new(Log6, true, new VegetationConfig
                {
                    Biome = ZoneManager.AnyBiomeOf( Heightmap.Biome.Meadows, Heightmap.Biome.Swamp),
                    Min = 0,
                    Max = 3,
                    ScaleMin = 1.5f,
                    ScaleMax = 2.4f,
                    MinAltitude = -0.5f,
                    MaxAltitude = 500f,
                    MaxTilt = 25f,
                    MinTerrainDelta = 1,
                    MaxTerrainDelta = 3,
                });
                ZoneManager.Instance.AddCustomVegetation(CustomLog6);
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding vegetation: {arg}");
            }
        }

        private void AddItems()
        {
            try
            {
                foreach (string prefabName in ItemList)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        GameObject dupeCheck = PrefabManager.Cache.GetPrefab<GameObject>(prefabName);
                        if (dupeCheck == null)
                        {
                            CustomItem customPrefab = new CustomItem(prefab, true);
                            ItemManager.Instance.AddItem(customPrefab);
                            if (LoggingEnable.Value) { Logger.LogMessage("Added: " + prefabName + " to the Object database"); }
                        }
                    }
                    else
                    {
                        Logger.LogMessage("Failed to add: " + prefabName + " to the object database");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogWarning($"Exception caught while adding prefabs: {ex}");
            }
        }
    }
}