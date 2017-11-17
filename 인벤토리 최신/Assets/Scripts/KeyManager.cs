using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour {

	public Inventory inventory;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (inventory.gameObject.activeInHierarchy == false ) {
			if (Input.GetKeyDown(KeyCode.I)) {
				inventory.gameObject.SetActive (true);
				Debug.Log (111);
			}			
		} 
		else {
			if (Input.GetKeyDown (KeyCode.I)) {
				inventory.gameObject.SetActive (false);
				Debug.Log (222);
			}	
		}
	}
}
