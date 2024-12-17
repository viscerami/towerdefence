using Money;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
  public class UpgradeSystem : MonoBehaviour
  {
    [SerializeField] private Button button;
    [SerializeField] private CoinManager coinManager;
    [SerializeField] private int requiredGold;
    public event Action OnUpgrade;

    private void Update()
    {
      CheckForUpdate();
    }

    public void CheckForUpdate()
    {
      if (coinManager.totalCoins >= requiredGold)
      {
        button.interactable = true; 
      }
      else
      {
        button.interactable = false; 
      }
    }

    public void Upgrade()
    {
      OnUpgrade?.Invoke();
    }
  }
}
