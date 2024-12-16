using Money;
using System;
using System.Collections;
using UnityEngine;

namespace Player
{
  public class MoneyTower : MonoBehaviour
  {
    private CoinManager _coinManager;
    private int _addCoin=5;

    private void Start()
    {
      _coinManager = FindObjectOfType<CoinManager>();
      StartCoroutine(DelayedStart());
    }

    private IEnumerator GiveGold()
    {
      while (true)
      {
        Debug.Log("начал"); 
        _coinManager.AddCoins(_addCoin);
        yield return new WaitForSeconds(2f);
        Debug.Log("закончил"); 
      }
    }
    private IEnumerator DelayedStart()
    {
      yield return new WaitForSeconds(5f);
      StartCoroutine(GiveGold());
    }
  }
}
