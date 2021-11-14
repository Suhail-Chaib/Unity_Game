using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{

    public GameObject target;
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){   
            
           other.transform.position = target.transform.GetChild(0).transform.position; 
        }
    }

     
    
}
