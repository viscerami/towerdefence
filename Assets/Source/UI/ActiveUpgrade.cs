using System;
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
