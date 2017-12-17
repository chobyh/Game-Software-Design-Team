using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifferentSprite : MonoBehaviour {

    public Sprite offSprite;
    public Sprite onSprite;

    // Use this for initialization
    void Start () {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = offSprite;
	}
	
	// Update is called once per frame
	public void changeSprite()
    {
        if(this.gameObject.GetComponent<SpriteRenderer>().sprite == offSprite)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = onSprite;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = offSprite;
        }
    }
}
