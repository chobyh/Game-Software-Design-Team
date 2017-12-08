using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : MonoBehaviour {

	public List<Item> items = new List<Item> ();
	// Use this for initialization
	void Start () {
		items.Add (new Item ("벽돌1", 4, "힌트", 10, Item.ItemType.Hint));
		items.Add (new Item ("씨앗", 1, "힌트", 10, Item.ItemType.Hint));
		items.Add (new Item ("나무", 2, "힌트", 10, Item.ItemType.Hint));
		items.Add (new Item ("사과", 3, "힌트", 10, Item.ItemType.Hint));

        //일지 아이템
        items.Add(new Item("일지", 0, "힌트", 10, Item.ItemType.Hint));

    }

}
