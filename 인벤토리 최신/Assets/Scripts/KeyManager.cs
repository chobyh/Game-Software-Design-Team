using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour {

	public Inventory inventory;
	// Use this for initialization
	void Start () {
		inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
		if (inventory.gameObject.activeInHierarchy == false) {
			if (Input.GetKeyDown (KeyCode.I)) {
				inventory.gameObject.SetActive (true);
			}			
		} else {
			if (Input.GetKeyDown (KeyCode.I)) {
				inventory.gameObject.SetActive (false);
				inventory.Slots [inventory.n].transform.GetChild (1).gameObject.SetActive (false);
				inventory.n = 0;
			}	
		}
	}
}
