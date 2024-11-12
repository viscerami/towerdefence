using UnityEngine;
using UnityEngine.UI; 

public class CoinDisplay : MonoBehaviour
{
    public CoinManager coinManager; 
    private Text coinText; 

    void Start()
    {
        coinText = GetComponent<Text>(); 
        UpdateCoinDisplay(); 
    }

    
    public void UpdateCoinDisplay()
    {
        coinText.text = "Монеты: " + coinManager.GetCoins().ToString(); 
    }
}