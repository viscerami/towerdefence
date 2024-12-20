using Money;
using System;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class TowerManager : MonoBehaviour
    {
        [SerializeField] private List<TowerData> towerDatas;
        private GameObject _selectedTower; 
        private CoinManager _coinManager;
        private const int _indexTutor = 1;
        public event Action OnTowerBuilt;
        void Start()
        {
            _coinManager = FindObjectOfType<CoinManager>();
        }

        public int GetCost(TowerType towerType)
        {
            foreach (var tower in towerDatas)
            {
                if (tower.TowerType == towerType)
                {
                    return tower.Cost;
                }
            }
            return 0;
        }
        public void SelectTower(TowerType towertype)
        {
            for (int i = 0; i < towerDatas.Count; i++)
            {
                if (towerDatas[i].TowerType == towertype)
                {
                    _selectedTower = towerDatas[i].TowerPrefab;   
                    break;
                }
            }
        }
        void Update()
        {
            
            if (Input.GetMouseButtonDown(0) && _selectedTower != null)
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            
                if (hit.collider != null && hit.collider.CompareTag("TowerSlot"))
                {
                    int towerIndex = -1;
                    for (int i = 0; i < towerDatas.Count; i++)
                    {
                        if (towerDatas[i].TowerPrefab == _selectedTower)
                        {
                            if (SceneManager.GetActiveScene().buildIndex == _indexTutor) 
                            {
                                OnTowerBuilt?.Invoke();
                            }
                            towerIndex = i;
                            break;
                        }
                    }
                    if (towerIndex >= 0 && _coinManager.SpendCoins(towerDatas[towerIndex].Cost))
                    {
                        Instantiate(_selectedTower, hit.collider.transform.position, Quaternion.identity);
                        Debug.Log("поставил"+ _selectedTower.gameObject.name);
                        Destroy(hit.collider.gameObject); 
                        _selectedTower = null; 
                    }
                    else
                    {
                        Debug.Log("!");
                    }
                }
               
            }
        }
    }
}