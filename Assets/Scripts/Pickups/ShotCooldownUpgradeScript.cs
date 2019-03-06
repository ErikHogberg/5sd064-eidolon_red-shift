using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCooldownUpgradeScript : MonoBehaviour
{
	public int RecoveryAmount = 20;

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.tag == "Player") {

			WeaponScript player = collision.GetComponent<WeaponScript>();
			if (player == null) {
				player = collision.transform.parent.GetComponentInChildren<WeaponScript>();
			}
			player.AttackTimers.Add(new Assets.Scripts.Utilities.Timer(player.Cooldown));

			Destroy(gameObject);
		}
	}

}
