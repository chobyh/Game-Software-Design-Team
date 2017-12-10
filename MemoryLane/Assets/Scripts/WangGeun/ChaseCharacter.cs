using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCharacter : MonoBehaviour {

    public float speed;
    float distance;

    GameObject Target;
	GameObject oriPosition;

	// Use this for initialization
	void Start () {
        Target = GameObject.FindGameObjectWithTag("Player");
		oriPosition = GameObject.FindGameObjectWithTag ("enemy");
	}
	
	// Update is called once per frame
	void Update () {
		if (!Target.gameObject.GetComponent<CharactorController> ().isHide) {
			this.transform.position = Vector2.MoveTowards (this.transform.position, Target.transform.position, speed * Time.deltaTime);
		} else {
			this.transform.position = Vector2.MoveTowards(this.transform.position, oriPosition.transform.position, speed * Time.deltaTime);
		}
    }
}
