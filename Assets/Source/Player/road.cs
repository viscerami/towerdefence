using enemy;
using System.Collections;
using UnityEngine;

namespace Player
{
    public class Road : MonoBehaviour
    {
        [SerializeField] private GameObject[] waypoints; 
        [SerializeField] private GameObject testEnemyPrefab; 
        [SerializeField] private int enemiesPerWave = 5; 
        [SerializeField] private float timeBetweenEnemies = 1f; 
        [SerializeField] private float timeBetweenWaves = 5f;
        [SerializeField] private int maxWaves = 3; 

        void Start()
        {
            StartCoroutine(SpawnWaves()); 
        }

        private IEnumerator SpawnWaves()
        {
            for (int wave = 0; wave < maxWaves; wave++)
            {
                for (int i = 0; i < enemiesPerWave; i++)
                {
                    SpawnEnemy(); 
                    yield return new WaitForSeconds(timeBetweenEnemies); 
                }
                yield return new WaitForSeconds(timeBetweenWaves); 
            }
        }
        private void SpawnEnemy()
        {
            GameObject enemy = Instantiate(testEnemyPrefab);
            enemy.GetComponent<MoveEnemy>().waypoints = waypoints;
        }
    }
}