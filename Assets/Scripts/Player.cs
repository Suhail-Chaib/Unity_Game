using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    float h;
    bool pulsado;
    float v;
    Vector3 moveDirection;

    bool movePrevent;
    public float speed = 15;

    public GameObject slashPrefab;

    CircleCollider2D attackCollider;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        attackCollider = transform.GetChild(0).GetComponent<CircleCollider2D>();
    }

    void PreventMovement(){        
            if (movePrevent){
                moveDirection = Vector3.zero;
            }      
    }

    void SlashAttack(){

        AnimatorStateInfo estado = anim.GetCurrentAnimatorStateInfo(0);
        bool loading = estado.IsName("Player_Slash");
        if(Input.GetKeyDown(KeyCode.LeftAlt)){
            anim.SetTrigger("loading");
        }else if (Input.GetKeyUp(KeyCode.LeftAlt)){
            anim.SetTrigger("attacking");
            float angle = Mathf.Atan2( 
                anim.GetFloat("movX"),
                anim.GetFloat("movY")
            )* Mathf.Rad2Deg;

            GameObject slashObj = Instantiate(
                slashPrefab, transform.position,
                Quaternion.AngleAxis(angle, Vector3.forward)
            );

            Slash slash = slashObj.GetComponent<Slash>();
            slash.mov.x = anim.GetFloat("movX");
            slash.mov.y = anim.GetFloat("movY");

        }
    }



    void Update()
    {

        h = CrossPlatformInputManager.GetAxis("Horizontal");
        v = CrossPlatformInputManager.GetAxis("Vertical");


        //h = Input.GetAxis("Horizontal");
        //v = Input.GetAxis("Vertical");
        moveDirection.x = h;
        moveDirection.y = v;

        transform.position += moveDirection * Time.deltaTime * speed;

        if(moveDirection != Vector3.zero){
            anim.SetFloat("movX", moveDirection.x);
            anim.SetFloat("movY", moveDirection.y);
            anim.SetBool("walking",true);
        }else{
            anim.SetBool("walking", false);
        }

        AnimatorStateInfo estado = anim.GetCurrentAnimatorStateInfo(0);
        bool atacando = estado.IsName("Player_Attack");

        if(Input.GetKeyDown("space") && (atacando == false)){
            anim.SetTrigger("attacking");
        }

        
        if(moveDirection != Vector3.zero){
            attackCollider.offset = new Vector2(moveDirection.x/14.285f, moveDirection.y/14.285f);
        }
        
        PreventMovement();
        SlashAttack();
      
    }
}
