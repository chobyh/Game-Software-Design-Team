using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : MonoBehaviour {

	public List<Item> items = new List<Item> ();
	// Use this for initialization
	void Start () {
        //items.Add(new Item("diary", 0, "힌트", 10, Item.ItemType.Hint));
        items.Add(new Item("Babt_Doll 1", 0, "힌트", 10, Item.ItemType.Hint));
        items.Add(new Item("Remote 1", 2, "힌트", 10, Item.ItemType.Hint));
        items.Add(new Item("Shovel 1", 3, "힌트", 10, Item.ItemType.Hint));
        items.Add(new Item("Inside_C_03_2", 4, "힌트", 10, Item.ItemType.Hint));
        items.Add(new Item("Inside_C_04", 5, "힌트", 10, Item.ItemType.Hint));
        items.Add(new Item("iconset_04", 6, "힌트", 10, Item.ItemType.Hint));
        items.Add(new Item("그림10", 7, "힌트", 10, Item.ItemType.Hint));
        items.Add(new Item("ace_library_candacis_and_pandamaru 1", 8, "힌트", 10, Item.ItemType.Hint));
        items.Add(new Item("SketchBook 1", 9, "힌트", 10, Item.ItemType.Hint));
    }

}
