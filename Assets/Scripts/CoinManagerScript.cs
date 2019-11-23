﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManagerScript : MonoBehaviour
{
    private float money = 0;
    public float Money => money;
    private Text coins;
    private Animator animator;

    public void CollectedCoin()
    {
        money += 1;

        coins = GameObject.Find("Coins").GetComponent<Text>();
        coins.text = money.ToString();
        
        if (money >= 10)
        {
            animator = GameObject.Find("Coin").GetComponent<Animator>();
            animator.SetBool("finish", true);
        }
    }
}
