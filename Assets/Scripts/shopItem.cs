using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopItem : MonoBehaviour {
    public GameObject shop;
    public GameObject item;
    public int price;

	// Use this for initialization
	void Start () {
        shop = GameObject.FindGameObjectWithTag("shop");
	}
	
	public void purchaseItem()
    {
        if(price <= GameMaster.score)
        {
            GameMaster.changescore(price);
            Instantiate(item, shop.transform.position, shop.transform.rotation);
        }
    }
}
