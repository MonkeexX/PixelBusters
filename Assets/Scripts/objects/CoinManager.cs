using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int coinCount;
    public int numCoinsToUnlock_1;
    public int numCoinsToUnlock_2;


    public GameObject door1;
    public GameObject door2;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (coinCount >= numCoinsToUnlock_1 && door1 != null)
        {
            Destroy(door1);
        }
        if (coinCount >= numCoinsToUnlock_2 && door2 != null)
        {
            Destroy(door2);
        }
    }
}
