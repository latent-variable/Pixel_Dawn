using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour {
	Animator anim;
	Animator armanim;
	Rigidbody2D rb;
	private bool jumping;
	private Player_movement bodyR;
	private float cannon_cool_down = 3;
	private float timer = 0;
	private GameObject ninjaarm;
	private GameObject cowboyarm;
	private GameObject throwarm;
	public static bool cannon_shot;

   // public tantrum T;

//Use this for initialization
	void Start () {
		if(gameObject.name == "ninja")
		{
			ninjaarm = GameObject.Find("ninja_arm");
		}
		if(gameObject.name == "cowboy")
		{
			throwarm = GameObject.Find("arm");
			armanim = throwarm.GetComponent<Animator>();
			cowboyarm = GameObject.Find("cowboyarm");
		}
		anim = GetComponent<Animator>();
		rb = gameObject.GetComponentInParent(typeof(Rigidbody2D)) as Rigidbody2D;
        bodyR = gameObject.GetComponentInParent(typeof(Player_movement)) as Player_movement;
        if (bodyR == null){
				Debug.LogError("BodyRotation not found!!");
		}
		if(gameObject.name == "Cowboy")
		{
			throwarm.SetActive(false);
		}
		timer = Time.time + cannon_cool_down;
		cannon_shot = false;
	}


	// Update is called once per frame
	void Update () {
        float velocityx = rb.velocity.x;
        float velocityy = rb.velocity.y;

        if (gameObject.name == "Little_girl" && GameMaster.canTantrum() && tantrum.tantrumTime && !GameMaster.isdead())
        {
            Debug.Log("animation starting");
            anim.SetInteger("state", 3);
            return;
        }

        //ANIMATION
        if ((velocityx > 0.01 || velocityx < -0.01) && (velocityy < 0.01 && velocityy > -0.01))
        {
			anim.SetInteger("state", 2); //transition to running
			//handle run_backwards
			if((bodyR.facingRight && velocityx < -0.01)){  //facing right moving left
				anim.SetFloat("direction",-1);
			}else if(bodyR.facingRight == false && velocityx > 0.01){ //facing left moving right
					anim.SetFloat("direction",-1);
			}else{
				anim.SetFloat("direction",1);
			}
        }
        else if(velocityy > 0.01 || velocityy < -0.01)
        {
            anim.SetInteger("state", 1); //transition to jumping
        }
        else if((velocityy < 0.01 || velocityy > -0.01) && (velocityx < 0.01 && velocityx > -0.01))
        {
            anim.SetInteger("state", 0); //transition to idle
        }
		if(!GameMaster.isdead())
		{
		        //ANIMATION
	        if((velocityx > 0.01 || velocityx < -0.01) && (velocityy < 0.01 && velocityy > -0.01))
	        {
				anim.SetInteger("state", 2); //transition to running
				//handle run_backwards
				if((bodyR.facingRight && velocityx < -0.01)){  //facing right moving left
					anim.SetFloat("direction",-1);
				}else if(bodyR.facingRight == false && velocityx > 0.01){ //facing left moving right
						anim.SetFloat("direction",-1);
				}else{
					anim.SetFloat("direction",1);
				}
	        }
	        else if((velocityy > 0.01 || velocityy < -0.01)&& bodyR.onfloor == false)
	        {
	            anim.SetInteger("state", 1); //transition to jumping
	        }
	        else if((velocityy < 0.01 || velocityy > -0.01) && (velocityx < 0.01 && velocityx > -0.01))
	        {

							if((Input.GetKeyDown("q") && Time.time > timer) && gameObject.name == "android")
							{
								AudioManager.PlaySound("cannon");
								cannon_shot = true;
								anim.SetBool("ability",true);
								timer = Time.time + cannon_cool_down;
							}
							else
							{
								anim.SetBool("ability",false);
								anim.SetInteger("state", 0); //transition to idle
								cannon_shot = false;

							}

	        }
			if(Input.GetKeyDown("q") && gameObject.name == "ninja")
			{
				ninjaarm.SetActive(false);
				anim.SetBool("ability", true);

			}
			else if(gameObject.name == "ninja")
			{
				anim.SetBool("ability", false);
			}
			if(Input.GetKeyDown("q") && gameObject.name == "cowboy")
			{
				cowboyarm.SetActive(false);
				throwarm.SetActive(true);
				armanim.Play("throw");
			}
			// else if( gameObject.name == "cowboy")
			// {
			// 	armanim.SetBool("throw", false);
			// }
		}
		else
		{
			anim.SetBool("dead",true);
		}
	}

	public void animationend()
	{
		ninjaarm.SetActive(true);
	}
	//methods used to comunicate with android cannon
	public static bool get_cannon_shot(){
		return(cannon_shot);
	}
}
