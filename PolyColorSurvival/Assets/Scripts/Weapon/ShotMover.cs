using UnityEngine;

namespace Assets.Scripts.Weapon
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ShotMover : MonoBehaviour
    {
        private Rigidbody2D _rigidBody;
        private Vector2 _start;
        private float _range;

        void Awake()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        public void SetVelocity(Vector2 newVelocity)
        {
            _rigidBody.velocity = newVelocity;
        }

        public void SetRange(float range)
        {
            _start = _rigidBody.position;
            _range = range;
        }

        void FixedUpdate()
        {
            if ((_rigidBody.position - _start).magnitude > _range)
            {
                Destroy(gameObject);
            }
        }

    }
}
