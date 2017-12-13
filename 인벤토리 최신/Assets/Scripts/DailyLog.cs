using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyLog : MonoBehaviour
{

    public List<GameObject> Slots2 = new List<GameObject>();
    public List<DailyItem> Items2 = new List<DailyItem>();
    public GameObject slots2;
    public GameObject DailyDesc;


    DailyDataBase database;
    int x = -62;
    int y = 310;

    public int t = 0;
    // Use this for initialization
    void Start()
    {
        int Slotamount = 0;
        database = GameObject.FindGameObjectWithTag("DailyDataBase").GetComponent<DailyDataBase>();
        for (int i = 1; i < 7; i++)
        {
            for (int k = 1; k < 6; k++)
            {
                GameObject slot1 = (GameObject)Instantiate(slots2);
                slot1.GetComponent<DailySlot>().slotNumber2 = Slotamount;
                Slots2.Add(slot1);
                Items2.Add(new DailyItem());
                slot1.transform.SetParent(this.gameObject.transform);
                slot1.name = "Slot" + i + "." + k;
                slot1.GetComponent<RectTransform>().localPosition = new Vector3(x, y, 0);
                
                x = x + 30;
                if (k == 5)
                {
                    x = -62;
                    y = y - 125;
                }
                slot1.transform.GetChild(2).gameObject.SetActive(true);
                Slotamount++;
            }
        }
        addItem(0);
        addItem(1);

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
        //일지 사용
        if(Slots2[t].transform.GetChild(1).gameObject.activeInHierarchy == true)
        {
            if(DailyDesc.transform.gameObject.activeInHierarchy == false)
            {
                if (Input.GetKeyDown(KeyCode.Space) == true)
                {
                    showDesc(DailyDesc.transform.localPosition);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space) == true)
                {
                    closeDesc();
                }
            }
        }
  
    }
    void addItem(int id2)
    {

        for (int i = 0; i < database.items2.Count; i++)
        {

            if (database.items2[i].itemID2 == id2)
            {
                DailyItem DailyItem = database.items2[i];
                addItemAtEmptySlot(DailyItem);
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
    void showDesc(Vector3 descPosition)
    {
        DailyDesc.SetActive(true);
        DailyDesc.transform.GetComponent<RectTransform>().localPosition = new Vector3(descPosition.x, descPosition.y, descPosition.z);
    }
    void closeDesc()
    {
        DailyDesc.SetActive(false);
    }
}
