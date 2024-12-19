using enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f; 
    private Vector3 _target; 
    public void Initialize(Vector3 target)
    {
        this._target = target;
    }

    void Update()
    {
        if (_target != null)
        {
            Vector3 direction = (_target - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            
            if (Vector3.Distance(transform.position, _target) < 0.1f)
            {
                Destroy(gameObject); 
            }
        }
    }
    
}
