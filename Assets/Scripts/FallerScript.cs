using UnityEngine;
using System.Collections;

public class FallerScript : GameController {

	// Use this for initialization
	void Start () 
    {
        block1 = GameObject.Find("Block1");
        block2 = GameObject.Find("Block2");
        GetColor(Random.Range(0, 2));
	}
	
	// Update is called once per frame
	void Update () 
    {
        //KeyClick();
        FallMovement();
	}
    void KeyClick()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetColor(Random.Range(0, 2));
        }
    }
    private void GetColor(int index)
    {
        switch (index)
        {
            case 0:
                gameObject.GetComponent<SpriteRenderer>().color = block1.GetComponent<SpriteRenderer>().color;
                break;
            case 1:
                gameObject.GetComponent<SpriteRenderer>().color = block2.GetComponent<SpriteRenderer>().color;
                break;
            default:
                break;
        }
    }
    private void FallMovement()
    {
        rigidbody2D.velocity = new Vector2(0, -moveSpeed);
    }
}
