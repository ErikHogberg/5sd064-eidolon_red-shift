using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody2D rb;
    private Vector3 mousePosition;
    public Transform crosshair;
    public float Speed = 400;
    private bool lookingRight = true;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        Cursor.visible = false;
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        crosshair.position = new Vector2(mousePosition.x, mousePosition.y);

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

    void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }
}
