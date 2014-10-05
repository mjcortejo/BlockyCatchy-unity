using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private GameObject block1;
    private GameObject block2;
    private GameObject leftSpawn;
    private GameObject rightSpawn;
    float leftRange;
    float rightRange;
    public int moveSpeed;
    //Block colors stored here
    public Color[] blockcolors;
	// Use this for initialization
	void Start () 
    {
        //Manual initialization of game objects because if public, these bastards show up in the child clas
        block1 = GameObject.Find("Block1");
        block2 = GameObject.Find("Block2");
        leftSpawn = GameObject.Find("LeftSpawnRange");
        rightSpawn = GameObject.Find("RightSpawnRange");
        blockcolors = new Color[2];
        blockcolors[0] = block1.GetComponent<SpriteRenderer>().color;//gets color for the first block
        blockcolors[1] = block2.GetComponent<SpriteRenderer>().color;//gets color for the 2nd block
        //Debug.Log("Left Spawn X: " + leftSpawn.transform.position.x);
        //Debug.Log("Right Spawn X: " + rightSpawn.transform.position.x);
        //Get the coordinates between two spawner ranges
        leftRange = leftSpawn.transform.position.x;
        rightRange = rightSpawn.transform.position.x;
        ChangeBlockColor();
	}
	
	// Update is called once per frame
	void Update () 
    {
        Block1Controller();
        Block2Controller();
	}
    float changeColorTimer = 0;
    public float changeColorInterval;
    void ChangeBlockColor()
    {
        int colorIndex = Random.Range(0, 5);
        block1.GetComponent<SpriteRenderer>().color = GetColor(colorIndex);
        colorIndex = Random.Range(0, 5);
        block2.GetComponent<SpriteRenderer>().color = GetColor(colorIndex);
    }
    void Block1Controller()
    {
        block1.rigidbody2D.velocity = new Vector2(GetVelocityForBlock1(), 0);
    }
    void Block2Controller()
    {
        block2.rigidbody2D.velocity = new Vector2(GetVelocityForBlock2(), 0);
    }

    int GetVelocityForBlock1()
    {
        int v = 0;
        if (Input.GetKey(KeyCode.A))
        {
            v = -moveSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            v = moveSpeed;
        }
        return v;
    }
    int GetVelocityForBlock2()
    {
        int v = 0;
        if (Input.GetKey(KeyCode.J))
        {
            v = -moveSpeed;
        }
        else if (Input.GetKey(KeyCode.L))
        {
            v = moveSpeed;
        }
        return v;
    }
    void SpawnBlocks()
    {
        //Get distance range of both spawner objects
        //Spawn random position based on both spawner objects
        float spawnPos = Random.Range(leftRange, rightRange);
        //Instantiate new spawning position
    }
    Color blockColor;
    public Color GetColor(int index)
    {
        switch (index)
        {
            case 0:
                blockColor = Color.red;
                break;
            case 1:
                blockColor = Color.blue;
                break;
            case 2:
                blockColor = Color.magenta;
                break;
            case 3:
                blockColor = Color.green;
                break;
            case 4:
                blockColor = Color.yellow;
                break;
            default:
                blockColor = Color.white;
                break;
        }
        return blockColor;
    }

}
