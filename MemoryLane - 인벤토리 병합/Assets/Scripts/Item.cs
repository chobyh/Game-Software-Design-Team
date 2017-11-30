﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Item{

	public string itemName;
	public int itemID;
	public string itemDesc;
	public Sprite itemIcon;
	public GameObject itemModel;
	public int itemPower;
	public int itemSpeed;
	public int itemValue;
	public ItemType itemType;

	public enum ItemType{
		Hint,
		Collects
	}
	public Item(string name, int id, string desc, int power, int speed, int value, ItemType type){
		itemName = name;
		itemID = id;
		itemDesc = desc;
		itemPower = power;
		itemSpeed = speed;
		itemValue = value;
		itemType = type;
		itemIcon = Resources.Load<Sprite> (name);
		itemModel = Resources.Load<GameObject> ("DroppedItem");

	}
	public Item(){
	}
}
