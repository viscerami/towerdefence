using UnityEngine;

public class Tower : MonoBehaviour
{
    public int damage = 10; 
    public float attackRange = 5f; 
    public float attackCooldown = 1f; 

    private float attackTimer = 0f; 

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