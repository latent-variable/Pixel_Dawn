using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : Player {
    Rigidbody2D rb;
    bool doublejump = false;
    bool walljump = false;
    bool jumping = false;
	// Use this for initialization
	public override void Start () {
        base.Start();
        rb = transform.parent.GetComponent<Rigidbody2D>();
    }

    void Jump()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();

        //AudioManager.PlaySound("jump");
        rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
    }

    void jump2()
    {
       // AudioManager.PlaySound("jump");
        Vector2 v = rb.velocity;
        v.y = 0;
        rb.velocity = v;
        Jump();
        doublejump = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor" || collision.gameObject.tag == "zombie")
        {
            onfloor = true;
            jumping = false;
        }
        if (collision.gameObject.tag == "wall")
        {
            doublejump = true;
            walljump = false;
        }
    }
    
    // Update is called once per frame
    public override void Update () {
        base.Update();
        if(jumping && doublejump)
        {
            jump2();
        }
	}
}
