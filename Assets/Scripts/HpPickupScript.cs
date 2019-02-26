using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpPickupScript : MonoBehaviour
{
	public int RecoveryAmount = 20;

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.tag == "Player") {

			PlayerMovementScript player = collision.GetComponent<PlayerMovementScript>();
			if (player == null) {
				player = collision.GetComponentInParent<PlayerMovementScript>();
			}
			player.Health += RecoveryAmount;

			Destroy(gameObject);
		}
	}

}
