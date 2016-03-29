using System;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyAI : MonoBehaviour, IEnemyAI
    {

        public Collider2D targetMoveRangeCollider;
        public Collider2D targetAttackRangeCollider;
        public float speed;
        public float actionRate;
        public float _damage;

        private GameObject[] _targets;
        private GameObject _currentMoveTarget;
        private Rigidbody2D _rigidbody;
        private float _nextAction;
        private EnemyManager _enemyManager;

        void Awake()
        {
            _nextAction = 0.0f;
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void SetTargets(GameObject[] targets)
        {
            _targets = targets;
        }

        public GameObject GetGameObject()
        {
            return gameObject;
        }

        public bool CanMakeAction()
        {
            return Time.time > _nextAction;
        }

        public bool CanMove()
        {
            return true;
        }

        public void MakeAction()
        {
            AttackTarget();
            FindMoveTarget();
            _nextAction = Time.time + actionRate;
        }

        private void AttackTarget()
        {
            if(_currentMoveTarget)
            { 
                var targetCollider = _currentMoveTarget.GetComponent<Collider2D>();
                if (targetCollider)
                {
                    if (targetAttackRangeCollider.IsTouching(targetCollider))
                    {
                        var playerHealth = _currentMoveTarget.GetComponent<PlayerHealth>();
                        playerHealth.Damage(_damage);
                        // ATTACK TARGET
                        Debug.Log("Attack target!");
                    }
                }
            }
        }

        private void FindMoveTarget()
        {
            _currentMoveTarget = null;
            foreach (var target in _targets)
            {
                var targetCollider = target.GetComponent<Collider2D>();
                if (targetCollider)
                {
                    if (targetMoveRangeCollider.IsTouching(targetCollider))
                    {
                        _currentMoveTarget = target;
                    }
                }
            }
        }

        public void Move()
        {
            if (_currentMoveTarget)
            {
                RotateTowards(_currentMoveTarget.GetComponent<Rigidbody2D>().position);
                MoveTowards(_currentMoveTarget.GetComponent<Rigidbody2D>().position);
            }
        }

        public void SetEnemyManager(EnemyManager enemyManager)
        {
            _enemyManager = enemyManager;
        }

        public void DestroySelf()
        {
            _enemyManager.DestroySelf(this);
        }

        private void RotateTowards(Vector2 target)
        {
            var positionToTarget = target - _rigidbody.position;
            var angle2 = Mathf.Atan2(positionToTarget.x, positionToTarget.y) * Mathf.Rad2Deg;
            _rigidbody.MoveRotation(-angle2);
        }

        private void MoveTowards(Vector2 target)
        {
            var targetDirection = target - _rigidbody.position;
            _rigidbody.MovePosition(_rigidbody.position + targetDirection.normalized * Time.fixedDeltaTime * speed);
        }
    }
}
