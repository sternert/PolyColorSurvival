using System.Collections.Generic;
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
                    _enemies.Add(newEnemyAI);
                }
            }

            foreach (var enemyAi in _enemies)
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

    }
}
