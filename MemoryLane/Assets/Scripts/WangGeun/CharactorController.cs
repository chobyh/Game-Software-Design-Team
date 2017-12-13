using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorController : MonoBehaviour {
    // Use this for initialization
    Animator animator;

    public AudioSource audio;
    public AudioClip walkSound;
	public AudioClip openSound;
	public AudioClip closeSound;

    public Transform hideTransform;
    public Transform offHideTransform;
    public Transform ghostSeeTransform;
    public float speed;

    public GameObject lockDoor;
    public TextBoxMgr openDoorText;

    public bool haveLanton = false;
    public bool haveDiary = false;
    public bool haveDoorKey = false;
    public bool haveRemote = false;
    public bool haveBabyDoll = false;
    public bool haveShovel = false;

    bool haveFathersLetter = false;
    bool haveDaughtersLetter = false;
    bool havePolice = false;
    bool haveAward = false;
    bool haveSketchBook = false;
    bool havePicture = false;
	public bool haveAllitem = false;

    public bool isreadClock = false;
    public bool isreadDeadMan = false;
    public bool isreadTV = false;
    public bool isreadHole = false;

    public bool haveHide = false;
	public bool isHide = false;


    private TextBoxMgr textboxmgr;

    void Start () {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
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
			if (this.gameObject.GetComponent<AudioSource> () != null) {
				this.gameObject.GetComponent<AudioSource> ().Play();
			}
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
		if (Input.GetButtonDown("Jump"))
        {
            textboxmgr = other.gameObject.GetComponentInChildren<TextBoxMgr>();

            if (haveDoorKey && other.gameObject == lockDoor.gameObject)
            {
                textboxmgr = openDoorText;
                other.gameObject.GetComponent<Animator>().SetBool("isOpened", true);
                Destroy(other.gameObject.GetComponent<BoxCollider2D>());
            }

            if (textboxmgr == null) { }
            else if((other.gameObject.transform.name.Equals("TV") && haveRemote == false )||((other.gameObject.transform.name.Equals("Hole")) && haveShovel == false) )
            { }
            else
            {
                GameObject.Find("UI").transform.Find("Canvas").
              transform.Find("TextBox").gameObject.SetActive(true);
                textboxmgr.SetDialog();
                Time.timeScale = 0;
            }

            if (other.gameObject.transform.name.Equals("TV") && haveRemote == true)
            {
                isreadTV = true;
                other.gameObject.GetComponent<DifferentSprite>().changeSprite();
            }

            if((other.gameObject.transform.name.Equals("Hole")) && haveShovel == true)
            {
                isreadHole = true;
                GameObject[] last = GameObject.FindGameObjectsWithTag("item");
                for(int a = 0; a < last.Length; a++)
                {
                    last[a].SetActive(true);
                }
            }

			if (other.transform.name.Equals ("Diary")) {
				haveDiary = true;
			} else if (other.transform.name.Equals ("Remote")) {
				haveRemote = true;
			} else if (other.transform.name.Equals ("BabyDoll")) {
				haveBabyDoll = true;
			} else if (other.transform.name.Equals ("DoorKey")) {
				haveDoorKey = true;
				this.gameObject.GetComponentInChildren<Camera> ().transform.Translate (0, 3, 0);
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
			} else if (haveFathersLetter && haveDaughtersLetter && havePolice && haveAward && haveSketchBook && havePicture) {
				haveAllitem = true;
			}

            if(other.transform.name.Equals("Clock"))
            {
                isreadClock = true;
            }
            else if(other.transform.name.Equals("DeadMan"))
            {
                isreadDeadMan = true;
            }
            if(other.gameObject.tag.Equals("Hide") && isHide == false)
            {
                haveHide = true;
                isHide = true;
                this.gameObject.transform.position = hideTransform.transform.position;
				other.gameObject.GetComponent<AudioSource> ().clip = openSound;
				other.gameObject.GetComponent<AudioSource> ().Play ();
            } else if(isHide == true)
            {
                isHide = false;
                this.gameObject.transform.position = offHideTransform.transform.position;
				//other.gameObject.GetComponent<AudioSource> ().clip = closeSound;
				//other.gameObject.GetComponent<AudioSource> ().Play ();
            }
          }
			
	}
}
