using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyDataBase : MonoBehaviour
{

    public List<DailyItem> items2 = new List<DailyItem>();

    // Use this for initialization
    void Start()
    {
        items2.Add(new DailyItem("일지1", 0, "일지1", 10, DailyItem.ItemType2.Hint));
        items2.Add(new DailyItem("일지1", 1, "일지2", 10, DailyItem.ItemType2.Hint));
        items2.Add(new DailyItem("일지1", 2, "일지3", 10, DailyItem.ItemType2.Hint));
        items2.Add(new DailyItem("일지1", 3, "일지4", 10, DailyItem.ItemType2.Hint));
        items2.Add(new DailyItem("일지1", 4, "일지5", 10, DailyItem.ItemType2.Hint));
        items2.Add(new DailyItem("일지1", 5, "일지6", 10, DailyItem.ItemType2.Hint));
        items2.Add(new DailyItem("일지1", 6, "일지7", 10, DailyItem.ItemType2.Hint));
        items2.Add(new DailyItem("일지1", 7, "일지8", 10, DailyItem.ItemType2.Hint));
        items2.Add(new DailyItem("일지1", 8, "일지9", 10, DailyItem.ItemType2.Hint));
        items2.Add(new DailyItem("일지1", 9, "일지10", 10, DailyItem.ItemType2.Hint));
        items2.Add(new DailyItem("일지1", 10, "일지11", 10, DailyItem.ItemType2.Hint));
        items2.Add(new DailyItem("일지1", 11, "일지12", 10, DailyItem.ItemType2.Hint));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
