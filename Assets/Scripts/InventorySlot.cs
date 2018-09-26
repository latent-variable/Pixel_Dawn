using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {
    public Image icon;
    Item item;

    public Transform player;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    public void UseItem()
    {
        if(item != null)
        {
            //If player is already holding a gun, destroy it to make space for this item
            if(player.GetChild(0).childCount == 1)
            {
                Destroy(player.GetChild(0).GetChild(0).gameObject);
            }

            //make child of player's arm v.2
            Sprite sp = player.GetChild(0).GetComponent<SpriteRenderer>().sprite;
            Vector3 armPosition;
            if(player.name == "ninjaPlayer"){
                 armPosition= player.GetChild(0).transform.localPosition + 2.1f*sp.bounds.max +new Vector3(0.2f,0.3f,0.0f);
            }else{
                 armPosition = player.GetChild(0).transform.localPosition + sp.bounds.max + new Vector3(0.5f,0.1f,0.0f);;
            }

            GameObject child = Instantiate(item.getGameObject(), armPosition, Quaternion.identity);
            child.transform.parent = player.GetChild(0).transform;
            child.transform.localPosition = armPosition;

            if (!player.GetComponent<Player_movement>().facingRight)
            {
                Vector3 flip = child.transform.localScale;
                flip.x *= -1;
                child.transform.localScale = flip;
            }
            item.Use();

            //make child of player's arm
            //Vector3 armPosition = player.GetChild(0).transform.localPosition;
            //armPosition.x += 1f;
            //armPosition.y += 1f;
            //GameObject child = Instantiate(item.getGameObject(), armPosition, Quaternion.identity);
            //child.transform.parent = player.GetChild(0).transform;
            //child.transform.localPosition = armPosition;
            //if(!player.GetComponent<Player_movement>().facingRight)
            //{
            //    Vector3 flip = child.transform.localScale;
            //    flip.x *= -1;
            //    child.transform.localScale = flip;
            //}
            //item.Use();
        }
    }
}
