using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartMenago : MonoBehaviour
{
    // Start is called before the first frame update
    public static int health =3;

    public static void heartbroken()
    {
        health -= 1;
    }
    public static void setHealth()
    {
       if(health==0)
        {
            health = 3;
        }
       else if(health>3)
        {
            health = 3;
        }
        else if (health < 0)
        {
            health = 0;
        }
    }
    public static int getHealth()
    {
        return health;
    }
}
