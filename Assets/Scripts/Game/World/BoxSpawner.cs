
using System;
using System.Collections;
using Assets.Scripts.Game.GameResources;
using UnityEngine;

namespace Assets.Scripts.Game.World
{
    public class BoxSpawner 
    {
        private const int EnergyBoxId = 4;
        private const int BlueMaterialId = 9;
        private const int RedMaterialId = 10;

        private static BoxSpawner _instance;
        public static BoxSpawner Instance
        {
            get
            {
                if (_instance==null)
                    _instance=new BoxSpawner();
                return _instance;
            }
        }

        public void SpawnNewEnergyBox(BoxType type, Vector3 position)
        {
            var go = GameObject.Instantiate(ResourcesLoader.Instance.GetResourceById(EnergyBoxId), position, Quaternion.identity) as GameObject;
            go.tag = "EnergyBox";
            var energyBox = go.GetComponent<EnergyBox>();
            switch (type)
            {
                case BoxType.BlueBox:
                    energyBox.Energy = 1;
                    go.GetComponent<MeshRenderer>().material = ResourcesLoader.Instance.GetResourceById(BlueMaterialId) as Material;
                    break;
                case BoxType.RedBox:
                    energyBox.Energy = 3;
                    go.GetComponent<MeshRenderer>().material = ResourcesLoader.Instance.GetResourceById(RedMaterialId) as Material;
                    break;
            }
            energyBox.Type = type;
        }
    }

    

    public enum BoxType
    {
        BlueBox,
        RedBox
    }
}
