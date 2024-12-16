using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace enemy
{
    public class WaveSystem : MonoBehaviour
    {
        [SerializeField] private Slider waveState;
        [SerializeField] private GameObject[] waypointsGround;
        [SerializeField] private GameObject[] waypointsFly;
        [SerializeField] private GameObject groundEnemyPrefab;
        [SerializeField] private GameObject flyEnemyPrefab;
        [SerializeField] private int flyEnemiesPerWave;
        [SerializeField] private int groundEnemiesPerWave;
        [SerializeField] private float timeBetweenWaves;
        [SerializeField] private int maxWaves;
        private readonly float _minTimeBetweenEnemies = 1f;
        private readonly float _maxTimeBetweenEnemies = 2f;

        void Start()
        {
            waveState.maxValue = flyEnemiesPerWave + groundEnemiesPerWave;
            waveState.value = waveState.maxValue;
            StartCoroutine(SpawnWaves(flyEnemyPrefab, waypointsFly, flyEnemiesPerWave));
            StartCoroutine(SpawnWaves(groundEnemyPrefab, waypointsGround, groundEnemiesPerWave));
        }

        private IEnumerator SpawnWaves(GameObject enemyPref, GameObject[] waypoints, int enemyperwave)
        {
            for (int wave = 0; wave < maxWaves; wave++)
            {
                for (int i = 0; i < enemyperwave; i++)
                {
                    SpawnEnemy(enemyPref, waypoints);
                    float randomTime = Random.Range(_minTimeBetweenEnemies, _maxTimeBetweenEnemies);
                    yield return new WaitForSeconds(randomTime);
                    waveState.value--;
                }
                yield return new WaitForSeconds(timeBetweenWaves);
                waveState.value = waveState.maxValue;
            }
        }

        private void SpawnEnemy(GameObject pref, GameObject[] waypoints)
        {
            GameObject enemy = Instantiate(pref);
            enemy.GetComponent<MoveEnemy>().Waypoints = waypoints;
        }
    }
}