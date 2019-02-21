using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.Scripts;
using Assets.Scripts.Utilities;

public class PlayerMovement : MonoBehaviour {
	private Rigidbody2D rb;
	private Vector3 mousePosition;

	public float Speed = 400;
	public float DodgeSpeed = 300;
	public float DodgeCooldownTime = .15f;
	public float DodgeDurationTime = .6f;

	public int Health = 100;
	private bool lookingRight = true;

	private Timer dodgeCooldown; // time until next dodge
	private Timer dodgeTimer; // time until dodge ends

	void Start() {

		Globals.Player = this;

		rb = GetComponent<Rigidbody2D>();

		dodgeTimer = new Timer(DodgeDurationTime);
		dodgeCooldown = new Timer(DodgeCooldownTime);

	}

	void LateUpdate() {
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");


		if (dodgeTimer.IsRunning()) {
			Vector2 direction = rb.velocity.normalized;
			rb.velocity = direction * DodgeSpeed * .05f;
			if (dodgeTimer.Update(Time.deltaTime)) {
				dodgeCooldown.Restart();
				Color color = GetComponent<SpriteRenderer>().color;
				color.a = 1.0f;
				GetComponent<SpriteRenderer>().color = color;
			}
			return; // NOTE: early return
		}

		dodgeCooldown.Update(Time.deltaTime);
		if (Input.GetKeyDown(KeyCode.LeftControl) && !dodgeCooldown.IsRunning()) {
			dodgeTimer.Restart();
			Color color = GetComponent<SpriteRenderer>().color;
			color.a = .5f;
			GetComponent<SpriteRenderer>().color = color;
		}

		Vector2 movement = new Vector2(moveHorizontal, moveVertical);
		rb.velocity = movement * Speed * Time.deltaTime;

		if (mousePosition.x < transform.position.x && lookingRight) {
			lookingRight = !lookingRight;
			Flip();
		} else if (mousePosition.x > transform.position.x && !lookingRight) {
			lookingRight = !lookingRight;
			Flip();
		}
	}

	public void TakeDamage(int damage) {

		// invulnerability frames
		if (dodgeTimer.IsRunning()) {
			return;
		}

		Health = Health - damage;

		if (Health < 0 || Health == 0) {
			Destroy(gameObject);
		}
	}

	void Flip() {
		transform.Rotate(0f, 180f, 0f);
	}
}
