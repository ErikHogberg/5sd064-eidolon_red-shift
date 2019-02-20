using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.Scripts.Utilities;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody2D rb;
    private Vector3 mousePosition;
    public float Speed = 400;
	public float DodgeSpeed = 1;
	public float DodgeCooldownTime = .3f;
	public float DodgeDurationTime = .6f;
	
    public int health = 100;
    private bool lookingRight = true;

	private Timer dodgeCooldown; // time until next dodge
	private Timer dodgeTimer; // time until dodge ends

	void Start() {
        rb = GetComponent<Rigidbody2D>();

		dodgeTimer = new Timer(DodgeDurationTime);
		dodgeCooldown = new Timer(DodgeCooldownTime);

    }

    void LateUpdate()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

		
		if (dodgeTimer.IsRunning()) {
			Vector2 direction = rb.velocity.normalized;
			rb.velocity = direction * DodgeSpeed;
			if (dodgeTimer.Update(Time.deltaTime)) {
				dodgeCooldown.Restart();
			}
			return; // NOTE: early return
		}

		dodgeCooldown.Update(Time.deltaTime);
		if (Input.GetKeyDown(KeyCode.LeftControl) && !dodgeCooldown.IsRunning()) {
			dodgeTimer.Restart();
		}

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

		// IDEA: invulnerability frames
		if (dodgeTimer.IsRunning()) {
			// IDEA: blink while dodging, make transparent?
			return;
		}

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
