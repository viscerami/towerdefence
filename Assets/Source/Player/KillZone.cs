using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class KillZone : MonoBehaviour
{
  [SerializeField] private LayerMask enemy;
  
  private void OnCollisionEnter2D(Collision2D other)
  {
    if (LayerMaskCheck.ContainsLayer(enemy, other.gameObject.layer))
    {
      if (enemy.CompareTag("Enemy") && attackTimer <= 0)
      {
        enemy.GetComponent<Health>().TakeDamage(damage); 
        attackTimer = attackCooldown; 
      }
    }
  }
}
