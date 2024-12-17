using System;

namespace Player
{
  public class TowerHealth : AHealth
  {
    public event Action OnTowerAttacked;

    protected override void Die()
    {
      OnTowerAttacked?.Invoke();
      base.Die();
    }
  }
}
