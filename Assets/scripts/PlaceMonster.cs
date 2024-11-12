using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceMonster : MonoBehaviour
{
    public GameObject monsterPrefab;
    private GameObject monster;

    private bool CanPlaceMonster()
    {
        return monster == null;
    }

    void OnMouseUp()
    {
        //2
        if (CanPlaceMonster())
        {
            //3
            monster = (GameObject)
              Instantiate(monsterPrefab, transform.position, Quaternion.identity);
            //4
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);

            // TODO: вычитать золото
        }
    }

    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}
