using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorController : MonoBehaviour {
    // Use this for initialization
    Animator animator;

    public GameObject sprite;

    public float speed;

    private TextBoxMgr textboxmgr;

    void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        moveChar();
    }

    void moveChar()
    {
        float xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float yMove = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        this.transform.Translate(new Vector2(xMove, yMove));
        if (xMove != 0.0f || yMove != 0.0f)
        {
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {  
        if (other.gameObject.tag.Equals("event"))
        {
            textboxmgr = other.GetComponentInChildren<TextBoxMgr>();
            if (textboxmgr == null)
                return;
            if (textboxmgr.isRead == false)
            {
               GameObject.Find("UI").transform.Find("Canvas").
               transform.Find("TextBox").gameObject.SetActive(true);
               textboxmgr.SetDialog();
               Time.timeScale = 0;
            }
        }
        else if(other.gameObject.tag.Equals("enemy"))
        {
            Application.LoadLevel("GameOver");
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (Input.GetButton("Jump"))
        {
            textboxmgr = other.gameObject.GetComponentInChildren<TextBoxMgr>();
			if (textboxmgr == null)
				return;
            if (textboxmgr.isRead == false)
            {
                GameObject.Find("UI").transform.Find("Canvas").
                transform.Find("TextBox").gameObject.SetActive(true);
				textboxmgr.SetDialog ();
                Time.timeScale = 0;
            }
        }
    }

}
