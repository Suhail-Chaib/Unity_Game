using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{

    public string destroyState;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D col){
        
        if(col.tag == "Attack"){
            anim.Play(destroyState);
        }

    } 
    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if(stateInfo.IsName(destroyState) && stateInfo.normalizedTime >=1){
            Destroy(gameObject);
        }        





    }
}
