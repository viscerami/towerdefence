using enemy;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class Road : MonoBehaviour
    {
        [SerializeField] private Slider waveState;
        [SerializeField] private GameObject[] waypointsGround;
        [SerializeField] private GameObject[] waypointsFly;
        [SerializeField] private  GameObject groundEnemyPrefab; 
        [SerializeField] private GameObject flyEnemyPrefab; 
        [SerializeField] private int flyEnemiesPerWave;
        [SerializeField] private int groundEnemiesPerWave; 
        [SerializeField] private float timeBetweenEnemies; 
        [SerializeField] private float timeBetweenWaves;
        [SerializeField] private int maxWaves;

        void Start()
        {
            waveState.maxValue = flyEnemiesPerWave + groundEnemiesPerWave;
            waveState.value = waveState.maxValue;
            //StartCoroutine(SpawnWaves(flyEnemyPrefab, waypointsFly, flyEnemiesPerWave));
            StartCoroutine(SpawnWaves(groundEnemyPrefab, waypointsGround, groundEnemiesPerWave));
        }
        private IEnumerator SpawnWaves(GameObject enemyPref, GameObject[] waypoints, int enemyperwave)
        {
            for (int wave = 0; wave < maxWaves; wave++)
            {
                for (int i = 0; i < enemyperwave; i++)
                {
                    SpawnEnemy(enemyPref,waypoints);
                    yield return new WaitForSeconds(timeBetweenEnemies); 
                    waveState.value--;
                }
                yield return new WaitForSeconds(timeBetweenWaves);
                waveState.value = waveState.maxValue;
            }
        }
        private void SpawnEnemy(GameObject pref, GameObject[] waypoints )
        {
            GameObject enemy = Instantiate(pref);
            enemy.GetComponent<GroundEnemyAttacker>().Waypoints = waypoints;
        }
    }
}