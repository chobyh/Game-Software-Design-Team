using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    GameObject PlayerObject;
    CharactorController EventFlow;
    public GameObject Door;
    public GameObject Ghost;
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
            Door.GetComponent<Animator>().SetBool("isOpened", true);
            Destroy(Door.GetComponent<BoxCollider2D>()); 
        }

        else if (EventFlow.haveBabyDoll && index == 1)
        {
            DynamicTextEvent[index].transform.position = PlayerObject.transform.position;
            index++;
        }

        else if (EventFlow.isreadTV && index == 2)
        {
            DynamicTextEvent[index].transform.position = PlayerObject.transform.position;
            Ghost.SetActive(true);
            index++;
        }

        else if (EventFlow.haveHide && index == 3)
        {
            DynamicTextEvent[index].transform.position = PlayerObject.transform.position;
            index++;
        }

        else if (EventFlow.haveHide && index == 4 && !EventFlow.isHide)
        {
            DynamicTextEvent[index].transform.position = PlayerObject.transform.position;
            GameObject.Find("Ghost").transform.gameObject.SetActive(false);
            GameObject.Find("Items").transform.Find("DoorKey").gameObject.SetActive(true);
            index++;
        }

        else if(EventFlow.haveDoorKey && EventFlow.haveBabyDoll && index == 5)
        {
            DynamicTextEvent[index].transform.position = PlayerObject.transform.position;
            index++;
        }

        else if (EventFlow.isreadHole && index == 6)
        {
            DynamicTextEvent[index].transform.position = PlayerObject.transform.position;
            index++;
        }

        else if (GameObject.FindGameObjectsWithTag("item") == null && index == 7)
        {
            DynamicTextEvent[index].transform.position = PlayerObject.transform.position;
            index++;
        }

    }
}
