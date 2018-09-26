using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dead_Menu : MonoBehaviour {


	public GameObject deadUI;
	private bool paused = false;
	// Use this for initialization
	void Start () {
			deadUI.SetActive(false);
	}

	// Update is called once per frame
	void Update () {

		    if( GameMaster.dead == true){
							deadUI.SetActive(true);
				}
				else{
						deadUI.SetActive(false);
				}

	}
	public void Restart(){
		Application.LoadLevel(Application.loadedLevel);
	}
	public void MainMenu(){
		Application.LoadLevel(0);
	}
	public void Quit(){
		Application.Quit();
	}

}
