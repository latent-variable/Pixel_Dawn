using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour {
    public bool shopActive;
    public GameObject shopCanvas;
    public GameObject shopUI;

	// Use this for initialization
	void Start () {
        shopActive = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(shopActive)
        {
            shopUI.SetActive(true);
            if(Input.GetKeyDown("g"))
            {
                shopActive = false;
                shopUI.SetActive(false);
            }
        }
	}
}
