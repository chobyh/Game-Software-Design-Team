using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyDataBase : MonoBehaviour {

    public List<DailyItem> items2 = new List<DailyItem>();

    // Use this for initialization
    void Start () {
        items2.Add(new DailyItem("쪽지", 0, "일지", 10, DailyItem.ItemType2.Hint));
        items2.Add(new DailyItem("일지", 1, "일지", 10, DailyItem.ItemType2.Hint));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
