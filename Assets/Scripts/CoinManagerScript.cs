using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManagerScript : MonoBehaviour
{
    private static float money = 0;
    private Text coins;
    private Animator animatorCoin;

    public static float GetMoney()
    {
        return money;
    }

    public static void ResetMoney()
    {
        money = 0;
    }
    
    public void CollectedCoin()
    {
        money += 1;
        LevelsManager.setPoints();

        coins = GameObject.Find("Coins").GetComponent<Text>();
        coins.text = money.ToString();
        
        if (money >= 10)
        {
            animatorCoin = GameObject.Find("Coin").GetComponent<Animator>();
            animatorCoin.SetBool("finish", true);
        }
    }
}
