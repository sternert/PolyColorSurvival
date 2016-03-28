using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public interface IEnemyAI
    {
        void SetTargets(GameObject[] targets);
        GameObject GetGameObject();

        bool CanMakeAction();
        bool CanMove();

        void MakeAction();
        void Move();
        void SetEnemyManager(EnemyManager enemyManager);
        void DestroySelf();
    }
}
