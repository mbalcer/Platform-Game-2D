using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip fallSound, jumpSound, completeSound, pickUpSound, hitSound, menuSound;
    public static AudioSource audioSrc;
    private static bool createdSound= false;
    // Start is called before the first frame update
    void Awake()
    {
        if (createdSound == false)
        {
            DontDestroyOnLoad(this.gameObject);
            createdSound = true;
        };
     
          // Jak to się odkomentuje to przy przejsciu z menu do innej sceny ten skrypt zostaje, jakby przekazywany jest dalej, ale jak się cofnie z levels do menu to skrypt się duplikuje
          // i dzwieki w tle sie nakladaja
          // Do każdej sceny teraz skopiowałem SoundManager(asset) - to jest jakies rozwiazanie ale muzyka za kazdym przejściem między scenami zaczyna się od nowa
          // Jak ktoś ma jakiś sposób jak to naprawić to śmiało
        
        
    
    }
    void Start()
    {
        fallSound = Resources.Load<AudioClip>("Fall");
        jumpSound = Resources.Load<AudioClip>("Jump2");
        completeSound = Resources.Load<AudioClip>("levelComplete");
        pickUpSound = Resources.Load<AudioClip>("PickUp");
        hitSound = Resources.Load<AudioClip>("hit");
        menuSound = Resources.Load<AudioClip>("Menu2");
        audioSrc = GetComponent<AudioSource>();
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
