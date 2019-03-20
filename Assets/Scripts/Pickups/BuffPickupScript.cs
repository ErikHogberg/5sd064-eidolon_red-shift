using Assets.Scripts.Pickups;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffPickupScript : MonoBehaviour {
	//public int RecoveryAmount = 20;

	public BuffType BuffType;
	public float BuffStrength;
	public float Duration;

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.tag == "Player") {

			PlayerMovementScript player = collision.GetComponent<PlayerMovementScript>();
			if (player == null) {
				player = collision.GetComponentInParent<PlayerMovementScript>();
			}
			player.AddBuff(new Buff(BuffType, BuffStrength, Duration));

			Destroy(gameObject);
		}
	}
}
