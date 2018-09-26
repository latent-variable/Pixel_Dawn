using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwarm : MonoBehaviour {
	private GameObject cowboyarm;
	private GameObject cowboy;
	private bool right;
	private bool didtransform = false;
//	private GameObject cowboy;
	// Use this for initialization
	void Start () {
		cowboy = GameObject.Find("cowboyPlayer");
		right = cowboy.GetComponent<Player_movement>().facingRight;
		gameObject.SetActive(true);
		cowboyarm = GameObject.Find("cowboyarm");
	}

	// Update is called once per frame
	void Update () {
		right = cowboy.GetComponent<Player_movement>().facingRight;
	}

	public void animationstart(){
		if(!Player_movement.direction()){
			transform.Rotate(0,180,0);
			didtransform = true;
		}
		else{
			transform.Rotate(0,0,0);
			didtransform = false;
		}
	}

	public void animationend3(){
		if(didtransform){
			transform.Rotate(0,180,0);
		}
		else{
			transform.Rotate(0,0,0);
		}
	}

	public void animationend2()
	{
		cowboyarm.SetActive(true);
		gameObject.SetActive(false);
	}
}
