using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    GameObject PlayerObject;
    CharactorController EventFlow;
    public GameObject Door1;
    int index = 0;

    public GameObject[] DynamicTextEvent;

    // Use this for initialization
    void Start () {
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
        EventFlow = GameObject.FindGameObjectWithTag("Player").GetComponent<CharactorController>();
	}
	
	// Update is called once per frame
	void Update () {
        CheckEvent();
	}

    void CheckEvent()
    {
        if(EventFlow.isreadClock && EventFlow.isreadDeadMan && index == 0)
        {
            DynamicTextEvent[index].transform.position = PlayerObject.transform.position;
            index++;
            Door1.GetComponent<Animator>().SetBool("isOpened", true);
            Destroy(Door1.GetComponent<BoxCollider2D>()); 
        }
        
    }
}
