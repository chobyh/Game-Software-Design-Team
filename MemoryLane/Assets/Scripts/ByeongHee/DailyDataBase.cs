using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyDataBase : MonoBehaviour {

    public List<DailyItem> items2 = new List<DailyItem>();

    // Use this for initialization
    void Start () {
        items2.Add(new DailyItem("diary", 0, Resources.Load<Sprite>("일지"), 10, DailyItem.ItemType2.Hint));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
