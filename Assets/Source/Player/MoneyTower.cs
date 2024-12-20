using Money;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
  public class MoneyTower : MonoBehaviour
  {
    private AudioSource _audioSource;
    private CoinManager _coinManager;
    [SerializeField] private int addCoin;

    private void Start()
    {
      _audioSource = GetComponent<AudioSource>();
      _coinManager = FindObjectOfType<CoinManager>();
      StartCoroutine(DelayedStart());
    }

    private IEnumerator GiveGold()
    {
      while (true)
      {
        _audioSource.Play();
        _coinManager.AddCoins(addCoin);
        yield return new WaitForSeconds(5);
      }
    }
    private IEnumerator DelayedStart()
    {
      yield return new WaitForSeconds(5f);
      StartCoroutine(GiveGold());
    }
  }
}
