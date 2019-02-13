using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {

	public float speedX = 1;
	public float speedY = 1;
	public float globalSpeed = 1;

	//private BoxCollider2D boxCollider;
	//private Rigidbody2D rb;

	// Use this for initialization
	void Start() {
		//speed = 1;
		//rb = GetComponent<Rigidbody2D>();
		//boxCollider = GetComponent<BoxCollider2D>();
	}

	// Update is called once per frame
	void FixedUpdate() {
		float vertical = Input.GetAxis("Vertical");
		float horizontal = Input.GetAxis("Horizontal");

		/*
			rb.AddForce(new Vector2( 
			horizontal * speedX * globalSpeed * Time.deltaTime,
			vertical * speedY * globalSpeed * Time.deltaTime
		));
		// */

		//*
		transform.position += new Vector3(
			horizontal * speedX * globalSpeed * Time.deltaTime,
			vertical * speedY * globalSpeed * Time.deltaTime,
			0
		);
		// */



	}
}
