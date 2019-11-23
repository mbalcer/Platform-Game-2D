using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManagerScript : MonoBehaviour
{
    private float money = 0;
    public Text coins;

    public void CollectedCoin()
    {
        money += 1;

        coins = GameObject.Find("Coins").GetComponent<Text>();
        coins.text = money.ToString();
    }
}
