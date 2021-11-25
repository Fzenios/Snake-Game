using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class MainMenu : MonoBehaviour
{
    public PauseMenu PauseMenu;

    public void PlayCasual ()
    {
        PauseMenu.gamechaos = false;
        PauseMenu.gamewalled = false;
        SceneManager.LoadScene("CasualGameMode");
    }
    public void PlayWalled ()
    {
        PauseMenu.gamechaos = false;
        PauseMenu.gamewalled = true;
        SceneManager.LoadScene("WalledGameMode");
    }
    public void PlayChaos ()
    {
        PauseMenu.gamechaos = true;
        PauseMenu.gamewalled = false;
        SceneManager.LoadScene("ChaosGameMode");
    }
        public void QuitGame()
    {
        Application.Quit();
    }
 
}
