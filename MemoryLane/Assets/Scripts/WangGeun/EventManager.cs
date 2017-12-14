using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    GameObject PlayerObject;
    CharactorController EventFlow;
    public GameObject StartDoor;
    public GameObject NextDoor;
    public GameObject Ghost;
    public int index = 0;

    public AudioSource FlowAudio;
    public AudioClip GhostSound;
    public AudioClip DoorOpen;

    public GameObject[] HideObjects;
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
            StartDoor.GetComponent<Animator>().SetBool("isOpened", true);
            //StartDoor.GetComponent<AudioSource>().Play();
            Destroy(StartDoor.GetComponent<BoxCollider2D>()); 
        }

        else if (EventFlow.haveBabyDoll && index == 1)
        {
            DynamicTextEvent[index].transform.position = PlayerObject.transform.position;
            index++;
            NextDoor.GetComponent<Animator>().SetBool("isOpened", true);
            FlowAudio.clip = DoorOpen;
            FlowAudio.Play();
            //NextDoor.GetComponent<AudioSource>().Play();
            Destroy(NextDoor.GetComponent<BoxCollider2D>());
        }

        else if (EventFlow.isreadTV && index == 2)
        {
            DynamicTextEvent[index].transform.position = PlayerObject.transform.position;
            Ghost.SetActive(true);
            FlowAudio.clip = GhostSound;
            FlowAudio.Play();
            index++;
        }

        else if (EventFlow.haveHide && index == 3)
        {
            DynamicTextEvent[index].transform.position = PlayerObject.transform.position;
            index++;
            FlowAudio.PlayDelayed(3.0f);
        }

        else if (EventFlow.haveHide && index == 4 && !EventFlow.isHide)
        {
            FlowAudio.clip = null;
            DynamicTextEvent[index].transform.position = PlayerObject.transform.position;
			Ghost.SetActive(false);
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
			for (int a = 0; a < HideObjects.Length; a++) {
				HideObjects [a].SetActive (true);
			}
            index++;
        }

		else if (EventFlow.haveAllitem && index == 7)
        {
            DynamicTextEvent[index].transform.position = PlayerObject.transform.position;
            index++;
        }

    }
}
