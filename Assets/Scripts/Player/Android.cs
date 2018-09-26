using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Android : Player
{
    private float time_hovering = 0;
    public float hoverTime = 2;
    private float Hoversound = .1f;
    private float curHoverSound = 0.0f;
    Rigidbody2D rb;

    public override void Start()
    {
        base.Start();
        time_hovering = Time.time + hoverTime;
        curHoverSound = Time.time + Hoversound;
        rb = transform.parent.GetComponent<Rigidbody2D>();
    }

    void hover()
    {

        if (Time.time > curHoverSound)
        {
            curHoverSound = Time.time + Hoversound;
            //AudioManager.PlaySound("hover");
        }
        onfloor = false;
        rb.AddForce(new Vector2(rb.velocity.x, 20));

    }
    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (Input.GetKey(KeyCode.Space) && Time.time < time_hovering)
        {
            hover();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor" || collision.gameObject.tag == "zombie")
        {
            time_hovering = Time.time + hoverTime;
        }
    }
}
