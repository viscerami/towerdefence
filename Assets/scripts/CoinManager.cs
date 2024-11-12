using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int totalCoins = 100; 
    public CoinDisplay coinDisplay; 

    
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