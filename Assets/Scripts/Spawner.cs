using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> objectToSpawn = new List<GameObject>();

    public bool isRandomized;

    // public GameObject objectsToSpawn;

    public void SpawnObject()
    {


        int index1 = isRandomized ? Random.Range(0, objectToSpawn.Count) : 0;
        Instantiate(objectToSpawn[index1], new Vector3(1f, -6f, 0f), transform.rotation);
        Destroy(objectToSpawn[index1]);
        int index2 = isRandomized ? Random.Range(0, objectToSpawn.Count) : 0;
        Instantiate(objectToSpawn[index2], new Vector3(4.8f, -5.2f, 0f), transform.rotation);
        Destroy(objectToSpawn[index2]);
        int index3 = isRandomized ? Random.Range(0, objectToSpawn.Count) : 0;
        Instantiate(objectToSpawn[index3], new Vector3(18f, -5.3f, 0f), transform.rotation);
        Destroy(objectToSpawn[index3]);
        int index4 = isRandomized ? Random.Range(0, objectToSpawn.Count) : 0;
        Destroy(objectToSpawn[index4]);
        Instantiate(objectToSpawn[index4], new Vector3(9f, 0f, 0f), transform.rotation);
    }
    public void DestroyObject()
    {

    }
}
