using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryManager : MonoBehaviour {

    public CharactorController characterController;
    public EventManager eventFlow;
    bool UpdateFamliy;
    bool UpdateNewspaper;
    bool UpdateAward;
    bool UpdatePolice;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        UpdateDairy();
    }

    void UpdateDairy()
    {
        if(eventFlow.index == 1)
        {
            
        }
        else if()
        {

        }
        else if (characterController.haveBabyDoll)
        {

        }
        else if (characterController.is)
        {
            UpdateFamliy = true;
        }
        else if (characterController.is)
        {
            UpdateNewspaper = true;
        }
        else if (UpdateFamliy && UpdateNewspaper)
        {

        }
        else if (characterController.is)
        {

        }
        else if (eventFlow.index == )
        {

        }
        else if (characterController.have)
        {
            UpdatePolice = true;
        }
        else if (characterController.have)
        {
            UpdateAward = true;
        }
        else if (UpdatePolice && UpdateAward)
        {

        }
        else if (characterController.have)
        {

        }
    }
}
