using System;
using UI;
using UnityEngine;

namespace Player
{
  [Serializable]
  public class TowerData
  { 
    [field: SerializeField] public GameObject TowerPrefab { get; private set;}
    [field: SerializeField] public int Cost { get; private set; }
    [field: SerializeField] public TowerType TowerType { get; private set; }
    
    
  }
}
