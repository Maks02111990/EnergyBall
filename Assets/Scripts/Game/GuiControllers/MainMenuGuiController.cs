using Assets.Scripts.Game.GameResources;
using Assets.Scripts.Game.Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game.GuiControllers
{
    public class MainMenuGuiController : MonoBehaviour
    {
        public void StartGame()
        {
            GetComponent<Animator>().SetBool("Start",true);
        }

        void LoadGame()
        {
            GameManager.Instance.StartGame();
        }

        void ShowScoreGui()
        {
            Destroy(gameObject);
        }
    }
}
