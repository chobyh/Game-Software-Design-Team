﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxMgr : MonoBehaviour
{

    //변수모음
    public GameObject textBox;//어떤 대화창인지

    public Text theName;//이름 Text 오브젝트
    public Text theDialogue;//대화 Text 오브젝트
	public Button nextButton;

    public string[] NtextLines;//이름
    public string[] DtextLines;//대사
    public Sprite[] IFile;//일러스트 파일 

    public int currentLine = 0;//진행중인 대사
    public int endAtLine = 0;//마지막 대사

    public bool isChoiceSentence = false;//선택문이 있는가
    public int setChoice = 0;//몇번째 문장에 선택문을 쓸것인가

    public bool ActiveControler = true;//컨트롤러 온오프

    public bool canTyping = false;//오토타이핑 쓸껀가
    public float typingSpeed = 0f;//오토타이핑 속도
    private bool isTyping = false;//대화 온오프
    private bool cancelTyping = false;//오토타이핑 정지

    private bool nextbutton = false;//스킵버튼 온오프
    public float BwaitTime = 1f;//스킵버튼 시간

    public bool isSprite = false;//일러스트가 있는가
    public Image theImage;//이미지 오브젝트

	GameObject thisGameObject;

    UnityEngine.Events.UnityAction action;


    //스크립트 활성화마다 실행함수
    public void SetDialog()
    {
        currentLine = 0;//대화상태 초기화
        ReadyDialogue();
		thisGameObject = this.gameObject.transform.parent.gameObject;
    }

    //대화창 준비함수
    void ReadyDialogue()
    {
        action = () => {; nextButtonControl(); };
        nextButton.onClick.AddListener (action); // 여기서 endAtLine이 호출 되어 실행 되는듯!

        if (endAtLine == 0)
        {
            endAtLine = NtextLines.Length - 1;//배열길이로 초기화
        }

        if (canTyping == true)//타이핑효과 쓰면
        {
            NextDialogue();
            DnextButton();
        }

        else//안쓰면
        {
            NextText();
            EnextButton();
        }

        if (ActiveControler == false)//컨트롤러를 끌꺼면 
        {
            GameObject.Find("UI").transform.Find("Canvas").
            transform.Find("PlayerControler").gameObject.SetActive(false);
        }

        if (isSprite == true)//일러스트 넣을거면
        {
            GameObject.Find("UI").transform.Find("Canvas").
            transform.Find("TextBox").transform.Find("Image").gameObject.SetActive(true);
        }

        if (isChoiceSentence == true)
        {
            GameObject.Find("UI").transform.Find("Canvas").transform.Find("TextBox").
            transform.Find("Button").transform.Find("Choice").gameObject.SetActive(false);
        }
    }

    //다음대화 함수
    void NextDialogue()//타이핑 쓰면
    {
        if (isTyping == false)
        {
            if (isSprite == true)
            {
                theImage.sprite = IFile[currentLine];
            }
            theName.text = NtextLines[currentLine];

            if (currentLine == endAtLine)//같을때 endAtLine 문제!
            {
                Time.timeScale = 1;
                nextButton.onClick.RemoveListener(action);
                DisableTextBox();//비활성화 함수
				if (thisGameObject.tag.Equals ("item")) {
					Destroy (thisGameObject);
				} else if (this.gameObject.tag.Equals ("event")) {
					Destroy (this.gameObject);
				}
            }
            else
            {
                StartCoroutine(TextScroll(DtextLines[currentLine]));
            }

            currentLine += 1;
        }

        else if (isTyping && cancelTyping)
        {
            cancelTyping = true;
        }

        if (isChoiceSentence == true && currentLine == setChoice)//선택문이 활성화되고 때가 왔는가
        {
            ChoiceDialogue();
        }

        DnextButton();
    }



    void NextText()//타이핑 안 쓰면
    {
        if (isTyping == false)
        {
            if (isSprite == true)
            {
                theImage.sprite = IFile[currentLine];
            }

            theName.text = NtextLines[currentLine];
            theDialogue.text = DtextLines[currentLine];

            currentLine += 1;

            if (currentLine > endAtLine)//클때
            {
				nextButton.onClick.RemoveListener(action);
                DisableTextBox();//비활성화 함수
            }
        }

        else if (isTyping && cancelTyping)
        {
            cancelTyping = true;
        }

        if (isChoiceSentence == true && currentLine == setChoice)//선택문이 활성화되고 때가 왔는가
        {
            ChoiceDialogue();
        }
    } 

    //타자효과 함수
    private IEnumerator TextScroll(string lineOfText)
    {
        int letter = 0;
        theDialogue.text = "";
        isTyping = true;
        cancelTyping = false;

        while (isTyping && !cancelTyping && (letter < lineOfText.Length - 1))
        {
            theDialogue.text += lineOfText[letter];
            letter += 1;
            yield return new WaitForSeconds(typingSpeed);
        }

        theDialogue.text = lineOfText;
        isTyping = false;
        cancelTyping = false;

        yield return new WaitForSeconds(BwaitTime);//스킵버튼 쿨타임

        if (isChoiceSentence == false)
        {
            EnextButton();
        }

        else if (isChoiceSentence == true && currentLine != setChoice)
        {
            EnextButton();
        }
    }

    //스킵버튼을 누르면 상태에 따라 알맞은 함수를 실행하는 함수
    public void nextButtonControl()
    {
        if (canTyping == true)
        {
            NextDialogue();
        }

        else
        {
            NextText();
        }
    }

    //활성화 비활성화 함수모음

    //버튼
    //버튼 ON함수
    void EnextButton()
    {
        if (nextbutton == false )
        {
            GameObject.Find("UI").transform.Find("Canvas").
            transform.Find("TextBox").transform.Find("Button").
            transform.Find("nextButton").gameObject.SetActive(true);
            //찾아서 활성화
            nextbutton = true;
        }
    }


    //버튼 OFF함수
    void DnextButton()
    {
        if (nextbutton == true)
        {
            GameObject.Find("UI").transform.Find("Canvas").
            transform.Find("TextBox").transform.Find("Button").
            transform.Find("nextButton").gameObject.SetActive(false);
            //찾아서 비활성화
            nextbutton = false;
        }
    } 


    //선택문
    void ChoiceDialogue()
    {
        DnextButton();//스킵버튼 비활성화
        GameObject.Find("UI").transform.Find("Canvas").transform.Find("TextBox").
        transform.Find("Button").transform.Find("Choice").gameObject.SetActive(true);
    }


    //대화창
    //대화창 활성화 함수




    //대화창 비활성화 함수
    public void DisableTextBox()
    {
        currentLine = 0;//대화상태 초기화


        if (ActiveControler == false)//컨트롤러가 꺼있으면
        {
            GameObject.Find("UI").transform.Find("Canvas").
            transform.Find("PlayerControler").gameObject.SetActive(true);//찾아서 활성화
        }

        if (isSprite == true)//일러스트 쓰면
        {
            GameObject.Find("UI").transform.Find("Canvas").transform.Find("TextBox").
            transform.Find("Image").gameObject.SetActive(false);
        }

        if (isChoiceSentence == true)//선택문 활성화 되있으면
        {
            GameObject.Find("UI").transform.Find("Canvas").transform.Find("TextBox").
            transform.Find("Button").transform.Find("Choice").gameObject.SetActive(false);
        }
        StopCoroutine("TextScroll");//코루틴 종료
        textBox.SetActive(false);//대화창 비활성화
    }  

}