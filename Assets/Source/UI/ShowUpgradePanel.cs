using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace UI
{
    public class ShowUpgradePanel : MonoBehaviour, IPointerEnterHandler
    {
        [SerializeField] private ActiveUpgrade activeUpgrade;
        private bool _upgradeActive = false;
        [SerializeField] private GameObject upgradePanel;
    
        private void Start()
        {
            activeUpgrade.OnUpgradeActive += ChangeStatus;
            upgradePanel.SetActive(false); // Убедитесь, что панель изначально скрыта
        }
    
        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("зашёл");
            if (_upgradeActive)
            { 
                upgradePanel.SetActive(true);
            }
        }

        public void Exit()
        {
            upgradePanel.SetActive(false);
        }
        
        private void ChangeStatus()
        {
            Debug.Log("поменял");
            _upgradeActive = !_upgradeActive;
            Debug.Log(_upgradeActive);
        }
        
    }
}
