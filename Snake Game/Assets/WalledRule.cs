using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalledRule : MonoBehaviour
{
    public GameObject GameOverWindow;
    public GameObject AudioMain;

    public Head Head;

   
        void OnTriggerEnter2D(Collider2D other) 
        {    
        if(other.gameObject.CompareTag("BackGround"))
            {
                Time.timeScale = 0f;
                AudioMain.GetComponent<AudioSource>().Stop();
                GameOverWindow.SetActive(true);
                Head.CantPause = true; 
            }
        }
}
