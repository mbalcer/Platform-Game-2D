using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControll : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    private Animator animatorChest;
    float speed = 40f;
    float moveHor = 0f;
    bool jump = false;
    bool crouch = false;
    bool finish = false;
    Rigidbody2D rb; 

    CoinManagerScript coinManager;
    GameManagerScript gameManager;
    // Update is called once per frame
    void Start()
    {
        coinManager = GameObject.Find("CoinManager").GetComponent<CoinManagerScript>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        animatorChest = GameObject.Find("Chest").GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveHor = Input.GetAxis("Horizontal") * speed;
        animator.SetFloat("Speed", Mathf.Abs(moveHor));
       // Debug.Log(GameObject.Find("Chest").transform.position.x - GameObject.Find("Player").transform.position.x);
        animatorChest.SetFloat("DifferenceX", GameObject.Find("Chest").transform.position.x - GameObject.Find("Player").transform.position.x);
        if (coinManager.Money >= 10)
        {


            animatorChest.SetBool("open", true);
        }

            if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
            SoundManagerScript.PlaySound("jump");
        }
        if (Input.GetButtonDown("Crouch"))
        {
            animator.SetBool("IsCrouching", true);
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            animator.SetBool("IsCrouching", false);
            crouch = false;
        }
    }

    public void OnLanding()
    {

        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {

        animator.SetBool("IsCrouching", isCrouching);

    }

    public void FixedUpdate()
    {
        controller.Move(moveHor * Time.fixedDeltaTime, crouch, jump);

        jump = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            coinManager.CollectedCoin();
            Destroy(collision.gameObject);
            SoundManagerScript.PlaySound("pickup");
        }

        else if (collision.tag == "Chest")
        {
            if (coinManager.Money >= 10)
            {
                
            
                animatorChest.SetBool("open", true);

                //TODO: przerwa w działaniu. To poniżej nie działa...
                //StartCoroutine(Wait());

                if(SceneManager.GetActiveScene().name == "Level1")
                {
                    LevelsManager.setLevel2();
                }

                else if (SceneManager.GetActiveScene().name == "Level2")
                {
                    LevelsManager.setLevel3();
                }

                gameManager.LoadLevels();
                SoundManagerScript.PlaySound("complete");
            }
        }

        else if (collision.tag == "Spike")
        {
            SoundManagerScript.PlaySound("hit");
            HeartMenago.heartbroken();
            gameManager.ResetLevel(controller);

            //TODO taking the player's life
        }

        else if (collision.tag == "Dead")
        {

            HeartMenago.heartbroken();
            gameManager.ResetLevel(controller);
            SoundManagerScript.PlaySound("fall");
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
    }
}

