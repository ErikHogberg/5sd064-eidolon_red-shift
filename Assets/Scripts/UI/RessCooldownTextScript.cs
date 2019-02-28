using Assets.Scripts;
using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RessCooldownTextScript : TextScript
{

	public Color ReadyColor = Color.green;
	public Color ChargingColor = Color.red;

	private Timer cooldown;

	private Image panel;

	private new void Start() {
		panel = GetComponentInParent<Image>();
		base.Start();
	}

	void Update() {
		if (cooldown == null) {
			cooldown = Globals.Player.GetComponentInChildren<RespawnScript>().CooldownTimer;
		}

		if (cooldown.IsRunning()) {
			panel.color = ChargingColor;
		} else {
			panel.color = ReadyColor;
		}

		UpdateValue(cooldown.TimeLeft());
	}
}
