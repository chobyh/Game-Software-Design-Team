using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCharacter : MonoBehaviour {

    public float speed;
    float distance;

    GameObject Target;

	// Use this for initialization
	void Start () {
        Target = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = Vector2.Lerp(this.transform.position, Target.transform.position, speed * Time.deltaTime);
    }
}
