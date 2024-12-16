using enemy;
using System;
using UnityEngine;
using Utils;

namespace Player
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private int damage = 10; 
        [SerializeField] private float attackRange = 5f; 
        [SerializeField] private float attackCooldown = 1f; 
        [SerializeField] private float attackTimer = 0f; 
        [SerializeField] private LayerMask enemy;
        private GameObject _enemy;
        void Update()
        {
            attackTimer -= Time.deltaTime; 
        /*
            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, attackRange);
            foreach (var enemy in enemies)
            {
                if (enemy.CompareTag("Enemy") && attackTimer <= 0)
                {
                    enemy.GetComponent<Health>().TakeDamage(damage); 
                    attackTimer = attackCooldown; 
                }
            }
            */
        }

        private void OnCollisionStay2D (Collision2D other)
        {
            if (LayerMaskCheck.ContainsLayer(enemy, other.gameObject.layer))
            {
                if (attackTimer <= 0)
                {
                    other.gameObject.GetComponent<enemyHealth>().TakeDamage(damage);
                    attackTimer = attackCooldown;
                }
            }
        }
    }
}