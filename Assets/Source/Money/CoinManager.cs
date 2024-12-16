using UnityEngine;
using UnityEngine.Serialization;

namespace Money
{
    public class CoinManager : MonoBehaviour
    {

        [SerializeField] public int totalCoins = 100; 
        [SerializeField] private CoinDisplay coinDisplay; 
        public bool SpendCoins(int amount)
        {
            if (totalCoins >= amount)
            {
                totalCoins -= amount;
                UpdateCoinDisplay(); 
                return true; 
            }
            return false; 
        }
        public void AddCoins(int amount)
        {
            totalCoins += amount;
            UpdateCoinDisplay(); 
            Debug.Log("Вы получили золото! Текущая сумма: " + totalCoins);
        }
        public int GetCoins()
        {
            return totalCoins;
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