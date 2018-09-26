using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteUnusedCharacters : MonoBehaviour {
    
    public GameObject[] characterList;
    private int index;

	// Use this for initialization
	void Awake () { 
        Destroy(GameObject.Find("BackgroundMusicMenu"));
        index = PlayerPrefs.GetInt("Selection");

        foreach (GameObject x in characterList)
        {
            x.SetActive(false);
        }

        if(characterList[index])
        {
            characterList[index].SetActive(true);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
