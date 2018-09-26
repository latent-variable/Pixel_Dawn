using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour {

	public int rotationOffset = 90;
	public Quaternion current_rotation;
	public bool armRight = true;


	// Update is called once per frame
	void Update () {

		Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		difference.Normalize();



		float rotz = Mathf.Atan2(difference.y, difference.x)*Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f,0f,rotz + rotationOffset);
		current_rotation = transform.rotation;

		Vector3 theScale = transform.localScale;
		Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
		float WorldXPos = Camera.main.ScreenToWorldPoint(pos).x; //Converts screen point to point in world

		//invert the arm when turning left and then again when turning right
		if (WorldXPos > gameObject.transform.position.x)
		{
				theScale.y = 1;
				transform.localScale = theScale;
		}

		else
		{
				armRight = !armRight;
				theScale.y = -1;
				transform.localScale = theScale;
		}
	}
}
