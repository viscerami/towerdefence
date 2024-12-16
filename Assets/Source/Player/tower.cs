using enemy;
using System;
using UnityEngine;
using Utils;

namespace Player
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private int damage = 10; 
        [SerializeField] private float attackCooldown = 1f; 
        [SerializeField] private float attackTimer = 0f; 
        [SerializeField] private LayerMask enemy;
        void Update()
        {
            //attackTimer -= Time.deltaTime; 
        }
        
        private void OnTriggerStay2D(Collider2D other)
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