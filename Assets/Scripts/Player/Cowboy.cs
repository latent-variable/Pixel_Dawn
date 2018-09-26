using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowboy : Player {
    Rigidbody2D rb;
	// Use this for initialization
	public override void Start () {
        base.Start();
        rb = transform.parent.GetComponent<Rigidbody2D>();
    }

    void run()
    {
        float runSpeed = 20f;
        rb.AddForce(new Vector2(rb.velocity.x * runSpeed, rb.velocity.y));
    }
    // Update is called once per frame
    public override void Update () {
        base.Update();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            run();
        }
    }
}
