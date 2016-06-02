using Assets.Scripts.Game.World;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Game.Controllers
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [Range(1.0f, 5.0f)]
        public float MovieSpeed;
        private CharacterController _charController;
        
        void Awake()
        {
            _charController = GetComponent<CharacterController>();
            _charController.detectCollisions = true;
        }

        void Update()
        {
            if (Input.GetAxis("Vertical") != 0)
            {
                _charController.SimpleMove(transform.TransformDirection(new Vector3(0, 0, Input.GetAxis("Vertical"))) * MovieSpeed);
            }
            if (Input.GetAxis("Horizontal") != 0)
            {
                transform.eulerAngles += Quaternion.Euler(new Vector3(0, Input.GetAxis("Horizontal"), 0)).eulerAngles;
            }
        }

        void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (hit.gameObject.tag == "EnergyBox")
            {
                hit.gameObject.GetComponent<EnergyBox>().Take();
            }
        }
    }
}
