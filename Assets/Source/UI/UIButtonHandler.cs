using Player;
using UnityEngine;

namespace UI
{
    public class UIButtonHandler : MonoBehaviour
    {
        [SerializeField] private TowerManager towerManager; // ������ �� TowerManager
        [SerializeField] private int towerIndex; // ������ ����� � �������

        // ����� ��� ��������� ����� ��� ������� �� ������
        public void OnButtonClick()
        {
            towerManager.SelectTower(towerIndex);
        }
    }
}