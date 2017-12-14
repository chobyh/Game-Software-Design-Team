using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryManager : MonoBehaviour {

    public CharactorController characterController;
    public EventManager eventFlow;
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
        if(eventFlow.index == 1) // 2번 일지
        {
            diary.Play();
        }
        else if(characterController.isShout) // 3번 일지
        {
            diary.Play();
        }
        else if (characterController.isreadGuiltybook) // 4번 일지
        {
            diary.Play();
        }
        else if (characterController.isreadCalender) // 5번 일지
        {
            diary.Play();
        }
        else if (characterController.isreadFamilyPhoto) // 6번 일지
        {
            UpdateFamliy = true;
            diary.Play();
        }
        else if (characterController.isreadNewspaper) // 7번 일지
        {
            UpdateNewspaper = true;
            diary.Play();
        }
        else if (UpdateFamliy && UpdateNewspaper) // 8번 일지
        {
            diary.Play();
        }
        else if (characterController.isreadTV) // 9번 일지
        {
            diary.Play();
        }
        else if (characterController.haveFathersLetter) // 10번 일지
        {
            diary.Play();
        }
        else if (characterController.haveDaughtersLetter) // 11번 일지
        {
            diary.Play();
        }
        else if (characterController.haveAward && characterController.havePolice) // 12번 일지
        {
            UpdateAward = true;
            diary.Play();
        }
        else if (characterController.havePicture) // 13번 일지
        {
            UpdatePicture = true;
            diary.Play();
        }
        else if (UpdatePicture && UpdateAward) // 14번 일지
        {
            diary.Play();
        }
    }
}
