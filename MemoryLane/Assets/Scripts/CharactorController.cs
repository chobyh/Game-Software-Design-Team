using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorController : MonoBehaviour {
    // Use this for initialization
    Animator animator;

    public GameObject sprite;
    public Ray2D ray;
    public RaycastHit2D raycasthit;

    public float speed;

    private TextBoxMgr textboxmgr;

    void Start () {
        animator = GetComponent<Animator>();
        //ray = GetComponent<Ray2D>();
        //raycasthit = GetComponent<RaycastHit2D>();
    }
	
	// Update is called once per frame
	void Update () {
        moveChar();
        FrontCheck();
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
        textboxmgr = other.GetComponentInChildren<TextBoxMgr>();
        if (other.gameObject.tag.Equals("event"))
        {
            if(textboxmgr.isRead == false)
            {
               GameObject.Find("UI").transform.Find("Canvas").
               transform.Find("TextBox").gameObject.SetActive(true);
               Time.timeScale = 0;
            }
        }
        else if(other.gameObject.tag.Equals("enemy"))
        {
            Application.LoadLevel("Game_Over");
        }
    }

    void OnTriggerExit2D()
    {
    }

    void FrontCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { }
    }
}
