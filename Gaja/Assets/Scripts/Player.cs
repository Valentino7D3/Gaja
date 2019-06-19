using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Animator anim;
	public GameObject WorldGenerator;
	public Rigidbody rb;
	public bool onGround = false;
	public float maxHorizontalVelocity = 80;
	public float acceleration = 20000;
	RaycastHit hit;

		private static Vector3 mouseDownPoint;
	private static Vector3 mouseUpPoint;
	private static Vector3 currentMousePoint;
	private float raycastLength = Mathf.Infinity;
    // Start is called before the first frame update
    void Start()
    {
        rb.transform.position = new Vector3(0, WorldGenerator.GetComponent<WorldGenerator>().wH, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, raycastLength))
		{
			currentMousePoint = hit.point;
			if (Input.GetMouseButtonDown(0))
			{
				Debug.Log(hit.collider.gameObject.name);
				Destroy(hit.collider.gameObject);
			}

		}

		if(rb.velocity.x > 0){
			//ManWalk animation
		}
		if(rb.velocity.x < 0){
			//Flip Character
			//ManWalk animation
		}
    }

	void FixedUpdate(){

		if(Input.GetKey("space") && onGround){
			rb.velocity = rb.velocity + new Vector3(0, 5, 0);
			//rb.AddForce(new Vector3(0, 80000 * Time.deltaTime, 0));
			onGround = false;
		}
		if(Input.GetKey("a") && rb.velocity.x > -maxHorizontalVelocity){
			rb.AddForce(new Vector3(-acceleration * Time.deltaTime, 0, 0));

		}
		if(Input.GetKey("d") && rb.velocity.x < maxHorizontalVelocity){

			rb.AddForce(new Vector3(acceleration * Time.deltaTime, 0, 0));
			//rb.velocity = rb.velocity + new Vector3(0.1f, 0, 0);

		}
		Debug.Log("OnGround: " + onGround);
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.transform.parent.name == "Map"){
			Debug.Log("IsCollieding: " + col.gameObject.transform.parent.name);
			onGround = true;
		}
	}
}
