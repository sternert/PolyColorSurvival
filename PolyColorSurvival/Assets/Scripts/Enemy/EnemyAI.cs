using Assets.Scripts.MainManagers;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyAI : MonoBehaviour, IEnemyAI
    {

        public Collider2D targetAttackRangeCollider;
        public float speed;
        public float actionRate;
        public float _damage;
        public long points;

        private GameObject[] _targets;
        private GameObject _currentMoveTarget;
        private Collider2D _targetCollider;
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
            FindMoveTarget();
            AttackTarget();
            _nextAction = Time.time + actionRate;
        }

        public void PulseAnimation(bool scaleUp)
        {
            if (scaleUp)
            {
                gameObject.transform.localScale = new Vector3(1.15f, 1.15f);
            }
            else
            {
                gameObject.transform.localScale = new Vector3(1f, 1f);
            }
        }

        private void AttackTarget()
        {
            if (_currentMoveTarget)
            { 
                if (_targetCollider)
                {
                    if (targetAttackRangeCollider.IsTouching(_targetCollider))
                    {
                        var playerHealth = _currentMoveTarget.GetComponent<PlayerHealth>();
                        playerHealth.Damage(_damage);
                    }
                }
            }
        }

        private void FindMoveTarget()
        {
            _currentMoveTarget = null;
            var closestDistance = float.MaxValue;
            foreach (var target in _targets)
            {
                var targetDistance = Vector2.Distance(transform.position, target.transform.position);
                if (closestDistance > targetDistance)
                {
                    closestDistance = targetDistance;
                    _currentMoveTarget = target;
                    _targetCollider = _currentMoveTarget.GetComponent<Collider2D>();
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
            StateManager.AddPoints(points);
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
