using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 50; 
    private CoinManager coinManager; 
    public Transform[] waypoints; 

    void Start()
    {
        coinManager = FindObjectOfType<CoinManager>(); 
    }

    public void TakeDamage(int damage)
    {
        health -= damage; 
        if (health <= 0)
        {
            Die(); 
        }
    }

    private void Die()
    {
        if (coinManager != null)
        {
            coinManager.AddCoins(20); 
        }
        Destroy(gameObject); 
    }

    
    void Update()
    {
        
    }
}