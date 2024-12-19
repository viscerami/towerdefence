using enemy;
using System;
using UnityEngine;
using UnityEngine.Serialization;
using Utils;

namespace Player
{
    public class TowerAttack : MonoBehaviour
    {
        [SerializeField] private int damage = 10; 
        [SerializeField] private float attackCooldown = 1f; 
        [SerializeField] private float attackTimer = 0f; 
        [SerializeField] private LayerMask enemy;
        [SerializeField] private GameObject projectile;
        [SerializeField] private Transform firePoint;
        
        void Start()
        {
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("tower"), LayerMask.NameToLayer("Slot"));
        }
        
        private void Update()
        {
            attackTimer -= Time.deltaTime; 
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (LayerMaskCheck.ContainsLayer(enemy, other.gameObject.layer))
            {
                if (attackTimer <= 0)
                {
                    GameObject bullet = Instantiate(projectile, firePoint.position, firePoint.rotation);
                    bullet.GetComponent<Projectile>().Initialize(other.transform.position); // Передаем цель в пулю
                    other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
                    attackTimer = attackCooldown;
                }
            }
        }
    }
}