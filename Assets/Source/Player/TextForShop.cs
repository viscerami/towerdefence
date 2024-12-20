using Player;
using TMPro;
using UI;
using UnityEngine;


namespace Player
{
  public class TextForShop : MonoBehaviour
  {
    //[SerializeField] private TowerAttack towerAttack;
    [SerializeField] private TowerManager towerManager;
    //[SerializeField] private TextMeshPro attack;
    [SerializeField] private TextMeshProUGUI cost;
    [SerializeField] private UIButtonHandler handler;

    private void ChangeStore()
    {
      Debug.Log(handler.CurrentType);
      cost.text = towerManager.GetCost(handler.CurrentType).ToString();
    }

    private void Start()
    {
      handler.onChange += ChangeStore;
      ChangeStore();
    }
  }
}
