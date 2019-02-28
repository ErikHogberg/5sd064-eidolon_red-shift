using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Assets.Scripts;

public class HealthTextScript : TextScript {

	void Update() {
		UpdateValue(Globals.Player.Health);
	}
}
