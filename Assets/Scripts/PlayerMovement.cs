using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody2D rb;
    public float Speed = 400;
    private bool lookingRight = true;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb.velocity = movement * Speed * Time.deltaTime;

        if(moveHorizontal > 0 && !lookingRight)
        {
            Flip();
        } else if (moveHorizontal < 0 && lookingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        lookingRight = !lookingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
