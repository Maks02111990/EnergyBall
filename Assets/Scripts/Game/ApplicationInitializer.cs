using System;
using Assets.Scripts.Game.GameResources;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game
{
    public class ApplicationInitializer : MonoBehaviour
    {
        void Awake()
        {
            ResourcesLoader.Instance.Initialize();
            SceneManager.LoadScene("Main");
        }
    }
}
