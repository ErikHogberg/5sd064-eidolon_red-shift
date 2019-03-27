using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInitScript : MonoBehaviour {

	public FadeScript FadePanel;

	void Start() {
		Globals.FadePanel = FadePanel;
	}

}
