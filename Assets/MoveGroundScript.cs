using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGroundScript : MonoBehaviour {

	public float speed = 1;

	// Use this for initialization
	void Start() {
		//speed = 1;

	}

	// Update is called once per frame
	void Update() {
		float vertical = Input.GetAxis("Vertical");
		float horizontal = Input.GetAxis("Horizontal");


		transform.position += new Vector3(
			horizontal * speed * Time.deltaTime,
			vertical * speed * Time.deltaTime,
			0
		);



	}
}
