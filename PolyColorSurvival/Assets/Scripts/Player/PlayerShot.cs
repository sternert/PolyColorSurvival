using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Collider2D))]
    public class PlayerShot : MonoBehaviour
    {
        public float damage;
        public GameObject shotParticle;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Enemy")
            {
                var hasHealth = other.gameObject.GetComponent<HasHealth>();
                hasHealth.Damage(damage);
                CreateShotParticle(transform.position);
                Destroy(gameObject);
            }
            if (other.tag == "Object")
            {
                CreateShotParticle(transform.position);
                Destroy(gameObject);
            }
        }

        private void CreateShotParticle(Vector3 position)
        {
            Instantiate(shotParticle, position, Quaternion.identity);
        }
    }
}
