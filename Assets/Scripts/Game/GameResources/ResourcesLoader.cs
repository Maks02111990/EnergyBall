using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game.GameResources
{
    public sealed class ResourcesLoader
    {
        private static ResourcesLoader _instance;
        public static ResourcesLoader Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ResourcesLoader();
                return _instance;
            }
        }
        private ResourcesLoader() { }
        private ResourcesTree _resourcesTree = new ResourcesTree();

        private ResourcesData _resourcesData;
        private ResourcesData ResourcesData
        {
            get
            {
                if (_resourcesData == null)
                    _resourcesData = ResourcesData.GetCurrentResourcesData();
                return _resourcesData;
            }
        }

        private Dictionary<string, AssetBundle> _assetBundles;

        public void Initialize()
        {
            _resourcesTree.Initialize(ResourcesData);
            LoadAllAssets(); 
        }

        private void LoadAllAssets()
        {
            foreach (var assetData in ResourcesData.AssetDatas)
            {
                var textAsset = Resources.Load<TextAsset>(_resourcesTree.GetAsset(assetData.Id));
                var asset = AssetBundle.LoadFromMemory(textAsset.bytes);
                if (_assetBundles == null)
                    _assetBundles = new Dictionary<string, AssetBundle>();
                if (!_assetBundles.ContainsKey(_resourcesTree.GetAsset(assetData.Id)))
                    _assetBundles.Add(_resourcesTree.GetAsset(assetData.Id), asset);
            }
        }

        public Object GetResourceById(int id)
        {
            var resource = _resourcesTree.GetResource(id);
            var asset = _resourcesTree.GetAssetPathByResourcesId(id);
            return _assetBundles[asset].LoadAsset(resource);
        }
    }
}
