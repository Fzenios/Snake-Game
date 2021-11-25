using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public Head Head; //για να πάρω μεταβλιτή απο το script
    public SpownPointScript SpownPointScript;

    public static bool gamewalled = false;
    public static bool gamechaos = false;
    

    void Update()
    {  
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(!Head.CantPause)
            {  
                if (GameIsPaused)
                {
                Resume();
                }
                else 
                {
                Pause();
                }
            }
        }
    }

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Resume();
        SceneManager.LoadScene("StartMenu");
    }

    public void QuitGame()
    {
        Resume();
        SceneManager.LoadScene("StartMenu");
    }

     public void NewGameCasual()
    {
        Resume();
        gamewalled = false;
        gamechaos = false;

        SceneManager.LoadScene("CasualGameMode");
    }
        public void NewGameWalled()
    {
        Resume();
        gamewalled = true;
        SceneManager.LoadScene("WalledGameMode");
    }

       public void NewGameChaos()
    {
        Resume();
        gamechaos = true;
        SceneManager.LoadScene("ChaosGameMode");
    }
}
