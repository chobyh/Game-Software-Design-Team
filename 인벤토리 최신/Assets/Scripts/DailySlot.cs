using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailySlot : MonoBehaviour {

    public DailyItem item;
    Image itemImage;
    public int slotNumber2;
    DailyLog dailyLog;
    // Use this for initialization
    void Start () {
        dailyLog = GameObject.FindGameObjectWithTag("DailyLog").GetComponent<DailyLog>();
        itemImage = gameObject.transform.GetChild(0).GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        if (dailyLog.Items2[slotNumber2].itemName2 != null)
        {
            itemImage.enabled = true;
            itemImage.sprite = dailyLog.Items2[slotNumber2].itemIcon2;
        }
        else
        {
            itemImage.enabled = false;
        }
    }
}
