using UnityEngine;
using UnityEngine.UI;

public class UIButtonHandler : MonoBehaviour
{
    public TowerManager towerManager; // —сылка на TowerManager
    public int towerIndex; // »ндекс башни в массиве

    // ћетод дл€ установки башни при нажатии на кнопку
    public void OnButtonClick()
    {
        towerManager.SelectTower(towerIndex);
    }
}