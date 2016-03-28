using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemySpawn : MonoBehaviour
    {
        public float spawnRate;
        public GameObject spawn;

        private float _nextSpawn;

        void Awake()
        {
            _nextSpawn = 0.0f;
        }

        public bool CanSpawn()
        {
            return Time.time > _nextSpawn;
        }

        public GameObject Spawn()
        {
            _nextSpawn = Time.time + spawnRate;
            return Instantiate (spawn, transform.position, transform.rotation) as GameObject;
        }
    }
}
