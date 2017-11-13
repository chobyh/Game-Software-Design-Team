using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public List<GameObject> Slots = new List<GameObject> ();
	public List<Item> Items = new List<Item>();
	public GameObject slots;
	ItemDataBase database;
	int x = -62;
	int y = 310;

	public GameObject tooltip;
	public GameObject draggedItemGameObject;
	public bool draggingItem = false;
	public Item draggedItem;
	public int indexOfDraggedItem;

	void Update()
	{
		if (draggingItem) {
			Vector3 posi = (Input.mousePosition - GameObject.FindGameObjectWithTag ("Canvas").GetComponent<RectTransform> ().localPosition);
			draggedItemGameObject.GetComponent<RectTransform> ().localPosition = new Vector3(posi.x + 15, posi.y -15, posi.z);
		}
	}

	public void showTooltip(Vector3 toolPosition, Item item)
	{
		tooltip.SetActive (true);
		tooltip.transform.GetComponent<RectTransform> ().localPosition = new Vector3 (toolPosition.x + 185, toolPosition.y, toolPosition.z );

		tooltip.transform.GetChild (0).GetComponent<Text> ().text = item.itemName;
		tooltip.transform.GetChild (1).GetComponent<Text> ().text = item.itemDesc;
	}

	public void showDraggedItem(Item item, int slotnumber)
	{
		indexOfDraggedItem = slotnumber;
		closeTooltip ();
		draggedItemGameObject.SetActive (true);
		draggedItem = item;
		draggingItem = true;
		draggedItemGameObject.GetComponent<Image> ().sprite = item.itemIcon;
	}

	public void closeDraggedItem()
	{
		draggingItem = false;
		draggedItemGameObject.SetActive (false);
	}
	public void closeTooltip()
	{
		tooltip.SetActive (false);
	}
	// Use this for initialization
	void Start () {

		int Slotamount = 0;
		database = GameObject.FindGameObjectWithTag ("ItemDataBase").GetComponent<ItemDataBase> ();
		for (int i = 1; i < 7; i++) {
			for (int k = 1; k < 6; k++) {
				GameObject slot = (GameObject)Instantiate (slots);
				slot.GetComponent<SlotScript>().slotNumber = Slotamount;
				Slots.Add (slot);
				Items.Add (new Item());
				slot.transform.parent = this.gameObject.transform;
				slot.name = "Slot" + i + "." + k;
				slot.GetComponent<RectTransform> ().localPosition = new Vector3 (x, y, 0);
				x = x + 30;
				if (k == 5) {
					x = -62;
					y = y - 125;
				}
				Slotamount++;
			}
		}
		addItem (0);
		addItem (1);
	}

	void addItem(int id)
	{
		
		for (int i = 0; i < database.items.Count; i++) 
		{
			
			if (database.items [i].itemID == id) 
			{
				Item item = database.items [i];
				addItemAtEmptySlot (item);
				break;
			}
		}
	}

	void addItemAtEmptySlot(Item item)
	{
		for (int i = 0; i < Items.Count; i++) 
		{
			if (Items [i].itemName == null) 
			{
				Items [i] = item;
				break;
			}
		}
	}
}
