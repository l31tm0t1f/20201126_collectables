using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> objectToSpawn = new List<GameObject>();
    public List<string> coinValuesAll;
    public int coinValue;
    public bool isRandomized;
    public int[] coinValuesArray;
    private List<int> coinValueList;
    private List<int> coinValueList2;
    private int rNumber;
    private int rValue;

    // public GameObject objectsToSpawn;

    public void SpawnObject()
    {
        int index1 = isRandomized ? Random.Range(0, objectToSpawn.Count) : 0;
        Instantiate(objectToSpawn[index1], new Vector3(1f, -6f, 0f), transform.rotation);
        coinValue = int.Parse(objectToSpawn[index1].GetComponent<CollectScript>().itemType);
        print("CoinValue on " + coinValue);
        coinValueList.Add(coinValue);

        int index2 = isRandomized ? Random.Range(0, objectToSpawn.Count) : 0;
        Instantiate(objectToSpawn[index2], new Vector3(4.8f, -5.2f, 0f), transform.rotation);
        coinValue = int.Parse(objectToSpawn[index2].GetComponent<CollectScript>().itemType);
        print("CoinValue on " + coinValue);
        coinValueList.Add(coinValue);

        int index3 = isRandomized ? Random.Range(0,objectToSpawn.Count) : 0;
        Instantiate(objectToSpawn[index3], new Vector3(18f, -5.3f, 0f), transform.rotation);
        coinValue = int.Parse(objectToSpawn[index3].GetComponent<CollectScript>().itemType);
        print("CoinValue on " + coinValue);
        coinValueList.Add(coinValue);

        int index4 = isRandomized ? Random.Range(0, objectToSpawn.Count) : 0;
        Instantiate(objectToSpawn[index4], new Vector3(9f, 0f, 0f), transform.rotation);
        coinValue = int.Parse(objectToSpawn[index4].GetComponent<CollectScript>().itemType);
        print("CoinValue on " + coinValue);
        coinValueList.Add(coinValue);

        for (int i = 0; i < coinValueList.Count - 1; i++)
        {
            rNumber = Random.Range(0, coinValueList.Count);
            rValue = coinValueList[rNumber];
            print("Järjekorras nr: " + rNumber);
            print("Väärtus: " + rValue);
            coinValueList.Remove(rNumber);
            coinValueList.TrimExcess();

        }




        coinValueList.Clear();

            //Destroy(objectToSpawn[index1]);

       
    }
}
