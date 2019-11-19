using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    private static bool created = false;

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
}