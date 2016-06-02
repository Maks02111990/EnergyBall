using System.Collections;
using Assets.Scripts.Game.GameResources;
using Assets.Scripts.Game.Manager;
using Assets.Scripts.Game.World;
using UnityEngine;

namespace Assets.Scripts.Game.GuiControllers
{
    public class ScoreGuiController : MonoBehaviour
    {
        private const int WinLevelGuiController=8;
        private const int ScoreGui = 7;
        public CollectIndicatorElement BlueIndicator;
        public CollectIndicatorElement RedIndicarot;

        private static ScoreGuiController _instance;

        public static ScoreGuiController Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<ScoreGuiController>();
                if (_instance == null)
                    _instance = Instantiate(ResourcesLoader.Instance.GetResourceById(ScoreGui) as GameObject).GetComponent<ScoreGuiController>();
                return _instance;
            }
        }

        void Awake()
        {
            GameManager.Instance.WinLevel+=GameManagerOnWinLevel;
        }

        public Vector3 GetPosition(BoxType type)
        {
            Ray ray;
            Vector3 pos;
            switch (type)
            {
                case BoxType.BlueBox:
                    ray = Camera.main.ScreenPointToRay(BlueIndicator.transform.position);
                    pos = ray.origin + ray.direction*2;
                    return Camera.main.transform.InverseTransformPoint(pos);
                case BoxType.RedBox:
                    ray = Camera.main.ScreenPointToRay(RedIndicarot.transform.position);
                    pos = ray.origin + ray.direction*2;
                    return Camera.main.transform.InverseTransformPoint(pos);
            }
            return Vector2.zero;
        }

        public void AnimateIndicator(BoxType type)
        {
            switch (type)
            {
                case BoxType.BlueBox:
                    BlueIndicator.StartAnimate();
                    break;
                case BoxType.RedBox:
                    RedIndicarot.StartAnimate();
                    break;
            }
        }

        private void GameManagerOnWinLevel()
        {
            GetComponent<Animator>().SetBool("WinLEvel", true);
        }

        private void LevelEnded()
        {
            StartCoroutine(WinLevelCoroutine());
        }

        void OnDestroy()
        {
            if(GameManager.Instance!=null)
            GameManager.Instance.WinLevel -= GameManagerOnWinLevel;
        }

        IEnumerator WinLevelCoroutine()
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(ResourcesLoader.Instance.GetResourceById(WinLevelGuiController));
            GetComponent<Animator>().SetBool("WinLEvel", false);
            gameObject.SetActive(false);
        }
    }
}
