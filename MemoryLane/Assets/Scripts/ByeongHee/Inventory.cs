using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public List<GameObject> Slots = new List<GameObject>();
    public List<Item> Items = new List<Item>();
    public GameObject slots;
    public Image ItemDesc;
    public GameObject ItemDesc2;
    public SlotScript itemImage;
    ItemDataBase database;
    int x = -77;
    int y = 80;

    public int n = 0;
    int num1, num2, num3, num4, num5, num6, num7, num8, num9, num10, num11 = 0;


    public CharactorController Gameitem;

    void Update()
    {
        if (Slots[n].transform.GetChild(1).gameObject.activeInHierarchy == false)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Slots[n].transform.GetChild(1).gameObject.SetActive(true);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Slots[n].transform.GetChild(1).gameObject.SetActive(false);
                n = 0;
            }
        }
        if (Slots[n].transform.GetChild(1).gameObject.activeInHierarchy == true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) == true)
            {
                Slots[n + 1].transform.GetChild(1).gameObject.SetActive(true);
                Slots[n].transform.GetChild(1).gameObject.SetActive(false);
                n = n + 1;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) == true)
            {
                Slots[n - 1].transform.GetChild(1).gameObject.SetActive(true);
                Slots[n].transform.GetChild(1).gameObject.SetActive(false);
                n = n - 1;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) == true)
            {
                Slots[n + 4].transform.GetChild(1).gameObject.SetActive(true);
                Slots[n].transform.GetChild(1).gameObject.SetActive(false);
                n = n + 4;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) == true)
            {
                Slots[n - 4].transform.GetChild(1).gameObject.SetActive(true);
                Slots[n].transform.GetChild(1).gameObject.SetActive(false);
                n = n - 4;
            }
        }
        if (Gameitem.haveBabyDoll == true && num1 == 0)
        {
            addItem(0);
            num1 += 1;
        }
        else if (Gameitem.haveBabyDoll == false && num1 == 1)
        {

        }
        if (Gameitem.haveRemote == true && num4 == 0)
        {
            addItem(2);
            num4 += 1;
        }
        if (Gameitem.haveShovel == true && num5 == 0)
        {
            addItem(3);
            num5 += 1;
        }
        if (Gameitem.haveFathersLetter == true && num6 == 0)
        {
            addItem(4);
            num6 += 1;
        }
        if (Gameitem.haveDaughtersLetter == true && num7 == 0)
        {
            addItem(5);
            num7 += 1;
        }
        if (Gameitem.havePolice == true && num8 == 0)
        {
            addItem(6);
            num8 += 1;
        }
        if (Gameitem.havePicture == true && num9 == 0)
        {
            addItem(7);
            num9 += 1;
        }
        if (Gameitem.haveAward == true && num10 == 0)
        {
            addItem(8);
            num10 += 1;
        }
        if (Gameitem.haveSketchBook == true && num11 == 0)
        {
            addItem(9);
            num11 += 1;
        }
        //인벤토리 사용
        for (int i = 0; i < 3; i++)
        {
            if (Slots[i].transform.GetChild(1).gameObject.activeInHierarchy == true)
            {
                if (ItemDesc.transform.gameObject.activeInHierarchy == false)
                {
                    if (ItemDesc2 != null)
                    {
                        ItemDesc2.transform.gameObject.SetActive(false);
                        ItemDesc2 = null;
                    }
<<<<<<< HEAD
                    SpaceOpenEvent(item);
=======
                   // SpaceOpenEvent(Item item);
>>>>>>> 75092b39c4f767a57ba173f250f757b899fdeb65
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.Space) == true)
                    {
                        ItemDesc.transform.gameObject.SetActive(false);
                    }
                }
                break;
            }
        }
    }

    void Start()
    {

        int Slotamount = 0;
        Gameitem = Gameitem.gameObject.GetComponent<CharactorController>();
        database = GameObject.FindGameObjectWithTag("ItemDataBase").GetComponent<ItemDataBase>();
        for (int i = 1; i < 6; i++)
        {
            for (int k = 1; k < 5; k++)
            {
                GameObject slot = (GameObject)Instantiate(slots);
                slot.GetComponent<SlotScript>().slotNumber = Slotamount;
                Slots.Add(slot);
                Items.Add(new Item());
                slot.transform.SetParent(this.gameObject.transform);
                slot.name = "Slot" + i + "." + k;
                slot.GetComponent<RectTransform>().localPosition = new Vector3(x, y, 0);
                x = x + 50;
                if (k == 4)
                {
                    x = -77;
                    y = y - 40;
                }
                Slotamount++;
            }
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
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].itemName == null)
            {
                Items[i] = item;
                break;
            }
        }
    }
    void SpaceOpenEvent(Item item)
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            if (item.itemInfo != null)
            {
                ItemDesc.sprite = item.itemInfo;
            }
           
        }
    }
}
