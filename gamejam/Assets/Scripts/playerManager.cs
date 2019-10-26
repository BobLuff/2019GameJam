using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{

    public float speed;
    private Animator animator;
 
    private Vector3 move;
  //  private bool isInRoom = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    
        
    }

    // Update is called once per frame
    void Update()
    {
        move = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            move.x = -1f;

        }
        if(Input.GetKey(KeyCode.D))
        {
            move.x = 1f;
        }

        if(Input.GetKey(KeyCode.W))
        {
            move.y = 1f;
        }
        
        if(Input.GetKey(KeyCode.S))
        {
            move.y = -1f;
        }


        if(move.sqrMagnitude>0)
        {
            animator.SetBool("move", true);
        }
        else
        {
            animator.SetBool("move", false);
        }

        animator.SetFloat("X", move.x);
        animator.SetFloat("Y", move.y);

        transform.position += move * speed * Time.deltaTime;
        /*
        if (isInRoom)
        {
            transform.position += move * speed * Time.deltaTime;

        }
        */

 
    }


 /*
    void OnTriggerEnter2D(Collider2D collidedObject)
    {
        Debug.Log("ground-->"+collidedObject.tag);
        if(collidedObject.tag==ConstKey.TAG_ROOM&&!isInRoom)
        {
            isInRoom = true;
        }
        
    }

 
    void OnTriggerExit2D(Collider2D collidedObject)
    {
        if (collidedObject.tag == ConstKey.TAG_ROOM&&isInRoom)
        {
            isInRoom = false;
        }

    }
    */
    
}
