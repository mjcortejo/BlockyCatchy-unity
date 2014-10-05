using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    protected GameObject block1;
    protected GameObject block2;
    protected GameObject fallerblock;
    private GameObject leftSpawn;
    private GameObject rightSpawn;
    private float leftRange;
    private float rightRange;
    public int moveSpeed;
	// Use this for initialization
	void Start () 
    {
        //Manual initialization of game objects because if public, these bastards show up in the child clas
        block1 = GameObject.Find("Block1");
        block2 = GameObject.Find("Block2");
        fallerblock = (GameObject)Resources.Load("Prefabs/Fallers");
        leftSpawn = GameObject.Find("LeftSpawnRange");
        rightSpawn = GameObject.Find("RightSpawnRange");
        //Align y coordinates of two spawner ranges
        leftSpawn.transform.position = new Vector2(leftSpawn.transform.position.x, rightSpawn.transform.position.y);
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
        SpawnBlocks();
        ChangeBlockColorOnInterval();
        //KeyClick();
	}
    float changeColorTimer = 0;
    public float changeColorInterval;
    void ChangeBlockColorOnInterval()
    {
        changeColorTimer += Time.deltaTime;
        if (changeColorTimer >= changeColorInterval)
        {
            ChangeBlockColor();
            changeColorTimer = 0;
        }
    }
    private void ChangeBlockColor()
    {
        bool isTheSame = true;
        while (isTheSame)
        {
            int colorIndex1 = Random.Range(0, 5);
            int colorIndex2 = Random.Range(0, 5);
            if (colorIndex1 == colorIndex2)
            {
                isTheSame = true;
            }
            else
            {
                isTheSame = false;
                block1.GetComponent<SpriteRenderer>().color = GetColor(colorIndex1);
                block2.GetComponent<SpriteRenderer>().color = GetColor(colorIndex2);
            }
        }
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
    float spawnTimer = 0;
    float spawnIntervalTimer = 1;
    void SpawnBlocks()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnIntervalTimer)
        {
            //Spawn random position based on both spawner objects
            float randPos = Random.Range(leftRange, rightRange);
            //Instantiate new spawning position'
            Vector2 spawnPos = new Vector2(randPos, leftSpawn.transform.position.y);
            Instantiate(fallerblock, spawnPos, gameObject.transform.rotation);
            spawnTimer = 0;
        }
    }
    Color blockColor;
    private Color GetColor(int index)
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
