using Assets.Scripts;
using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryCooldownScript : MonoBehaviour {

	public Color ReadyColor;
	public Color ChargingColor;

	public int CooldownIndex;


	private Timer cooldown;

	private SpriteRenderer sprite;

	void Start() {
		sprite = GetComponent<SpriteRenderer>();
	}

	void Update() {
		if (cooldown == null) {
			cooldown = Globals.Player.GetComponentInChildren<WeaponScript>().AttackTimers[CooldownIndex];
		}
		
		if (cooldown.IsRunning()) {
			sprite.color = ChargingColor;
		} else {
			sprite.color = ReadyColor;
		}

	}

}
