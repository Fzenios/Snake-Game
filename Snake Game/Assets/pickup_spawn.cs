using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup_spawn : MonoBehaviour
{
    //public GameObject[] pickupitemlist;
    void OnTriggerEnter2D(Collider2D other) 
    {
        //if(!other.gameObject.CompareTag("HunterBullet") || !other.gameObject.CompareTag("Hunter"))
        if(other.tag != ("HunterBullet") && other.tag != ("Hunter"))
        {
            Destroy(gameObject); 
        }
    }
   /* {
        if(other.gameObject.CompareTag("SnakeHead"))
        {
            float randomspawnpickupx = Random.Range(-1.15f,1.15f);
            float randomspawnpickupy = Random.Range(-0.61f,0.61f);
            int randompickupitem = Random.Range(0,5);
            Vector2 itemspownpos = new Vector2 (randomspawnpickupx,randomspawnpickupy);
            Instantiate(pickupitemlist[randompickupitem],itemspownpos,Quaternion.identity );
            Destroy(gameObject);  
        }
       else if (other.gameObject.CompareTag("Tail"))
        {
            Debug.Log("oura");
            float randomspawnpickupx = Random.Range(-1.15f,1.15f);
            float randomspawnpickupy = Random.Range(-0.61f,0.61f);
            transform.position = new Vector2 (randomspawnpickupx,randomspawnpickupy);        
        }
    }
    */
}
