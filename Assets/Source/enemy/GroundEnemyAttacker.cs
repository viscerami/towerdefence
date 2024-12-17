using enemy;
using Player;
using System;
using UnityEngine;
using Utils;

namespace enemy
{
    public class GroundEnemyAttacker : MoveEnemy
    {
        [SerializeField] private LayerMask tower;
        [SerializeField] private float attackTimer;// Интервал между атаками
        [SerializeField] private float attackCooldown;
        public bool _tryAttackTower;
        private TowerHealth _currentTower;

        public override void Update()
        {
            base.Update();
            attackTimer -= Time.deltaTime; 
        }

        protected override void Move()
        {
            if (_tryAttackTower)
            {
                return;
            }
            base.Move();
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent<TowerHealth>(out TowerHealth tower))
            {
                if (_currentTower == tower)
                {
                    _currentTower.OnTowerAttacked -= ChangeMood; 
                    _currentTower = null; 
                }
            }
        }
        
        private void OnTriggerStay2D(Collider2D other)
        {
            if (_currentTower != null) 
            {
                if (attackTimer <= 0) 
                {
                    _currentTower.TakeDamage(damage);
                    attackTimer = attackCooldown;
                }
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<TowerHealth>(out TowerHealth tower))
            {
                ChangeMood();
                _currentTower = tower; 
                _currentTower.OnTowerAttacked += ChangeMood; 
            }
        }

        private void ChangeMood()
        {
            _tryAttackTower = !_tryAttackTower;
        }
    }
}
