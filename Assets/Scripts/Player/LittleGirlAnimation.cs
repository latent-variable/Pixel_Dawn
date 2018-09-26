using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleGirlAnimation : MonoBehaviour {
    Animator anim;
    Rigidbody2D rb;
    private bool jumping;
    private Player bodyR;
    private float timer = 0;

    //Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = gameObject.GetComponentInParent(typeof(Rigidbody2D)) as Rigidbody2D;
        bodyR = gameObject.GetComponentInParent(typeof(LittleGirl)) as LittleGirl;
        if (bodyR == null)
        {
            Debug.LogError("BodyRotation not found!!");
        }
    }


    // Update is called once per frame
    void Update()
    {
        float velocityx = rb.velocity.x;
        float velocityy = rb.velocity.y;

        //ANIMATION
        if ((velocityx > 0.01 || velocityx < -0.01) && (velocityy < 0.01 && velocityy > -0.01))
        {
            anim.SetInteger("state", 2); //transition to running
                                         //handle run_backwards
            if ((bodyR.facingRight && velocityx < -0.01))
            {  //facing right moving left
                anim.SetFloat("direction", -1);
            }
            else if (bodyR.facingRight == false && velocityx > 0.01)
            { //facing left moving right
                anim.SetFloat("direction", -1);
            }
            else
            {
                anim.SetFloat("direction", 1);
            }
        }
        else if (velocityy > 0.01 || velocityy < -0.01)
        {
            anim.SetInteger("state", 1); //transition to jumping
        }
        else if ((velocityy < 0.01 || velocityy > -0.01) && (velocityx < 0.01 && velocityx > -0.01))
        {
            anim.SetInteger("state", 0); //transition to idle
        }
        if (!GameMaster.isdead())
        {
            //ANIMATION
            if ((velocityx > 0.01 || velocityx < -0.01) && (velocityy < 0.01 && velocityy > -0.01))
            {
                anim.SetInteger("state", 2); //transition to running
                                             //handle run_backwards
                if ((bodyR.facingRight && velocityx < -0.01))
                {  //facing right moving left
                    anim.SetFloat("direction", -1);
                }
                else if (bodyR.facingRight == false && velocityx > 0.01)
                { //facing left moving right
                    anim.SetFloat("direction", -1);
                }
                else
                {
                    anim.SetFloat("direction", 1);
                }
            }
            else if ((velocityy > 0.01 || velocityy < -0.01) && bodyR.onfloor == false)
            {
                anim.SetInteger("state", 1); //transition to jumping
            }
        }
        else
        {
            anim.SetBool("dead", true);
        }
    }
}
