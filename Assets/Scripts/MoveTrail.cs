using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrail : MonoBehaviour {
    public int moveSpeed = 230;
    public GameObject player;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    // Update is called once per frame
    void Update () {
        //Vector3 direction;
        //if(!player.GetComponent<Player_movement>().facingRight)
        //{
        //    direction = Vector3.left;
        //}
        //else
        //{
        //    direction = Vector3.right;
        //}
        //Debug.Log(direction);
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        Destroy(gameObject, 1);
        //OnCollisionEnter();
	}

    /*private void OnCollisionEnter()
    {
        Destroy(gameObject);
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "zombie")
        {
            Debug.Log("zombb");
            Destroy(this.gameObject);
        }
    }
}
