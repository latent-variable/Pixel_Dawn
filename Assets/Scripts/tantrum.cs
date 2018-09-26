using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class tantrum : MonoBehaviour {
    public Text myText;
    float time = 0.0f;
    public static bool tantrumTime = false;
    private GameObject[] guns;
	// Use this for initialization
	void Start () {
        myText.text = "Kill more to tantrum.";
        guns = GameObject.FindGameObjectsWithTag("tantrum");
        for (int i = 0; i < 5; i++)
        {
            guns[i].SetActive(false);
        }
    }

    void tantrumBegin()
    {

        for (int i = 0; i < 5; i++)
        {
            guns[i].SetActive(true);
        }

    }

    public IEnumerator tantrumEnd()
    {
        Debug.Log("waiting");
        yield return new WaitForSeconds(5f);
        GameMaster.setTantrum(false);
        for (int i = 0; i < 5; i++)
        {
            guns[i].SetActive(false);
        }
        tantrumTime = false;
        myText.text = "Kill more to tantrum.";
        //GameMaster.setTantrum(false);
    }

    public bool returnTantrumTime()
    {
        return tantrumTime;
    }
	// Update is called once per frame
	void Update () {
        if(GameMaster.canTantrum())
        {
            myText.text = "Tantrum Mode Available! (Q)";
        }
    	if(GameMaster.canTantrum() && (Input.GetKeyDown("q")))
        {
          AudioManager.PlaySound("Tantrum");

            tantrumTime = true;
            tantrumBegin();
        }
      // while(tantrumTime)
       // {
            Debug.Log("tantrum here");
        // tantrumBegin();
        //tantrumEnd();
        if(tantrumTime)
        StartCoroutine("tantrumEnd");
       // }
	}

}
