using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : MonoBehaviour {

	public List<Item> items = new List<Item> ();
	// Use this for initialization
	void Start () {
		items.Add (new Item ("벽돌1", 0, "힌트", 10, 10, 1, Item.ItemType.Hint));
		items.Add (new Item ("씨앗", 1, "힌트", 10, 10, 1, Item.ItemType.Hint));
		items.Add (new Item ("나무", 2, "힌트", 10, 10, 1, Item.ItemType.Hint));
		items.Add (new Item ("사과", 3, "힌트", 10, 10, 1, Item.ItemType.Hint));
		items.Add (new Item ("씨앗", 4, "힌트", 10, 10, 1, Item.ItemType.Hint));
		items.Add (new Item ("아이스", 5, "힌트", 10, 10, 1, Item.ItemType.Hint));
		items.Add (new Item ("알약", 6, "힌트", 10, 10, 1, Item.ItemType.Hint));

	}

}
