using enemy;
using System.Collections;
using UnityEngine;

namespace Player
{
    public class Road : MonoBehaviour
    {
        [SerializeField] private GameObject[] waypointsGround;
        [SerializeField] private GameObject[] waypointsFly;
        [SerializeField] private GameObject groundEnemyPrefab; 
        [SerializeField] private GameObject flyEnemyPrefab; 
        [SerializeField] private int flyEnemiesPerWave;
        [SerializeField] private int groundEnemiesPerWave; 
        [SerializeField] private float timeBetweenEnemies; 
        [SerializeField] private float timeBetweenWaves;
        [SerializeField] private int maxWaves; 

        void Start()
        {
            StartCoroutine(SpawnGroundWaves()); 
            StartCoroutine(SpawnFlyWaves()); 
        }

        private IEnumerator SpawnGroundWaves()
        {
            for (int wave = 0; wave < maxWaves; wave++)
            {
                for (int i = 0; i < groundEnemiesPerWave; i++)
                {
                    SpawnEnemy(groundEnemyPrefab,waypointsGround);
                    yield return new WaitForSeconds(timeBetweenEnemies); 
                }
                yield return new WaitForSeconds(timeBetweenWaves); 
            }
        }
        private IEnumerator SpawnFlyWaves()
        {
            for (int wave = 0; wave < maxWaves; wave++)
            {
                for (int i = 0; i < flyEnemiesPerWave; i++)
                {
                    SpawnEnemy(flyEnemyPrefab,waypointsFly);
                    yield return new WaitForSeconds(timeBetweenEnemies); 
                }
                yield return new WaitForSeconds(timeBetweenWaves); 
            }
        }
        private void SpawnEnemy(GameObject pref, GameObject[] waypoints )
        {
            GameObject enemy = Instantiate(pref);
            enemy.GetComponent<MoveEnemy>().waypoints = waypoints;
        }


    }
}