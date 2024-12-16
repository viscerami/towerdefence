using System;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
  public class PlayerHealth : AHealth
  {
    [SerializeField] private Slider playerHealth;

    public override void Start()
    {
      base.Start();
      playerHealth.maxValue = maxHealth;
      playerHealth.value = currentHealth;
    }

    public override void TakeDamage(int damage)
    {
      base.TakeDamage(damage);
      playerHealth.value = currentHealth;
    }
  }
}
