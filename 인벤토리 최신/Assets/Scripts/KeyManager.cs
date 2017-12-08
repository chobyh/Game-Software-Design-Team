using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour {

	public Inventory inventory;
	public DailyLog dailylog;
	// Use this for initialization
	void Start () {
        //inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        //dailylog = GameObject.FindGameObjectWithTag("DailyLog").GetComponent<DailyLog>();
    }
	
	// Update is called once per frame
	void Update () {
		if (inventory.gameObject.activeInHierarchy == false) {
			if (Input.GetKeyDown (KeyCode.I)) {
                if(dailylog.gameObject.activeInHierarchy == true)
                {
                    dailylog.gameObject.SetActive(false);
                }
                inventory.gameObject.SetActive (true);
            }			
		} else {
			if (Input.GetKeyDown (KeyCode.I)) {
				inventory.gameObject.SetActive (false);
				inventory.Slots [inventory.n].transform.GetChild (1).gameObject.SetActive (false);
				inventory.n = 0;
			}	
		}
		if (dailylog.gameObject.activeInHierarchy == false) {
			if (Input.GetKeyDown (KeyCode.Q)) {
                if(inventory.gameObject.activeInHierarchy == true)
                {
                    inventory.gameObject.SetActive(false);
                }
				dailylog.gameObject.SetActive (true);
			}			
		} else {
			if (Input.GetKeyDown (KeyCode.Q)) {
				dailylog.gameObject.SetActive (false);
				dailylog.Slots2 [dailylog.t].transform.GetChild (1).gameObject.SetActive (false);
				dailylog.t = 0;
			}	
		}
	}
}
