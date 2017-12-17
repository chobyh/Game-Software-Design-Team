using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotScript : MonoBehaviour {

	public Item item;
	Image itemImage;
    public int slotNumber;
	Inventory inventory;

	// Use this for initialization
	void Start () {
		inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        itemImage = gameObject.transform.GetChild (0).GetComponent<Image> ();

    }

    // Update is called once per frame
    void Update()
    {

        if (inventory.Items[slotNumber].itemName != null)
        {
            itemImage.enabled = true;
            itemImage.sprite = inventory.Items[slotNumber].itemIcon;
        }
        else
        {
            itemImage.enabled = false;
        }



        /*public void OnPointerDown(PointerEventData data)
        {
            if (inventory.Items [slotNumber].itemName == null && inventory.draggingItem) 
            {
                inventory.Items [slotNumber] = inventory.draggedItem;
                inventory.closeDraggedItem ();
            } 
            else if (inventory.draggingItem && inventory.Items [slotNumber].itemName != null) 
            {
                inventory.Items [inventory.indexOfDraggedItem] = inventory.Items [slotNumber];
                inventory.Items [slotNumber] = inventory.draggedItem;
                inventory.closeDraggedItem();
            }
        }
        public void OnPointerEnter(PointerEventData data)
        {
            if (inventory.Items [slotNumber].itemName != null && !inventory.draggingItem) 
            { 
                //inventory.showTooltip (inventory.Slots [slotNumber].GetComponent<RectTransform> ().localPosition, inventory.Items [slotNumber]);
            }
        }

        public void OnPointerExit(PointerEventData data)
        {
            if (inventory.Items [slotNumber].itemName != null) 
            {
                inventory.closeTooltip ();
            }
        }

        public void OnDrag(PointerEventData data)
        {
            if (inventory.Items [slotNumber].itemName != null) 
            { 
                inventory.showDraggedItem (inventory.Items [slotNumber], slotNumber);
                inventory.Items [slotNumber] = new Item ();
            }
        }*/
    }
}
