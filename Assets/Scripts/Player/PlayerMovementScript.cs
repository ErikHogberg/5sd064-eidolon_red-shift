using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.Scripts;
using Assets.Scripts.Utilities;

public class PlayerMovementScript: MonoBehaviour {
	private Rigidbody2D rb;
	private Vector3 mousePosition;

	public float Speed = 400;
	public float DodgeSpeed = 300;
	public float DodgeCooldownTime = .6f;
	public float DodgeDurationTime = .15f;

	public int Health = 100;
	public bool HpRegen = false;
	public int HpRegenCap = 100;
	public float HpRegenRate = 2.0f; // amount restored per second
	private Timer hpRegenTimer;

	private bool lookingRight = true;

	public Timer DodgeCooldown; // time until next dodge
	public Timer DodgeTimer; // time until dodge ends

	void Start() {

		Globals.Player = this;

		rb = GetComponent<Rigidbody2D>();

		hpRegenTimer = new Timer(1.0f / HpRegenRate);

		DodgeCooldown = new Timer(DodgeCooldownTime);
		DodgeCooldown.Stop();
		DodgeTimer = new Timer(DodgeDurationTime);
		DodgeTimer.Stop();

	}

	private void Update() {

		if (HpRegen && Health < HpRegenCap) {
			if (hpRegenTimer.Update()) {
				Health += 1;
				hpRegenTimer.RestartWithDelta();
			}
		}

		DodgeCooldown.Update(Time.deltaTime);
		if (Input.GetKeyDown(KeyCode.LeftShift) && !DodgeCooldown.IsRunning()) {
			DodgeTimer.Restart(DodgeDurationTime);
			DodgeCooldown.Restart(DodgeCooldownTime);
			Color color = GetComponent<SpriteRenderer>().color;
			color.a = .5f;
			GetComponent<SpriteRenderer>().color = color;
		}
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");


		if (DodgeTimer.IsRunning()) {
			Vector2 direction = rb.velocity.normalized;
			rb.velocity = direction * DodgeSpeed * .05f;
			if (DodgeTimer.Update(Time.deltaTime)) {
				//DodgeCooldown.Restart(DodgeCooldownTime);
				Color color = GetComponent<SpriteRenderer>().color;
				color.a = 1.0f;
				GetComponent<SpriteRenderer>().color = color;
			}
			return; // NOTE: early return
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

	void LateUpdate() {
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}

	public void TakeDamage(int damage) {

		// invulnerability frames
		if (DodgeTimer.IsRunning()) {
			return;
		}

		Health = Health - damage;

		if (Health < 0 || Health == 0) {
			//Destroy(gameObject);
			gameObject.SetActive(false);
		}
	}

	void Flip() {
		//transform.Rotate(0f, 180f, 0f);
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
