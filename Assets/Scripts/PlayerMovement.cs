using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody2D rb;
    public float Speed=400;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
       // Speed = 400;
	}
	
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb.velocity = movement * Speed * Time.deltaTime;
    }
}
