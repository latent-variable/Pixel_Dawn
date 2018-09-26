using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharSelect : MonoBehaviour {
    public Image[] pic;

	// Use this for initialization
	void Start () {
        // pic.enabled = false;
        pic[0].enabled = false;
        pic[1].enabled = false;
        pic[2].enabled = false;
        pic[3].enabled = false;
        PlayerPrefs.SetInt("Selection", 0); //default
    }
	

    public void girlSelect()
    {
        pic[0].enabled = true;
        pic[1].enabled = false;
        pic[2].enabled = false;
        pic[3].enabled = false;
        PlayerPrefs.SetInt("Selection", 0);
    }

    public void androidSelect()
    {
        pic[0].enabled = false;
        pic[1].enabled = true;
        pic[2].enabled = false;
        pic[3].enabled = false;
        PlayerPrefs.SetInt("Selection", 1);
    }

    public void cowboySelect()
    {
        pic[0].enabled = false;
        pic[1].enabled = false;
        pic[2].enabled = true;
        pic[3].enabled = false;
        PlayerPrefs.SetInt("Selection", 2);
    }

    public void ninjaSelect()
    {
        pic[0].enabled = false;
        pic[1].enabled = false;
        pic[2].enabled = false;
        pic[3].enabled = true;
        PlayerPrefs.SetInt("Selection", 3);
    }

    public void select(string scenename)
    {
        if(!(pic[0].enabled == false && pic[1].enabled == false && pic[2].enabled == false && pic[3].enabled == false))
        SceneManager.LoadScene(scenename);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
