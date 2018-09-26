using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_script : MonoBehaviour {

	public AudioClip MusicClip;

	public AudioSource BackgroundSource;
	// Use this for initialization
	void Start () {
			BackgroundSource.clip = MusicClip;
			BackgroundSource.Play();
	}

	// Update is called once per frame
	void Update () {


	}
}
