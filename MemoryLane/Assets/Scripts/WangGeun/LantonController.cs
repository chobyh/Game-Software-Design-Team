using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LantonController : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private bool lantonOn = false;

    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[0];
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            LantonOn();
        }
    }

    void LantonOn()
    {
        if (lantonOn == false)
        {
            spriteRenderer.sprite = sprites[1];
            lantonOn = true;
        }
        else
        {
            spriteRenderer.sprite = sprites[0];
            lantonOn = false;
        }
    }
}
