using System;
using Assets.Scripts.Game.GameResources;
using Assets.Scripts.Game.Manager;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Game.World
{
    public class RandomMapGenerator : MonoBehaviour
    {
        public Transform SpawnPoint;
        private const int PlayerResourceId = 3;


        private Bounds _bounds;

        private void SpawnPlayer()
        {
            Instantiate(ResourcesLoader.Instance.GetResourceById(PlayerResourceId) as GameObject, SpawnPoint.position, Quaternion.identity).name="Player";
            FindObjectOfType<Camera>().tag = "MainCamera";
        }

        private void SpawnEnergyBoxes(Vector2 counterRB)
        {
            Debug.Log("GetValues");
            for (int i = 0; i < counterRB.x; i++)
            {
                BoxSpawner.Instance.SpawnNewEnergyBox(BoxType.BlueBox, GetRandomMapPosition());
            }
            for (int i = 0; i < counterRB.y; i++)
            {
               BoxSpawner.Instance.SpawnNewEnergyBox(BoxType.RedBox, GetRandomMapPosition());
            }
        }

        void Awake()
        {
            _bounds = GetComponent<MeshFilter>().mesh.bounds;
            SpawnPlayer();
            SpawnEnergyBoxes(GameManager.Instance.GetBoxesCount());
        }

        public Vector3 GetRandomMapPosition()
        {
            var position = new Vector3(Random.Range(_bounds.min.x*transform.localScale.x+0.25f,_bounds.max.x * transform.localScale.x - 0.25f), 0.25f, Random.Range(_bounds.min.z * transform.localScale.z + 0.25f, _bounds.max.z * transform.localScale.z - 0.25f));
            if (Vector3.Distance(SpawnPoint.position, position) < 2)
                position = GetRandomMapPosition();
            return position;
        }
    }
}
