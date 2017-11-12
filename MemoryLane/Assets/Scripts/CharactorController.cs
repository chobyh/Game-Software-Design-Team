using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorController : MonoBehaviour {
    // Use this for initialization
    Animator animator;

    public GameObject sprite;

    public float speed;
    void Start () {
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
        Debug.Log(xMove);
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
        if (other.gameObject.tag.Equals("event"))
        {
            GameObject.Find("UI").transform.Find("Canvas").
            transform.Find("TextBox").gameObject.SetActive(true);
        }
        else if(other.gameObject.tag.Equals("enemy"))
        {
            Application.LoadLevel("Game_Over");
        }
    }
}
