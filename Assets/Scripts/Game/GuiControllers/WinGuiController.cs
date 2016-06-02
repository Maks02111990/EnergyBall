using System;
using Assets.Scripts.Game.Manager;
using Assets.Scripts.Game.World;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Game.GuiControllers
{
    public class WinGuiController : MonoBehaviour
    {
        public Text Time;

        public void Restart()
        {
            GetComponent<Animator>().SetBool("Restart",true);
        }

        protected void ShowResult()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            var finalTyme = (int) GameManager.Instance.TimeInSec;
            var score = GameManager.Instance.GetScore();
            Time.text = String.Format("{0} очков за {1} мин. {2} сек.",score , finalTyme / 60, finalTyme%60);
        }

        protected void LoadLevel()
        {
            GameManager.Instance.StartGame();
        }

        protected void UnloadThisGui()
        {
            Destroy(gameObject);
        }
    }
}
