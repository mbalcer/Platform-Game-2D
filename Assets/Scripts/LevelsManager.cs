using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsManager : MonoBehaviour
{
    private static bool level2 = false;
    private static bool level3 = false;
    private static int points = 0;

    public static void setLevel2()
    {
        level2 = true;
    }

    public static void setLevel3()
    {
        level3 = true;
    }

    public static bool getLevel2()
    {
        return level2;
    }

    public static bool getLevel3()
    {
        return level3;
    }

    public static void setPoints()
    {
        points++;
    }

    public static int getPoints()
    {
        return points;
    }
}
