using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bulllet : MonoBehaviour
{
    public float speedbullet = 1f;
    public float rotateSpeed = 100f;
    //public GameObject snake; 
    Transform SnakePos;
    Vector3 SnakeDirection;
    Vector3 targetlocked;
    Rigidbody2D rb;
    public HunterScrp HunterScrp;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SnakePos = GameObject.FindGameObjectWithTag("SnakeHead").transform;
        //targetlocked = new Vector3 (SnakePos.position.x, SnakePos.position.y);
        Vector3 characterScale = transform.localScale;
        if(HunterScrp.randomx == 0)
        {
            characterScale.x = 0.01f;
            transform.localScale = characterScale;
        }
        else 
        {
            characterScale.x = -0.01f;
            transform.localScale = characterScale;
        }
    }
    void FixedUpdate()
    {
        
        Vector2 direction = ((Vector2)SnakePos.position - rb.position).normalized;
        //direction.Normalize();
        
        if(HunterScrp.HunterRight)
        { 
        float rotateAmount = Vector3.Cross(direction, -transform.right).z;
        rb.angularVelocity = -rotateAmount * rotateSpeed;
        rb.velocity = -transform.right * speedbullet;
        }
        else if(!HunterScrp.HunterRight)
        {
            float rotateAmount = Vector3.Cross(direction, transform.right).z;
            rb.angularVelocity = -rotateAmount * rotateSpeed;
            rb.velocity = transform.right * speedbullet;
        }
        //SnakeDirection = (SnakePos.position - transform.position).normalized;
        //transform.Translate(SnakeDirection * Time.deltaTime * speedbullet); */ //κώδικας για να σε ακολουθεί κα΄τι.    
        
        //transform.Translate(SnakePos.position * speedbullet * Time.deltaTime);    
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "EdgeOfMap")
       // if (other.gameObject.CompareTag("EdgeOfMap"))
        {
            Destroy(gameObject); 
        }

    }
}
