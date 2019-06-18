using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
	public GameObject Player;
	public Transform tf;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		//Debug.Log("Updating Camera to: " + Player.transform.position.x + "; " + Player.transform.position.y);
        tf.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z - 10);
    }
}
