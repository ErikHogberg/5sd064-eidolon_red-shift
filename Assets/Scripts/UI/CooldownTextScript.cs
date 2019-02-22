using Assets.Scripts;
using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownTextScript : TextScript {
	public int CooldownIndex;

	private Timer cooldown;

	//private void Start() {
		//cooldown = Globals.Player.GetComponentInChildren<WeaponScript>().AttackTimers[CooldownIndex];
	//}

	void Update() {
		if (cooldown == null) {
			cooldown = Globals.Player.GetComponentInChildren<WeaponScript>().AttackTimers[CooldownIndex];
		}
		UpdateValue(cooldown.TimeLeft());

	}
}
