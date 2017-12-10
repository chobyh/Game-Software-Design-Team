using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorController : MonoBehaviour {
    // Use this for initialization
    Animator animator;

    public AudioSource audio;
    public AudioClip walkSound;

    public float speed;

	public bool haveLanton = false;
    public bool haveDiary = false;
    bool haveDoorKey = false;
    bool haveRemote = false;
    bool haveBabyDoll = false;
    bool haveShovel = false;
    bool haveFathersLetter = false;
    bool haveDaughtersLetter = false;
    bool havePolice = false;
    bool haveAward = false;
    bool haveSketchBook = false;
    bool havePicture = false;

    public bool isreadClock = false;
    public bool isreadDeadMan = false;
    public bool isread = false;

	public bool isHide = false;


    private TextBoxMgr textboxmgr;

    void Start () {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        audio.clip = walkSound;
    }
	
	// Update is called once per frame
	void Update () {
        moveChar();
    }

    void moveChar()
    {
        Vector3 scale = transform.localScale;
        float xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float yMove = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        this.transform.Translate(new Vector2(xMove, yMove));
        if (xMove != 0.0f || yMove != 0.0f)
        {
            scale.z = 1;
            if(xMove < 0)
            {
                scale.x = -Mathf.Abs(scale.x);
                transform.localScale = scale;
                animator.SetBool("Move", true);
            }
            else
            {
                scale.x = Mathf.Abs(scale.x);
                transform.localScale = scale;
                animator.SetBool("Move", true);
            }
            if (!audio.isPlaying) { audio.Play(); }
        }
        else
        {
            animator.SetBool("Move", false);
            audio.Stop();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {  
        if (other.gameObject.tag.Equals("event"))
        {
			
          	textboxmgr = other.GetComponentInChildren<TextBoxMgr>();
            if (textboxmgr == null)
                return;
            GameObject.Find("UI").transform.Find("Canvas").
            transform.Find("TextBox").gameObject.SetActive(true);
            textboxmgr.SetDialog();
            Time.timeScale = 0;
        }
        else if(other.gameObject.tag.Equals("enemy"))
        {
            Application.LoadLevel("GameOver");
        }
    }
    
    void OnCollisionStay2D(Collision2D other)
    {
		if (other.gameObject.tag.Equals ("Hide")) {
			isHide = true;
		}
		else if (Input.GetButtonDown("Jump"))
        {
            textboxmgr = other.gameObject.GetComponentInChildren<TextBoxMgr>();
			if (textboxmgr == null)
				return;
            GameObject.Find("UI").transform.Find("Canvas").
            transform.Find("TextBox").gameObject.SetActive(true);
			textboxmgr.SetDialog ();
            Time.timeScale = 0;

			if (other.transform.name.Equals ("Diary")) {
				haveDiary = true;
			} else if (other.transform.name.Equals ("Remote")) {
				haveRemote = true;
			} else if (other.transform.name.Equals ("BabyDoll")) {
				haveBabyDoll = true;
			} else if (other.transform.name.Equals ("Shovel")) {
				haveShovel = true;
			} else if (other.transform.name.Equals ("Father'sLetter")) {
				haveFathersLetter = true;
			} else if (other.transform.name.Equals ("Daughter'sLetter")) {
				haveDaughtersLetter = true;
			} else if (other.transform.name.Equals ("Police")) {
				havePolice = true;
			} else if (other.transform.name.Equals ("Award")) {
				haveAward = true;
			} else if (other.transform.name.Equals ("SketchBook")) {
				haveSketchBook = true;
			} else if (other.transform.name.Equals ("Picture")) {
				havePicture = true;
			} else if (other.transform.name.Equals ("Lanton")) {
				haveLanton = true;
			}

            if(other.transform.name.Equals("Clock"))
            {
                isreadClock = true;
            }
            else if(other.transform.name.Equals("DeadMan"))
            {
                isreadDeadMan = true;
            }
          }
			
	}
	void OnCollisionOut2D (Collision2D other)
	{
		isHide = false;
	}
}
