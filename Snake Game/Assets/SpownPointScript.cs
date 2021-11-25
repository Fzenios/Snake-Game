using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpownPointScript : MonoBehaviour
{
    public GameObject[] pickupitemlist;
    public Transform SpownPosition; 
    GameObject NewItemSpown;
    public GameObject WinnerWindow;
    int ResetCounter = 0;
    int ItemCounter = 0;
    public int ScoreCounter = 0;
    public GameObject AudioMain;
    public Head Head;
    public Slider slider;
    public PauseMenu PauseMenu;
    
    //static float ScoreSlider = 0;

    private void Update() 
    { 
        if (ResetCounter > 300)
        {
        Time.timeScale = 0f;
        AudioMain.GetComponent<AudioSource>().Stop();
        WinnerWindow.SetActive(true);
        Head.CantPause = true;
        } 
    
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("SnakeHead"))
        {
            Destroy(NewItemSpown);
            ResetCounter = 0;
            ItemCounter++;
            ScoreCounter++;
            //Debug.Log(PauseMenu.gamewalled);
            if(PauseMenu.gamewalled)
            {    
                float randomspawnpickupx = Random.Range(-1.05f,1.04f);
                float randomspawnpickupy = Random.Range(-0.56f,0.56f);
                transform.position = new Vector2 (randomspawnpickupx,randomspawnpickupy);
            }
            else 
            {
                float randomspawnpickupx = Random.Range(-1.15f,1.15f);
                float randomspawnpickupy = Random.Range(-0.61f,0.61f);
                transform.position = new Vector2 (randomspawnpickupx,randomspawnpickupy);
            }
            if (!other.gameObject.CompareTag("Tail"))
            {
                //Debug.Log(ItemCounter);
                if(ItemCounter == 1)
                {
                Invoke("CreateNewItem",1f);
                }
            }
        }
       else if (other.gameObject.CompareTag("Tail"))
        {
            ResetCounter++;
            slider.value = ResetCounter/2;
            Debug.Log(ResetCounter);
            float randomspawnpickupx = Random.Range(-1.15f,1.15f);
            float randomspawnpickupy = Random.Range(-0.61f,0.61f);
            transform.position = new Vector2 (randomspawnpickupx,randomspawnpickupy);  
        }

    }

    void CreateNewItem ()
    {
        int randompickupitem = Random.Range(0,5);
        NewItemSpown = Instantiate(pickupitemlist[randompickupitem],SpownPosition.position,Quaternion.identity);
        ItemCounter = 0;
    }


}
