using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSceneTriggerScript : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "Boundary") {
			GetComponent<SpriteRenderer>().color = Color.red;
		}
	}

	private void OnTriggerExit2D(Collider2D collision) {
		if (collision.tag == "Boundary") {
			GetComponent<SpriteRenderer>().color = Color.white;
		}

	}

}
