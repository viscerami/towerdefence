using Player;
using System;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace UI
{
    public class UIButtonHandler : MonoBehaviour
    {
        [SerializeField] private TowerManager towerManager;
        [SerializeField] private int towerIndex;
        [SerializeField] private UpgradeSystem upgrade;
        [SerializeField] private Sprite buttonSprite;
        [SerializeField] private Image buttonImage;

        private void Start()
        {
            upgrade.OnUpgrade += Change;
        }

        public void OnButtonClick()
        {
            towerManager.SelectTower(towerIndex);
        }

        private void Change()
        {
            towerIndex += 3;
            buttonImage.sprite = buttonSprite;
        }
    }
}