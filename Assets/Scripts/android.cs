using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class android : MonoBehaviour {

	public GameObject cannon;
	private GameObject copy;
	public float cannon_time;
	private float cannon_off;
	// Use this for initialization
	void Start () {

			cannon.SetActive(false);
			copy = cannon;

	}

	// Update is called once per frame
	void Update () {

				if(Animations.get_cannon_shot()){
						cannon.SetActive(true);
						cannon_off = cannon_time + Time.time;
				}else if( cannon_off < Time.time){
						cannon.transform.localPosition = new Vector3(2,0,0);
					  cannon.SetActive(false);
				}

	}

}
