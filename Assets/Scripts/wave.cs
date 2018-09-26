using UnityEngine;
﻿using System.Collections;
using UnityEngine.UI;

public class wave : MonoBehaviour {

	private int wave_val = 0;
	Text wavetxt;
	// Use this for initialization
	void Start () {
			wavetxt = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update () {
		wave_val = GameMaster.getwave();
		wavetxt.text = "Wave: " + wave_val;
	}
}
