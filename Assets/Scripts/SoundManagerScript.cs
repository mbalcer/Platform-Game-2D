using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip fallSound, jumpSound, completeSound, pickUpSound, hitSound, menuSound, music;
    public static AudioSource audioSrc;
    private static bool createdSound = false;
    
    void Start()
    {
        
        fallSound = Resources.Load<AudioClip>("Fall");
        jumpSound = Resources.Load<AudioClip>("Jump2");
        completeSound = Resources.Load<AudioClip>("levelComplete");
        pickUpSound = Resources.Load<AudioClip>("PickUp");
        hitSound = Resources.Load<AudioClip>("hit");
        menuSound = Resources.Load<AudioClip>("Menu2");
        music = Resources.Load<AudioClip>("Tiny_Blocks");
        audioSrc = GetComponent<AudioSource>();
        if (createdSound == false)
        {
            DontDestroyOnLoad(this.gameObject);
            createdSound = true;
            audioSrc.loop = true;
            audioSrc.Play();
        };
    }

    // Update is called once per frame

    void Update()
    {
        
    }
    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "fall":
                audioSrc.PlayOneShot(fallSound);
                break;
            case "complete":
                audioSrc.PlayOneShot(completeSound);
                break;
            case "pickup":
                audioSrc.PlayOneShot(pickUpSound);
                break;
            case "hit":
                 audioSrc.PlayOneShot(hitSound);
                break;
            case "menu":
                audioSrc.PlayOneShot(menuSound);
                break;
        }
    }
}
