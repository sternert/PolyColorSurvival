using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Collider2D))]
    public class PlayerShot : MonoBehaviour
    {
        public float damage;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Enemy")
            {
                var hasHealth = other.gameObject.GetComponent<HasHealth>();
                hasHealth.Damage(damage);
                Destroy(gameObject);
            }
            if (other.tag == "Object")
            {
                Destroy(gameObject);
            }
        }
    }
}
