using Money;
using UnityEngine;
using UnityEngine.UI;

namespace Money
{
    public class CoinDisplay : MonoBehaviour
    {
        [SerializeField] private CoinManager coinManager; 
        private Text _coinText; 
        void Start()
        {
            _coinText = GetComponent<Text>(); 
            UpdateCoinDisplay(); 
        }
        public void UpdateCoinDisplay()
        {
            _coinText.text = "������: " + coinManager.GetCoins().ToString(); 
        }
    }
}