using BepInEx;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using System;

namespace RtDBiomes                        
{
    internal partial class RtDBiomes : BaseUnityPlugin   
    {
        public void AddSaplings()
        {
            try
            {
                PieceConfig val15 = new PieceConfig();
                val15.PieceTable = PieceTables.Cultivator;
                val15.AddRequirement(new RequirementConfig("AshLandsSeed2_RtD", 1, 0, true));
                val15.Category = "Saplings";
                PieceManager.Instance.AddPiece(new CustomPiece(MyAssets, "AshLandsSaplingD1_RtD", true, val15));

                PieceConfig val18 = new PieceConfig();
                val18.PieceTable = PieceTables.Cultivator;
                val18.AddRequirement(new RequirementConfig("AshLandsSeed2_RtD", 1, 0, true));
                val18.Category = "Saplings";
                PieceManager.Instance.AddPiece(new CustomPiece(MyAssets, "AshLandsSaplingD3_RtD", true, val18));
                
                PieceConfig val2 = new PieceConfig();
                val2.PieceTable = PieceTables.Cultivator;
                val2.AddRequirement(new RequirementConfig("AcaciaSeeds_RtD", 1, 0, true));
                val2.Category = "Saplings";
                PieceManager.Instance.AddPiece(new CustomPiece(MyAssets, "AcaciaSapling_RtD", true, val2));

                PieceConfig val3 = new PieceConfig();
                val3.PieceTable = PieceTables.Cultivator;
                val3.AddRequirement(new RequirementConfig("BlossomSeeds_RtD", 1, 0, true));
                val3.Category = "Saplings";
                PieceManager.Instance.AddPiece(new CustomPiece(MyAssets, "BlossomSapling_RtD", true, val3));

                PieceConfig val4 = new PieceConfig();
                val4.PieceTable = PieceTables.Cultivator;
                val4.AddRequirement(new RequirementConfig("CottonWoodSeeds_RtD", 1, 0, true));
                val4.Category = "Saplings";
                PieceManager.Instance.AddPiece(new CustomPiece(MyAssets, "CottonWoodSapling_RtD", true, val4));

                PieceConfig val6 = new PieceConfig();
                val6.PieceTable = PieceTables.Cultivator;
                val6.AddRequirement(new RequirementConfig("OakWoodSeeds_RtD", 1, 0, true));
                val6.Category = "Saplings";
                PieceManager.Instance.AddPiece(new CustomPiece(MyAssets, "OakSapling_RtD", true, val6));

                PieceConfig val7 = new PieceConfig();
                val7.PieceTable = PieceTables.Cultivator;
                val7.AddRequirement(new RequirementConfig("PalmTreeSeeds_RtD", 1, 0, true));
                val7.Category = "Saplings";
                PieceManager.Instance.AddPiece(new CustomPiece(MyAssets, "PalmTreeSapling_RtD", true, val7));

                PieceConfig val8 = new PieceConfig();
                val8.PieceTable = PieceTables.Cultivator;
                val8.AddRequirement(new RequirementConfig("RedPineSeeds_RtD", 1, 0, true));
                val8.Category = "Saplings";
                PieceManager.Instance.AddPiece(new CustomPiece(MyAssets, "RedPineSapling_RtD", true, val8));

                PieceConfig val9 = new PieceConfig();
                val9.PieceTable = PieceTables.Cultivator;
                val9.AddRequirement(new RequirementConfig("ThinPineSeeds_RtD", 1, 0, true));
                val9.Category = "Saplings";
                PieceManager.Instance.AddPiece(new CustomPiece(MyAssets, "ThinPineSapling_RtD", true, val9));

                PieceConfig val10 = new PieceConfig();
                val10.PieceTable = PieceTables.Cultivator;
                val10.AddRequirement(new RequirementConfig("WillowSeeds_RtD", 1, 0, true));
                val10.Category = "Saplings";
                PieceManager.Instance.AddPiece(new CustomPiece(MyAssets, "WillowSapling_RtD", true, val10));

                PieceConfig val11 = new PieceConfig();
                val11.PieceTable = PieceTables.Cultivator;
                val11.AddRequirement(new RequirementConfig("WinterPineSeeds1_RtD", 1, 0, true));
                val11.Category = "Saplings";
                PieceManager.Instance.AddPiece(new CustomPiece(MyAssets, "WinterPineSapling1_RtD", true, val11));

                PieceConfig val12 = new PieceConfig();
                val12.PieceTable = PieceTables.Cultivator;
                val12.AddRequirement(new RequirementConfig("WinterPineSeeds2_RtD", 1, 0, true));
                val12.Category = "Saplings";
                PieceManager.Instance.AddPiece(new CustomPiece(MyAssets, "WinterPineSapling2_RtD", true, val12));

                PieceConfig val13 = new PieceConfig();
                val13.PieceTable = PieceTables.Cultivator;
                val13.AddRequirement(new RequirementConfig("MapleSeed_RtD", 1, 0, true));
                val13.Category = "Saplings";
                PieceManager.Instance.AddPiece(new CustomPiece(MyAssets, "MapleSapling1_RtD", true, val13));

                PieceConfig val14 = new PieceConfig();
                val14.PieceTable = PieceTables.Cultivator;
                val14.AddRequirement(new RequirementConfig("MapleSeed_RtD", 1, 0, true));
                val14.Category = "Saplings";
                PieceManager.Instance.AddPiece(new CustomPiece(MyAssets, "MapleSapling2_RtD", true, val14));
                
                PieceConfig val5 = new PieceConfig();
                val5.PieceTable = PieceTables.Cultivator;
                val5.AddRequirement(new RequirementConfig("FaeSeed_RtD", 1, 0, true));
                val5.Category = "Saplings";
                PieceManager.Instance.AddPiece(new CustomPiece(MyAssets, "MagicTreeSapling1_RtD", true, val5));

                PieceConfig val16 = new PieceConfig();
                val16.PieceTable = PieceTables.Cultivator;
                val16.AddRequirement(new RequirementConfig("AshLandsSeed1_RtD", 1, 0, true));
                val16.Category = "Saplings";
                PieceManager.Instance.AddPiece(new CustomPiece(MyAssets, "AshLandsSaplingD2_RtD", true, val16));

                PieceConfig val19 = new PieceConfig();
                val19.PieceTable = PieceTables.Cultivator;
                val19.AddRequirement(new RequirementConfig("AncientSeed", 1, 0, true));
                val19.Category = "Saplings";
                PieceManager.Instance.AddPiece(new CustomPiece(MyAssets, "SwampSapling1_RtD", true, val19));

                PieceConfig val20 = new PieceConfig();
                val20.PieceTable = PieceTables.Cultivator;
                val20.AddRequirement(new RequirementConfig("AncientSeed", 1, 0, true));
                val20.Category = "Saplings";
                PieceManager.Instance.AddPiece(new CustomPiece(MyAssets, "SwampSapling2_RtD", true, val20));


            }
            catch (Exception ex)
            {
                Logger.LogWarning($"Exception caught while adding prefabs: {ex}");
            }
        }
        
