using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public GameObject[] towerPrefabs; 
    public int[] towerCosts;
    private GameObject selectedTower; 
    private CoinManager coinManager; 

    void Start()
    {
        coinManager = FindObjectOfType<CoinManager>();
    }

   
    public void SelectTower(int towerIndex)
    {
        if (towerIndex >= 0 && towerIndex < towerPrefabs.Length)
        {
            selectedTower = towerPrefabs[towerIndex];
        }
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && selectedTower != null)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            
            if (hit.collider != null && hit.collider.CompareTag("TowerSlot"))
            {
                int towerIndex = System.Array.IndexOf(towerPrefabs, selectedTower);
                if (towerIndex >= 0 && coinManager.SpendCoins(towerCosts[towerIndex]))
                {
                    
                    Instantiate(selectedTower, hit.collider.transform.position, Quaternion.identity);
                    Destroy(hit.collider.gameObject); 
                    selectedTower = null; 
                }
                else
                {
                    Debug.Log("Не хватает монет для покупки этой башни!");
                }
            }
        }
    }
}