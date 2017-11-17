using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyUseText : MonoBehaviour {

    public GameObject TextEventPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Jump"))
        {
            TextEventPrefab.gameObject.GetComponentInChildren<TextBoxMgr>().nextButtonControl();
        }
	}
}
