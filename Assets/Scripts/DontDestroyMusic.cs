using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DontDestroyMusic : MonoBehaviour {
    Scene s;

    private void Awake()
    {
   //     s = SceneManager.GetActiveScene();
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        if(objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        GameObject temp = GameObject.Find("GM");
        Debug.Log("here");
        if (temp == null)
       {
            Debug.Log("not destroying");
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Debug.Log("deleting");
            Destroy(this.gameObject);
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
}
