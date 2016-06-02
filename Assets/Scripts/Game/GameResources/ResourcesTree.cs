using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Game.GameResources
{
    public class ResourcesTree
    {
        Dictionary<int, DirectoryData> _directories;
        Dictionary<int, AssetData> _assets;
        Dictionary<int, ResourceData> _resources;

        /// <summary>
        /// метод не обрабатывает ошибки
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetDirectory(int id)
        {
            var path = _directories[id].Path;
            if (_directories[id].ParentId >= 0)
            {
                path = GetDirectory(_directories[id].ParentId) +"/"+ path;
            }
            return path;
        }

        /// <summary>
        /// метод не обрабатывает ошибки
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetAsset(int id)
        {
            var path = _assets[id].Name;
            path = GetDirectory(_assets[id].DirectoryId) + "/" + path;
            return path;
        }

        /// <summary>
        /// метод не обрабатывает ошибки
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetResource(int id)
        {
            var path = _resources[id].Name;
            path = GetDirectory(_resources[id].DirectoryId) +"/"+ path;
            return path;
        }

        /// <summary>
        /// метод не обрабатывает ошибки
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetAssetPathByResourcesId(int id)
        {
            return GetAsset(_resources[id].AssetId);
        }

        public void Initialize(ResourcesData resourcesData)
        {
            _directories = resourcesData.DirectoryDatas.ToDictionary(data=>data.Id);
            _assets = resourcesData.AssetDatas.ToDictionary(data => data.Id);
            _resources = resourcesData.ResourceDatas.ToDictionary(data => data.Id);
        }

    }
}
