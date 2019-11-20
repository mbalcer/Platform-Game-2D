using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePoints : MonoBehaviour
{
    public Text pointsText = null;

    // Start is called before the first frame update
    void Start()
    {
        pointsText.text = "00";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
