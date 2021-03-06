﻿using Assets.Scripts;
using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeBatteryCooldownScript : MonoBehaviour {

	public Color ReadyColor;
	public Color ChargingColor;

	private Timer cooldown;

	private SpriteRenderer sprite;

	void Start() {
		sprite = GetComponent<SpriteRenderer>();
	}

	void Update() {
		if (cooldown == null) {
			cooldown = Globals.Player.DodgeCooldown;
		}
		if (cooldown == null) {
			sprite.color = ReadyColor;
			return;
		}

		if (cooldown.IsRunning()) {
			sprite.color = ChargingColor;
		} else {
			sprite.color = ReadyColor;
		}

	}

}
