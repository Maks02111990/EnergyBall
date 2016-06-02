using System;
using Assets.Scripts.Game.GameResources;
using Assets.Scripts.Game.GuiControllers;
using Assets.Scripts.Game.World;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Game.Manager
{
    public class GameManager : MonoBehaviour
    {
        private const int MainMenuGuiId = 6;
        private const int MapGuiId = 5;

        public float TimeInSec;
        public event Action WinLevel;

        private int _blueBoxesCount;
        private int _redBoxesCount;
        private int _blueBoxesTaked;
        private int _redBoxesTaked;

        private int _score;

        private static GameManager _instance;

        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<GameManager>();
                return _instance;
            }
            private set { }
        }

        void Awake()
        {
            ResourcesLoader.Instance.Initialize();
            Instantiate(ResourcesLoader.Instance.GetResourceById(MainMenuGuiId));
        }

        public int GetScore()
        {
            return _score;
        }
        public void OnEnergyBlockTake(EnergyBox box)
        {
            _score += box.Energy;
            switch (box.Type)
            {
                case BoxType.BlueBox:
                    _blueBoxesTaked += 1;
                    
                    break;
                case BoxType.RedBox:
                    _redBoxesTaked += 1;
                    break;
            }
        }

        public string ReturnScore(BoxType type)
        {
            string text = "";
            switch (type)
            {
                case BoxType.BlueBox:
                    text = string.Format("{0}/{1}", _blueBoxesTaked, _blueBoxesCount);
                    break;
                case BoxType.RedBox:
                    text = string.Format("{0}/{1}", _redBoxesTaked, _redBoxesCount);
                    break;
            }
            if (_blueBoxesTaked == _blueBoxesCount && _redBoxesTaked == _redBoxesCount)
                WinLevel();
            return text;
        }

        public Vector2 GetBoxesCount()
        {
            var counter = new Vector2(_blueBoxesCount, _redBoxesCount);
            return counter;
        }

        public void StartGame()
        {
            TimeInSec = 0;
            _score = 0;
            _blueBoxesCount = Random.Range(4, 8);
            _redBoxesCount = Random.Range(2, 5);
            _blueBoxesTaked = 0;
            _redBoxesTaked = 0;
            if(FindObjectOfType<RandomMapGenerator>()!=null)
                Destroy(FindObjectOfType<RandomMapGenerator>().gameObject);
            if (GameObject.Find("Player") != null)
                Destroy(GameObject.Find("Player"));
            Instantiate(ResourcesLoader.Instance.GetResourceById(MapGuiId));
            ScoreGuiController.Instance.gameObject.SetActive(true);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
            TimeInSec += Time.deltaTime;
        }

}
}
