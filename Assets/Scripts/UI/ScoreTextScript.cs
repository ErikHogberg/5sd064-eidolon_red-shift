using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Assets.Scripts;

public class ScoreTextScript : TextScript {

	void Update() {
		UpdateValue(Globals.Score);
	}
}
