using Assets.Scripts.Game.Manager;
using Assets.Scripts.Game.World;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game.GuiControllers
{
    public class CollectIndicatorElement : MonoBehaviour
    {
        public Text CollectionText;
        public BoxType Type;
        

        private AnimationState _state=AnimationState.None;
        private readonly float _scaleFactor=1.2f; 

        protected virtual void OnEnable()
        {
            Calcuate();
        }

        public void Calcuate()
        {
            Debug.Log("Calculate");
            CollectionText.text = GameManager.Instance.ReturnScore(Type);
        }

        protected virtual void Update()
        {
            if (transform.localScale.x < _scaleFactor && _state == AnimationState.StartScaleUp)
                transform.localScale *= 1 + Time.deltaTime*3;
            if (transform.localScale.x >= _scaleFactor && _state == AnimationState.StartScaleUp)
                _state = AnimationState.StartScaleDown;
            if (transform.localScale.x > 1 && _state == AnimationState.StartScaleDown)
                transform.localScale *= 1 - Time.deltaTime*3;
            if (transform.localScale.x <= 1 && _state == AnimationState.StartScaleDown)
            {
                transform.localScale=Vector3.one;
                _state = AnimationState.None;
                Calcuate();
            }
        }

        public void StartAnimate()
        {
            _state = AnimationState.StartScaleUp;
        }

        private enum AnimationState
        {
            StartScaleUp,
            StartScaleDown,
            None
        }
    }
}
