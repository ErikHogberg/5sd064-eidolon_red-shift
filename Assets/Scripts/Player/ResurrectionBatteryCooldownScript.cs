using Assets.Scripts;
using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResurrectionBatteryCooldownScript : MonoBehaviour {

	public Color ReadyColor;
	public Color ChargingColor;

	private Timer cooldown;

	private SpriteRenderer sprite;

	void Start() {
		sprite = GetComponent<SpriteRenderer>();
	}

	void Update() {
		if (cooldown == null) {
			cooldown = Globals.Player.GetComponentInChildren<RespawnScript>().CooldownTimer;
		}
		if (cooldown == null) {
			sprite.color = ReadyColor;
			//sprite.color = new Color(0.0f,0.0f,0.0f,0.0f);
			return;
		}

		if (cooldown.IsRunning()) {
			sprite.color = ChargingColor;
		} else {
			sprite.color = ReadyColor;
		}

	}

}
