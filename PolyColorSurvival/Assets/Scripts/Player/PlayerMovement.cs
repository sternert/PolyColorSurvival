using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed;

        private Rigidbody2D _rigidbody;

        void Awake ()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
	
        void FixedUpdate ()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            var mouse = Input.mousePosition;
            MovePlayer(horizontal, vertical);
            RotatePlayer(new Vector2(mouse.x, mouse.y));
        }

        private void RotatePlayer(Vector2 mouse)
        {
            var playerPositionInScreen = (Vector2)Camera.main.WorldToScreenPoint(_rigidbody.position);
            var playerToMouse = mouse - playerPositionInScreen;
            var angle2 = Mathf.Atan2(playerToMouse.x, playerToMouse.y)*Mathf.Rad2Deg;
            _rigidbody.MoveRotation(-angle2);
        }

        private void MovePlayer(float horizontal, float vertical)
        {
            var movement = new Vector2(horizontal, vertical);
            movement = movement.normalized*Time.fixedDeltaTime*speed;

            _rigidbody.MovePosition(_rigidbody.position + movement);
        }
    }
}
