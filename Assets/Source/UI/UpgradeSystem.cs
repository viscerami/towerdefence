using Money;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
  public class UpgradeSystem : MonoBehaviour
  {
    [SerializeField] private Button button;
    [SerializeField] private CoinManager coinManager;
    [SerializeField] private int requiredGold;
    [SerializeField] private AudioSource audioSourcePref;
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
      coinManager.totalCoins -= requiredGold;
      Instantiate(audioSourcePref);
      OnUpgrade?.Invoke();
      gameObject.SetActive(false);
    }
  }
}
