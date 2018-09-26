using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Android_cannon : MonoBehaviour {

	public float cannon_speed;
	public int cannonDamage;
	private bool shot;
	private Vector3 original_pos;
	Rigidbody2D rb;
	Animator anim;
	Transform tran;
	// Use this for initialization
	void Start () {

		tran = GetComponent<Transform>();
	  original_pos = tran.localPosition;
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		shot = false;


	}

	// Update is called once per frame
	void Update () {

		if(Animations.get_cannon_shot()){
			anim.SetBool("shot",true);
			tran.localPosition = this.transform.parent.position;


		}else{

			if(Player_movement.direction()){
					rb.velocity = new Vector2(cannon_speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
			}else{
					rb.velocity = new Vector2(-cannon_speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
			}
			anim.SetBool("shot",false);

		}
	}
	void OnCollisionStay2D(Collision2D col){
		Debug.Log("Zombie collision");
		if(col.gameObject.tag == "zombie" || col.gameObject.tag == "wolf"){
		  	col.gameObject.GetComponent<Enemy>().DamageEnemy(cannonDamage);
		}
	}


}
