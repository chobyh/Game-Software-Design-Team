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
		oriPosition.transform.position = GameObject.FindGameObjectWithTag ("enemy").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!Target.gameObject.GetComponent<CharactorController> ().isHide) {
			this.transform.position = Vector2.Lerp (this.transform.position, Target.transform.position, speed * Time.deltaTime);
		} else {
			this.transform.position = Vector2.Lerp (this.transform.position, oriPosition.transform.position, speed * Time.deltaTime);
		}
    }
}
