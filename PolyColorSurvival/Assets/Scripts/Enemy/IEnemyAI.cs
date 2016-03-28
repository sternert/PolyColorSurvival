using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public interface IEnemyAI
    {
        void SetTargets(GameObject[] targets);

        bool CanMakeAction();
        bool CanMove();

        void MakeAction();
        void Move();
    }
}
