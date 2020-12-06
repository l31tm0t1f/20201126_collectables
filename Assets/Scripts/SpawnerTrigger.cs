using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTrigger : MonoBehaviour
{
    public Spawner spawner;
    public bool HasSpawned = false;

    void OnTriggerEnter2D(Collider2D other) {
        if (HasSpawned = false && other.gameObject.CompareTag("Player")) ;
        {
            spawner.SpawnObject();
            HasSpawned = true;                  // this does not work as it should be

        }
    }
    //void OnTriggerExit(Collider2D other) {      // this does not work as it should be
    //    if (other.gameObject.CompareTag("Player")) ;
     //   {
     //       HasSpawned = true;
     //   }

//    }

}