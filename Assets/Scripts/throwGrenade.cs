using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwGrenade : MonoBehaviour
{

    public GameObject grenade;
    public float throwForce = 400;
    Rigidbody2D cowboyrb;
    Vector3 up;
    private int maxgrenades = 5;
    private int currentwave;

    void Start()
    {
        cowboyrb = GetComponent<Rigidbody2D>();
        up = new Vector3(0f, 1f, 0f);
        currentwave = GameMaster.getwave();
       // Physics2D.IgnoreLayerCollision(9, 9);
        //gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentwave != GameMaster.getwave())
        {
            maxgrenades = 5;
            currentwave = GameMaster.getwave();
        }
        if (Input.GetKeyDown(KeyCode.Q) && maxgrenades > 0)
        {
            //gameObject.SetActive(true);
            throwObject();
            maxgrenades--;
            //anim.Play("throw");
            //gameObject.SetActive(false);
        }
    }

    void throwObject()
    {
        GameObject gr = Instantiate(grenade, transform.position + up, transform.rotation);
        Rigidbody2D rb = gr.GetComponent<Rigidbody2D>();
        if (gameObject.GetComponent<Player_movement>().facingRight)
        {
            throwForce += cowboyrb.velocity.x;
            rb.AddForce(transform.right * throwForce);
        }
        else
        {
            throwForce += -cowboyrb.velocity.x;
            rb.AddForce(-transform.right * (throwForce + -rb.velocity.x));
        }
    }
}
