using UnityEngine;
﻿using System.Collections;
using UnityEngine.UI;

public class Stamina: MonoBehaviour {

	private float stamina = 0;
	Text staminatxt;
	// Use this for initialization
	void Start () {
			staminatxt = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update () {
		stamina = Player_movement.getStamina();
		staminatxt.text = "Stamina: " + Mathf.RoundToInt(stamina);
	}
}
