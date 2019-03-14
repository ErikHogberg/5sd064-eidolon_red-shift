using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollStopperDisableTriggerScript : MonoBehaviour
{

	public ScrollStopperScript ScrollStopper;

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "Player") {
			Destroy(ScrollStopper.gameObject);
			Destroy(gameObject);
		}
	}

}
