using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenAttackScript : MonoBehaviour {

	private bool attacking = false;
	private bool swing = false;

	public float attackInterval = 2.0f;
	private Timer attackTimer;

	private void Start() {
		attackTimer = new Timer(attackInterval);
	}

	void Update() {
		if (GetComponentInParent<BossScript>().dead) {
			return;
		}

		if (attacking) {
			if (attackTimer.Update()) {
				swing = true;
				attackTimer.Restart(attackInterval);
			}
		}

		attacking = false;

	}

	private void OnTriggerStay2D(Collider2D collision) {
		if (collision.tag == "Player") {
			if (swing) {
				var player = collision.GetComponent<PlayerMovementScript>();
				if (player == null) {
					player = collision.GetComponentInParent<PlayerMovementScript>();
				}
				player.TakeDamage(999999999);
			}
			attacking = true;
		}
	}

}
