using UnityEngine;
﻿using System.Collections;
using UnityEngine.UI;

public class score : MonoBehaviour {

	private int score_val = 0;
	Text scoretxt;
	// Use this for initialization
	void Start () {
			scoretxt = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update () {
		score_val = GameMaster.getscore();
		scoretxt.text = "Score: " + score_val;
	}
}
