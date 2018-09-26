using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private int health;
    Rigidbody2D rb;
    public Interactable focus;
    //public LayerMask movementMask;
    public int playerSpeed = 10;

    public float jumpForce = 200;
    public string child;
    private float moveX;
    private bool jumping;
    public bool onfloor = true;
    public bool facingRight = true;

    Transform playerGraphics;

    // Use this for initialization
    public virtual void Start() {
      //  Debug.Log(transform.parent.name);
        rb = transform.parent.GetComponent<Rigidbody2D>();
        playerGraphics = transform.GetChild(0);
        if (playerGraphics == null)
        {
            Debug.LogError("No Graphics as child of player !");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("here");
        if (collision.gameObject.tag == "floor" || collision.gameObject.tag == "zombie")
        {
            onfloor = true;
            jumping = false;
        }
    }

    void Jump()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();

        //AudioManager.PlaySound("jump");
        jumping = true;
        onfloor = false;
        rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
    }
    void FlipPlayer()
    {
        
        //flip camera based of mouse dirrection to the character
        Vector3 theScale = playerGraphics.localScale;
        Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        float WorldXPos = Camera.main.ScreenToWorldPoint(pos).x; //Converts screen point to point in world

        if (WorldXPos > gameObject.transform.position.x)
        {
            theScale.x = 1;
            playerGraphics.localScale = theScale;
            facingRight = true;
        }
        else
        {

            facingRight = false;
            theScale.x = -1;
            playerGraphics.localScale = theScale;
        }
    
    }

    // Update is called once per frame
    public virtual void Update() {

        rb = transform.parent.GetComponent<Rigidbody2D>();

        //CONTROLS
        moveX = Input.GetAxis("Horizontal");
        FlipPlayer();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onfloor == true)
            {
                Jump();
            }
        }

        //PHYSICS
        rb.velocity = new Vector2(moveX* playerSpeed, rb.velocity.y);

    }

    public bool getJump()
    {
        return jumping;
    }
}
