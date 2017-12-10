using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour {

    public TextBoxMgr textboxmgr;

    bool isrleft = true;

    int start = 0;
    // Use this for initialization
    void Start () {
        GameObject.Find("UI").transform.Find("Canvas").
        transform.Find("TextBox").gameObject.SetActive(true);
        textboxmgr.SetDialog();
    }

    // Update is called once per frame
    void Update () {
        if(isrleft)
        {
            transform.Rotate(new Vector3(0, 0, 1) * 0.05f);
            if(this.gameObject.transform.rotation.z > 0.03f)
            {
                isrleft = false;
            }
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, -1) * 0.05f);
            if (this.gameObject.transform.rotation.z < -0.03f)
            {
                isrleft = true ;
            }
        }
    }
}
