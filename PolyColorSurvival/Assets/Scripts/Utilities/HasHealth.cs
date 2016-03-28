using Assets.Scripts.Enemy;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    [RequireComponent(typeof(IEnemyAI))]
    public class HasHealth : MonoBehaviour
    {
        public float health;

        public void Damage(float damage)
        {
            health -= damage;
            if (health <= 0)
            {
                var enemyAi = GetComponent<IEnemyAI>();
                enemyAi.DestroySelf();
            }
        }
    }
}
