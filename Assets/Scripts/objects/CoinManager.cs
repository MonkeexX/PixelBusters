using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int coinCount;
    public int numCoinsToUnlock_door1;

    public GameObject door1;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (coinCount >= numCoinsToUnlock_door1 && door1 != null)
        {
            Destroy(door1);
        }
    }
}
