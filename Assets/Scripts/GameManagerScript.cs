using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    private Vector3 POS_BEGIN_LVL1 = new Vector3((float)4.08, (float)0.92, 0);
    private Vector3 POS_BEGIN_LVL2 = new Vector3((float)-8.9, (float)4.1, 0);
    private Vector3 POS_BEGIN_LVL3 = new Vector3();

    private static bool created = false;
    private Scene scene;

    private void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void LoadLevels()
    {
        SceneManager.LoadScene("Levels", LoadSceneMode.Single);
    }

    public void LoadInfo()
    {
        SceneManager.LoadScene("Authors", LoadSceneMode.Single);
    }

    public void Load1Level()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    public void Load2Level()
    {
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }

    public void Load3Level()
    {
        SceneManager.LoadScene("Level3", LoadSceneMode.Single);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ResetLevel(CharacterController2D player)
    {
        if(scene.name == "Level1")
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
}