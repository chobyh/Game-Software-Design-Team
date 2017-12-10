using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    GameObject PlayerObject;
    CharactorController EventFlow;
    public GameObject Door1;
    public GameObject Door2;
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
        if(EventFlow.isreadClock && EventFlow.isreadDeadMan && index == 0 && EventFlow.haveDiary)
        {
            DynamicTextEvent[index].transform.position = PlayerObject.transform.position;
            index++;
            Door1.GetComponent<Animator>().SetBool("isOpened", true);
            Destroy(Door1.GetComponent<BoxCollider2D>()); 
        }

        if (EventFlow.haveRemote && EventFlow.haveBabyDoll && EventFlow.haveDoorKey && index == 2)
        {
            DynamicTextEvent[index].transform.position = PlayerObject.transform.position;
            index++;
            Door2.GetComponent<Animator>().SetBool("isOpened", true);
            Destroy(Door2.GetComponent<BoxCollider2D>());
        }

        if (EventFlow.haveRemote && EventFlow.haveBabyDoll && EventFlow.haveDoorKey && index == 2)
        {
            DynamicTextEvent[index].transform.position = PlayerObject.transform.position;
            index++;
            Door2.GetComponent<Animator>().SetBool("isOpened", true);
            Destroy(Door2.GetComponent<BoxCollider2D>());
        }

    }
}
