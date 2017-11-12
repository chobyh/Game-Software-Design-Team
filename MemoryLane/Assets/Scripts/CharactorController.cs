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
    }
	
	// Update is called once per frame
	void Update () {
        moveChar();
    }

    void moveChar()
    {
        float xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime * Time.timeScale;
        float yMove = Input.GetAxis("Vertical") * speed * Time.deltaTime * Time.timeScale;
        this.transform.Translate(new Vector2(xMove, yMove));
        if (-0.0001f < xMove && xMove < 0.0001f)
        {
            GetComponent<Animator>().SetBool("Move", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("Move", true);
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
            }
        }
        else if(other.gameObject.tag.Equals("enemy"))
        {
            Application.LoadLevel("Game_Over");
        }
    }
}
