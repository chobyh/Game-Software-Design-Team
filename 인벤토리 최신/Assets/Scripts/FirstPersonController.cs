using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit))
			{
				float distance = Vector3.Distance (hit.transform.position, this.transform.position);

				if (hit.transform.tag == "Item" && distance <= 3) {
					Debug.Log ("hit");
				}
			}
		}
	}
}
