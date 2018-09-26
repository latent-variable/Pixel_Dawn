using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found");
            return;
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 6;
    public List<Item> items = new List<Item>();

    public Transform itemsParent;

    public void Start()
    {
        itemsParent = GameObject.FindGameObjectWithTag("itemsParent").transform;
    }

    public void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            Debug.Log("1111");
            itemsParent.GetChild(0).GetComponentInChildren<InventorySlot>().UseItem();
        }
        if (Input.GetKeyDown("2"))
        {
            itemsParent.GetChild(1).GetComponentInChildren<InventorySlot>().UseItem();
        }
        if (Input.GetKeyDown("3"))
        {
            itemsParent.GetChild(2).GetComponentInChildren<InventorySlot>().UseItem();
        }
        if (Input.GetKeyDown("4"))
        {
            itemsParent.GetChild(3).GetComponentInChildren<InventorySlot>().UseItem();
        }
        if (Input.GetKeyDown("5"))
        {
            itemsParent.GetChild(4).GetComponentInChildren<InventorySlot>().UseItem();
        }
        if (Input.GetKeyDown("6"))
        {
            itemsParent.GetChild(5).GetComponentInChildren<InventorySlot>().UseItem();
        }
    }

    public bool Add(Item item)
    {
        if(items.Count >= space)
        {
            Debug.Log("Not enough room in inventory");
            return false;
        }
        items.Add(item);
        if(onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
        onItemChangedCallback.Invoke(); //triggering event
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
