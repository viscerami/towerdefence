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
        private void Start()
        {
            player = FindObjectOfType<PlayerHealth>();
            lastWaypointSwitchTime = Time.time;
        }
        private void Update()
        {
            Move();
            attackTimer -= Time.deltaTime; 
        }

        public override void Move()
        {
            if (_tryAttackTower)
            {
                return;
            }
            base.Move();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (LayerMaskCheck.ContainsLayer(tower, other.gameObject.layer))
            {
                _tryAttackTower = false;
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (LayerMaskCheck.ContainsLayer(tower, other.gameObject.layer))
            {
                _tryAttackTower = true;
                if (other != null)
                {
                    other.gameObject.GetComponent<TowerHealth>();
                    if (attackTimer <= 0)
                    {
                        other.gameObject.GetComponent<TowerHealth>().TakeDamage(damage);
                        attackTimer = attackCooldown;
                    }
                }
                
            }
        }
    }
}
