using Scene;
using System;
using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace enemy
{
    public class WaveSystem : MonoBehaviour
    {
         public Slider waveState;
        [SerializeField] private GameObject[] waypointsGround;
        [SerializeField] private GameObject[] waypointsFly;
        [SerializeField] private GameObject groundEnemyPrefab;
        [SerializeField] private GameObject flyEnemyPrefab;
        [SerializeField] private int flyEnemiesPerWave;
        [SerializeField] private int groundEnemiesPerWave;
        [SerializeField] private float timeBetweenWaves;
        [SerializeField] private int maxWaves;
        private int _remaingEnemy;
        private readonly float _minTimeBetweenEnemies = 1f;
        private readonly float _maxTimeBetweenEnemies = 2f;
        [SerializeField] private SceneChanger sceneChanger;
        [SerializeField] private GameObject winPanel;

        void Start()
        {
            waveState.maxValue = (flyEnemiesPerWave + groundEnemiesPerWave)*maxWaves;
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
                    SpawnEnemy(enemyPref, waypoints);
                    float randomTime = Random.Range(_minTimeBetweenEnemies, _maxTimeBetweenEnemies);
                    yield return new WaitForSeconds(randomTime);
                    Debug.Log("выпустил");
                }
                Debug.Log(waveState.maxValue);
                Debug.Log("запуск новой волны");
                yield return new WaitForSeconds(timeBetweenWaves);
                Debug.Log("запустил ");
            }
        }

        private void SpawnEnemy(GameObject pref, GameObject[] waypoints)
        {
            GameObject enemy = Instantiate(pref);
            enemy.GetComponent<MoveEnemy>().Waypoints = waypoints;
        }

        private void Update()
        {
            if (waveState.value == 0)
            {
                winPanel.SetActive(true);
            }   
        }
    }
}