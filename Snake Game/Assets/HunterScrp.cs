using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterScrp : MonoBehaviour
{
    public bool HunterAlive = false; 
    //public GameObject NewHunterSpown;
    //public int counter = 0;
    float randomspawnhuntery;
    float hunterx;
    public Transform ShotSpot;
    public GameObject HunterBullet;
    public static bool HunterRight = true; 
    public static int randomx;


    void Start() 
    {
        //ShotSpot = GameObject.FindGameObjectWithTag("ShotSpot").transform;
        Vector3 characterScale = transform.localScale;        
    }

    void Update()
    {
        if(!HunterAlive)
        {         
            HunterAlive = true;  
            //Debug.Log(HunterAlive);
            Invoke("CreateHunter",4f);
        }
    }

    void CreateHunter ()
    {
        Vector3 characterScale = transform.localScale;  
        randomx = Random.Range(0,2);
        
        if (randomx == 0)
        {
            randomspawnhuntery = Random.Range(-0.55f,0.55f);
            hunterx = -1.1f; 

            characterScale.x = 0.04f;
            transform.localScale = characterScale;
            HunterRight = false; 
        }
        else if (randomx == 1)
        {
            randomspawnhuntery = Random.Range(-0.55f,0.55f);
            hunterx = 1.1f; 

            characterScale.x = -0.04f;
            transform.localScale = characterScale;
            HunterRight = true; 
        }

        Vector2 HunterPos = new Vector2 (hunterx,randomspawnhuntery);
        transform.SetPositionAndRotation(HunterPos,Quaternion.identity);
        InvokeRepeating("HunterShoot",1f,5f);
    }

    void HunterShoot()
    {
       // Debug.Log(ShotSpot.position);
        Instantiate(HunterBullet, ShotSpot.position, Quaternion.identity);        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {        
        if(other.tag == "SnakeHead")
        {
            transform.position = new Vector3 (1,1,0);
            CancelInvoke();
            HunterAlive = false;
        }
    }
}
