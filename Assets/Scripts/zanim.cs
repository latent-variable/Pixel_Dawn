using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zanim : MonoBehaviour {
    public GameObject zombie;
    Animator anim;
    //Rigidbody2D rb;

    private EnemyAI Aiaccess;
    private bool aiattack;
    private bool aimove = true;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        //rb = gameObject.GetComponentInParent(typeof(Rigidbody2D)) as Rigidbody2D;
        Aiaccess = zombie.GetComponent<EnemyAI>();
        aiattack = Aiaccess.attacking;
        aimove = Aiaccess.moving;
    }
	
	// Update is called once per frame
	void Update () {
        Aiaccess = zombie.GetComponent<EnemyAI>();
        aiattack = Aiaccess.attacking;
        aimove = Aiaccess.moving;
        //Debug.Log(aiattack);
        //Debug.Log(aimove);
        if (!aiattack)
        {
            aimove = true;
        }
        if (aimove)
        {
            anim.SetInteger("state", 1); //transition to walking
           // Debug.Log("here");
        }
        if (aiattack)
        {
            //Debug.Log("here2");
            anim.SetInteger("state", 2); //transition to attacking
            //Debug.Log(aiattack);
            aimove = false;
        }
        else if (!aimove && !aiattack)
        {
            anim.SetInteger("state", 0); //transition to idle
        }

    }
}
