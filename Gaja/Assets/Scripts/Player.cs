using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public GameObject WorldGenerator;
	public Rigidbody2D rb;
	public bool onGround = false;
	public float maxHorizontalVelocity = 2;

    // Start is called before the first frame update
    void Start()
    {
        rb.transform.position = new Vector2(0, WorldGenerator.GetComponent<WorldGenerator>().wH);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void FixedUpdate(){

		if(Input.GetKey("space") && onGround){
			rb.AddForce(new Vector2(0, 20000 * Time.deltaTime));
			onGround = false;
		}
		if(Input.GetKey("a") && rb.velocity.x > -maxHorizontalVelocity){
			rb.AddForce(new Vector2(-2000 * Time.deltaTime, 0));

		}
		if(Input.GetKey("d") && rb.velocity.x < maxHorizontalVelocity){
			rb.AddForce(new Vector2(2000 * Time.deltaTime, 0));
			//rb.velocity = rb.velocity + new Vector3(0.1f, 0, 0);

		}
		Debug.Log("OnGround: " + onGround);
	}

	void OnCollisionEnter(Collision col){
		//if(col.gameObject.transform.parent.name == "Map"){
			Debug.Log("IsCollieding: " + col.gameObject.transform.parent.name);
			//onGround = true;
		//}
	}
}
