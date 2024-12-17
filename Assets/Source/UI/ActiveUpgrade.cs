using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveUpgrade : MonoBehaviour
{
  public event Action OnUpgradeActive;
  
  public void ShowUpgrade()
  {
    OnUpgradeActive?.Invoke();
    Debug.Log("запустил");
  }
  
  
  
}
