using UnityEngine;
using UnityEngine.UI;

public class UIButtonHandler : MonoBehaviour
{
    public TowerManager towerManager; // ������ �� TowerManager
    public int towerIndex; // ������ ����� � �������

    // ����� ��� ��������� ����� ��� ������� �� ������
    public void OnButtonClick()
    {
        towerManager.SelectTower(towerIndex);
    }
}