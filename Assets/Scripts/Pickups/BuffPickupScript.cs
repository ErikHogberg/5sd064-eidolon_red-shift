using Assets.Scripts;
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

			string message = "Picked up buff";
			switch (BuffType) {
				case BuffType.HpRegen:
					message += ": Hp Regeneration";
					break;
				case BuffType.ZombieHpRegen:
					message += ": Zombie Hp Regen.";
					break;
				case BuffType.ZombieSpeedUp:
					message += ": Zombie Speed Up";
					break;
				case BuffType.Invulnerability:
					message += ": Invulnerability";
					break;
				case BuffType.NoWeaponCooldown:
					break;
				case BuffType.FullAutoWeapon:
					message += ": Full Auto";
					break;
				case BuffType.DamageIncrease:
					break;
				case BuffType.AoEWeapon:
					break;
				default:
					break;
			}
			Globals.NotificationWindow.Show(message);

			Destroy(gameObject);
		}
	}
}
