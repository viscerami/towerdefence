using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace enemy
{
  public abstract class AAttack : MonoBehaviour
  {
    [SerializeField] protected int damage = 10; 
    [SerializeField] protected float attackCooldown = 1f; 
    [SerializeField] protected float attackTimer = 0f; 
    [SerializeField] protected LayerMask tower;
    private void OnTriggerStay2D(Collider2D other)
    {
      if (LayerMaskCheck.ContainsLayer(tower, other.gameObject.layer))
      {
        if (attackTimer <= 0)
        {
          other.gameObject.GetComponent<AHealth>().TakeDamage(damage);
          attackTimer = attackCooldown;
        }
      }
    }
  }
}