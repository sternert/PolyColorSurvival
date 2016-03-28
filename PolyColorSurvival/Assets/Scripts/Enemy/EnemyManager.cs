using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyManager : MonoBehaviour
    {
        public GameObject[] targets;

        private IList<IEnemyAI> _enemies;
        private EnemySpawn[] _spawns;

        void Awake()
        {
            _spawns = GetComponentsInChildren<EnemySpawn>();
            _enemies = new List<IEnemyAI>();
        }

        void FixedUpdate()
        {
            foreach (var enemySpawn in _spawns)
            {
                if (enemySpawn.CanSpawn())
                {
                    var newEnemy = enemySpawn.Spawn();
                    var newEnemyAI = newEnemy.GetComponent<IEnemyAI>();
                    newEnemyAI.SetTargets(targets);
                    newEnemyAI.SetEnemyManager(this);
                    _enemies.Add(newEnemyAI);
                }
            }

            var updateEnemies = _enemies.ToList();
            foreach (var enemyAi in updateEnemies)
            {
                if (enemyAi.CanMakeAction())
                {
                    enemyAi.MakeAction();
                }
                if (enemyAi.CanMove())
                {
                    enemyAi.Move();
                }
            }
        }

        public void DestroySelf(EnemyAI enemyAi)
        {
            _enemies.Remove(enemyAi);
            Destroy(enemyAi.GetGameObject());
        }
    }
}
