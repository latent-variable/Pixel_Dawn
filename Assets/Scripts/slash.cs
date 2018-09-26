using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slash : MonoBehaviour {

	public GameObject slashobj;
	public float slashforce = 400;
	private float delay = .5f;
	private float slashTime;
	private bool initiated;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Q)){
			slashTime = delay + Time.time;
			initiated = true;
		}else if(initiated && (slashTime < Time.time)){
				AudioManager.PlaySound("sword");
				slashobject();
				initiated = false;
		}
	}

	void slashobject(){
		GameObject sl;
		if(gameObject.GetComponent<Player_movement>().facingRight){
			sl = Instantiate(slashobj, transform.position, transform.rotation);
		}
		else{
			sl = Instantiate(slashobj, transform.position + new Vector3(-2,0,0), Quaternion.Euler(0,180,0));
		}
		Rigidbody2D rb = sl.GetComponent<Rigidbody2D>();
		if(gameObject.GetComponent<Player_movement>().facingRight){
			rb.velocity = Vector3.right * slashforce;
		}
		else{
			rb.velocity = Vector3.left * slashforce;
		}
	}
}
