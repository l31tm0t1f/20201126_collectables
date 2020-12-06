using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public List<GameObject> objectToSpawn = new List<GameObject>();
    public int coinValue;               // Value of the COin
    public bool isRandomized;           // Random No
    public List<int> coinValueList;    // List of spawn cCoin Values
    private int rNumber;                // collected coin position in the coinValueList
    private int r1Number;               // collected coin position in the coinValueList + 1
    private int rValue;                 // COllected coin value
    public int SummaSumma;              // collected Coin Values



    public void SpawnObject()
    {
        int index1 = isRandomized ? Random.Range(0, objectToSpawn.Count) : 0;
        Instantiate(objectToSpawn[index1], new Vector3(0.5f, -2f, 0f), transform.rotation);
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

        SummaSumma = 0;

        for (int i = 0; i < 2; i++)
        {
            rNumber = Random.Range(0, coinValueList.Count);
            rValue = coinValueList[rNumber];
            print("Järjekorras nr: " + rNumber);
            print("Väärtus: " + rValue);
            SummaSumma = SummaSumma + rValue;
            print("Listis numbreid kokku: " + coinValueList.Count);
            r1Number = rNumber + 1;
            coinValueList.Remove(r1Number);
            coinValueList.TrimExcess();
            print("Listis numbreid kokku: " + coinValueList.Count);

        }

        coinValueList.Clear();
        print("SummaSumma on " + SummaSumma);
        ScoreScript.SummaScore = SummaSumma;

    }
}
