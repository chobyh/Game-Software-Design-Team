using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyLog : MonoBehaviour
{

    public List<GameObject> Slots2 = new List<GameObject>();
    public List<Item> Items2 = new List<Item>();
    public GameObject slots2;
    public Inventory inventory;

    ItemDataBase database;
    int x = -62;
    int y = 310;

    public int t = 0;
    // Use this for initialization
    void Start()
    {
        int Slotamount = 0;
        database = GameObject.FindGameObjectWithTag("ItemDataBase").GetComponent<ItemDataBase>();
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        for (int i = 1; i < 7; i++)
        {
            for (int k = 1; k < 6; k++)
            {
                GameObject slot1 = (GameObject)Instantiate(slots2);
                slot1.GetComponent<SlotScript>().slotNumber = Slotamount;
                Slots2.Add(slot1);
                Items2.Add(new Item());
                slot1.transform.SetParent(this.gameObject.transform);
                slot1.name = "Slot" + i + "." + k;
                slot1.GetComponent<RectTransform>().localPosition = new Vector3(x, y, 0);
                x = x + 30;
                if (k == 5)
                {
                    x = -62;
                    y = y - 125;
                }
                Slotamount++;
            }
        }
        addItem(4);

    }

    // Update is called once per frame
    void Update()
    {
        if (Slots2[t].transform.GetChild(1).gameObject.activeInHierarchy == false)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Slots2[t].transform.GetChild(1).gameObject.SetActive(true);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Slots2[t].transform.GetChild(1).gameObject.SetActive(false);
                t = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) == true)
        {
            Slots2[t + 1].transform.GetChild(1).gameObject.SetActive(true);
            Slots2[t].transform.GetChild(1).gameObject.SetActive(false);
            t = t + 1;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) == true)
        {
            Slots2[t - 1].transform.GetChild(1).gameObject.SetActive(true);
            Slots2[t].transform.GetChild(1).gameObject.SetActive(false);
            t = t - 1;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) == true)
        {
            Slots2[t + 5].transform.GetChild(1).gameObject.SetActive(true);
            Slots2[t].transform.GetChild(1).gameObject.SetActive(false);
            t = t + 5;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) == true)
        {
            Slots2[t - 5].transform.GetChild(1).gameObject.SetActive(true);
            Slots2[t].transform.GetChild(1).gameObject.SetActive(false);
            t = t - 5;
        }
    }
    void addItem(int id)
    {

        for (int i = 0; i < database.items.Count; i++)
        {

            if (database.items[i].itemID == id)
            {
                Item item = database.items[i];
                addItemAtEmptySlot(item);
                break;
            }
        }
    }
    void addItemAtEmptySlot(Item item)
    {
        for (int i = 0; i < Items2.Count; i++)
        {
            if (Items2[i].itemName == null)
            {
                Items2[i] = item;
                break;
            }
        }
    }
}
