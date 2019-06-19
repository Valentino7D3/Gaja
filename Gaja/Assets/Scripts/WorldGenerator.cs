using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WorldGenerator : MonoBehaviour
{
    public static int world_width = 100;
	public static int world_height = 10;
	public int wH = world_height;

	public GameObject stone_prefab;
	public GameObject dirt_prefab;
	public GameObject sand_prefab;

	private GameObject block_prefab;

	public Block[,] block_list = new Block[world_width, world_height];
    
    // Start is called before the first frame update
	void Start()
    {
		for(int i = 0; i < world_width; i++){
			for(int k = 0; k < world_height; k++){
				block_list[i, k] = new Block(new Vector3(i, k));
				
				block_list[i, k].block_prefab = stone_prefab;

				if(world_height - block_list[i, k].getPosition().y < 3){
					block_list[i, k].block_prefab = dirt_prefab;
				}
				//Debug.Log("Created new Block at position(x: " + i + ";y: " + k + ")");
			}
		}

		//block_prefab = stone_prefab;

		for(int i = 0; i < world_width; i++){
			for(int k = 0; k < world_height; k++){
				GameObject newObj = Instantiate(block_list[i, k].block_prefab, block_list[i, k].getPosition(), new Quaternion(0, 0,0,0));
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
	public GameObject block_prefab;
	private Vector3 position;

	public Block(){
	}

	public Block(Vector3 position){
		this.position = position;
	}

	public void setPosition(Vector3 position){
		this.position = position;
	}

	public Vector3 getPosition(){
		return this.position;
	}
}
