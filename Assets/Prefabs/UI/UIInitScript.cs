using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInitScript : MonoBehaviour {

	public FadeScript FadePanel;

	public bool KeepMenuMusic = false;

	void Start() {
		Globals.FadePanel = FadePanel;

		if (!KeepMenuMusic) {
			// Stop menu music
			Destroy(Globals.PeristentMusic);
		}
	}

}
