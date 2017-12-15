using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Item
{

    public string itemName;
    public int itemID;
    public string itemDesc;
    public Sprite itemIcon;
    public GameObject itemModel;
    public int itemValue;
    public ItemType itemType;

    public enum ItemType
    {
        Hint,
        Collects
    }
    public Item(string name, int id, string desc, int value, ItemType type)
    {
        itemName = name;
        itemID = id;
        itemDesc = desc;
        itemValue = value;
        itemType = type;
        itemIcon = Resources.Load<Sprite>(name);
        itemModel = Resources.Load<GameObject>("DroppedItem");

    }
    public Item()
    {
    }
}

[System.Serializable]
public class DailyItem
{
    public string itemName2;
    public int itemID2;
    public string itemDesc2;
    public Sprite itemIcon2;
    public GameObject itemModel2;
    public int itemValue2;
    public ItemType2 itemType2;

    public enum ItemType2
    {
        Hint,
        Collects
    }
    public DailyItem(string name2, int id2, string desc2, int value2, ItemType2 type2)
    {
        itemName2 = name2;
        itemID2 = id2;
        itemDesc2 = "일지";
        itemValue2 = value2;
        itemType2 = type2;
        itemIcon2 = Resources.Load<Sprite>(name2);
        itemModel2 = Resources.Load<GameObject>("DroppedItem");

    }
    public DailyItem()
    {

    }
}
