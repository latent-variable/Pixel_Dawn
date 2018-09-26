using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slashobject : MonoBehaviour {

	private float startTime = 0;
	private float timeafterdestroy = 1f;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		startTime += Time.deltaTime;
		if(startTime >= timeafterdestroy){
			destroy();
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "zombie" || collision.gameObject.tag == "wolf" ){
			collision.gameObject.GetComponent<Enemy>().DamageEnemy(50);
		}
	}

	void destroy(){
		Destroy(gameObject);
	}
}
