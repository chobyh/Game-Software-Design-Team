using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour {
    private Camera mainCamera;
	// Use this for initialization
	void Start () {
        mainCamera = GetComponent<Camera>();
        mainCamera.backgroundColor = Color.white;
    }
	
	// Update is called once per frame
	void Update () {
	}
}
