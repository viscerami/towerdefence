using UnityEngine;

namespace Player
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private int damage = 10; 
        [SerializeField] private float attackRange = 5f; 
        [SerializeField] private float attackCooldown = 1f; 
        [SerializeField] private float attackTimer = 0f; 
        void Update()
        {
            attackTimer -= Time.deltaTime; 
        
            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, attackRange);
            foreach (var enemy in enemies)
            {
                if (enemy.CompareTag("Enemy") && attackTimer <= 0)
                {
                    enemy.GetComponent<Health>().TakeDamage(damage); 
                    attackTimer = attackCooldown; 
                }
            }
        }
    }
}