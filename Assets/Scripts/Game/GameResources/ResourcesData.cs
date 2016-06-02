using System.Collections.Generic;

namespace Assets.Scripts.Game.GameResources
{
    public class ResourcesData
    {
        public List<DirectoryData> DirectoryDatas;
        public List<AssetData> AssetDatas; 
        public List<ResourceData> ResourceDatas;

        public static ResourcesData GetCurrentResourcesData()
        {
            ResourcesData resourcesData = new ResourcesData
            {
                DirectoryDatas = new List<DirectoryData>
                {
                    new DirectoryData
                    {
                        Id = 0,
                        ParentId = -1,
                        Path = "AssetBundles"
                    },
                    new DirectoryData
                    {
                        Id = 1,
                        ParentId = -1,
                        Path = "Assets"
                    },
                    new DirectoryData
                    {
                        Id = 2,
                        ParentId = 1,
                        Path = "Resources"
                    },
                    new DirectoryData
                    {
                        Id = 3,
                        ParentId = 2,
                        Path = "EnergyBoxes"
                    },
                    new DirectoryData
                    {
                        Id = 4,
                        ParentId = 2,
                        Path = "Player"
                    },
                    new DirectoryData
                    {
                        Id = 5,
                        ParentId = 2,
                        Path = "World"
                    },
                    new DirectoryData
                    {
                        Id = 6,
                        ParentId = 2,
                        Path = "GUI"
                    }

                },


                AssetDatas = new List<AssetData>
                {
                    new AssetData
                    {
                        Id = 0,
                        DirectoryId = 0,
                        Name = "map"
                    },
                    new AssetData
                    {
                        Id = 1,
                        DirectoryId = 0,
                        Name = "player"
                    },
                    new AssetData
                    {
                        Id = 2,
                        DirectoryId = 0,
                        Name = "energybox"
                    },
                    new AssetData
                    {
                        Id=3,
                        DirectoryId = 0,
                        Name = "bluematerial"
                    },
                    new AssetData
                    {
                        Id = 4,
                        DirectoryId = 0,
                        Name = "redmaterial"
                    },
                    new AssetData
                    {
                        Id = 5,
                        DirectoryId = 0,
                        Name = "mainmenugui"
                    },
                    new AssetData
                    {
                        Id = 6,
                        DirectoryId = 0,
                        Name = "scoregui"
                    },
                    new AssetData
                    {
                        Id = 7,
                        DirectoryId = 0,
                        Name = "resultgui"
                    }
                },


                ResourceDatas = new List<ResourceData>
                {
                    new ResourceData
                    {
                        Id = 0,
                        AssetId = 5,
                        DirectoryId = 6,
                        Name = "MainMenuGui.prefab"
                    },
                    new ResourceData
                    {
                        Id = 1,
                        AssetId = 6,
                        DirectoryId = 6,
                        Name = "ScoreGuiController.prefab"
                    },
                    new ResourceData
                    {
                        Id = 2,
                        AssetId = 7,
                        DirectoryId = 6,
                        Name = "ResultGui.prefab"
                    },
                    new ResourceData
                    {
                        Id = 3,
                        AssetId = 1,
                        DirectoryId = 4,
                        Name = "Player.prefab"
                    },
                    new ResourceData
                    {
                        Id = 4,
                        AssetId = 2,
                        DirectoryId = 3,
                        Name = "EnergyBox.prefab"
                    },
                    new ResourceData
                    {
                        Id = 5,
                        AssetId = 0,
                        DirectoryId = 5,
                        Name = "Map.prefab"
                    },
                    new ResourceData
                    {
                        Id =6 ,
                        AssetId =5,
                        DirectoryId = 6,
                        Name = "MainMenuGui.prefab"
                    },
                    new ResourceData
                    {
                        Id = 7,
                        AssetId =6,
                        DirectoryId = 6,
                        Name = "ScoreGuiController.prefab"
                    },
                    new ResourceData
                    {
                        Id = 8,
                        AssetId =7,
                        DirectoryId = 6,
                        Name = "ResultGui.prefab"
                    },
                    new ResourceData
                    {
                        Id = 9,
                        AssetId = 3,
                        DirectoryId = 3,
                        Name = "BlueBoxMaterial.mat"
                    },
                    new ResourceData
                    {
                        Id = 10,
                        AssetId = 4,
                        DirectoryId = 3,
                        Name = "RedBoxMaterial.mat"
                    }
                }
            };
            return resourcesData;
        }
    }
}