        public void CreateRecipes()
        {
            try
            {
                // Vines
                PieceConfig pieceConfig = new PieceConfig();
                pieceConfig.PieceTable = PieceTables.Hammer;
                pieceConfig.CraftingStation = CraftingStations.Workbench;
                pieceConfig.Category = "Vines";
                pieceConfig.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallCD_1_FB_RtD", true, pieceConfig));
                
                PieceConfig pieceConfig2 = new PieceConfig();
                pieceConfig2.PieceTable = PieceTables.Hammer;
                pieceConfig2.CraftingStation = CraftingStations.Workbench;
                pieceConfig2.Category = "Vines";
                pieceConfig2.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig2.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallCD_2_FB_RtD", true, pieceConfig2));
                
                PieceConfig pieceConfig3 = new PieceConfig();
                pieceConfig3.PieceTable = PieceTables.Hammer;
                pieceConfig3.CraftingStation = CraftingStations.Workbench;
                pieceConfig3.Category = "Vines";
                pieceConfig3.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig3.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_1_FB_RtD", true, pieceConfig3));
                
                PieceConfig pieceConfig4 = new PieceConfig();
                pieceConfig4.PieceTable = PieceTables.Hammer;
                pieceConfig4.CraftingStation = CraftingStations.Workbench;
                pieceConfig4.Category = "Vines";
                pieceConfig4.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig4.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_2_FB_RtD", true, pieceConfig4));
                
                PieceConfig pieceConfig5 = new PieceConfig();
                pieceConfig5.PieceTable = PieceTables.Hammer;
                pieceConfig5.CraftingStation = CraftingStations.Workbench;
                pieceConfig5.Category = "Vines";
                pieceConfig5.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig5.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_3_FB_RtD", true, pieceConfig5));
                
                PieceConfig pieceConfig6 = new PieceConfig();
                pieceConfig6.PieceTable = PieceTables.Hammer;
                pieceConfig6.CraftingStation = CraftingStations.Workbench;
                pieceConfig6.Category = "Vines";
                pieceConfig6.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig6.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_4_FB_RtD", true, pieceConfig6));
                
                PieceConfig pieceConfig7 = new PieceConfig();
                pieceConfig7.PieceTable = PieceTables.Hammer;
                pieceConfig7.CraftingStation = CraftingStations.Workbench;
                pieceConfig7.Category = "Vines";
                pieceConfig7.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig7.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_5_FB_RtD", true, pieceConfig7));
                
                PieceConfig pieceConfig8 = new PieceConfig();
                pieceConfig8.PieceTable = PieceTables.Hammer;
                pieceConfig8.CraftingStation = CraftingStations.Workbench;
                pieceConfig8.Category = "Vines";
                pieceConfig8.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig8.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_6_FB_RtD", true, pieceConfig8));
                
                PieceConfig pieceConfig9 = new PieceConfig();
                pieceConfig9.PieceTable = PieceTables.Hammer;
                pieceConfig9.CraftingStation = CraftingStations.Workbench;
                pieceConfig9.Category = "Vines";
                pieceConfig9.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig9.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallU_1_FB_RtD", true, pieceConfig9));
                
                PieceConfig pieceConfig10 = new PieceConfig();
                pieceConfig10.PieceTable = PieceTables.Hammer;
                pieceConfig10.CraftingStation = CraftingStations.Workbench;
                pieceConfig10.Category = "Vines";
                pieceConfig10.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig10.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallU_2_FB_RtD", true, pieceConfig10));
                
                PieceConfig pieceConfig11 = new PieceConfig();
                pieceConfig11.PieceTable = PieceTables.Hammer;
                pieceConfig11.CraftingStation = CraftingStations.Workbench;
                pieceConfig11.Category = "Vines";
                pieceConfig11.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig11.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallU_3_FB_RtD", true, pieceConfig11));
                
                PieceConfig pieceConfig12 = new PieceConfig();
                pieceConfig12.PieceTable = PieceTables.Hammer;
                pieceConfig12.CraftingStation = CraftingStations.Workbench;
                pieceConfig12.Category = "Vines";
                pieceConfig12.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig12.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallU_4_FB_RtD", true, pieceConfig12));
                
                PieceConfig pieceConfig13 = new PieceConfig();
                pieceConfig13.PieceTable = PieceTables.Hammer;
                pieceConfig13.CraftingStation = CraftingStations.Workbench;
                pieceConfig13.Category = "Vines";
                pieceConfig13.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig13.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallWD_1_FB_RtD", true, pieceConfig13));
                
                PieceConfig pieceConfig14 = new PieceConfig();
                pieceConfig14.PieceTable = PieceTables.Hammer;
                pieceConfig14.CraftingStation = CraftingStations.Workbench;
                pieceConfig14.Category = "Vines";
                pieceConfig14.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig14.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallWD_2_FB_RtD", true, pieceConfig14));
                
                PieceConfig pieceConfig15 = new PieceConfig();
                pieceConfig15.PieceTable = PieceTables.Hammer;
                pieceConfig15.CraftingStation = CraftingStations.Workbench;
                pieceConfig15.Category = "Vines";
                pieceConfig15.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig15.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_1_FC_RtD", true, pieceConfig15));
                
                PieceConfig pieceConfig16 = new PieceConfig();
                pieceConfig16.PieceTable = PieceTables.Hammer;
                pieceConfig16.CraftingStation = CraftingStations.Workbench;
                pieceConfig16.Category = "Vines";
                pieceConfig16.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig16.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_2_FC_RtD", true, pieceConfig16));
                
                PieceConfig pieceConfig17 = new PieceConfig();
                pieceConfig17.PieceTable = PieceTables.Hammer;
                pieceConfig17.CraftingStation = CraftingStations.Workbench;
                pieceConfig17.Category = "Vines";
                pieceConfig17.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig17.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_3_FC_RtD", true, pieceConfig17));
                
                PieceConfig pieceConfig18 = new PieceConfig();
                pieceConfig18.PieceTable = PieceTables.Hammer;
                pieceConfig18.CraftingStation = CraftingStations.Workbench;
                pieceConfig18.Category = "Vines";
                pieceConfig18.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig18.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_4_FC_RtD", true, pieceConfig18));
                
                PieceConfig pieceConfig19 = new PieceConfig();
                pieceConfig19.PieceTable = PieceTables.Hammer;
                pieceConfig19.CraftingStation = CraftingStations.Workbench;
                pieceConfig19.Category = "Vines";
                pieceConfig19.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig19.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_5_FC_RtD", true, pieceConfig19));
                
                PieceConfig pieceConfig20 = new PieceConfig();
                pieceConfig20.PieceTable = PieceTables.Hammer;
                pieceConfig20.CraftingStation = CraftingStations.Workbench;
                pieceConfig20.Category = "Vines";
                pieceConfig20.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig20.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_6_FC_RtD", true, pieceConfig20));
                
                PieceConfig pieceConfig21 = new PieceConfig();
                pieceConfig21.PieceTable = PieceTables.Hammer;
                pieceConfig21.CraftingStation = CraftingStations.Workbench;
                pieceConfig21.Category = "Vines";
                pieceConfig21.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig21.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_1_FE_RtD", true, pieceConfig21));
                
                PieceConfig pieceConfig22 = new PieceConfig();
                pieceConfig22.PieceTable = PieceTables.Hammer;
                pieceConfig22.CraftingStation = CraftingStations.Workbench;
                pieceConfig22.Category = "Vines";
                pieceConfig22.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig22.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_2_FE_RtD", true, pieceConfig22));
                
                PieceConfig pieceConfig23 = new PieceConfig();
                pieceConfig23.PieceTable = PieceTables.Hammer;
                pieceConfig23.CraftingStation = CraftingStations.Workbench;
                pieceConfig23.Category = "Vines";
                pieceConfig23.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig23.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_4_FE_RtD", true, pieceConfig23));
                
                PieceConfig pieceConfig24 = new PieceConfig();
                pieceConfig24.PieceTable = PieceTables.Hammer;
                pieceConfig24.CraftingStation = CraftingStations.Workbench;
                pieceConfig24.Category = "Vines";
                pieceConfig24.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig24.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_5_FE_RtD", true, pieceConfig24));
                
                PieceConfig pieceConfig25 = new PieceConfig();
                pieceConfig25.PieceTable = PieceTables.Hammer;
                pieceConfig25.CraftingStation = CraftingStations.Workbench;
                pieceConfig25.Category = "Vines";
                pieceConfig25.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig25.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_6_FE_RtD", true, pieceConfig25));
                
                PieceConfig pieceConfig26 = new PieceConfig();
                pieceConfig26.PieceTable = PieceTables.Hammer;
                pieceConfig26.CraftingStation = CraftingStations.Workbench;
                pieceConfig26.Category = "Vines";
                pieceConfig26.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig26.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallU_1_FE_RtD", true, pieceConfig26));
                
                PieceConfig pieceConfig27 = new PieceConfig();
                pieceConfig27.PieceTable = PieceTables.Hammer;
                pieceConfig27.CraftingStation = CraftingStations.Workbench;
                pieceConfig27.Category = "Vines";
                pieceConfig27.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig27.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallU_2_FE_RtD", true, pieceConfig27));
                
                PieceConfig pieceConfig28 = new PieceConfig();
                pieceConfig28.PieceTable = PieceTables.Hammer;
                pieceConfig28.CraftingStation = CraftingStations.Workbench;
                pieceConfig28.Category = "Vines";
                pieceConfig28.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig28.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallU_3_FE_RtD", true, pieceConfig28));
                
                PieceConfig pieceConfig29 = new PieceConfig();
                pieceConfig29.PieceTable = PieceTables.Hammer;
                pieceConfig29.CraftingStation = CraftingStations.Workbench;
                pieceConfig29.Category = "Vines";
                pieceConfig29.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig29.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallU_4_FE_RtD", true, pieceConfig29));
                
                PieceConfig pieceConfig30 = new PieceConfig();
                pieceConfig30.PieceTable = PieceTables.Hammer;
                pieceConfig30.CraftingStation = CraftingStations.Workbench;
                pieceConfig30.Category = "Vines";
                pieceConfig30.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig30.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallWD_1_FE_RtD", true, pieceConfig30));
                
                PieceConfig pieceConfig31 = new PieceConfig();
                pieceConfig31.PieceTable = PieceTables.Hammer;
                pieceConfig31.CraftingStation = CraftingStations.Workbench;
                pieceConfig31.Category = "Vines";
                pieceConfig31.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig31.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallWD_2_FE_RtD", true, pieceConfig31));
                
                PieceConfig pieceConfig32 = new PieceConfig();
                pieceConfig32.PieceTable = PieceTables.Hammer;
                pieceConfig32.CraftingStation = CraftingStations.Workbench;
                pieceConfig32.Category = "Vines";
                pieceConfig32.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig32.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_1_FP_RtD", true, pieceConfig32));
                
                PieceConfig pieceConfig33 = new PieceConfig();
                pieceConfig33.PieceTable = PieceTables.Hammer;
                pieceConfig33.CraftingStation = CraftingStations.Workbench;
                pieceConfig33.Category = "Vines";
                pieceConfig33.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig33.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_2_FP_RtD", true, pieceConfig33));
                
                PieceConfig pieceConfig34 = new PieceConfig();
                pieceConfig34.PieceTable = PieceTables.Hammer;
                pieceConfig34.CraftingStation = CraftingStations.Workbench;
                pieceConfig34.Category = "Vines";
                pieceConfig34.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig34.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_3_FP_RtD", true, pieceConfig34));
                
                PieceConfig pieceConfig35 = new PieceConfig();
                pieceConfig35.PieceTable = PieceTables.Hammer;
                pieceConfig35.CraftingStation = CraftingStations.Workbench;
                pieceConfig35.Category = "Vines";
                pieceConfig35.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig35.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_4_FP_RtD", true, pieceConfig35));
                
                PieceConfig pieceConfig36 = new PieceConfig();
                pieceConfig36.PieceTable = PieceTables.Hammer;
                pieceConfig36.CraftingStation = CraftingStations.Workbench;
                pieceConfig36.Category = "Vines";
                pieceConfig36.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig36.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_5_FP_RtD", true, pieceConfig36));
                
                PieceConfig pieceConfig37 = new PieceConfig();
                pieceConfig37.PieceTable = PieceTables.Hammer;
                pieceConfig37.CraftingStation = CraftingStations.Workbench;
                pieceConfig37.Category = "Vines";
                pieceConfig37.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig37.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_6_FP_RtD", true, pieceConfig37));
                
                PieceConfig pieceConfig38 = new PieceConfig();
                pieceConfig38.PieceTable = PieceTables.Hammer;
                pieceConfig38.CraftingStation = CraftingStations.Workbench;
                pieceConfig38.Category = "Vines";
                pieceConfig38.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig38.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallU_1_FP_RtD", true, pieceConfig38));
                
                PieceConfig pieceConfig39 = new PieceConfig();
                pieceConfig39.PieceTable = PieceTables.Hammer;
                pieceConfig39.CraftingStation = CraftingStations.Workbench;
                pieceConfig39.Category = "Vines";
                pieceConfig39.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig39.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallU_2_FP_RtD", true, pieceConfig39));
                
                PieceConfig pieceConfig40 = new PieceConfig();
                pieceConfig40.PieceTable = PieceTables.Hammer;
                pieceConfig40.CraftingStation = CraftingStations.Workbench;
                pieceConfig40.Category = "Vines";
                pieceConfig40.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig40.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallU_3_FP_RtD", true, pieceConfig40));
                
                PieceConfig pieceConfig41 = new PieceConfig();
                pieceConfig41.PieceTable = PieceTables.Hammer;
                pieceConfig41.CraftingStation = CraftingStations.Workbench;
                pieceConfig41.Category = "Vines";
                pieceConfig41.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig41.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallU_4_FP_RtD", true, pieceConfig41));
                
                PieceConfig pieceConfig42 = new PieceConfig();
                pieceConfig42.PieceTable = PieceTables.Hammer;
                pieceConfig42.CraftingStation = CraftingStations.Workbench;
                pieceConfig42.Category = "Vines";
                pieceConfig42.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig42.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallWD_1_FP_RtD", true, pieceConfig42));
                
                PieceConfig pieceConfig43 = new PieceConfig();
                pieceConfig43.PieceTable = PieceTables.Hammer;
                pieceConfig43.CraftingStation = CraftingStations.Workbench;
                pieceConfig43.Category = "Vines";
                pieceConfig43.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig43.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallWD_2_FP_RtD", true, pieceConfig43));
                
                PieceConfig pieceConfig44 = new PieceConfig();
                pieceConfig44.PieceTable = PieceTables.Hammer;
                pieceConfig44.CraftingStation = CraftingStations.Workbench;
                pieceConfig44.Category = "Vines";
                pieceConfig44.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig44.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_1_FR_RtD", true, pieceConfig44));
                
                PieceConfig pieceConfig45 = new PieceConfig();
                pieceConfig45.PieceTable = PieceTables.Hammer;
                pieceConfig45.CraftingStation = CraftingStations.Workbench;
                pieceConfig45.Category = "Vines";
                pieceConfig45.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig45.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_2_FR_RtD", true, pieceConfig45));
                
                PieceConfig pieceConfig46 = new PieceConfig();
                pieceConfig46.PieceTable = PieceTables.Hammer;
                pieceConfig46.CraftingStation = CraftingStations.Workbench;
                pieceConfig46.Category = "Vines";
                pieceConfig46.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig46.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_3_FE_RtD", true, pieceConfig46));
                
                PieceConfig pieceConfig47 = new PieceConfig();
                pieceConfig47.PieceTable = PieceTables.Hammer;
                pieceConfig47.CraftingStation = CraftingStations.Workbench;
                pieceConfig47.Category = "Vines";
                pieceConfig47.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig47.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_3_FR_RtD", true, pieceConfig47));
                
                PieceConfig pieceConfig48 = new PieceConfig();
                pieceConfig48.PieceTable = PieceTables.Hammer;
                pieceConfig48.CraftingStation = CraftingStations.Workbench;
                pieceConfig48.Category = "Vines";
                pieceConfig48.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig48.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_4_FR_RtD", true, pieceConfig48));
                
                PieceConfig pieceConfig49 = new PieceConfig();
                pieceConfig49.PieceTable = PieceTables.Hammer;
                pieceConfig49.CraftingStation = CraftingStations.Workbench;
                pieceConfig49.Category = "Vines";
                pieceConfig49.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig49.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_5_FR_RtD", true, pieceConfig49));
                
                PieceConfig pieceConfig50 = new PieceConfig();
                pieceConfig50.PieceTable = PieceTables.Hammer;
                pieceConfig50.CraftingStation = CraftingStations.Workbench;
                pieceConfig50.Category = "Vines";
                pieceConfig50.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig50.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_6_FR_RtD", true, pieceConfig50));
                
                PieceConfig pieceConfig51 = new PieceConfig();
                pieceConfig51.PieceTable = PieceTables.Hammer;
                pieceConfig51.CraftingStation = CraftingStations.Workbench;
                pieceConfig51.Category = "Vines";
                pieceConfig51.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig51.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallU_1_FR_RtD", true, pieceConfig51));
                
                PieceConfig pieceConfig52 = new PieceConfig();
                pieceConfig52.PieceTable = PieceTables.Hammer;
                pieceConfig52.CraftingStation = CraftingStations.Workbench;
                pieceConfig52.Category = "Vines";
                pieceConfig52.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig52.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallU_2_FR_RtD", true, pieceConfig52));
                
                PieceConfig pieceConfig53 = new PieceConfig();
                pieceConfig53.PieceTable = PieceTables.Hammer;
                pieceConfig53.CraftingStation = CraftingStations.Workbench;
                pieceConfig53.Category = "Vines";
                pieceConfig53.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig53.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallU_3_FR_RtD", true, pieceConfig53));
                
                PieceConfig pieceConfig54 = new PieceConfig();
                pieceConfig54.PieceTable = PieceTables.Hammer;
                pieceConfig54.CraftingStation = CraftingStations.Workbench;
                pieceConfig54.Category = "Vines";
                pieceConfig54.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig54.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallU_4_FR_RtD", true, pieceConfig54));
                
                PieceConfig pieceConfig55 = new PieceConfig();
                pieceConfig55.PieceTable = PieceTables.Hammer;
                pieceConfig55.CraftingStation = CraftingStations.Workbench;
                pieceConfig55.Category = "Vines";
                pieceConfig55.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig55.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallWD_1_FR_RtD", true, pieceConfig55));
                
                PieceConfig pieceConfig56 = new PieceConfig();
                pieceConfig56.PieceTable = PieceTables.Hammer;
                pieceConfig56.CraftingStation = CraftingStations.Workbench;
                pieceConfig56.Category = "Vines";
                pieceConfig56.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig56.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallWD_2_FR_RtD", true, pieceConfig56));
                
                PieceConfig pieceConfig57 = new PieceConfig();
                pieceConfig57.PieceTable = PieceTables.Hammer;
                pieceConfig57.CraftingStation = CraftingStations.Workbench;
                pieceConfig57.Category = "Vines";
                pieceConfig57.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig57.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyFloor_1_FS_RtD", true, pieceConfig57));
                
                PieceConfig pieceConfig58 = new PieceConfig();
                pieceConfig58.PieceTable = PieceTables.Hammer;
                pieceConfig58.CraftingStation = CraftingStations.Workbench;
                pieceConfig58.Category = "Vines";
                pieceConfig58.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig58.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyFloor_2_FS_RtD", true, pieceConfig58));
                
                PieceConfig pieceConfig59 = new PieceConfig();
                pieceConfig59.PieceTable = PieceTables.Hammer;
                pieceConfig59.CraftingStation = CraftingStations.Workbench;
                pieceConfig59.Category = "Vines";
                pieceConfig59.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig59.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyFloor_3_FS_RtD", true, pieceConfig59));
                
                PieceConfig pieceConfig60 = new PieceConfig();
                pieceConfig60.PieceTable = PieceTables.Hammer;
                pieceConfig60.CraftingStation = CraftingStations.Workbench;
                pieceConfig60.Category = "Vines";
                pieceConfig60.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig60.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyFloor_4_FS_RtD", true, pieceConfig60));
                
                PieceConfig pieceConfig61 = new PieceConfig();
                pieceConfig61.PieceTable = PieceTables.Hammer;
                pieceConfig61.CraftingStation = CraftingStations.Workbench;
                pieceConfig61.Category = "Vines";
                pieceConfig61.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig61.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_1_FS_RtD", true, pieceConfig61));
                
                PieceConfig pieceConfig62 = new PieceConfig();
                pieceConfig62.PieceTable = PieceTables.Hammer;
                pieceConfig62.CraftingStation = CraftingStations.Workbench;
                pieceConfig62.Category = "Vines";
                pieceConfig62.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig62.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_2_FS_RtD", true, pieceConfig62));
                
                PieceConfig pieceConfig63 = new PieceConfig();
                pieceConfig63.PieceTable = PieceTables.Hammer;
                pieceConfig63.CraftingStation = CraftingStations.Workbench;
                pieceConfig63.Category = "Vines";
                pieceConfig63.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig63.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_3_FS_RtD", true, pieceConfig63));
                
                PieceConfig pieceConfig64 = new PieceConfig();
                pieceConfig64.PieceTable = PieceTables.Hammer;
                pieceConfig64.CraftingStation = CraftingStations.Workbench;
                pieceConfig64.Category = "Vines";
                pieceConfig64.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig64.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_4_FS_RtD", true, pieceConfig64));
                
                PieceConfig pieceConfig65 = new PieceConfig();
                pieceConfig65.PieceTable = PieceTables.Hammer;
                pieceConfig65.CraftingStation = CraftingStations.Workbench;
                pieceConfig65.Category = "Vines";
                pieceConfig65.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig65.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_5_FS_RtD", true, pieceConfig65));
                
                PieceConfig pieceConfig66 = new PieceConfig();
                pieceConfig66.PieceTable = PieceTables.Hammer;
                pieceConfig66.CraftingStation = CraftingStations.Workbench;
                pieceConfig66.Category = "Vines";
                pieceConfig66.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig66.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_6_FS_RtD", true, pieceConfig66));
                
                PieceConfig pieceConfig67 = new PieceConfig();
                pieceConfig67.PieceTable = PieceTables.Hammer;
                pieceConfig67.CraftingStation = CraftingStations.Workbench;
                pieceConfig67.Category = "Vines";
                pieceConfig67.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig67.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallU_1_FS_RtD", true, pieceConfig67));
                
                PieceConfig pieceConfig68 = new PieceConfig();
                pieceConfig68.PieceTable = PieceTables.Hammer;
                pieceConfig68.CraftingStation = CraftingStations.Workbench;
                pieceConfig68.Category = "Vines";
                pieceConfig68.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig68.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallU_2_FS_RtD", true, pieceConfig68));
                
                PieceConfig pieceConfig69 = new PieceConfig();
                pieceConfig69.PieceTable = PieceTables.Hammer;
                pieceConfig69.CraftingStation = CraftingStations.Workbench;
                pieceConfig69.Category = "Vines";
                pieceConfig69.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig69.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallU_3_FS_RtD", true, pieceConfig69));
                
                PieceConfig pieceConfig70 = new PieceConfig();
                pieceConfig70.PieceTable = PieceTables.Hammer;
                pieceConfig70.CraftingStation = CraftingStations.Workbench;
                pieceConfig70.Category = "Vines";
                pieceConfig70.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig70.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallU_4_FS_RtD", true, pieceConfig70));
                
                PieceConfig pieceConfig71 = new PieceConfig();
                pieceConfig71.PieceTable = PieceTables.Hammer;
                pieceConfig71.CraftingStation = CraftingStations.Workbench;
                pieceConfig71.Category = "Vines";
                pieceConfig71.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig71.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallWD_1_FS_RtD", true, pieceConfig71));
                
                PieceConfig pieceConfig72 = new PieceConfig();
                pieceConfig72.PieceTable = PieceTables.Hammer;
                pieceConfig72.CraftingStation = CraftingStations.Workbench;
                pieceConfig72.Category = "Vines";
                pieceConfig72.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig72.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallWD_2_FS_RtD", true, pieceConfig72));
                
                PieceConfig pieceConfig73 = new PieceConfig();
                pieceConfig73.PieceTable = PieceTables.Hammer;
                pieceConfig73.CraftingStation = CraftingStations.Workbench;
                pieceConfig73.Category = "Vines";
                pieceConfig73.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig73.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_1_FV_RtD", true, pieceConfig73));
                
                PieceConfig pieceConfig74 = new PieceConfig();
                pieceConfig74.PieceTable = PieceTables.Hammer;
                pieceConfig74.CraftingStation = CraftingStations.Workbench;
                pieceConfig74.Category = "Vines";
                pieceConfig74.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig74.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_2_FV_RtD", true, pieceConfig74));
                
                PieceConfig pieceConfig75 = new PieceConfig();
                pieceConfig75.PieceTable = PieceTables.Hammer;
                pieceConfig75.CraftingStation = CraftingStations.Workbench;
                pieceConfig75.Category = "Vines";
                pieceConfig75.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig75.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_3_FV_RtD", true, pieceConfig75));
                
                PieceConfig pieceConfig76 = new PieceConfig();
                pieceConfig76.PieceTable = PieceTables.Hammer;
                pieceConfig76.CraftingStation = CraftingStations.Workbench;
                pieceConfig76.Category = "Vines";
                pieceConfig76.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig76.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_4_FV_RtD", true, pieceConfig76));
                
                PieceConfig pieceConfig77 = new PieceConfig();
                pieceConfig77.PieceTable = PieceTables.Hammer;
                pieceConfig77.CraftingStation = CraftingStations.Workbench;
                pieceConfig77.Category = "Vines";
                pieceConfig77.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig77.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_5_FV_RtD", true, pieceConfig77));
                
                PieceConfig pieceConfig78 = new PieceConfig();
                pieceConfig78.PieceTable = PieceTables.Hammer;
                pieceConfig78.CraftingStation = CraftingStations.Workbench;
                pieceConfig78.Category = "Vines";
                pieceConfig78.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig78.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_6_FV_RtD", true, pieceConfig78));
                
                PieceConfig pieceConfig79 = new PieceConfig();
                pieceConfig79.PieceTable = PieceTables.Hammer;
                pieceConfig79.CraftingStation = CraftingStations.Workbench;
                pieceConfig79.Category = "Vines";
                pieceConfig79.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig79.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallU_1_FV_RtD", true, pieceConfig79));
                
                PieceConfig pieceConfig80 = new PieceConfig();
                pieceConfig80.PieceTable = PieceTables.Hammer;
                pieceConfig80.CraftingStation = CraftingStations.Workbench;
                pieceConfig80.Category = "Vines";
                pieceConfig80.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig80.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallU_2_FV_RtD", true, pieceConfig80));
                
                PieceConfig pieceConfig81 = new PieceConfig();
                pieceConfig81.PieceTable = PieceTables.Hammer;
                pieceConfig81.CraftingStation = CraftingStations.Workbench;
                pieceConfig81.Category = "Vines";
                pieceConfig81.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig81.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallU_3_FV_RtD", true, pieceConfig81));
                
                PieceConfig pieceConfig82 = new PieceConfig();
                pieceConfig82.PieceTable = PieceTables.Hammer;
                pieceConfig82.CraftingStation = CraftingStations.Workbench;
                pieceConfig82.Category = "Vines";
                pieceConfig82.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig82.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallU_4_FV_RtD", true, pieceConfig82));
                
                PieceConfig pieceConfig83 = new PieceConfig();
                pieceConfig83.PieceTable = PieceTables.Hammer;
                pieceConfig83.CraftingStation = CraftingStations.Workbench;
                pieceConfig83.Category = "Vines";
                pieceConfig83.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig83.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallWD_1_FV_RtD", true, pieceConfig83));
                
                PieceConfig pieceConfig84 = new PieceConfig();
                pieceConfig84.PieceTable = PieceTables.Hammer;
                pieceConfig84.CraftingStation = CraftingStations.Workbench;
                pieceConfig84.Category = "Vines";
                pieceConfig84.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig84.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallWD_2_FV_RtD", true, pieceConfig84));
                
                PieceConfig pieceConfig85 = new PieceConfig();
                pieceConfig85.PieceTable = PieceTables.Hammer;
                pieceConfig85.CraftingStation = CraftingStations.Workbench;
                pieceConfig85.Category = "Vines";
                pieceConfig85.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig85.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_1_RtD", true, pieceConfig85));
                
                PieceConfig pieceConfig86 = new PieceConfig();
                pieceConfig86.PieceTable = PieceTables.Hammer;
                pieceConfig86.CraftingStation = CraftingStations.Workbench;
                pieceConfig86.Category = "Vines";
                pieceConfig86.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig86.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_2_RtD", true, pieceConfig86));
                
                PieceConfig pieceConfig87 = new PieceConfig();
                pieceConfig87.PieceTable = PieceTables.Hammer;
                pieceConfig87.CraftingStation = CraftingStations.Workbench;
                pieceConfig87.Category = "Vines";
                pieceConfig87.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig87.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_3_RtD", true, pieceConfig87));
                
                PieceConfig pieceConfig88 = new PieceConfig();
                pieceConfig88.PieceTable = PieceTables.Hammer;
                pieceConfig88.CraftingStation = CraftingStations.Workbench;
                pieceConfig88.Category = "Vines";
                pieceConfig88.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig88.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_4_RtD", true, pieceConfig88));
                
                PieceConfig pieceConfig89 = new PieceConfig();
                pieceConfig89.PieceTable = PieceTables.Hammer;
                pieceConfig89.CraftingStation = CraftingStations.Workbench;
                pieceConfig89.Category = "Vines";
                pieceConfig89.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig89.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_5_RtD", true, pieceConfig89));
                
                PieceConfig pieceConfig90 = new PieceConfig();
                pieceConfig90.PieceTable = PieceTables.Hammer;
                pieceConfig90.CraftingStation = CraftingStations.Workbench;
                pieceConfig90.Category = "Vines";
                pieceConfig90.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig90.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallD_6_RtD", true, pieceConfig90));
                
                PieceConfig pieceConfig91 = new PieceConfig();
                pieceConfig91.PieceTable = PieceTables.Hammer;
                pieceConfig91.CraftingStation = CraftingStations.Workbench;
                pieceConfig91.Category = "Vines";
                pieceConfig91.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig91.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallU_2_RtD", true, pieceConfig91));
                
                PieceConfig pieceConfig92 = new PieceConfig();
                pieceConfig92.PieceTable = PieceTables.Hammer;
                pieceConfig92.CraftingStation = CraftingStations.Workbench;
                pieceConfig92.Category = "Vines";
                pieceConfig92.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig92.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallU_3_RtD", true, pieceConfig92));
                
                PieceConfig pieceConfig93 = new PieceConfig();
                pieceConfig93.PieceTable = PieceTables.Hammer;
                pieceConfig93.CraftingStation = CraftingStations.Workbench;
                pieceConfig93.Category = "Vines";
                pieceConfig93.AddRequirement(new RequirementConfig("Wood", 5, 0, true));
                pieceConfig93.AddRequirement(new RequirementConfig("Resin", 5, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "IvyWallU_4_RtD", true, pieceConfig93));
                
                // Decorative Plants
                
                //Meadows
                
                PieceConfig pieceConfig94 = new PieceConfig();
                pieceConfig94.PieceTable = PieceTables.Cultivator;
                pieceConfig94.CraftingStation = CraftingStations.Workbench;
                pieceConfig94.Category = "Decorative Plants";
                pieceConfig94.AddRequirement(new RequirementConfig("PlantSeedMeadows_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "DeepNorthBush1P_RtD", true, pieceConfig94));
                
                PieceConfig pieceConfig95 = new PieceConfig();
                pieceConfig95.PieceTable = PieceTables.Cultivator;
                pieceConfig95.CraftingStation = CraftingStations.Workbench;
                pieceConfig95.Category = "Decorative Plants";
                pieceConfig95.AddRequirement(new RequirementConfig("PlantSeedMeadows_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "DeepNorthBush2P_RtD", true, pieceConfig95));
                
                PieceConfig pieceConfig96 = new PieceConfig();
                pieceConfig96.PieceTable = PieceTables.Cultivator;
                pieceConfig96.CraftingStation = CraftingStations.Workbench;
                pieceConfig96.Category = "Decorative Plants";
                pieceConfig96.AddRequirement(new RequirementConfig("PlantSeedMeadows_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "DeepNorthBush3P_RtD", true, pieceConfig96));

                PieceConfig pieceConfig97 = new PieceConfig();
                pieceConfig97.PieceTable = PieceTables.Cultivator;
                pieceConfig97.CraftingStation = CraftingStations.Workbench;
                pieceConfig97.Category = "Decorative Plants";
                pieceConfig97.AddRequirement(new RequirementConfig("PlantSeedMeadows_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "DeepNorthBush4P_RtD", true, pieceConfig97));

                PieceConfig pieceConfig98 = new PieceConfig();
                pieceConfig98.PieceTable = PieceTables.Cultivator;
                pieceConfig98.CraftingStation = CraftingStations.Workbench;
                pieceConfig98.Category = "Decorative Plants";
                pieceConfig98.AddRequirement(new RequirementConfig("PlantSeedMeadows_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "DeepNorthBush5P_RtD", true, pieceConfig98));

                PieceConfig pieceConfig99 = new PieceConfig();
                pieceConfig99.PieceTable = PieceTables.Cultivator;
                pieceConfig99.CraftingStation = CraftingStations.Workbench;
                pieceConfig99.Category = "Decorative Plants";
                pieceConfig99.AddRequirement(new RequirementConfig("PlantSeedMeadows_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "DeepNorthBush6P_RtD", true, pieceConfig99));

                PieceConfig pieceConfig100 = new PieceConfig();
                pieceConfig100.PieceTable = PieceTables.Cultivator;
                pieceConfig100.CraftingStation = CraftingStations.Workbench;
                pieceConfig100.Category = "Decorative Plants";
                pieceConfig100.AddRequirement(new RequirementConfig("PlantSeedMeadows_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "DeepNorthBush7P_RtD", true, pieceConfig100));

                PieceConfig pieceConfig101 = new PieceConfig();
                pieceConfig101.PieceTable = PieceTables.Cultivator;
                pieceConfig101.CraftingStation = CraftingStations.Workbench;
                pieceConfig101.Category = "Decorative Plants";
                pieceConfig101.AddRequirement(new RequirementConfig("PlantSeedMeadows_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "DeepNorthBush8P_RtD", true, pieceConfig101));

                PieceConfig pieceConfig102 = new PieceConfig();
                pieceConfig102.PieceTable = PieceTables.Cultivator;
                pieceConfig102.CraftingStation = CraftingStations.Workbench;
                pieceConfig102.Category = "Decorative Plants";
                pieceConfig102.AddRequirement(new RequirementConfig("PlantSeedMeadows_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "DeepNorthBush9P_RtD", true, pieceConfig102));
                
                PieceConfig pieceConfig103 = new PieceConfig();
                pieceConfig103.PieceTable = PieceTables.Cultivator;
                pieceConfig103.CraftingStation = CraftingStations.Workbench;
                pieceConfig103.Category = "Decorative Plants";
                pieceConfig103.AddRequirement(new RequirementConfig("PlantSeedMeadows_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "DeepNorthBush10P_RtD", true, pieceConfig103));

                PieceConfig pieceConfig104 = new PieceConfig();
                pieceConfig104.PieceTable = PieceTables.Cultivator;
                pieceConfig104.CraftingStation = CraftingStations.Workbench;
                pieceConfig104.Category = "Decorative Plants";
                pieceConfig104.AddRequirement(new RequirementConfig("PlantSeedMeadows_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "MeadowsBush01P_RtD", true, pieceConfig104));

                PieceConfig pieceConfig105 = new PieceConfig();
                pieceConfig105.PieceTable = PieceTables.Cultivator;
                pieceConfig105.CraftingStation = CraftingStations.Workbench;
                pieceConfig105.Category = "Decorative Plants";
                pieceConfig105.AddRequirement(new RequirementConfig("PlantSeedMeadows_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "MeadowsBush1P_RtD", true, pieceConfig105));

                PieceConfig pieceConfig106 = new PieceConfig();
                pieceConfig106.PieceTable = PieceTables.Cultivator;
                pieceConfig106.CraftingStation = CraftingStations.Workbench;
                pieceConfig106.Category = "Decorative Plants";
                pieceConfig106.AddRequirement(new RequirementConfig("PlantSeedMeadows_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "MeadowsBush02P_RtD", true, pieceConfig106));

                PieceConfig pieceConfig107 = new PieceConfig();
                pieceConfig107.PieceTable = PieceTables.Cultivator;
                pieceConfig107.CraftingStation = CraftingStations.Workbench;
                pieceConfig107.Category = "Decorative Plants";
                pieceConfig107.AddRequirement(new RequirementConfig("PlantSeedMeadows_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "MeadowsBush2P_RtD", true, pieceConfig107));

                PieceConfig pieceConfig108 = new PieceConfig();
                pieceConfig108.PieceTable = PieceTables.Cultivator;
                pieceConfig108.CraftingStation = CraftingStations.Workbench;
                pieceConfig108.Category = "Decorative Plants";
                pieceConfig108.AddRequirement(new RequirementConfig("PlantSeedMeadows_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "MeadowsBush03P_RtD", true, pieceConfig108));

                PieceConfig pieceConfig109 = new PieceConfig();
                pieceConfig109.PieceTable = PieceTables.Cultivator;
                pieceConfig109.CraftingStation = CraftingStations.Workbench;
                pieceConfig109.Category = "Decorative Plants";
                pieceConfig109.AddRequirement(new RequirementConfig("PlantSeedMeadows_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "MeadowsBush3P_RtD", true, pieceConfig109));

                PieceConfig pieceConfig110 = new PieceConfig();
                pieceConfig110.PieceTable = PieceTables.Cultivator;
                pieceConfig110.CraftingStation = CraftingStations.Workbench;
                pieceConfig110.Category = "Decorative Plants";
                pieceConfig110.AddRequirement(new RequirementConfig("PlantSeedMeadows_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "MeadowsBush04P_RtD", true, pieceConfig110));

                PieceConfig pieceConfig111 = new PieceConfig();
                pieceConfig111.PieceTable = PieceTables.Cultivator;
                pieceConfig111.CraftingStation = CraftingStations.Workbench;
                pieceConfig111.Category = "Decorative Plants";
                pieceConfig111.AddRequirement(new RequirementConfig("PlantSeedMeadows_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "MeadowsBush4P_RtD", true, pieceConfig111));

                PieceConfig pieceConfig112 = new PieceConfig();
                pieceConfig112.PieceTable = PieceTables.Cultivator;
                pieceConfig112.CraftingStation = CraftingStations.Workbench;
                pieceConfig112.Category = "Decorative Plants";
                pieceConfig112.AddRequirement(new RequirementConfig("PlantSeedMeadows_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "MeadowsBush05P_RtD", true, pieceConfig112));

                PieceConfig pieceConfig113 = new PieceConfig();
                pieceConfig113.PieceTable = PieceTables.Cultivator;
                pieceConfig113.CraftingStation = CraftingStations.Workbench;
                pieceConfig113.Category = "Decorative Plants";
                pieceConfig113.AddRequirement(new RequirementConfig("PlantSeedMeadows_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "MeadowsBush5P_RtD", true, pieceConfig113));

                PieceConfig pieceConfig114 = new PieceConfig();
                pieceConfig114.PieceTable = PieceTables.Cultivator;
                pieceConfig114.CraftingStation = CraftingStations.Workbench;
                pieceConfig114.Category = "Decorative Plants";
                pieceConfig114.AddRequirement(new RequirementConfig("PlantSeedMeadows_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "MeadowsBush06P_RtD", true, pieceConfig114));

                PieceConfig pieceConfig115 = new PieceConfig();
                pieceConfig115.PieceTable = PieceTables.Cultivator;
                pieceConfig115.CraftingStation = CraftingStations.Workbench;
                pieceConfig115.Category = "Decorative Plants";
                pieceConfig115.AddRequirement(new RequirementConfig("PlantSeedMeadows_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "SmallBushP_RtD", true, pieceConfig115));

                //Mistlands
                
                PieceConfig pieceConfig116 = new PieceConfig();
                pieceConfig116.PieceTable = PieceTables.Cultivator;
                pieceConfig116.CraftingStation = CraftingStations.Workbench;
                pieceConfig116.Category = "Decorative Plants";
                pieceConfig116.AddRequirement(new RequirementConfig("PlantSeedMistlands_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "MistLandsBush1P_RtD", true, pieceConfig116));

                PieceConfig pieceConfig117 = new PieceConfig();
                pieceConfig117.PieceTable = PieceTables.Cultivator;
                pieceConfig117.CraftingStation = CraftingStations.Workbench;
                pieceConfig117.Category = "Decorative Plants";
                pieceConfig117.AddRequirement(new RequirementConfig("PlantSeedMistlands_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "MistLandsBush2P_RtD", true, pieceConfig117));

                PieceConfig pieceConfig118 = new PieceConfig();
                pieceConfig118.PieceTable = PieceTables.Cultivator;
                pieceConfig118.CraftingStation = CraftingStations.Workbench;
                pieceConfig118.Category = "Decorative Plants";
                pieceConfig118.AddRequirement(new RequirementConfig("PlantSeedMistlands_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "MistLandsBush3P_RtD", true, pieceConfig118));
                
                PieceConfig pieceConfig119 = new PieceConfig();
                pieceConfig119.PieceTable = PieceTables.Cultivator;
                pieceConfig119.CraftingStation = CraftingStations.Workbench;
                pieceConfig119.Category = "Decorative Plants";
                pieceConfig119.AddRequirement(new RequirementConfig("PlantSeedMistlands_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "MistLandsBush4P_RtD", true, pieceConfig119));

                PieceConfig pieceConfig120 = new PieceConfig();
                pieceConfig120.PieceTable = PieceTables.Cultivator;
                pieceConfig120.CraftingStation = CraftingStations.Workbench;
                pieceConfig120.Category = "Decorative Plants";
                pieceConfig120.AddRequirement(new RequirementConfig("PlantSeedMistlands_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "MistLandsBush5P_RtD", true, pieceConfig120));

                PieceConfig pieceConfig121 = new PieceConfig();
                pieceConfig121.PieceTable = PieceTables.Cultivator;
                pieceConfig121.CraftingStation = CraftingStations.Workbench;
                pieceConfig121.Category = "Decorative Plants";
                pieceConfig121.AddRequirement(new RequirementConfig("PlantSeedMistlands_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "MistLandsBush6P_RtD", true, pieceConfig121));

                /*PieceConfig pieceConfig122 = new PieceConfig();
                pieceConfig122.PieceTable = PieceTables.Cultivator;
                pieceConfig122.CraftingStation = CraftingStations.Workbench;
                pieceConfig122.Category = "Decorative Plants";
                pieceConfig122.AddRequirement(new RequirementConfig("PlantSeedMistlands_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "xxx", true, pieceConfig122));*/

                PieceConfig pieceConfig123 = new PieceConfig();
                pieceConfig123.PieceTable = PieceTables.Cultivator;
                pieceConfig123.CraftingStation = CraftingStations.Workbench;
                pieceConfig123.Category = "Decorative Plants";
                pieceConfig123.AddRequirement(new RequirementConfig("PlantSeedMistlands_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "MistLandsBush7P_RtD", true, pieceConfig123));

                //Mountains
                
                PieceConfig pieceConfig124 = new PieceConfig();
                pieceConfig124.PieceTable = PieceTables.Cultivator;
                pieceConfig124.CraftingStation = CraftingStations.Workbench;
                pieceConfig124.Category = "Decorative Plants";
                pieceConfig124.AddRequirement(new RequirementConfig("PlantSeedMountain_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "EverGreen1P_RtD", true, pieceConfig124));

                PieceConfig pieceConfig125 = new PieceConfig();
                pieceConfig125.PieceTable = PieceTables.Cultivator;
                pieceConfig125.CraftingStation = CraftingStations.Workbench;
                pieceConfig125.Category = "Decorative Plants";
                pieceConfig125.AddRequirement(new RequirementConfig("PlantSeedMountain_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "EverGreen2P_RtD", true, pieceConfig125));

                PieceConfig pieceConfig126 = new PieceConfig();
                pieceConfig126.PieceTable = PieceTables.Cultivator;
                pieceConfig126.CraftingStation = CraftingStations.Workbench;
                pieceConfig126.Category = "Decorative Plants";
                pieceConfig126.AddRequirement(new RequirementConfig("PlantSeedMountain_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "EverGreen3P_RtD", true, pieceConfig126));

                PieceConfig pieceConfig127 = new PieceConfig();
                pieceConfig127.PieceTable = PieceTables.Cultivator;
                pieceConfig127.CraftingStation = CraftingStations.Workbench;
                pieceConfig127.Category = "Decorative Plants";
                pieceConfig127.AddRequirement(new RequirementConfig("PlantSeedMountain_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "EverGreen4P_RtD", true, pieceConfig127));

                PieceConfig pieceConfig128 = new PieceConfig();
                pieceConfig128.PieceTable = PieceTables.Cultivator;
                pieceConfig128.CraftingStation = CraftingStations.Workbench;
                pieceConfig128.Category = "Decorative Plants";
                pieceConfig128.AddRequirement(new RequirementConfig("PlantSeedMountain_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "MountainBush1P_RtD", true, pieceConfig128));

                PieceConfig pieceConfig129 = new PieceConfig();
                pieceConfig129.PieceTable = PieceTables.Cultivator;
                pieceConfig129.CraftingStation = CraftingStations.Workbench;
                pieceConfig129.Category = "Decorative Plants";
                pieceConfig129.AddRequirement(new RequirementConfig("PlantSeedMountain_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "MountainBush2P_RtD", true, pieceConfig129));

                PieceConfig pieceConfig130 = new PieceConfig();
                pieceConfig130.PieceTable = PieceTables.Cultivator;
                pieceConfig130.CraftingStation = CraftingStations.Workbench;
                pieceConfig130.Category = "Decorative Plants";
                pieceConfig130.AddRequirement(new RequirementConfig("PlantSeedMountain_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "MountainBush3P_RtD", true, pieceConfig130));

                // Plains
                
                PieceConfig pieceConfig131 = new PieceConfig();
                pieceConfig131.PieceTable = PieceTables.Cultivator;
                pieceConfig131.CraftingStation = CraftingStations.Workbench;
                pieceConfig131.Category = "Decorative Plants";
                pieceConfig131.AddRequirement(new RequirementConfig("PlantSeedPlains_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "PlainsBush1P_RtD", true, pieceConfig131));

                PieceConfig pieceConfig132 = new PieceConfig();
                pieceConfig132.PieceTable = PieceTables.Cultivator;
                pieceConfig132.CraftingStation = CraftingStations.Workbench;
                pieceConfig132.Category = "Decorative Plants";
                pieceConfig132.AddRequirement(new RequirementConfig("PlantSeedPlains_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "PlainsBush2P_RtD", true, pieceConfig132));

                PieceConfig pieceConfig133 = new PieceConfig();
                pieceConfig133.PieceTable = PieceTables.Cultivator;
                pieceConfig133.CraftingStation = CraftingStations.Workbench;
                pieceConfig133.Category = "Decorative Plants";
                pieceConfig133.AddRequirement(new RequirementConfig("PlantSeedPlains_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "PlainsBush3P_RtD", true, pieceConfig133));

                PieceConfig pieceConfig134 = new PieceConfig();
                pieceConfig134.PieceTable = PieceTables.Cultivator;
                pieceConfig134.CraftingStation = CraftingStations.Workbench;
                pieceConfig134.Category = "Decorative Plants";
                pieceConfig134.AddRequirement(new RequirementConfig("PlantSeedPlains_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "PlainsBush4P_RtD", true, pieceConfig134));

                PieceConfig pieceConfig135 = new PieceConfig();
                pieceConfig135.PieceTable = PieceTables.Cultivator;
                pieceConfig135.CraftingStation = CraftingStations.Workbench;
                pieceConfig135.Category = "Decorative Plants";
                pieceConfig135.AddRequirement(new RequirementConfig("PlantSeedPlains_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "PlainsBush5P_RtD", true, pieceConfig135));

                PieceConfig pieceConfig136 = new PieceConfig();
                pieceConfig136.PieceTable = PieceTables.Cultivator;
                pieceConfig136.CraftingStation = CraftingStations.Workbench;
                pieceConfig136.Category = "Decorative Plants";
                pieceConfig136.AddRequirement(new RequirementConfig("PlantSeedPlains_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "PlainsBush6P_RtD", true, pieceConfig136));

                PieceConfig pieceConfig137 = new PieceConfig();
                pieceConfig137.PieceTable = PieceTables.Cultivator;
                pieceConfig137.CraftingStation = CraftingStations.Workbench;
                pieceConfig137.Category = "Decorative Plants";
                pieceConfig137.AddRequirement(new RequirementConfig("PlantSeedPlains_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "PlainsBush7P_RtD", true, pieceConfig137));

                PieceConfig pieceConfig138 = new PieceConfig();
                pieceConfig138.PieceTable = PieceTables.Cultivator;
                pieceConfig138.CraftingStation = CraftingStations.Workbench;
                pieceConfig138.Category = "Decorative Plants";
                pieceConfig138.AddRequirement(new RequirementConfig("PlantSeedPlains_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "PlainsBush8P_RtD", true, pieceConfig138));

                // Swamps
                
                PieceConfig pieceConfig139 = new PieceConfig();
                pieceConfig139.PieceTable = PieceTables.Cultivator;
                pieceConfig139.CraftingStation = CraftingStations.Workbench;
                pieceConfig139.Category = "Decorative Plants";
                pieceConfig139.AddRequirement(new RequirementConfig("PlantSeedSwamp_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "DeadIvy1P_RtD", true, pieceConfig139));

                PieceConfig pieceConfig140 = new PieceConfig();
                pieceConfig140.PieceTable = PieceTables.Cultivator;
                pieceConfig140.CraftingStation = CraftingStations.Workbench;
                pieceConfig140.Category = "Decorative Plants";
                pieceConfig140.AddRequirement(new RequirementConfig("PlantSeedSwamp_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "DeadIvy2P_RtD", true, pieceConfig140));

                PieceConfig pieceConfig141 = new PieceConfig();
                pieceConfig141.PieceTable = PieceTables.Cultivator;
                pieceConfig141.CraftingStation = CraftingStations.Workbench;
                pieceConfig141.Category = "Decorative Plants";
                pieceConfig141.AddRequirement(new RequirementConfig("PlantSeedSwamp_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "SwampBush1P_RtD", true, pieceConfig141));

                PieceConfig pieceConfig142 = new PieceConfig();
                pieceConfig142.PieceTable = PieceTables.Cultivator;
                pieceConfig142.CraftingStation = CraftingStations.Workbench;
                pieceConfig142.Category = "Decorative Plants";
                pieceConfig142.AddRequirement(new RequirementConfig("PlantSeedSwamp_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "SwampBush2P_RtD", true, pieceConfig142));

                PieceConfig pieceConfig143 = new PieceConfig();
                pieceConfig143.PieceTable = PieceTables.Cultivator;
                pieceConfig143.CraftingStation = CraftingStations.Workbench;
                pieceConfig143.Category = "Decorative Plants";
                pieceConfig143.AddRequirement(new RequirementConfig("PlantSeedSwamp_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "SwampBush3P_RtD", true, pieceConfig143));

                PieceConfig pieceConfig144 = new PieceConfig();
                pieceConfig144.PieceTable = PieceTables.Cultivator;
                pieceConfig144.CraftingStation = CraftingStations.Workbench;
                pieceConfig144.Category = "Decorative Plants";
                pieceConfig144.AddRequirement(new RequirementConfig("PlantSeedSwamp_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "SwampBush4P_RtD", true, pieceConfig144));

                PieceConfig pieceConfig145 = new PieceConfig();
                pieceConfig145.PieceTable = PieceTables.Cultivator;
                pieceConfig145.CraftingStation = CraftingStations.Workbench;
                pieceConfig145.Category = "Decorative Plants";
                pieceConfig145.AddRequirement(new RequirementConfig("PlantSeedSwamp_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "SwampBush5P_RtD", true, pieceConfig145));

                PieceConfig pieceConfig146 = new PieceConfig();
                pieceConfig146.PieceTable = PieceTables.Cultivator;
                pieceConfig146.CraftingStation = CraftingStations.Workbench;
                pieceConfig146.Category = "Decorative Plants";
                pieceConfig146.AddRequirement(new RequirementConfig("PlantSeedSwamp_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "SwampBush6P_RtD", true, pieceConfig146));

                PieceConfig pieceConfig147 = new PieceConfig();
                pieceConfig147.PieceTable = PieceTables.Cultivator;
                pieceConfig147.CraftingStation = CraftingStations.Workbench;
                pieceConfig147.Category = "Decorative Plants";
                pieceConfig147.AddRequirement(new RequirementConfig("PlantSeedSwamp_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "SwampBush7P_RtD", true, pieceConfig147));

                PieceConfig pieceConfig148 = new PieceConfig();
                pieceConfig148.PieceTable = PieceTables.Cultivator;
                pieceConfig148.CraftingStation = CraftingStations.Workbench;
                pieceConfig148.Category = "Decorative Plants";
                pieceConfig148.AddRequirement(new RequirementConfig("PlantSeedSwamp_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "SwampBush8P_RtD", true, pieceConfig148));

                PieceConfig pieceConfig149 = new PieceConfig();
                pieceConfig149.PieceTable = PieceTables.Cultivator;
                pieceConfig149.CraftingStation = CraftingStations.Workbench;
                pieceConfig149.Category = "Decorative Plants";
                pieceConfig149.AddRequirement(new RequirementConfig("PlantSeedSwamp_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "SwampBush9P_RtD", true, pieceConfig149));

                PieceConfig pieceConfig150 = new PieceConfig();
                pieceConfig150.PieceTable = PieceTables.Cultivator;
                pieceConfig150.CraftingStation = CraftingStations.Workbench;
                pieceConfig150.Category = "Decorative Plants";
                pieceConfig150.AddRequirement(new RequirementConfig("PlantSeedSwamp_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "SwampBush10P_RtD", true, pieceConfig150));

                PieceConfig pieceConfig151 = new PieceConfig();
                pieceConfig151.PieceTable = PieceTables.Cultivator;
                pieceConfig151.CraftingStation = CraftingStations.Workbench;
                pieceConfig151.Category = "Decorative Plants";
                pieceConfig151.AddRequirement(new RequirementConfig("PlantSeedSwamp_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "SwampBush11P_RtD", true, pieceConfig151));

                PieceConfig pieceConfig152 = new PieceConfig();
                pieceConfig152.PieceTable = PieceTables.Cultivator;
                pieceConfig152.CraftingStation = CraftingStations.Workbench;
                pieceConfig152.Category = "Decorative Plants";
                pieceConfig152.AddRequirement(new RequirementConfig("PlantSeedSwamp_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "SwampBush12P_RtD", true, pieceConfig152));

                PieceConfig pieceConfig153 = new PieceConfig();
                pieceConfig153.PieceTable = PieceTables.Cultivator;
                pieceConfig153.CraftingStation = CraftingStations.Workbench;
                pieceConfig153.Category = "Decorative Plants";
                pieceConfig153.AddRequirement(new RequirementConfig("PlantSeedSwamp_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "SwampBush13P_RtD", true, pieceConfig153));

                /*PieceConfig pieceConfig154 = new PieceConfig();
                pieceConfig154.PieceTable = PieceTables.Cultivator;
                pieceConfig154.CraftingStation = CraftingStations.Workbench;
                pieceConfig154.Category = "Decorative Plants";
                pieceConfig154.AddRequirement(new RequirementConfig("PlantSeedSwamp_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "xxx", true, pieceConfig154));*/

                PieceConfig pieceConfig155 = new PieceConfig();
                pieceConfig155.PieceTable = PieceTables.Cultivator;
                pieceConfig155.CraftingStation = CraftingStations.Workbench;
                pieceConfig155.Category = "Decorative Plants";
                pieceConfig155.AddRequirement(new RequirementConfig("PlantSeedSwamp_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "SwampBush14P_RtD", true, pieceConfig155));

                // Meadows Shrooms
                
                PieceConfig pieceConfig156 = new PieceConfig();
                pieceConfig156.PieceTable = PieceTables.Cultivator;
                pieceConfig156.CraftingStation = CraftingStations.Workbench;
                pieceConfig156.Category = "Decorative Mushrooms";
                pieceConfig156.AddRequirement(new RequirementConfig("PlantSeedMeadows_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "MeadowsShroom1P_RtD", true, pieceConfig156));

                PieceConfig pieceConfig157 = new PieceConfig();
                pieceConfig157.PieceTable = PieceTables.Cultivator;
                pieceConfig157.CraftingStation = CraftingStations.Workbench;
                pieceConfig157.Category = "Decorative Mushrooms";
                pieceConfig157.AddRequirement(new RequirementConfig("PlantSeedMeadows_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "MeadowsShroom2P_RtD", true, pieceConfig157));

                PieceConfig pieceConfig158 = new PieceConfig();
                pieceConfig158.PieceTable = PieceTables.Cultivator;
                pieceConfig158.CraftingStation = CraftingStations.Workbench;
                pieceConfig158.Category = "Decorative Mushrooms";
                pieceConfig158.AddRequirement(new RequirementConfig("PlantSeedMeadows_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "MeadowsShroom3P_RtD", true, pieceConfig158));

                PieceConfig pieceConfig159 = new PieceConfig();
                pieceConfig159.PieceTable = PieceTables.Cultivator;
                pieceConfig159.CraftingStation = CraftingStations.Workbench;
                pieceConfig159.Category = "Decorative Mushrooms";
                pieceConfig159.AddRequirement(new RequirementConfig("PlantSeedMeadows_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "MeadowsShroom4P_RtD", true, pieceConfig159));

                // BlackForest Shrooms
                
                PieceConfig pieceConfig160 = new PieceConfig();
                pieceConfig160.PieceTable = PieceTables.Cultivator;
                pieceConfig160.CraftingStation = CraftingStations.Workbench;
                pieceConfig160.Category = "Decorative Mushrooms";
                pieceConfig160.AddRequirement(new RequirementConfig("PlantSeedBlackForest_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "BlackShroom1P_RtD", true, pieceConfig160));
                
                PieceConfig pieceConfig161 = new PieceConfig();
                pieceConfig161.PieceTable = PieceTables.Cultivator;
                pieceConfig161.CraftingStation = CraftingStations.Workbench;
                pieceConfig161.Category = "Decorative Mushrooms";
                pieceConfig161.AddRequirement(new RequirementConfig("PlantSeedBlackForest_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "BlackShroom2P_RtD", true, pieceConfig161));

                PieceConfig pieceConfig162 = new PieceConfig();
                pieceConfig162.PieceTable = PieceTables.Cultivator;
                pieceConfig162.CraftingStation = CraftingStations.Workbench;
                pieceConfig162.Category = "Decorative Mushrooms";
                pieceConfig162.AddRequirement(new RequirementConfig("PlantSeedBlackForest_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "BlackShroom3P_RtD", true, pieceConfig162));

                PieceConfig pieceConfig163 = new PieceConfig();
                pieceConfig163.PieceTable = PieceTables.Cultivator;
                pieceConfig163.CraftingStation = CraftingStations.Workbench;
                pieceConfig163.Category = "Decorative Mushrooms";
                pieceConfig163.AddRequirement(new RequirementConfig("PlantSeedBlackForest_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "BlackShroom4P_RtD", true, pieceConfig163));

                // Swamp Shrooms
                
                PieceConfig pieceConfig164 = new PieceConfig();
                pieceConfig164.PieceTable = PieceTables.Cultivator;
                pieceConfig164.CraftingStation = CraftingStations.Workbench;
                pieceConfig164.Category = "Decorative Mushrooms";
                pieceConfig164.AddRequirement(new RequirementConfig("PlantSeedSwamp_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "GreenShroom1P_RtD", true, pieceConfig164));

                PieceConfig pieceConfig165 = new PieceConfig();
                pieceConfig165.PieceTable = PieceTables.Cultivator;
                pieceConfig165.CraftingStation = CraftingStations.Workbench;
                pieceConfig165.Category = "Decorative Mushrooms";
                pieceConfig165.AddRequirement(new RequirementConfig("PlantSeedSwamp_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "GreenShroom2P_RtD", true, pieceConfig165));

                PieceConfig pieceConfig166 = new PieceConfig();
                pieceConfig166.PieceTable = PieceTables.Cultivator;
                pieceConfig166.CraftingStation = CraftingStations.Workbench;
                pieceConfig166.Category = "Decorative Mushrooms";
                pieceConfig166.AddRequirement(new RequirementConfig("PlantSeedSwamp_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "GreenShroom3P_RtD", true, pieceConfig166));

                PieceConfig pieceConfig167 = new PieceConfig();
                pieceConfig167.PieceTable = PieceTables.Cultivator;
                pieceConfig167.CraftingStation = CraftingStations.Workbench;
                pieceConfig167.Category = "Decorative Mushrooms";
                pieceConfig167.AddRequirement(new RequirementConfig("PlantSeedSwamp_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "GreenShroom4P_RtD", true, pieceConfig167));

                // Mistlands Shrooms
                
                PieceConfig pieceConfig168 = new PieceConfig();
                pieceConfig168.PieceTable = PieceTables.Cultivator;
                pieceConfig168.CraftingStation = CraftingStations.Workbench;
                pieceConfig168.Category = "Decorative Mushrooms";
                pieceConfig168.AddRequirement(new RequirementConfig("PlantSeedMistlands_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "BlueShroom1P_RtD", true, pieceConfig168));

                PieceConfig pieceConfig169 = new PieceConfig();
                pieceConfig169.PieceTable = PieceTables.Cultivator;
                pieceConfig169.CraftingStation = CraftingStations.Workbench;
                pieceConfig169.Category = "Decorative Mushrooms";
                pieceConfig169.AddRequirement(new RequirementConfig("Wood", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "BlueShroom2P_RtD", true, pieceConfig169));

                PieceConfig pieceConfig170 = new PieceConfig();
                pieceConfig170.PieceTable = PieceTables.Cultivator;
                pieceConfig170.CraftingStation = CraftingStations.Workbench;
                pieceConfig170.Category = "Decorative Mushrooms";
                pieceConfig170.AddRequirement(new RequirementConfig("Wood", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "BlueShroom3P_RtD", true, pieceConfig170));

                PieceConfig pieceConfig171 = new PieceConfig();
                pieceConfig171.PieceTable = PieceTables.Cultivator;
                pieceConfig171.CraftingStation = CraftingStations.Workbench;
                pieceConfig171.Category = "Decorative Mushrooms";
                pieceConfig171.AddRequirement(new RequirementConfig("PlantSeedMistlands_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "BlueShroom4P_RtD", true, pieceConfig171));

                PieceConfig pieceConfig172 = new PieceConfig();
                pieceConfig172.PieceTable = PieceTables.Cultivator;
                pieceConfig172.CraftingStation = CraftingStations.Workbench;
                pieceConfig172.Category = "Decorative Mushrooms";
                pieceConfig172.AddRequirement(new RequirementConfig("PlantSeedMistlands_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "YellowShroom1P_RtD", true, pieceConfig172));

                PieceConfig pieceConfig173 = new PieceConfig();
                pieceConfig173.PieceTable = PieceTables.Cultivator;
                pieceConfig173.CraftingStation = CraftingStations.Workbench;
                pieceConfig173.Category = "Decorative Mushrooms";
                pieceConfig173.AddRequirement(new RequirementConfig("PlantSeedMistlands_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "YellowShroom2P_RtD", true, pieceConfig173));

                PieceConfig pieceConfig174 = new PieceConfig();
                pieceConfig174.PieceTable = PieceTables.Cultivator;
                pieceConfig174.CraftingStation = CraftingStations.Workbench;
                pieceConfig174.Category = "Decorative Mushrooms";
                pieceConfig174.AddRequirement(new RequirementConfig("PlantSeedMistlands_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "YellowShroom3P_RtD", true, pieceConfig174));

                PieceConfig pieceConfig175 = new PieceConfig();
                pieceConfig175.PieceTable = PieceTables.Cultivator;
                pieceConfig175.CraftingStation = CraftingStations.Workbench;
                pieceConfig175.Category = "Decorative Mushrooms";
                pieceConfig175.AddRequirement(new RequirementConfig("PlantSeedMistlands_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "YellowShroom4P_RtD", true, pieceConfig175));

                // AshLands Shrooms
                
                PieceConfig pieceConfig176 = new PieceConfig();
                pieceConfig176.PieceTable = PieceTables.Cultivator;
                pieceConfig176.CraftingStation = CraftingStations.Workbench;
                pieceConfig176.Category = "Decorative Mushrooms";
                pieceConfig176.AddRequirement(new RequirementConfig("PlantSeedAshLands_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "RedShroom1P_RtD", true, pieceConfig176));

                PieceConfig pieceConfig177 = new PieceConfig();
                pieceConfig177.PieceTable = PieceTables.Cultivator;
                pieceConfig177.CraftingStation = CraftingStations.Workbench;
                pieceConfig177.Category = "Decorative Mushrooms";
                pieceConfig177.AddRequirement(new RequirementConfig("Wood", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "RedShroom2P_RtD", true, pieceConfig177));

                PieceConfig pieceConfig178 = new PieceConfig();
                pieceConfig178.PieceTable = PieceTables.Cultivator;
                pieceConfig178.CraftingStation = CraftingStations.Workbench;
                pieceConfig178.Category = "Decorative Mushrooms";
                pieceConfig178.AddRequirement(new RequirementConfig("Wood", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "RedShroom3P_RtD", true, pieceConfig178));

                PieceConfig pieceConfig179 = new PieceConfig();
                pieceConfig179.PieceTable = PieceTables.Cultivator;
                pieceConfig179.CraftingStation = CraftingStations.Workbench;
                pieceConfig179.Category = "Decorative Mushrooms";
                pieceConfig179.AddRequirement(new RequirementConfig("Wood", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "RedShroom4P_RtD", true, pieceConfig179));

                // Mountain Shrooms
                
                PieceConfig pieceConfig180 = new PieceConfig();
                pieceConfig180.PieceTable = PieceTables.Cultivator;
                pieceConfig180.CraftingStation = CraftingStations.Workbench;
                pieceConfig180.Category = "Decorative Mushrooms";
                pieceConfig180.AddRequirement(new RequirementConfig("PlantSeedMountain_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "MountainShroom1P_RtD", true, pieceConfig180));

                PieceConfig pieceConfig181 = new PieceConfig();
                pieceConfig181.PieceTable = PieceTables.Cultivator;
                pieceConfig181.CraftingStation = CraftingStations.Workbench;
                pieceConfig181.Category = "Decorative Mushrooms";
                pieceConfig181.AddRequirement(new RequirementConfig("PlantSeedMountain_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "MountainShroom2P_RtD", true, pieceConfig181));

                PieceConfig pieceConfig182 = new PieceConfig();
                pieceConfig182.PieceTable = PieceTables.Cultivator;
                pieceConfig182.CraftingStation = CraftingStations.Workbench;
                pieceConfig182.Category = "Decorative Mushrooms";
                pieceConfig182.AddRequirement(new RequirementConfig("PlantSeedMountain_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "MountainShroom3P_RtD", true, pieceConfig182));

                PieceConfig pieceConfig183 = new PieceConfig();
                pieceConfig183.PieceTable = PieceTables.Cultivator;
                pieceConfig183.CraftingStation = CraftingStations.Workbench;
                pieceConfig183.Category = "Decorative Mushrooms";
                pieceConfig183.AddRequirement(new RequirementConfig("PlantSeedMountain_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "MountainShroom4P_RtD", true, pieceConfig183));

                // AshLands
                
                PieceConfig pieceConfig184 = new PieceConfig();
                pieceConfig184.PieceTable = PieceTables.Cultivator;
                pieceConfig184.CraftingStation = CraftingStations.Workbench;
                pieceConfig184.Category = "Decorative Plants";
                pieceConfig184.AddRequirement(new RequirementConfig("PlantSeedAshLands_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "AshLandsBush1P_RtD", true, pieceConfig184));

                PieceConfig pieceConfig185 = new PieceConfig();
                pieceConfig185.PieceTable = PieceTables.Cultivator;
                pieceConfig185.CraftingStation = CraftingStations.Workbench;
                pieceConfig185.Category = "Decorative Plants";
                pieceConfig185.AddRequirement(new RequirementConfig("PlantSeedAshLands_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "AshLandsBush2P_RtD", true, pieceConfig185));

                PieceConfig pieceConfig186 = new PieceConfig();
                pieceConfig186.PieceTable = PieceTables.Cultivator;
                pieceConfig186.CraftingStation = CraftingStations.Workbench;
                pieceConfig186.Category = "Decorative Plants";
                pieceConfig186.AddRequirement(new RequirementConfig("PlantSeedPlains_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "AshLandsBush3P_RtD", true, pieceConfig186));

                PieceConfig pieceConfig187 = new PieceConfig();
                pieceConfig187.PieceTable = PieceTables.Cultivator;
                pieceConfig187.CraftingStation = CraftingStations.Workbench;
                pieceConfig187.Category = "Decorative Plants";
                pieceConfig187.AddRequirement(new RequirementConfig("PlantSeedPlains_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "AshLandsBush4P_RtD", true, pieceConfig187));

                PieceConfig pieceConfig188 = new PieceConfig();
                pieceConfig188.PieceTable = PieceTables.Cultivator;
                pieceConfig188.CraftingStation = CraftingStations.Workbench;
                pieceConfig188.Category = "Decorative Plants";
                pieceConfig188.AddRequirement(new RequirementConfig("PlantSeedAshLands_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "AshLandsBush5P_RtD", true, pieceConfig188));

                PieceConfig pieceConfig189 = new PieceConfig();
                pieceConfig189.PieceTable = PieceTables.Cultivator;
                pieceConfig189.CraftingStation = CraftingStations.Workbench;
                pieceConfig189.Category = "Decorative Plants";
                pieceConfig189.AddRequirement(new RequirementConfig("PlantSeedAshLands_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "AshLandsBush6P_RtD", true, pieceConfig189));

                PieceConfig pieceConfig190 = new PieceConfig();
                pieceConfig190.PieceTable = PieceTables.Cultivator;
                pieceConfig190.CraftingStation = CraftingStations.Workbench;
                pieceConfig190.Category = "Decorative Plants";
                pieceConfig190.AddRequirement(new RequirementConfig("PlantSeedAshLands_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "AshLandsBush7P_RtD", true, pieceConfig190));

                PieceConfig pieceConfig191 = new PieceConfig();
                pieceConfig191.PieceTable = PieceTables.Cultivator;
                pieceConfig191.CraftingStation = CraftingStations.Workbench;
                pieceConfig191.Category = "Decorative Plants";
                pieceConfig191.AddRequirement(new RequirementConfig("PlantSeedAshLands_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "AshLandsBush8P_RtD", true, pieceConfig191));

                PieceConfig pieceConfig192 = new PieceConfig();
                pieceConfig192.PieceTable = PieceTables.Cultivator;
                pieceConfig192.CraftingStation = CraftingStations.Workbench;
                pieceConfig192.Category = "Decorative Plants";
                pieceConfig192.AddRequirement(new RequirementConfig("PlantSeedAshLands_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "AshLandsBush9P_RtD", true, pieceConfig192));

                PieceConfig pieceConfig193 = new PieceConfig();
                pieceConfig193.PieceTable = PieceTables.Cultivator;
                pieceConfig193.CraftingStation = CraftingStations.Workbench;
                pieceConfig193.Category = "Decorative Plants";
                pieceConfig193.AddRequirement(new RequirementConfig("PlantSeedAshLands_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "AshLandsBush10P_RtD", true, pieceConfig193));

                PieceConfig pieceConfig194 = new PieceConfig();
                pieceConfig194.PieceTable = PieceTables.Cultivator;
                pieceConfig194.CraftingStation = CraftingStations.Workbench;
                pieceConfig194.Category = "Decorative Plants";
                pieceConfig194.AddRequirement(new RequirementConfig("PlantSeedAshLands_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "AshLandsBush11P_RtD", true, pieceConfig194));

                PieceConfig pieceConfig195 = new PieceConfig();
                pieceConfig195.PieceTable = PieceTables.Cultivator;
                pieceConfig195.CraftingStation = CraftingStations.Workbench;
                pieceConfig195.Category = "Decorative Plants";
                pieceConfig195.AddRequirement(new RequirementConfig("PlantSeedAshLands_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "AshLandsBush12P_RtD", true, pieceConfig195));

                PieceConfig pieceConfig196 = new PieceConfig();
                pieceConfig196.PieceTable = PieceTables.Cultivator;
                pieceConfig196.CraftingStation = CraftingStations.Workbench;
                pieceConfig196.Category = "Decorative Plants";
                pieceConfig196.AddRequirement(new RequirementConfig("PlantSeedAshLands_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "AshLandsBush13P_RtD", true, pieceConfig196));

                PieceConfig pieceConfig197 = new PieceConfig();
                pieceConfig197.PieceTable = PieceTables.Cultivator;
                pieceConfig197.CraftingStation = CraftingStations.Workbench;
                pieceConfig197.Category = "Decorative Plants";
                pieceConfig197.AddRequirement(new RequirementConfig("PlantSeedAshLands_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "AshLandsBush14P_RtD", true, pieceConfig197));

                PieceConfig pieceConfig198 = new PieceConfig();
                pieceConfig198.PieceTable = PieceTables.Cultivator;
                pieceConfig198.CraftingStation = CraftingStations.Workbench;
                pieceConfig198.Category = "Decorative Plants";
                pieceConfig198.AddRequirement(new RequirementConfig("PlantSeedAshLands_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "AshLandsBush15P_RtD", true, pieceConfig198));

                PieceConfig pieceConfig199 = new PieceConfig();
                pieceConfig199.PieceTable = PieceTables.Cultivator;
                pieceConfig199.CraftingStation = CraftingStations.Workbench;
                pieceConfig199.Category = "Decorative Plants";
                pieceConfig199.AddRequirement(new RequirementConfig("PlantSeedAshLands_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "AshLandsBush16P_RtD", true, pieceConfig199));

                PieceConfig pieceConfig200 = new PieceConfig();
                pieceConfig200.PieceTable = PieceTables.Cultivator;
                pieceConfig200.CraftingStation = CraftingStations.Workbench;
                pieceConfig200.Category = "Decorative Plants";
                pieceConfig200.AddRequirement(new RequirementConfig("PlantSeedPlains_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "AshLandsBush17P_RtD", true, pieceConfig200));
                
                PieceConfig pieceConfig201 = new PieceConfig();
                pieceConfig201.PieceTable = PieceTables.Cultivator;
                pieceConfig201.CraftingStation = CraftingStations.Workbench;
                pieceConfig201.Category = "Decorative Plants";
                pieceConfig201.AddRequirement(new RequirementConfig("PlantSeedPlains_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "AshLandsBush18P_RtD", true, pieceConfig201));

                PieceConfig pieceConfig202 = new PieceConfig();
                pieceConfig202.PieceTable = PieceTables.Cultivator;
                pieceConfig202.CraftingStation = CraftingStations.Workbench;
                pieceConfig202.Category = "Decorative Plants";
                pieceConfig202.AddRequirement(new RequirementConfig("PlantSeedPlains_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "AshLandsBush19P_RtD", true, pieceConfig202));

                PieceConfig pieceConfig203 = new PieceConfig();
                pieceConfig203.PieceTable = PieceTables.Cultivator;
                pieceConfig203.CraftingStation = CraftingStations.Workbench;
                pieceConfig203.Category = "Decorative Plants";
                pieceConfig203.AddRequirement(new RequirementConfig("PlantSeedPlains_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "AshLandsBush20P_RtD", true, pieceConfig203));

                PieceConfig pieceConfig204 = new PieceConfig();
                pieceConfig204.PieceTable = PieceTables.Cultivator;
                pieceConfig204.CraftingStation = CraftingStations.Workbench;
                pieceConfig204.Category = "Decorative Plants";
                pieceConfig204.AddRequirement(new RequirementConfig("PlantSeedPlains_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "AshLandsBush21P_RtD", true, pieceConfig204));

                PieceConfig pieceConfig205 = new PieceConfig();
                pieceConfig205.PieceTable = PieceTables.Cultivator;
                pieceConfig205.CraftingStation = CraftingStations.Workbench;
                pieceConfig205.Category = "Decorative Plants";
                pieceConfig205.AddRequirement(new RequirementConfig("PlantSeedPlains_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "AshLandsBush22P_RtD", true, pieceConfig205));

                PieceConfig pieceConfig206 = new PieceConfig();
                pieceConfig206.PieceTable = PieceTables.Cultivator;
                pieceConfig206.CraftingStation = CraftingStations.Workbench;
                pieceConfig206.Category = "Decorative Plants";
                pieceConfig206.AddRequirement(new RequirementConfig("PlantSeedPlains_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "AshLandsBush23P_RtD", true, pieceConfig206));

                PieceConfig pieceConfig207 = new PieceConfig();
                pieceConfig207.PieceTable = PieceTables.Cultivator;
                pieceConfig207.CraftingStation = CraftingStations.Workbench;
                pieceConfig207.Category = "Decorative Plants";
                pieceConfig207.AddRequirement(new RequirementConfig("PlantSeedPlains_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "AshLandsBush24P_RtD", true, pieceConfig207));

                PieceConfig pieceConfig208 = new PieceConfig();
                pieceConfig208.PieceTable = PieceTables.Cultivator;
                pieceConfig208.CraftingStation = CraftingStations.Workbench;
                pieceConfig208.Category = "Decorative Plants";
                pieceConfig208.AddRequirement(new RequirementConfig("PlantSeedPlains_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "AshLandsBush25P_RtD", true, pieceConfig208));

                PieceConfig pieceConfig209 = new PieceConfig();
                pieceConfig209.PieceTable = PieceTables.Cultivator;
                pieceConfig209.CraftingStation = CraftingStations.Workbench;
                pieceConfig209.Category = "Decorative Plants";
                pieceConfig209.AddRequirement(new RequirementConfig("PlantSeedPlains_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this.MyAssets, "AshLandsBush26P_RtD", true, pieceConfig209));
                
            }
            catch (Exception arg)
            {
                Logger.LogWarning(string.Format("Exception caught while adding configuration values: {0}", arg));
            }
        }
    }
} 
 
