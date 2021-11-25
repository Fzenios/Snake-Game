using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class Head : MonoBehaviour
{
    public float speed = 5f;
    public float moveRate = 0.3f;
    public SpriteRenderer spriteRenderer;
    private Vector2 direction;
    public List <Transform> TailPositions;
    public GameObject tail;
    private int currentStep, totalSteps;
    public GameObject GameOverWindow;
    public bool CantPause = false;
    //public PauseMenu PauseMenu;
    public AudioSource AudioSour;
    public AudioClip[] AudioClipArray;
    public GameObject AudioMain; 
    void Start()
    {
        Time.timeScale = 1f;
        direction = Vector2.up;
        InvokeRepeating ("Move", moveRate, moveRate);
    }

    void Update()
    {
        if (currentStep != totalSteps)
        ChangeDirection();
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == ("PickUp")||other.tag == ("Hunter"))
        {
        //if (other.tag == "PickUp")
        //Debug.Log("test"); 
        createnewtail();
        AudioSour.clip = AudioClipArray[Random.Range(0,AudioClipArray.Length)];
        AudioSour.PlayOneShot(AudioSour.clip);        
        }


        if (other.tag == ("Tail")||other.tag == ("HunterBullet"))
        {
         Time.timeScale = 0f;
         AudioMain.GetComponent<AudioSource>().Stop();
         GameOverWindow.SetActive(true);
         CantPause = true; 
        } 
           
    }

    void Move()
    {
        Vector3 lastPos = transform.position;
        transform.Translate (direction * speed);
        
        if(TailPositions.Count !=0 ){
        TailPositions.Last ().position = lastPos;
        TailPositions.Insert (0,TailPositions.Last());
        TailPositions.RemoveAt(TailPositions.Count -1); 
        //Debug.Log(TailPositions.Last());
        }
        
        if     (transform.position.x < -1.20)
            transform.position += new Vector3 (2.40f,0,0);
        else if(transform.position.x > 1.20)
            transform.position += new Vector3 (-2.40f,0,0);
        else if(transform.position.y > 0.74)
            transform.position += new Vector3 (0,-1.4f,0);
        else if(transform.position.y < -0.74)
            transform.position += new Vector3 (0,1.4f,0);

        totalSteps++;
        
    }

    void ChangeDirection()
    {
        if(!PauseMenu.GameIsPaused && !CantPause)
        {
        if(Input.GetButtonDown("Vertical up") && direction!= Vector2.down)
        {
            spriteRenderer.transform.eulerAngles = new Vector3 (0,0,0);
            direction = Vector2.up;
            currentStep = totalSteps;
        } 
        else if (Input.GetButtonDown("Vertical down")&& direction!= Vector2.up)
        {
            direction = Vector2.down;
            spriteRenderer.transform.eulerAngles = new Vector3 (0,0,180);
            currentStep = totalSteps;
        }
        else if (Input.GetButtonDown("Horizontal left")&& direction!= Vector2.right)
        {
            spriteRenderer.transform.eulerAngles = new Vector3 (0,0,90);
            direction = Vector2.left;
            currentStep = totalSteps;
        } 
        else if (Input.GetButtonDown("Horizontal right")&& direction!= Vector2.left)
        {
            spriteRenderer.transform.eulerAngles = new Vector3 (0,0,-90);
            direction = Vector2.right;
            currentStep = totalSteps;
        }
        }
    }

   void createnewtail()
    {   
        //other.gameObject.SetActive(false);
        Vector2 spawnPos = new Vector2 (5,5);
        GameObject newtail = Instantiate(tail, spawnPos, Quaternion.identity) as GameObject;
        newtail.transform.parent = GameObject.Find ("Tail Holder").transform;  //για να κάνει το newtail child του tail holder 
        TailPositions.Add (newtail.transform);
    }
}
