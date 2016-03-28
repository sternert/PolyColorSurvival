﻿using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyAI : MonoBehaviour, IEnemyAI
    {

        public Collider2D targetMoveRangeCollider;
        public float speed;
        public float actionRate;

        private GameObject[] _targets;
        private GameObject _currentTarget;
        private Rigidbody2D _rigidbody;
        private float _nextAction;

        void Awake()
        {
            _nextAction = 0.0f;
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void SetTargets(GameObject[] targets)
        {
            _targets = targets;
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
            _nextAction = Time.time + actionRate;
        }

        private void FindMoveTarget()
        {
            _currentTarget = null;
            foreach (var target in _targets)
            {
                var targetCollider = target.GetComponent<Collider2D>();
                if (targetCollider)
                {
                    if (targetMoveRangeCollider.IsTouching(targetCollider))
                    {
                        _currentTarget = target;
                    }
                }
            }
        }

        public void Move()
        {
            if (_currentTarget)
            {
                RotateTowards(_currentTarget.GetComponent<Rigidbody2D>().position);
                MoveTowards(_currentTarget.GetComponent<Rigidbody2D>().position);
            }
            else
            {
            }
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
