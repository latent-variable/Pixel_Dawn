using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    Camera cam;
    public Interactable focus;
    //public LayerMask movementMask;

    Rigidbody2D rb;
    public int playerSpeed = 10;

    public float jumpForce = 200;
    public bool candoublejump = false;
    public bool canwalljump = false;
    public bool canRun = false;
    private bool doublejump = false;
    private bool walljump = true;
    public string child;
    public bool canHover;
    public float hoverTime = 2;
    private float moveX;
    private bool jumping;
    public  bool onfloor = true;
    private float time_hovering = 0;
    public bool facingRight = true;
    public static bool fr;

    private float Hoversound = .1f;
    private float curHoverSound = 0.0f;

    public bool weaponEntered = false;
    public bool shopEntered = false;
    private Interactable interactable;

    //Stamina implementation
    public float Max_stamina;
    public static float stamina;
    public bool unlimited;
    private bool freeze;
    //use to only turn character sprite
    Transform playerGraphics;
    // Use this for initialization
    void Start()
    {
        // armR = Arm.GetComponent<ArmRotation>();
        rb = GetComponent<Rigidbody2D>();
        playerGraphics = transform.Find(child);
        if (playerGraphics == null)
        {
            Debug.LogError("No Graphics as child of player !");
        }
        time_hovering = Time.time + hoverTime;


        cam = Camera.main;

        //stamina
	      curHoverSound = Time.time + Hoversound;
        stamina = Max_stamina;
        freeze = false;


    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown("e") && weaponEntered)
        {
            if (interactable != null)
            {
                SetFocus(interactable);
            }
        }

        if(Input.GetKeyDown("b") && shopEntered)
        {
            Debug.Log("shop bb ;)");
            GameObject.FindGameObjectWithTag("shop").GetComponent<shop>().shopActive = true;
        }

      if(!GameMaster.isdead()){
            stamina += 1;
            stamina = Mathf.Clamp(stamina,0.0f,Max_stamina);
            //CONTROLS
            moveX = Input.GetAxis("Horizontal");
            FlipPlayer();
            if (Input.GetKeyDown(KeyCode.Space) && freeze == false)
            {
                if (onfloor == true)
                {
                    Jump();
                    stamina -= 10;
                }
                else if (candoublejump == true && doublejump == true)
                {
                    jump2();
                    stamina -= 10;

                }
            }
            if (Input.GetKey(KeyCode.Space) && canHover && Time.time < time_hovering)
            {
                hover();
            }
        }
        if (Input.GetKey(KeyCode.Space) && canHover && Time.time < time_hovering)
        {
            hover();
        }
        if(Input.GetKey(KeyCode.LeftShift) && canRun)
        {
            run();
        }

        //PHYSICS
        if(gameObject.GetComponent<Rigidbody2D>().velocity.x != 0 ){
            stamina -= 1.5f;
        }
        if(stamina > 0 && freeze == false){
              gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }else if (stamina <= 0){
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, gameObject.GetComponent<Rigidbody2D>().velocity.y);
                freeze = true;
        }else if(freeze == true){
            if(stamina >= Max_stamina ){
              freeze = false;
            }

        }
        if(unlimited){
           stamina = Max_stamina;
        }



        //ITEM INTERACTION
        if (Input.GetKeyDown("x"))
        {
            RemoveFocus();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "weapon")
        {
            weaponEntered = true;
            interactable = other.GetComponent<Interactable>();
            //Interactable interactable = other.GetComponent<Interactable>();
            //if (interactable != null)
            //{
            //    SetFocus(interactable);
            //}
        }
        else if(other.gameObject.tag == "shop")
        {
            Debug.Log("shopppp");
            shopEntered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        weaponEntered = false;
        shopEntered = false;
    }

    void SetFocus(Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if(focus != null)
            {
                focus.OnDefocused();
            }
            focus = newFocus;
        }
        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if(focus != null)
            {
                focus.OnDefocused();
            }
        focus = null;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor"||collision.gameObject.tag == "zombie")
        {
            onfloor = true;
            jumping = false;
            walljump = true;
            time_hovering = Time.time + hoverTime;
        }
        if (collision.gameObject.tag == "wall")
        {
            if (walljump == true)
            {
                doublejump = true;
                walljump = false;
            }
        }
    }

    void hover()
    {
        if(Time.time > curHoverSound){
            curHoverSound = Time.time + Hoversound;
            AudioManager.PlaySound("hover");
        }

        jumping = true;
        onfloor = false;
        rb.AddForce(new Vector2(rb.velocity.x, 20));

    }
    void run()
    {
        float runSpeed = 20f;
        rb.AddForce(new Vector2(rb.velocity.x * runSpeed, rb.velocity.y));
    }
    void jump2()
    {
        AudioManager.PlaySound("jump");
        Vector2 v = rb.velocity;
        v.y = 0;
        rb.velocity = v;
        Jump();
        doublejump = false;
    }

    void Jump()
    {
        AudioManager.PlaySound("jump");
        jumping = true;
        onfloor = false;
        rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
        doublejump = true;
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
            fr = facingRight;
        }
        else
        {

            facingRight = false;
            fr = facingRight;
            theScale.x = -1;
            playerGraphics.localScale = theScale;
        }
    }
    public static bool direction(){

        return(fr);

    }
    public static float getStamina(){
        return(stamina);
    }

}
