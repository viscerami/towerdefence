using Player;
using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace enemy
{
    public abstract class MoveEnemy: MonoBehaviour
    {
        public GameObject[] Waypoints;
        private int _currentWaypoint = 0;
        private float _lastWaypointSwitchTime;
        private const float _speed = 1.0f;
        [SerializeField] protected PlayerHealth player;
        private const int _damage=20;
        [SerializeField] private WaveSystem waveSystem;
        
        public virtual void Start()
        {
            waveSystem = FindObjectOfType<WaveSystem>();
            player = FindObjectOfType<PlayerHealth>();
            player.OnDead += Exit;
            _lastWaypointSwitchTime = Time.time;
        }

        public virtual void Update()
        {
            Move();
        }

        protected virtual void Move()
        {
            Vector3 startPosition = Waypoints[_currentWaypoint].transform.position;
            Vector3 endPosition = Waypoints[_currentWaypoint + 1].transform.position;

            if (Vector2.Distance(gameObject.transform.position, endPosition) < 0.1f)
            {
                if (_currentWaypoint < Waypoints.Length - 2)
                {
                    _currentWaypoint++;
                    _lastWaypointSwitchTime = Time.time;
                }
                else
                {
                    if (player.currentHealth > 0)
                    {
                        waveSystem.waveState.value--;
                        player.TakeDamage(_damage);
                        Destroy(gameObject);
                    }
                    else
                    {
                        Destroy(gameObject);
                    }
                    Debug.Log("Игрок получил урон!");
                }
            }
            else
            {
                float pathLength = Vector3.Distance(startPosition, endPosition);
                float totalTimeForPath = pathLength / _speed;
                float currentTimeOnPath = Time.time - _lastWaypointSwitchTime;
                gameObject.transform.position = Vector2.Lerp(startPosition, endPosition, currentTimeOnPath / totalTimeForPath);
            }
        }

        private void Exit()
        {
            player.OnDead -= Exit;
            waveSystem.LosePanel.SetActive(true);
        }
    }
}
