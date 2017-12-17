using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryManager : MonoBehaviour {

    public CharactorController characterController;
    public EventManager eventFlow;
    public DailyLog dailylog;
    GameObject writingMark;
    bool iswrite = false;
    bool UpdateFamliy;
    bool UpdateNewspaper;
    bool UpdateAward;
    bool UpdatePicture;

    AudioSource diary;
    public AudioClip diarySound;
    int num1, num2, num3, num4, num5, num6, num7, num8, num9, num10, num11, num12, num13 = 0;
    void Start()
    {
        diary = GetComponent<AudioSource>();
        diary.clip = diarySound;
        writingMark = GameObject.Find("UI").transform.Find("Canvas").transform.Find("Write").gameObject;
    }

    void Update()
    {
        UpdateDairy();
    }

    // Use this for initializations
    void UpdateDairy()
    {
        if(eventFlow.index == 1 && num1 == 0) // 2번 일지
        {
            MarkVisable();
            Invoke("MarkVisable", 1.0f);
            diary.Play();
            dailylog.addItem(1);
            num1 += 1;
        }
        else if(characterController.isShout && num2 == 0) // 3번 일지
        {
            MarkVisable();
            Invoke("MarkVisable", 1.0f);
            diary.Play();
            dailylog.addItem(2);
            num2 += 1;
        }
        else if (characterController.isreadGuiltybook && num3 == 0) // 4번 일지
        {
            MarkVisable();
            Invoke("MarkVisable", 1.0f);
            diary.Play();
            dailylog.addItem(3);
            num3 += 1;
        }
        else if (characterController.isreadCalender && num4 == 0) // 5번 일지
        {
            MarkVisable();
            Invoke("MarkVisable", 1.0f);
            diary.Play();
            dailylog.addItem(8);
            num4 += 1;
        }
        else if (characterController.isreadFamilyPhoto && num5 == 0) // 6번 일지
        {
            MarkVisable();
            Invoke("MarkVisable", 1.0f);
            UpdateFamliy = true;
            diary.Play();
            dailylog.addItem(6);
            num5 += 1;
        }
        else if (characterController.isreadNewspaper && num6 == 0) // 7번 일지
        {
            MarkVisable();
            Invoke("MarkVisable", 1.0f);
            UpdateNewspaper = true;
            diary.Play();
            dailylog.addItem(4);
            num6 += 1;
        }
        else if (UpdateFamliy && UpdateNewspaper && num7 == 0) // 8번 일지
        {
            MarkVisable();
            Invoke("MarkVisable", 1.0f);
            diary.Play();
            dailylog.addItem(7);
            num7 += 1;
        }
        else if (characterController.isreadTV && num8 == 0) // 9번 일지
        {
            MarkVisable();
            Invoke("MarkVisable", 1.0f);
            diary.Play();
            dailylog.addItem(5);
            num8 += 1;
        }
        else if (characterController.haveFathersLetter && num9 == 0) // 10번 일지
        {
            MarkVisable();
            Invoke("MarkVisable", 1.0f);
            diary.Play();
            dailylog.addItem(9);
            num9 += 1;
        }
        else if (characterController.haveDaughtersLetter && num10 == 0) // 11번 일지
        {
            MarkVisable();
            Invoke("MarkVisable", 1.0f);
            diary.Play();
            dailylog.addItem(10);
            num10 += 1;
        }
        else if (characterController.haveAward && num11 == 0) // 12번 일지
        {
            MarkVisable();
            Invoke("MarkVisable", 1.0f);
            UpdateAward = true;
            diary.Play();
            dailylog.addItem(11);
            num11 += 1;
        }
        else if (characterController.havePicture && num12 == 0) // 13번 일지
        {
            MarkVisable();
            Invoke("MarkVisable", 1.0f);
            UpdatePicture = true;
            diary.Play();
            dailylog.addItem(12);
            num12 += 1;
        }
        else if (UpdatePicture && UpdateAward && num13 == 0) // 14번 일지
        {
            MarkVisable();
            Invoke("MarkVisable", 1.0f);
            diary.Play();
            dailylog.addItem(13);
            num13 += 1;
        }
    }

    void MarkVisable()
    {
        if(iswrite == false)
        {
            writingMark.SetActive(true);
            iswrite = true;
        }
        else
        {
            writingMark.SetActive(false);
        }
        
    }
}
