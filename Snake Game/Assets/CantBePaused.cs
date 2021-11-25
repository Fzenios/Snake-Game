using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CantBePaused : MonoBehaviour
{
    public Head Head;
    void OnEnable()
    {
        Head.CantPause = true;
    }
    
    void OnDisable() 
    {
        Head.CantPause = false;        
    } 
}
