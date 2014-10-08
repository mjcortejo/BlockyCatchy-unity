using UnityEngine;
using System.Collections;

public class BlockColliderManagerScript : GameController
{
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<SpriteRenderer>().color == gameObject.GetComponent<SpriteRenderer>().color)
        {
            Destroy(col.gameObject);
        }
    }
}
