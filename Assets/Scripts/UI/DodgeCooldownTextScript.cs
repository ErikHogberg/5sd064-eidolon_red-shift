using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Assets.Scripts;

public class DodgeCooldownTextScript : TextScript {

	public Color ReadyColor = Color.green;
	public Color ChargingColor = Color.red;

	private Image panel;

	private new void Start() {
		panel = GetComponentInParent<Image>();
		base.Start();
	}

	void Update() {
		if (Globals.Player.DodgeCooldown.IsRunning()) {
			panel.color = ChargingColor;
		} else {
			panel.color = ReadyColor;
		}

		UpdateValue(Globals.Player.DodgeCooldown.TimeLeft());
	}

}
