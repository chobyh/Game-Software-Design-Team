﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropBox : MonoBehaviour, IPointerDownHandler {

	Inventory inventory;
	// Use this for initialization
	void Start () {
		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerDown(PointerEventData data)
	{
		if (inventory.draggingItem) 
		{
			dropItem (inventory.draggedItem);
			inventory.closeDraggedItem ();
		}	
	}

	void dropItem(Item item)
	{
		GameObject itemAsGameObject = (GameObject)Instantiate (item.itemModel, GameObject.FindGameObjectWithTag ("Player").transform.position, Quaternion.identity);
		itemAsGameObject.GetComponent<DroppedItem> ().item = item;
	}
}
