using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Assets.Scripts;

public class HealthTextScript : TextScript {

	// Update is called once per frame
	void Update() {
		UpdateValue(Globals.Player.Health);
	}
}
