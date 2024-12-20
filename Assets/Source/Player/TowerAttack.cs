using enemy;
using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

namespace Player
{
    public class TowerAttack : MonoBehaviour
    {
         public int Damage; 
        [SerializeField] private float attackCooldown = 1f; 
        [SerializeField] private float attackTimer = 0f; 
        [SerializeField] private LayerMask enemy;
        [SerializeField] private GameObject projectile;
        [SerializeField] private Transform firePoint;
        private List<GameObject> _enemyHealths = new List<GameObject>();
        private AudioSource _audioSource;
        
        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0)
            {
                if (_enemyHealths.Count > 0)
                {
                    _audioSource.Play();
                    int random = Random.Range(0, _enemyHealths.Count);
                    GameObject bullet = Instantiate(projectile, firePoint.position, firePoint.rotation);
                    bullet.GetComponent<Projectile>().Initialize(_enemyHealths[random].transform.position); // Передаем цель в пулю
                    _enemyHealths[random].GetComponent<EnemyHealth>().TakeDamage(Damage);
                    attackTimer = attackCooldown;

                }
            }
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (LayerMaskCheck.ContainsLayer(enemy, other.gameObject.layer))
            {
              _enemyHealths.Add(other.gameObject);
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (LayerMaskCheck.ContainsLayer(enemy, other.gameObject.layer))
            {
                _enemyHealths.Remove(other.gameObject);
            }
        }
    }
}