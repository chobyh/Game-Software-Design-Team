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

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        UpdateDairy();
    }

    void UpdateDairy()
    {
        if(eventFlow.index == 1) // 2번 일지
        {
            
        }
        else if(characterController.isShout) // 3번 일지
        {

        }
        else if (characterController.isreadGuiltybook) // 4번 일지
        {

        }
        else if (characterController.isreadCalender) // 5번 일지
        {
            
        }
        else if (characterController.isreadFamilyPhoto) // 6번 일지
        {
            UpdateFamliy = true;
        }
        else if (characterController.isreadNewspaper) // 7번 일지
        {
            UpdateNewspaper = true;
        }
        else if (UpdateFamliy && UpdateNewspaper) // 8번 일지
        {

        }
        else if (characterController.isreadTV) // 9번 일지
        {

        }
        else if (characterController.haveFathersLetter) // 10번 일지
        {

        }
        else if (characterController.haveDaughtersLetter) // 11번 일지
        {

        }
        else if (characterController.haveAward && characterController.havePolice) // 12번 일지
        {
            UpdateAward = true;
        }
        else if (characterController.havePicture) // 13번 일지
        {
            UpdatePicture = true;
        }
        else if (UpdatePicture && UpdateAward) // 14번 일지
        {
            
        }
    }
}
