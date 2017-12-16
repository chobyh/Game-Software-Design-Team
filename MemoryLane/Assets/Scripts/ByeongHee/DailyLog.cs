using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyLog : MonoBehaviour
{

    public List<GameObject> Slots2 = new List<GameObject>();
    public List<DailyItem> Items2 = new List<DailyItem>();
    public GameObject[] DailyDesc;
    public GameObject slots2;
    public GameObject DailyDesc2;

    DailyDataBase database;
    int x = -75;
    int y = 80;

    public int t = 0;
    // Use this for initialization
    void Start()
    {
        int Slotamount = 0;
        database = GameObject.FindGameObjectWithTag("DailyDataBase").GetComponent<DailyDataBase>();
        for (int i = 1; i < 6; i++)
        {
            for (int k = 1; k < 5; k++)
            {
                GameObject slot1 = (GameObject)Instantiate(slots2);
                slot1.GetComponent<DailySlot>().slotNumber2 = Slotamount;
                Slots2.Add(slot1);
                Items2.Add(new DailyItem());
                slot1.transform.SetParent(this.gameObject.transform);
                slot1.name = "Slot" + i + "." + k;
                slot1.GetComponent<RectTransform>().localPosition = new Vector3(x, y, 0);

                x = x + 50;
                if (k == 4)
                {
                    x = -75;
                    y = y - 40;
                }
                Slotamount++;
            }
        }
        for (int j = 0; j < 11; j++)
        {

        }
        addItem(0);
    }

    // Update is called once per frame
    void Update()
    {
        //z로 활성화
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
        //z상태시 방향키로 이동
        if (Slots2[t].transform.GetChild(1).gameObject.activeInHierarchy == true)
        {
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
                Slots2[t + 4].transform.GetChild(1).gameObject.SetActive(true);
                Slots2[t].transform.GetChild(1).gameObject.SetActive(false);
                t = t + 4;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) == true)
            {
                Slots2[t - 4].transform.GetChild(1).gameObject.SetActive(true);
                Slots2[t].transform.GetChild(1).gameObject.SetActive(false);
                t = t - 4;
            }
        }
        
        //일지 사용
        for (int i = 0; i < 15; i++)
        {
            if (Slots2[i].transform.GetChild(1).gameObject.activeInHierarchy == true)
            {
                if (DailyDesc[i].transform.gameObject.activeInHierarchy == false)
                {
                    if (DailyDesc2 != null)
                    {
                        DailyDesc2.transform.gameObject.SetActive(false);
                        DailyDesc2 = null;
                    }
                    SpaceOpenEvent(DailyDesc[i]);
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.Space) == true)
                    {
                        DailyDesc[i].transform.gameObject.SetActive(false);
                    }
                }
                break;
            }
        }

    }
    public void addItem(int id2)
    {

        for (int i = 0; i < database.items2.Count; i++)
        {

            if (database.items2[i].itemID2 == id2)
            {
                DailyItem DailyItem = database.items2[i];
                //addItemAtEmptySlot(DailyItem);
                if(Items2[id2].itemName2 == null)
                {
                    Items2[id2] = DailyItem;
                }
                break;
            }
        }
    }
    void addItemAtEmptySlot(DailyItem item)
    {
        for (int i = 0; i < Items2.Count; i++)
        {
            if (Items2[i].itemName2 == null)
            {
                Items2[i] = item;
                break;
            }
        }
    }
    void SpaceOpenEvent(GameObject DailyDesc)
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            DailyDesc.SetActive(true);
            DailyDesc.transform.GetComponent<RectTransform>().localPosition = new Vector3(x + 120, y + 120 );
            DailyDesc2 = DailyDesc;
        }
    }
}
