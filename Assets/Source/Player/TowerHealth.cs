using enemy;
using System;
using UnityEngine;

namespace Player
{
  public class TowerHealth : AHealth
  {
    [SerializeField] private WaveSystem wave;
    [SerializeField] private AudioSource audioSourcePref;
    public event Action OnTowerAttacked;

    public override void Start()
    {
      wave = FindObjectOfType<WaveSystem>();
      base.Start();
      wave.Finish += Die;
    }

    protected override void Die()
    {
      Instantiate(audioSourcePref);
      wave.Finish -= Die;
      OnTowerAttacked?.Invoke();
      Destroy(gameObject);
    }
  }
}
