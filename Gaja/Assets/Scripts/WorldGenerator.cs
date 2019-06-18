using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WorldGenerator : MonoBehaviour
{
    public static int world_width = 1000;
	public static int world_height = 100;
	public int wH = world_height;

	public GameObject block_prefab;
	public Block[,] block_list = new Block[world_width, world_height];
    
    // Start is called before the first frame update
	void Start()
    {
		for(int i = 0; i < world_width; i++){
			for(int k = 0; k < world_height; k++){
				block_list[i, k] = new Block(new Vector2(i, k));
				//Debug.Log("Created new Block at position(x: " + i + ";y: " + k + ")");
			}
		}

		for(int i = 0; i < world_width; i++){
			for(int k = 0; k < world_height; k++){
				GameObject newObj = Instantiate(block_prefab, block_list[i, k].getPosition(), new Quaternion(0, 0,0,0));
				newObj.transform.parent = GameObject.Find("Map").transform;
				newObj.name = "Block(" + Convert.ToString(i) + "|" + Convert.ToString(k) + ")";


			}
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Block {

	private Vector2 position;

	public Block(){
	}

	public Block(Vector2 position){
		this.position = position;
	}

	public void setPosition(Vector2 position){
		this.position = position;
	}

	public Vector2 getPosition(){
		return this.position;
	}
}
