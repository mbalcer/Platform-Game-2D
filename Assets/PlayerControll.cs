using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    float speed = 40f;
    float moveHor = 0f;
    bool jump = false;
    bool crouch = false;

    CoinManagerScript coinManager;
    GameManagerScript gameManager;
    // Update is called once per frame
    void Start()
    {
        coinManager = GameObject.Find("CoinManager").GetComponent<CoinManagerScript>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    void Update()
    {
        moveHor = Input.GetAxis("Horizontal") * speed;
        animator.SetFloat("Speed", Mathf.Abs(moveHor));
        
        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        if (Input.GetButtonDown("Crouch"))
        {
            animator.SetBool("IsCrouching", true);
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
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
        controller.Move(moveHor * Time.fixedDeltaTime,crouch,jump);
        jump = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Coin")
        {
            coinManager.CollectedCoin();
            Destroy(collision.gameObject);
        } 
        else if(collision.tag == "Chest")
        {
            gameManager.LoadLevels();
        }
    }

}

