using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade : MonoBehaviour {

	public float timeAfterExplosion = 3f;
	private float startTime = 0f;
	public float grenadeRadius = 2f;
	public float explosionForce = 500f;
	Animator anim;

	// Update is called once per frame
	void Update () {
		anim = GetComponent<Animator>();
		startTime += Time.deltaTime;
		if(startTime >= timeAfterExplosion){
			explode();
		}
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		rb.angularDrag += 0.2f;
	}

	void explode(){
		anim.SetBool("exploded",true);
		AudioManager.PlaySound("grenade");
		//anim.SetBool("exploded",true);
	}

	public void destroy(){
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, grenadeRadius);
		for(int i = 0; i < colliders.Length; i++){
			Rigidbody2D rb = colliders[i].GetComponent<Rigidbody2D>();
			if(rb != null){
				Vector2 dir = rb.transform.position - transform.position;
				float wearoff = 1 - (dir.magnitude / grenadeRadius);
				rb.AddForce(dir.normalized * explosionForce * wearoff);
				if(colliders[i].gameObject.tag == "zombie" || colliders[i].gameObject.tag == "wolf"){
					colliders[i].gameObject.GetComponent<Enemy>().DamageEnemy(100);
				}
			}
		}
		Destroy(gameObject);
	}
}
