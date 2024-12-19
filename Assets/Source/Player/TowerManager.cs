using Money;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class TowerManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] towerPrefabs; 
        [SerializeField] private int[] towerCosts;
        private GameObject _selectedTower; 
        private CoinManager _coinManager;
        private const int _indexTutor = 1;
        public event Action OnTowerBuilt;
        void Start()
        {
            _coinManager = FindObjectOfType<CoinManager>();
        }
        public void SelectTower(int towerIndex)
        {
            if (towerIndex >= 0 && towerIndex < towerPrefabs.Length)
            {
                _selectedTower = towerPrefabs[towerIndex];
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
                    int towerIndex = System.Array.IndexOf(towerPrefabs, _selectedTower);
                    if (towerIndex >= 0 && _coinManager.SpendCoins(towerCosts[towerIndex]))
                    {
                        Instantiate(_selectedTower, hit.collider.transform.position, Quaternion.identity);
                        Destroy(hit.collider.gameObject); 
                        if (SceneManager.GetActiveScene().buildIndex == _indexTutor) 
                        {
                            OnTowerBuilt?.Invoke();
                        }
                        _selectedTower = null; 
                    }
                    else
                    {
                        Debug.Log("�� ������� ����� ��� ������� ���� �����!");
                    }
                }
            }
        }
    }
}