using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTrigger : MonoBehaviour
{
    public Spawner spawner;
    public bool HasSpawned = false;             // has Coins spawned already (set to "false" at the start

    void OnTriggerEnter2D(Collider2D other) {   // When SpawnerTrigger object collides with object with "Player" tag
        if (HasSpawned = false && other.gameObject.CompareTag("Player")) ;      // also checks if Coins have spawned already
        {
            spawner.SpawnObject();
            HasSpawned = true;                  // we want to set it true, to avoid further spawnings but this does not work as it should
        }
    }
    //void OnTriggerExit(Collider2D other) {      // tryed this also, but not helping
    //    if (other.gameObject.CompareTag("Player")) ;
     //   {
     //       HasSpawned = true;
     //   }

//    }

}