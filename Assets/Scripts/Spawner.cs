using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public List<GameObject> objectToSpawn = new List<GameObject>();
    public int coinValue;               // Value of the COin
    public bool isRandomized;           // Random No
    public List<int> coinValueList;     // List of spawn cCoin Values
    private int rNumber;                // collected coin position in the coinValueList
    private int r1Number;               // collected coin position in the coinValueList + 1
    private int rValue;                 // COllected coin value
    public int SummaSumma;              // collected Coin Values



    public void SpawnObject()
    {
        // this part can be done better probably, especially if we want to have way more coins
        // but right now we spawn only 4 coins
        int index1 = isRandomized ? Random.Range(0, objectToSpawn.Count) : 0;                   // coins the elements (coin) in the list and takes random one
        Instantiate(objectToSpawn[index1], new Vector3(0.5f, -2f, 0f), transform.rotation);     // will spawn the coin from the lsit (according to index No) to the certain place
        coinValue = int.Parse(objectToSpawn[index1].GetComponent<CollectScript>().itemType);    // takes the parameter from spawned object (itemType which reflects the coin value) and attributes it to "coinValue"
        // print("CoinValue on " + coinValue);                                                  // just to check if everything is ok
        coinValueList.Add(coinValue);                                                           // adds the value of the coin to the coinValueList

        int index2 = isRandomized ? Random.Range(0, objectToSpawn.Count) : 0;                   // same thing for 2...4th coin as before for 1st coin.
        Instantiate(objectToSpawn[index2], new Vector3(4.8f, -5.2f, 0f), transform.rotation);   // probably can use some kind of loop for that, but we don't have that much knowledge yet to implement
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

        SummaSumma = 0;                                                     // This parameter is set to 0 first

        for (int i = 0; i < 2; i++)                                         // loop for getting 2 random values from coinValueList
        {
            rNumber = Random.Range(0, coinValueList.Count);                 // takes random No from range which reflects the element No-s in coinValueList (position in List)
            rValue = coinValueList[rNumber];                                // According to the position in the list assignes the value of that particular member
            //print("Järjekorras nr: " + rNumber);                          // prints the pos number
            //print("Väärtus: " + rValue);                                  // prints the value of that coin (whis is positioned according to rNumber
            SummaSumma = SummaSumma + rValue;                               // coin values will be added to SummaSumma
            //print("Listis numbreid kokku: " + coinValueList.Count);       // prints how many members there are in coinValueList
            r1Number = rNumber + 1;                                         // need that No to remove particular value (which was added to the SummaSumma) from coinValueList,...
            coinValueList.Remove(r1Number);                                 // ...because we don't want to take coin's values twice, this removes the coinValue from the list
            coinValueList.TrimExcess();                                     // will make List shorter, so there will not be any empty addresses in the list
            //print("Listis numbreid kokku: " + coinValueList.Count);       // will pirnt out how many coin values left to the list

        }

        coinValueList.Clear();                                              // will clear the list
        // print("SummaSumma on " + SummaSumma);                            // prints final SummaSumma
        ScoreScript.SummaScore = SummaSumma;                                // attributes the value of SummaSumma to SummaScore which is used in ScoreSpript                   

    }
}
// test