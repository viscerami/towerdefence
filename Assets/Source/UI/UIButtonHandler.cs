using Player;
using System;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace UI
{
    public class UIButtonHandler : MonoBehaviour
    {
        [SerializeField] private TowerManager towerManager;
        [SerializeField] private TowerType towerType;
        [SerializeField] private TowerType upgradeType;
        public TowerType CurrentType { get; private set; }
        [SerializeField] private UpgradeSystem upgrade;
        [SerializeField] private Sprite buttonSprite;
        [SerializeField] private Image buttonImage;
        public event Action onChange; 

        private void Start()
        {
            CurrentType = towerType;
            upgrade.OnUpgrade += Change;
        }

        public void OnButtonClick()
        {
            towerManager.SelectTower(CurrentType);
            
        }

        private void Change()
        {
            CurrentType = upgradeType;
            buttonImage.sprite = buttonSprite;
            onChange?.Invoke();
        }
    }

    public enum TowerType
    {
        GroundTower1,
        GroundTower2,
        FlyTower1,
        FlyTower2,
        GoldTower1,
        GoldTower2
    }
}