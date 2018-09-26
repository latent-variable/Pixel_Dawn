using UnityEngine;

public class ItemPickup : Interactable {
    public Item item;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("picking up " + item.name);
        //add to invetnory
        bool wasPickedUp = Inventory.instance.Add(item);

        if(wasPickedUp)
        {
            Destroy(gameObject);
            //make child of player's arm
            //Vector3 newPosition = getPlayer().GetChild(0).transform.localPosition;
            //newPosition.x += 1f;
            //newPosition.y += 1f;
            //transform.parent = getPlayer().GetChild(0).transform;
            //transform.localPosition = newPosition;
        }
    }
}
