using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyDataBase : MonoBehaviour
{

    public List<DailyItem> items2 = new List<DailyItem>();

    // Use this for initialization
    void Start()
    {
        items2.Add(new DailyItem("일지시작", 0, "일지1", 10, DailyItem.ItemType2.Hint));
        items2.Add(new DailyItem("일지시작2", 1, "일지2", 10, DailyItem.ItemType2.Hint));
        items2.Add(new DailyItem("일지화장실", 2, "일지3", 10, DailyItem.ItemType2.Hint));
        items2.Add(new DailyItem("일지죄와벌", 3, "일지4", 10, DailyItem.ItemType2.Hint));
        items2.Add(new DailyItem("일지신문", 4, "일지9", 10, DailyItem.ItemType2.Hint));
        items2.Add(new DailyItem("일지리모컨", 5, "일지7", 10, DailyItem.ItemType2.Hint));
        items2.Add(new DailyItem("일지가족사진", 6, "일지5", 10, DailyItem.ItemType2.Hint));
        items2.Add(new DailyItem("일지단서", 7, "일지10", 10, DailyItem.ItemType2.Hint));
        items2.Add(new DailyItem("일지달력", 8, "일지6", 10, DailyItem.ItemType2.Hint));
        items2.Add(new DailyItem("일지아빠편지", 9, "일지13", 10, DailyItem.ItemType2.Hint));
        items2.Add(new DailyItem("일지딸편지", 10, "일지12", 10, DailyItem.ItemType2.Hint));
        items2.Add(new DailyItem("일지뱃지", 11, "일지11", 10, DailyItem.ItemType2.Hint));
        items2.Add(new DailyItem("일지그림", 12, "일지11", 10, DailyItem.ItemType2.Hint));
        items2.Add(new DailyItem("일지타임캡슐", 13, "일지14", 10, DailyItem.ItemType2.Hint));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
