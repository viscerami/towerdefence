using Money;
using UnityEngine;

namespace enemy
{
    public class Enemy : MonoBehaviour
    {
        private readonly int _maxHealth = 50;
        public int CurHealth; 
        private CoinManager _coinManager; 
        void Start()
        {
            CurHealth = _maxHealth;
            _coinManager = FindObjectOfType<CoinManager>(); 
        }
        public void TakeDamage(int damage)
        {
            CurHealth -= damage; 
            if (CurHealth <= 0)
            {
                Die(); 
            }
        }
        private void Die()
        {
            if (_coinManager != null)
            {
                _coinManager.AddCoins(20); 
            }
            Destroy(gameObject); 
        }
    }
}