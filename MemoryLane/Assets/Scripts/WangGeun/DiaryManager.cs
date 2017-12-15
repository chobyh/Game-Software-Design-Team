using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryManager : MonoBehaviour {

    public CharactorController characterController;
    public EventManager eventFlow;
    public DailyLog dailylog;
    bool UpdateFamliy;
    bool UpdateNewspaper;
    bool UpdateAward;
    bool UpdatePicture;

    AudioSource diary;
    public AudioClip diarySound;

    void Start()
    {
        diary = GetComponent<AudioSource>();
        diary.clip = diarySound;
    }

    void Update()
    {
        UpdateDairy();
    }

    // Use this for initializations
    void UpdateDairy()
    {
        if(eventFlow.index == 1 & dailylog.Slots2[1].transform.GetChild(2).gameObject.activeInHierarchy == true) // 2번 일지
        {
            diary.Play();
            dailylog.addItem(1);
            dailylog.Slots2[1].transform.GetChild(2).gameObject.SetActive(false); 
        }
        else if(characterController.isShout && dailylog.Slots2[2].transform.GetChild(2).gameObject.activeInHierarchy == true) // 3번 일지
        {
            diary.Play();
            dailylog.addItem(2);
            dailylog.Slots2[2].transform.GetChild(2).gameObject.SetActive(false);
        }
        else if (characterController.isreadGuiltybook && dailylog.Slots2[3].transform.GetChild(2).gameObject.activeInHierarchy == true) // 4번 일지
        {
            diary.Play();
            dailylog.addItem(3);
            dailylog.Slots2[3].transform.GetChild(2).gameObject.SetActive(false);
        }
        else if (characterController.isreadCalender && dailylog.Slots2[4].transform.GetChild(2).gameObject.activeInHierarchy == true) // 5번 일지
        {
            diary.Play();
            dailylog.addItem(4);
            dailylog.Slots2[4].transform.GetChild(2).gameObject.SetActive(false);
        }
        else if (characterController.isreadFamilyPhoto && dailylog.Slots2[5].transform.GetChild(2).gameObject.activeInHierarchy == true) // 6번 일지
        {
            UpdateFamliy = true;
            diary.Play();
            dailylog.addItem(5);
            dailylog.Slots2[5].transform.GetChild(2).gameObject.SetActive(false);
        }
        else if (characterController.isreadNewspaper && dailylog.Slots2[6].transform.GetChild(2).gameObject.activeInHierarchy == true) // 7번 일지
        {
            UpdateNewspaper = true;
            diary.Play();
            dailylog.addItem(6);
            dailylog.Slots2[6].transform.GetChild(2).gameObject.SetActive(false);
        }
        else if (UpdateFamliy && UpdateNewspaper && dailylog.Slots2[7].transform.GetChild(2).gameObject.activeInHierarchy == true) // 8번 일지
        {
            diary.Play();
            dailylog.addItem(7);
            dailylog.Slots2[7].transform.GetChild(2).gameObject.SetActive(false);
        }
        else if (characterController.isreadTV && dailylog.Slots2[8].transform.GetChild(2).gameObject.activeInHierarchy == true) // 9번 일지
        {
            diary.Play();
            dailylog.addItem(8);
            dailylog.Slots2[8].transform.GetChild(2).gameObject.SetActive(false);
        }
        else if (characterController.haveFathersLetter && dailylog.Slots2[9].transform.GetChild(2).gameObject.activeInHierarchy == true) // 10번 일지
        {
            diary.Play();
            dailylog.addItem(9);
            dailylog.Slots2[9].transform.GetChild(2).gameObject.SetActive(false);
        }
        else if (characterController.haveDaughtersLetter && dailylog.Slots2[10].transform.GetChild(2).gameObject.activeInHierarchy == true) // 11번 일지
        {
            diary.Play();
            dailylog.addItem(10);
            dailylog.Slots2[10].transform.GetChild(2).gameObject.SetActive(false);
        }
        else if (characterController.haveAward && characterController.havePolice && dailylog.Slots2[11].transform.GetChild(2).gameObject.activeInHierarchy == true) // 12번 일지
        {
            UpdateAward = true;
            diary.Play();
            dailylog.addItem(11);
            dailylog.Slots2[11].transform.GetChild(2).gameObject.SetActive(false);
        }
        else if (characterController.havePicture && dailylog.Slots2[12].transform.GetChild(2).gameObject.activeInHierarchy == true) // 13번 일지
        {
            UpdatePicture = true;
            diary.Play();
            dailylog.addItem(12);
            dailylog.Slots2[12].transform.GetChild(2).gameObject.SetActive(false);
        }
        else if (UpdatePicture && UpdateAward && dailylog.Slots2[13].transform.GetChild(2).gameObject.activeInHierarchy == true) // 14번 일지
        {
            diary.Play();
            dailylog.addItem(13);
            dailylog.Slots2[13].transform.GetChild(2).gameObject.SetActive(false);
        }
    }
}
