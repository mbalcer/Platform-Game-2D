using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    private Vector3 POS_BEGIN_LVL1 = new Vector3((float)4.08, (float)0.92, 0);
    private Vector3 POS_BEGIN_LVL2 = new Vector3((float)-8.9, (float)4.1, 0);
    private Vector3 POS_BEGIN_LVL3 = new Vector3((float)-25.0, (float)5.1, 0);
    
    public GameObject Heart, Heart1, Heart2;
    private static bool created = false;
    private Scene scene;

    public GameObject Level2, Level3;
    private bool level2, level3;
    private int points;
    private Text Points;
   
    private void Awake()
    {
        
        if (!created)
        {
          //  DontDestroyOnLoad(this.gameObject);
            created = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();

        if (scene.name == "Levels")
        {
            LevelsManagement();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level1" || SceneManager.GetActiveScene().name == "Level2" || SceneManager.GetActiveScene().name == "Level3")
        {
            HeartManager();
        }
    }

    public void LoadMenu()
    {
        
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void LoadLevels()
    {
        SoundManagerScript.PlaySound("menu");
        SceneManager.LoadScene("Levels", LoadSceneMode.Single);
    }

    public void LoadInfo()
    {
        SoundManagerScript.PlaySound("menu");
        SceneManager.LoadScene("Authors", LoadSceneMode.Single);
    }

    public void Load1Level()
    {
        SoundManagerScript.PlaySound("menu");
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    public void Load2Level()
    {
        SoundManagerScript.PlaySound("menu");
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }

    public void Load3Level()
    {
        SoundManagerScript.PlaySound("menu");
        SceneManager.LoadScene("Level3", LoadSceneMode.Single);
    }

    public void Exit()
    {
        SoundManagerScript.PlaySound("menu");
        Application.Quit();
    }

    public void ResetLevel(CharacterController2D player)
    {
        player.transform.Translate(new Vector3(0, 0, 0));
        if (scene.name == "Level1")
        {
            player.transform.position = POS_BEGIN_LVL1;
        }
        else if(scene.name == "Level2")
        {
            player.transform.position = POS_BEGIN_LVL2;
        }
        else if (scene.name == "Level3")
        {
            player.transform.position = POS_BEGIN_LVL3;
        }
    }

    public void HeartManager()
    {
        switch(HeartMenago.getHealth())
        {
            case 3:
                Heart.gameObject.SetActive(true);
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                break;
            case 2:
                Heart.gameObject.SetActive(true);
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(false);
                break;
            case 1:
                Heart.gameObject.SetActive(true);
                Heart1.gameObject.SetActive(false);
                Heart2.gameObject.SetActive(false);
                break;
            case 0:
                Heart.gameObject.SetActive(false);
                Heart1.gameObject.SetActive(false);
                Heart2.gameObject.SetActive(false);
                HeartMenago.setHealth();
                SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
                break;
        }
    }

    public void LevelsManagement()
    {
        level2 = LevelsManager.getLevel2();
        level3 = LevelsManager.getLevel3();

        if (!level2)
        {
            Level2.gameObject.SetActive(false);
            Level3.gameObject.SetActive(false);
        }

        else if(!level3)
        {
            Level2.gameObject.SetActive(true);
            Level3.gameObject.SetActive(false);
        }

        else
        {
            Level2.gameObject.SetActive(true);
            Level3.gameObject.SetActive(true);
        }

        points = LevelsManager.getPoints();
        Points = GameObject.Find("PointsText").GetComponent<Text>();
        Points.text = points.ToString();
    }
}