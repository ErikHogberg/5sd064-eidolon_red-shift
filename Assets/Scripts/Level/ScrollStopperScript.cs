using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollStopperScript : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "Boundary") {
			Globals.Ground.GetComponent<GroundMoveScript>().HaltScroll = true;
		}
	}

	private void OnDestroy() {
		var ground = Globals.Ground.GetComponent<GroundMoveScript>();
		if (ground.HaltScroll) {
			ground.HaltScroll = false;
		}
	}
}
