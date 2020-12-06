using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTrigger : MonoBehaviour
{
    public Spawner spawner;
    private bool HasSpawned = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (HasSpawned = false && other.gameObject.CompareTag("Player")) ;
        {
            spawner.SpawnObject();
            HasSpawned = true;  //doesn't work

        }
    }

    //void OnTriggerExit(Collider2D other)     {
    //    if (other.gameObject.CompareTag("Player")) ;
    //    {
    //        HasSpawned = true;
    //    }
    //}

}