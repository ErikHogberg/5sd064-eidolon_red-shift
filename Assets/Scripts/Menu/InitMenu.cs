using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class InitMenu : MonoBehaviour {

	public FadeScript FadePanel;

	private void Start() {
		Assets.Scripts.Globals.FadePanel = FadePanel;
	}

}
