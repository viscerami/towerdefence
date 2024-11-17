using UnityEngine;

namespace Money
{
    public class CoinManager : MonoBehaviour
    {
        [SerializeField] private int _totalCoins = 100; 
        [SerializeField] private CoinDisplay coinDisplay; 
        public bool SpendCoins(int amount)
        {
            if (_totalCoins >= amount)
            {
                _totalCoins -= amount;
                UpdateCoinDisplay(); 
                return true; 
            }
            return false; 
        }
        public void AddCoins(int amount)
        {
            _totalCoins += amount;
            UpdateCoinDisplay(); 
        }
        public int GetCoins()
        {
            return _totalCoins;
        }
        private void UpdateCoinDisplay()
        {
            if (coinDisplay != null)
            {
                coinDisplay.UpdateCoinDisplay();
            }
        }
    }
}