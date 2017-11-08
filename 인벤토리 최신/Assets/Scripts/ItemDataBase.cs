using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : MonoBehaviour {

	public List<Item> items = new List<Item> ();
	// Use this for initialization
	void Start () {
		items.Add (new Item ("003_air", 0, "Nice Hint", 10, 10, 1, Item.ItemType.Hint));
		items.Add (new Item ("004_tree", 1, "Good Hint", 10, 10, 1, Item.ItemType.Hint));
		items.Add (new Item ("005_light", 2, "Best Hint", 10, 10, 1, Item.ItemType.Collects));
		items.Add (new Item ("006_electricity", 3, "Better Hint", 10, 10, 1, Item.ItemType.Hint));		 
	}

}
