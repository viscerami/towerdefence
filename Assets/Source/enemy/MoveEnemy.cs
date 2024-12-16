using Player;
using UnityEngine;

namespace enemy
{
    public class MoveEnemy: MonoBehaviour
    {
        public GameObject[] waypoints;
        private int _currentWaypoint = 0;
        private float _lastWaypointSwitchTime;
        private const float _speed = 1.0f;
        [SerializeField] private PlayerHealth player;
        [SerializeField] private int damage;
        void Start()
        {
            player = FindObjectOfType<PlayerHealth>();
            _lastWaypointSwitchTime = Time.time;
        }
        void Update()
        {
            Vector3 startPosition = waypoints[_currentWaypoint].transform.position;
            Vector3 endPosition = waypoints[_currentWaypoint + 1].transform.position;
       
            float pathLength = Vector3.Distance(startPosition, endPosition);
            float totalTimeForPath = pathLength / _speed;
            float currentTimeOnPath = Time.time - _lastWaypointSwitchTime;
            gameObject.transform.position = Vector2.Lerp(startPosition, endPosition, currentTimeOnPath / totalTimeForPath);
        
            if (gameObject.transform.position.Equals(endPosition))
            {
                if (_currentWaypoint < waypoints.Length - 2)
                {
                    _currentWaypoint++;
                    _lastWaypointSwitchTime = Time.time;
                }
                else
                {
                    Destroy(gameObject);
                    //AudioSource audioSource = gameObject.GetComponent<AudioSource>();
                    //AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
                    Debug.Log("наношу урон");
                    player.TakeDamage(damage);
                }
            }
        }
    }
}
