using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCamera : MonoBehaviour {

	UnityEngine.Camera cam;
	public Transform obj;
	// Use this for initialization
	void Start () {
		cam = UnityEngine.Camera.main;
		obj = GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update () {
		Vector3 pos = cam.WorldToViewportPoint(obj.position);
		if(pos.x >= 0 && pos.x <= 1 && pos.y >= 0 && pos.y <= 1){
			Debug.Log("ON CAMERA!");
		}
	}
}
