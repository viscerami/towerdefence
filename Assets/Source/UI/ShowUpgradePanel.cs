using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace UI
{
    public class ShowUpgradePanel : MonoBehaviour
    {
        [SerializeField] private ActiveUpgrade activeUpgrade;
        private bool _upgradeActive = false;
        [SerializeField] private GameObject upgradePanel;

        private void Start()
        {
            activeUpgrade.OnUpgradeActive += ChangeStatus;
            upgradePanel.SetActive(false); // Убедитесь, что панель изначально скрыта
        }

        private void Update()
        {
            if (_upgradeActive == true)
            {
                upgradePanel.SetActive(true);
            }
            else
            {
                Exit();
            }
        }

        public void Exit()
        {
            upgradePanel.SetActive(false);
        }

        private void ChangeStatus()
        {
            _upgradeActive = !_upgradeActive;
        }
    }
}
