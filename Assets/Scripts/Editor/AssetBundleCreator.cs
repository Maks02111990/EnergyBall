using System.IO;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Editor
{
    public class AssetBundleCreator : MonoBehaviour
    {
        private static string AssetPath = "Assets/Resources/AssetBundles";

        [MenuItem("AssetBundle/Create all assets")]
        public static void CreateAllAssets()
        {
            if (!Directory.Exists(AssetPath))
                Directory.CreateDirectory(AssetPath);
            BuildPipeline.BuildAssetBundles(AssetPath);
            AssetDatabase.Refresh();
        }
    }
}
