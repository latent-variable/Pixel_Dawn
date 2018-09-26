using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public GameObject item;

    public virtual void Use()
    {
        //use item
        //something might happen

        Debug.Log("Using " + name);
        //GameObject item = GameObject.Find(name);
        //item.Get.Shoot();
    }

    public GameObject getGameObject()
    {
        return item;
    }
}
