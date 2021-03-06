﻿using Assets.Scripts.MainManagers;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        public float speed;

        private Rigidbody2D _rigidbody;

        void Awake ()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Restart()
        {
            _rigidbody.position = Vector2.zero;
            _rigidbody.rotation = 0;
        }
	
        void FixedUpdate ()
        {
            if (StateManager.CurrentState == GameState.Active)
            {
                var horizontal = Input.GetAxis("Horizontal");
                var vertical = Input.GetAxis("Vertical");
                var mouse = Input.mousePosition;
                MovePlayer(horizontal, vertical);
                RotatePlayer(new Vector2(mouse.x, mouse.y));
            }
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
