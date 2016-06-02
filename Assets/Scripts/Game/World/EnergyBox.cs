using System;
using Assets.Scripts.Game.GuiControllers;
using Assets.Scripts.Game.Manager;
using UnityEngine;

namespace Assets.Scripts.Game.World
{
    public class EnergyBox : MonoBehaviour
    {
        public int Energy;
        public BoxType Type;
        public event Action<EnergyBox> BlockTaked;
        private bool _isTaked;
        private Vector3 _finalPosition;

        public void Take()
        {
            Destroy(GetComponent<Collider>());
            _isTaked = true;
            transform.SetParent(Camera.main.transform);
            _finalPosition = ScoreGuiController.Instance.GetPosition(Type);
            
        }

        void Update()
        {
            if(!_isTaked)
                return;
            var direction = _finalPosition-transform.localPosition;
            var normalizeDirection = direction.normalized;
            var speed = Math.Min(5, direction.magnitude);
            transform.localPosition += normalizeDirection*Time.deltaTime*speed*5;
            transform.localScale = Vector3.one*Math.Min(1,direction.magnitude);
            if (direction.magnitude<0.1f)
            { 
                Destroy(gameObject);
                GameManager.Instance.OnEnergyBlockTake(this);
                ScoreGuiController.Instance.AnimateIndicator(Type);
            }
        }
    }
}
