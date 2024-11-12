using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject[] waypoints; 
    public GameObject testEnemyPrefab; 
    public int enemiesPerWave = 5; 
    public float timeBetweenEnemies = 1f; 
    public float timeBetweenWaves = 5f; 
    public int maxWaves = 3; 

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

    void Update()
    {
        
    }
}