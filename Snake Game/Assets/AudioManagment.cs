using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagment : MonoBehaviour
{
    public PauseMenu PauseMenu;     
 
    void Update()
    {
        if(PauseMenu.GameIsPaused)
        GetComponent<AudioSource>().Pause();
        else
        GetComponent<AudioSource>().UnPause();
    }
}
