using Scene;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace enemy
{
    public class WaveSystem : MonoBehaviour
    {
        public event Action Finish;
         public Slider waveState;
        [SerializeField] private GameObject[] waypointsGround;
        [SerializeField] private GameObject[] waypointsFly;
        [SerializeField] private GameObject groundEnemyAttackPrefab;
        [SerializeField] private GameObject groundEnemyPrefab;
        [SerializeField] private GameObject flyEnemyPrefab;
        [SerializeField] private int groundEnemyAttackPerWave;
        [SerializeField] private int flyEnemiesPerWave;
        [SerializeField] private int groundEnemiesPerWave;
        [SerializeField] private float timeBetweenWaves;
        [SerializeField] private int maxWaves;
        private int _remaingEnemy;
        private int _curWave;
        [SerializeField] private int _maxEnemy;
        private readonly float _minTimeBetweenEnemies = 1f;
        private readonly float _maxTimeBetweenEnemies = 2f;
        [SerializeField] private GameObject winPanel;
        public GameObject LosePanel;
        private const int _level1 = 2;
        private const int _level2 = 3;
        private const int _level3 = 4;
        private const int _tutor = 1;

        void Start()
        {
            waveState.maxValue = (_maxEnemy);
            waveState.value = waveState.maxValue;
            StartCoroutine(Wave());
        }

        private void StartWave()
        {
            if (SceneManager.GetActiveScene().buildIndex == _level1)
            {
                if (_curWave == 2)
                {
                    groundEnemyAttackPerWave = 2;
                    groundEnemiesPerWave = 3;
                }

                if (_curWave == 3)
                {
                    groundEnemyAttackPerWave = 2;
                    groundEnemiesPerWave = 3;
                    flyEnemiesPerWave = 3;
                }
            }
            if (SceneManager.GetActiveScene().buildIndex == _level2)
            {
                if (_curWave == 2)
                {
                    groundEnemyAttackPerWave = 2;
                    groundEnemiesPerWave = 3;
                }

                if (_curWave == 3)
                {
                    groundEnemyAttackPerWave = 2;
                    groundEnemiesPerWave = 3;
                    flyEnemiesPerWave = 3;
                }
            }
            if (SceneManager.GetActiveScene().buildIndex == _level3)
            {
                if (_curWave == 2)
                {
                    groundEnemyAttackPerWave = 2;
                    groundEnemiesPerWave = 3;
                }

                if (_curWave == 3)
                {
                    groundEnemyAttackPerWave = 2;
                    groundEnemiesPerWave = 3;
                    flyEnemiesPerWave = 3;
                }
            }
            
            StartCoroutine(SpawnWaves(groundEnemyAttackPrefab, waypointsGround, groundEnemyAttackPerWave));
            StartCoroutine(SpawnWaves(flyEnemyPrefab, waypointsFly, flyEnemiesPerWave));
            StartCoroutine(DelayedStart());
        }

        private IEnumerator Wave()
        {
            for (int wave = 0; wave < maxWaves; wave++)
            {
                _curWave++;
                StartWave();

                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }

        private IEnumerator DelayedStart()
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(SpawnWaves(groundEnemyPrefab,waypointsGround,groundEnemiesPerWave));
        }

        private IEnumerator SpawnWaves(GameObject enemyPref, GameObject[] waypoints, int enemyperwave)
        {
            for (int i = 0; i < enemyperwave; i++)
            {
                SpawnEnemy(enemyPref, waypoints);
                float randomTime = Random.Range(_minTimeBetweenEnemies, _maxTimeBetweenEnemies);
                yield return new WaitForSeconds(randomTime);
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }

        private void SpawnEnemy(GameObject pref, GameObject[] waypoints)
        {
            GameObject enemy = Instantiate(pref);
            enemy.GetComponent<MoveEnemy>().Waypoints = waypoints;
        }

        private void Update()
        {
            if (waveState.value == 0&&SceneManager.GetActiveScene().buildIndex != _tutor )
            {
                Finish?.Invoke();
                winPanel.SetActive(true);
            }   
        }
    }
}