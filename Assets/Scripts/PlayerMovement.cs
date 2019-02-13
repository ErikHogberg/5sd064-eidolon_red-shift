using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody2D rb;
    private Vector3 mousePosition;
    public float Speed = 400;
    public int health = 100;
    private bool lookingRight = true;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void LateUpdate()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * Speed * Time.deltaTime;

        if (mousePosition.x < transform.position.x && lookingRight)
        {
            lookingRight = !lookingRight;
            Flip();
        }
        else if (mousePosition.x > transform.position.x && !lookingRight)
        {
            lookingRight = !lookingRight;
            Flip();
        }
    }

    public void TakeDamage(int damage)
    {
        health = health - damage;

        if(health < 0 || health == 0)
        {
            Destroy(gameObject);
        }
    }

    void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }
}
