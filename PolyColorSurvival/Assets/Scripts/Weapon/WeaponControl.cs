using UnityEngine;

namespace Assets.Scripts.Weapon
{
    public class WeaponControl : MonoBehaviour {

        public GameObject shot;
        public Transform shotSpawn;
        public float shotRange;
        public float shotSpeed;
        public float fireRate;

        private float _nextShot;

        void Start()
        {
            _nextShot = 0.0f;
        }

        public bool CanAttack()
        {
            return Time.time > _nextShot;
        }

        public void Attack()
        {
            var newShotObject = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
            var newShotMover = newShotObject.GetComponent<ShotMover>();

            var velocity = shotSpawn.up * shotSpeed;
            var velocityVector2 = new Vector2(velocity.x, velocity.y);
            newShotMover.SetVelocity(velocityVector2);
            newShotMover.SetRange(shotRange);
            _nextShot = Time.time + fireRate;
        }
    }
}
