using Player;
using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace enemy
{
    public abstract class MoveEnemy: MonoBehaviour
    {
        public GameObject[] Waypoints;
        protected int currentWaypoint = 0;
        protected float lastWaypointSwitchTime;
        protected const float SPEED = 1.0f;
        [SerializeField] protected PlayerHealth player;
        [SerializeField] protected int damage;

        public virtual void Start()
        {
            player = FindObjectOfType<PlayerHealth>();
            lastWaypointSwitchTime = Time.time;
        }

        public virtual void Update()
        {
            Move();
        }

        protected virtual void Move()
        {
            Vector3 startPosition = Waypoints[currentWaypoint].transform.position;
            Vector3 endPosition = Waypoints[currentWaypoint + 1].transform.position;

            if (Vector2.Distance(gameObject.transform.position, endPosition) < 0.1f)
            {
                if (currentWaypoint < Waypoints.Length - 2)
                {
                    currentWaypoint++;
                    lastWaypointSwitchTime = Time.time;
                }
                else
                {
                    player.TakeDamage(damage);
                    Destroy(gameObject);
                    Debug.Log("Игрок получил урон!");
                }
            }
            else
            {
                float pathLength = Vector3.Distance(startPosition, endPosition);
                float totalTimeForPath = pathLength / SPEED;
                float currentTimeOnPath = Time.time - lastWaypointSwitchTime;
                gameObject.transform.position = Vector2.Lerp(startPosition, endPosition, currentTimeOnPath / totalTimeForPath);
            }
        }
    }
}
