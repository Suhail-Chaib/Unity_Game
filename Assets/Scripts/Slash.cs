using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{

    public float waitBeforeDestroy;
    public Vector2 mov;
    public float speed = 5;

 
    IEnumerator OnTriggerEnter2D(Collider2D col){

            if(col.tag == "Object"){
                yield return new WaitForSeconds(waitBeforeDestroy);
                Destroy(gameObject);
            }else if(col.tag != "Player" && col.tag != "Attack"){
                Destroy(gameObject);  
            }
    }   
    
     void Update()
    {
        transform.position += new Vector3(mov.x,mov.y,0) * speed *+ Time.deltaTime;
    }

    

      
}
