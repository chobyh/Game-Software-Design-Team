using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {
	public Transform targetTr;
	public float dist = 10.0f;
	public float height = 3.0f;
	public float dampTrace = 20.0f;

	private Transform tr;
	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		tr.position = Vector3.Lerp (tr.position,   //시작위치
			targetTr.position - (targetTr.forward * dist) + (Vector3.up * height),  //종료위치
			Time.deltaTime * dampTrace); //보간 시간

		tr.LookAt (targetTr.position);
	}
}
