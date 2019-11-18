using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManagerScript : MonoBehaviour
{
    private float money;

    public void CollectedCoin()
    {
        money += 1;
    }
}
