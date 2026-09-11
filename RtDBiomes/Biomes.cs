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
    [BepInIncompatibility("blacks7ar.SeedBed")]
    [BepInIncompatibility("randyknapp.mods.epicloot")]
    [BepInIncompatibility("org.bepinex.plugins.valheim_plus")]
    
    internal partial class RtDBiomes : BaseUnityPlugin
    {
        public const string PluginGUID = "soloredis.rtdbiomes";

        public const string PluginName = "RtDBiomes";

        public const string PluginVersion = "3.1.34";

        private AssetBundle MyAssets;

        private ConfigEntry<bool> LoggingEnable;

        private void Awake()
        {
            LoadBundle();
            CreateConfigs();
            Localizations();
            JSONSupport();
            AddItems();
            AddPrefabs();
            MeadowsClutterConfig();
            BlackForestClutterConfig();
            SwampClutterConfig();
            PlainsClutterConfig();
            MistlandsClutterConfig();
            AshLandsClutterConfig();
            DeepNorthClutterConfig();
            MeadowsBushConfig();
            BlackForestBushConfig();
            SwampBushConfig();
            MountainBushConfig();
            PlainsBushConfig();
            MistlandsBushConfig();
            AshLandsBushConfig();
            DeepNorthBushConfig();
            MeadowsTreeConfig();
            BlackForestTreeConfig();
            SwampTreeConfig();
            PlainsTreeConfig();
            MistlandsTreeConfig();
            AshLandsTreeConfig();
            DeepNorthTreeConfig();
            VariableTreeList();
            PlainsRockConfig();
            StaticVegetationList();
            AddSaplings();
            CreateRecipes();
            
            // Clutter
            ZoneManager.OnVanillaClutterAvailable += AdjustVanillaClutter;

            // Vegetation
            ZoneManager.OnVanillaLocationsAvailable += AdjustVanillaVegetation;

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

        public string[] MeadowsClutterList = new string[]
        {
          "Meadows1_RtD",
          "Meadows2_RtD"
        };

        public string[] BlackForestClutterList = new string[]
        {
          "BlackForest1_RtD",
          "BlackForest2_RtD",
          "BlackForest3_RtD"
        };

        public string[] SwampClutterList = new string[]
        {
          "Swamps1_RtD",
          "Swamps2_RtD",
          "SwampPlant_RtD"
        };

        public string[] PlainsClutterList = new string[]
        {
          "Daisy_RtD",
        };

        public string[] MistlandsClutterList = new string[]
        {
          "Mistlands1_RtD",
          "Mistlands2_RtD",
          "Mistlands3_RtD"
        };

        public string[] AshLandsClutterList = new string[]
        {
          "DesertGrass1_RtD",
          "DesertGrass2_RtD"
        };

        public string[] DeepNorthClutterList = new string[]
        {
          "NorthGrass1_RtD",
          "NorthGrass2_RtD"
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

        public string[] MistlandsBushList = new string[]
        {
          "BlueShroom1_RtD",
          "BlueShroom2_RtD",
          "BlueShroom3_RtD",
          "BlueShroom4_RtD",
          "YellowShroom1_RtD",
          "YellowShroom2_RtD",
          "YellowShroom3_RtD",
          "YellowShroom4_RtD",
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
          "Acacia4_RtD",
          "PalmTree1_RtD",
          "PalmTree2_RtD"
        };

        public string[] MistlandsTreeList = new string[]
        {
          "MagicTree1_RtD",
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
            Biome = Biome.None,
            MaxTilt = 30f,
            MaxTerrainDelta = 3f,
            GroupSizeMin = 1,
            GroupSizeMax = 2,
            InForest = true,
            ForestThresholdMin = 1.1f,
            ForestThresholdMax = 1.15f
        };


        // Clutter Values

        public static ClutterConfig MeadowsClutterValues = new ClutterConfig
        {
            Amount = 2,
            ScaleMin = 1.1f,
            ScaleMax = 1.25f,
            MinAltitude = 1f,
            MaxAltitude = 500f,
            Biome = Biome.Meadows,
            MaxOceanDepth = 500,
            MaxTilt = 20f,
            TerrainTilt = true,
            OnUncleared = true,
            OnCleared = false,
            Instanced = true,
            Enabled = true
        };

        public static ClutterConfig BlackForestClutterValues = new ClutterConfig
        {
            Amount = 2,
            ScaleMin = 1.1f,
            ScaleMax = 1.25f,
            MinAltitude = 1f,
            MaxAltitude = 500f,
            Biome = Biome.BlackForest,
            MaxOceanDepth = 500,
            MaxTilt = 20f,
            TerrainTilt = true,
            OnUncleared = true,
            OnCleared = false,
            Instanced = true,
            Enabled = true
        };

        public static ClutterConfig SwampClutterValues = new ClutterConfig
        {
            Amount = 2,
            ScaleMin = 1.1f,
            ScaleMax = 1.25f,
            MinAltitude = 0f,
            MaxAltitude = 500f,
            Biome = Biome.Swamp,
            MaxOceanDepth = 500,
            MaxTilt = 20f,
            TerrainTilt = true,
            OnUncleared = true,
            OnCleared = false,
            Instanced = true,
            Enabled = true
        };

/*        public static ClutterConfig MountainClutterValues = new ClutterConfig
        {
            Amount = 8,
            ScaleMin = 1.1f,
            ScaleMax = 1.25f,
            MinAltitude = 1f,
            MaxAltitude = 1f,
            Biome = Biome.Mountain,
            MaxTilt = 30f,
            TerrainTilt = true,
        };*/

        public static ClutterConfig PlainsClutterValues = new ClutterConfig
        {
            Amount = 2,
            ScaleMin = 1.1f,
            ScaleMax = 1.25f,
            MinAltitude = 1f,
            MaxAltitude = 500f,
            Biome = Biome.Plains,
            MaxOceanDepth = 500,
            MaxTilt = 25f,
            TerrainTilt = true,
            OnUncleared = true,
            OnCleared = false,
            Instanced = true,
            Enabled = true
        };

        public static ClutterConfig MistlandsClutterValues = new ClutterConfig
        {
            Amount = 2,
            ScaleMin = 1.1f,
            ScaleMax = 1.25f,
            MinAltitude = 1f,
            MaxAltitude = 500f,
            Biome = Biome.Mistlands,
            MaxOceanDepth = 500,
            MaxTilt = 35f,
            TerrainTilt = true,
            OnUncleared = true,
            OnCleared = false,
            Instanced = true,
            Enabled = true
        };

        public static ClutterConfig AshLandsClutterValues = new ClutterConfig
        {
            Amount = 2,
            ScaleMin = 1.1f,
            ScaleMax = 1.25f,
            MinAltitude = 1f,
            MaxAltitude = 500f,
            Biome = Biome.AshLands,
            MaxOceanDepth = 500,
            MaxTilt = 35f,
            TerrainTilt = true,
            OnUncleared = true,
            OnCleared = false,
            Instanced = true,
            Enabled = true
        };

        public static ClutterConfig DeepNorthClutterValues = new ClutterConfig
        {
            Amount = 2,
            ScaleMin = 1.1f,
            ScaleMax = 1.25f,
            MinAltitude = 1f,
            MaxAltitude = 500f,
            Biome = Biome.DeepNorth,
            MaxOceanDepth = 500,
            MaxTilt = 35f,
            TerrainTilt = true,
            OnUncleared = true,
            OnCleared = false,
            Instanced = true,
            Enabled = true
        };

        // Bush Values

        public static VegetationConfig MeadowsBushValues = new VegetationConfig
        {
            Min = 0.9f,
            Max = 1.5f,
            ScaleMin = 1.1f,
            ScaleMax = 1.85f,
            MinAltitude = 1f,
            Biome = Biome.Meadows,
            MaxTilt = 30f,
            MaxTerrainDelta = 3f,
            GroupSizeMin = 1,
            GroupSizeMax = 2
        };

        public static VegetationConfig BlackForestBushValues = new VegetationConfig
        {
            Min = 0.5f,
            Max = 0.9f,
            ScaleMin = 1.1f,
            ScaleMax = 1.85f,
            MinAltitude = 1f,
            Biome = Biome.BlackForest,
            MaxTilt = 40f,
            MaxTerrainDelta = 3f,
            GroupSizeMin = 1,
            GroupSizeMax = 2
        };

        public static VegetationConfig SwampBushValues = new VegetationConfig
        {
            Min = 1.1f,
            Max = 1.5f,
            ScaleMin = 2.1f,
            ScaleMax = 2.8f,
            MinAltitude = 1f,
            Biome = Biome.Swamp,
            MaxTilt = 20f,
            MaxTerrainDelta = 3f,
            GroupSizeMin = 1,
            GroupSizeMax = 2
        };

        public static VegetationConfig MountainBushValues = new VegetationConfig
        {
            Min = 0.7f,
            Max = 0.9f,
            ScaleMin = 1.1f,
            ScaleMax = 1.85f,
            MinAltitude = 1f,
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
            ScaleMin = 1.1f,
            ScaleMax = 1.85f,
            MinAltitude = 1f,
            Biome = Biome.Plains,
            MaxTilt = 50f,
            MaxTerrainDelta = 3f,
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
            Biome = Biome.Mistlands,
            MaxTilt = 50f,
            MaxTerrainDelta = 3f,
            GroupSizeMin = 1,
            GroupSizeMax = 2
        };

        public static VegetationConfig AshLandsBushValues = new VegetationConfig
        {
            Min = 1.9f,
            Max = 2.1f,
            ScaleMin = 1.4f,
            ScaleMax = 1.85f,
            MinAltitude = 1f,
            Biome = Biome.AshLands,
            MaxTilt = 50f,
            MaxTerrainDelta = 3f,
            GroupSizeMin = 1,
            GroupSizeMax = 2
        };

        public static VegetationConfig DeepNorthBushValues = new VegetationConfig
        {
            Min = 0.5f,
            Max = 1.4f,
            ScaleMin = 1.3f,
            ScaleMax = 1.85f,
            MinAltitude = 1f,
            Biome = Biome.DeepNorth,
            MaxTilt = 30f,
            MaxTerrainDelta = 3f,
            GroupSizeMin = 1,
            GroupSizeMax = 2
        };

        // Tree Values

        public static VegetationConfig MeadowsTreeValues = new VegetationConfig
        {
            Min = 0.8f,
            Max = 1.2f,
            ScaleMin = 1.1f,
            ScaleMax = 1.35f,
            MinAltitude = 1f,
            Biome = Biome.Meadows,
            MaxTilt = 20f,
            MaxTerrainDelta = 3f,
            GroupSizeMin = 1,
            GroupSizeMax = 2
        };

        public static VegetationConfig BlackForestTreeValues = new VegetationConfig
        {
            Min = 2f,
            Max = 2f,
            ScaleMin = 1.1f,
            ScaleMax = 1.25f,
            MinAltitude = 1f,
            Biome = Biome.BlackForest | Biome.Mountain | Biome.DeepNorth,
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
            Min = 0.7f,
            Max = 1.2f,
            ScaleMin = 1.1f,
            ScaleMax = 1.25f,
            MinAltitude = 1f,
            Biome = Biome.Plains,
            MaxTilt = 23f,
            MaxTerrainDelta = 3f,
            GroupSizeMin = 1,
            GroupSizeMax = 2
        };

        public static VegetationConfig MistlandsTreeValues = new VegetationConfig
        {
            Min = 0.1f,
            Max = 1f,
            ScaleMin = 1.1f,
            ScaleMax = 1.25f,
            MinAltitude = 1f,
            Biome = Biome.Mistlands,
            MaxTilt = 75f,
            MaxTerrainDelta = 3f,
            GroupSizeMin = 1,
            GroupSizeMax = 2
        };

        public static VegetationConfig AshLandsTreeValues = new VegetationConfig
        {
            Min = 0.1f,
            Max = 1f,
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
            Min = 0.1f,
            Max = 1.0f,
            ScaleMin = 2.65f,
            ScaleMax = 4.25f,
            MinAltitude = 1f,
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

            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding configuration values: {arg}");
            }
            finally
            {
                ZoneManager.OnVanillaLocationsAvailable -= AdjustVanillaClutter;
            }
        }

        private void AdjustVanillaClutter()
        {
            try
            {
                var MeadowsGrass1 = ZoneManager.Instance.GetClutter("grass green");
                MeadowsGrass1.m_enabled = true;
                MeadowsGrass1.m_amount = 35;

                var MeadowsGrass2 = ZoneManager.Instance.GetClutter("grass green short");
                MeadowsGrass2.m_enabled = true;
                MeadowsGrass2.m_amount = 35;

                var BlackForestGrass1 = ZoneManager.Instance.GetClutter("forest groundcover short brown");
                BlackForestGrass1.m_enabled = true;
                BlackForestGrass1.m_amount = 35;

                var BlackForestGrass2 = ZoneManager.Instance.GetClutter("forest groundcover");
                BlackForestGrass2.m_enabled = true;
                BlackForestGrass2.m_amount = 35;

                var SwampsGrass1 = ZoneManager.Instance.GetClutter("swampgrass");
                SwampsGrass1.m_enabled = true;
                SwampsGrass1.m_amount = 35;

                var PlainsGrass1 = ZoneManager.Instance.GetClutter("heath grass");
                PlainsGrass1.m_enabled = true;
                PlainsGrass1.m_amount = 20;

                var PlainsGrass2 = ZoneManager.Instance.GetClutter("heath grass green");
                PlainsGrass2.m_enabled = true;
                PlainsGrass2.m_amount = 20;

            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding configuration values: {arg}");
            }
            finally
            {
                ZoneManager.OnVanillaClutterAvailable -= AdjustVanillaClutter;
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

        private void StaticVegetationList()
        {
            try
            {
                foreach (string prefabName in StaticNoneList)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        ZoneManager.Instance.AddCustomVegetation(new CustomVegetation(prefab, true, StaticNoneValues));
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

        private void MeadowsClutterConfig()
        {
            try
            {
                foreach (string prefabName in MeadowsClutterList)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        ZoneManager.Instance.AddCustomClutter(new CustomClutter(prefab, true, MeadowsClutterValues));
                        if (LoggingEnable.Value) { Logger.LogMessage("Added Clutter: " + prefabName); }
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

        private void BlackForestClutterConfig()
        {
            try
            {
                foreach (string prefabName in BlackForestClutterList)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        ZoneManager.Instance.AddCustomClutter(new CustomClutter(prefab, true, BlackForestClutterValues));
                        if (LoggingEnable.Value) { Logger.LogMessage("Added Clutter: " + prefabName); }
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

        private void SwampClutterConfig()
        {
            try
            {
                foreach (string prefabName in SwampClutterList)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        ZoneManager.Instance.AddCustomClutter(new CustomClutter(prefab, true, SwampClutterValues));
                        if (LoggingEnable.Value) { Logger.LogMessage("Added Clutter: " + prefabName); }
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

        private void PlainsClutterConfig()
        {
            try
            {
                foreach (string prefabName in PlainsClutterList)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        ZoneManager.Instance.AddCustomClutter(new CustomClutter(prefab, true, PlainsClutterValues));
                        if (LoggingEnable.Value) { Logger.LogMessage("Added Clutter: " + prefabName); }
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

        private void MistlandsClutterConfig()
        {
            try
            {
                foreach (string prefabName in MistlandsClutterList)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        ZoneManager.Instance.AddCustomClutter(new CustomClutter(prefab, true, MistlandsClutterValues));
                        if (LoggingEnable.Value) { Logger.LogMessage("Added Clutter: " + prefabName); }
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

        private void AshLandsClutterConfig()
        {
            try
            {
                foreach (string prefabName in AshLandsClutterList)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        ZoneManager.Instance.AddCustomClutter(new CustomClutter(prefab, true, AshLandsClutterValues));
                        if (LoggingEnable.Value) { Logger.LogMessage("Added Clutter: " + prefabName); }
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

        private void DeepNorthClutterConfig()
        {
            try
            {
                foreach (string prefabName in DeepNorthClutterList)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        ZoneManager.Instance.AddCustomClutter(new CustomClutter(prefab, true, DeepNorthClutterValues));
                        if (LoggingEnable.Value) { Logger.LogMessage("Added Clutter: " + prefabName); }
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

        private void MeadowsBushConfig()
        {
            try
            {
                foreach (string prefabName in MeadowsBushList)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        ZoneManager.Instance.AddCustomVegetation(new CustomVegetation(prefab, true, MeadowsBushValues));
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

        private void BlackForestBushConfig()
        {
            try
            {
                foreach (string prefabName in BlackForestBushList)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        ZoneManager.Instance.AddCustomVegetation(new CustomVegetation(prefab, true, BlackForestBushValues));
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

        private void SwampBushConfig()
        {
            try
            {
                foreach (string prefabName in SwampBushList)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        ZoneManager.Instance.AddCustomVegetation(new CustomVegetation(prefab, true, SwampBushValues));
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

        private void MountainBushConfig()
        {
            try
            {
                foreach (string prefabName in MountainBushList)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        ZoneManager.Instance.AddCustomVegetation(new CustomVegetation(prefab, true, MountainBushValues));
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

        private void PlainsBushConfig()
        {
            try
            {
                foreach (string prefabName in PlainsBushList)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        ZoneManager.Instance.AddCustomVegetation(new CustomVegetation(prefab, true, PlainsBushValues));
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

        private void MistlandsBushConfig()
        {
            try
            {
                foreach (string prefabName in MistlandsBushList)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        ZoneManager.Instance.AddCustomVegetation(new CustomVegetation(prefab, true, MistlandsBushValues));
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

        private void AshLandsBushConfig()
        {
            try
            {
                foreach (string prefabName in AshLandsBushList)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        ZoneManager.Instance.AddCustomVegetation(new CustomVegetation(prefab, true, AshLandsBushValues));
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

        private void DeepNorthBushConfig()
        {
            try
            {
                foreach (string prefabName in DeepNorthBushList)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        ZoneManager.Instance.AddCustomVegetation(new CustomVegetation(prefab, true, DeepNorthBushValues));
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

        private void MeadowsTreeConfig()
        {
            try
            {
                foreach (string prefabName in MeadowsTreeList)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        ZoneManager.Instance.AddCustomVegetation(new CustomVegetation(prefab, true, MeadowsTreeValues));
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

        private void BlackForestTreeConfig()
        {
            try
            {
                foreach (string prefabName in BlackForestTreeList)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        ZoneManager.Instance.AddCustomVegetation(new CustomVegetation(prefab, true, BlackForestTreeValues));
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

        private void SwampTreeConfig()
        {
            try
            {
                foreach (string prefabName in SwampTreeList)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        ZoneManager.Instance.AddCustomVegetation(new CustomVegetation(prefab, true, SwampTreeValues));
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

        private void MountainTreeConfig()
        {
            try
            {
                foreach (string prefabName in MountainTreeList)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        ZoneManager.Instance.AddCustomVegetation(new CustomVegetation(prefab, true, MountainTreeValues));
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

        private void PlainsTreeConfig()
        {
            try
            {
                foreach (string prefabName in PlainsTreeList)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        ZoneManager.Instance.AddCustomVegetation(new CustomVegetation(prefab, true, PlainsTreeValues));
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

        private void MistlandsTreeConfig()
        {
            try
            {
                foreach (string prefabName in MistlandsTreeList)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        ZoneManager.Instance.AddCustomVegetation(new CustomVegetation(prefab, true, MistlandsTreeValues));
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

        // Changed to plains
        private void AshLandsTreeConfig()
        {
            try
            {
                foreach (string prefabName in AshLandsTreeList)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        ZoneManager.Instance.AddCustomVegetation(new CustomVegetation(prefab, true, AshLandsTreeValues));
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

        private void PlainsRockConfig()
        {
            try
            {
                foreach (string prefabName in PlainsRockList)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        ZoneManager.Instance.AddCustomVegetation(new CustomVegetation(prefab, true, PlainsRockValues));
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

        private void VariableTreeList()
        {
            try
            {
                // Swamp Log
                GameObject Log1 = MyAssets.LoadAsset<GameObject>("SwampTree2_log_RtD");
                CustomVegetation CustomLog1 = new(Log1, true, new VegetationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.BlackForest, Heightmap.Biome.Swamp),
                    Max = 1,
                    ScaleMin = 1.9f,
                    ScaleMax = 3.0f,
                    MinAltitude = -0.5f,
                    MaxTilt = 15f,
                    MinTerrainDelta = 1,
                    MaxTerrainDelta = 3,
                });
                ZoneManager.Instance.AddCustomVegetation(CustomLog1);

                GameObject Log2 = MyAssets.LoadAsset<GameObject>("MagicTree2_RtD");
                CustomVegetation CustomLog2 = new(Log2, true, new VegetationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.Meadows, Heightmap.Biome.BlackForest, Heightmap.Biome.Swamp),
                    Max = 1,
                    ScaleMin = 1.9f,
                    ScaleMax = 3.0f,
                    MinAltitude = -0.5f,
                    MaxTilt = 30f,
                    MinTerrainDelta = 1,
                    MaxTerrainDelta = 3,
                });
                ZoneManager.Instance.AddCustomVegetation(CustomLog2);
                
                GameObject Log3 = MyAssets.LoadAsset<GameObject>("WillowTree1_RtD");
                CustomVegetation CustomLog3 = new(Log3, true, new VegetationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf( Heightmap.Biome.Meadows, Heightmap.Biome.Swamp),
                    Max = 1,
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
                    Max = 1,
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
                    Max = 1,
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
                    Max = 1,
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

        private void DeepNorthTreeConfig()
        {
            try
            {
                foreach (string prefabName in DeepNorthTreeList)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        ZoneManager.Instance.AddCustomVegetation(new CustomVegetation(prefab, true, DeepNorthTreeValues));
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