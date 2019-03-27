using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEnableTriggerScript : MonoBehaviour {

	public List<GameObject> ObjectsToEnable;

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "Player") {

			foreach (GameObject ObjectToEnable in ObjectsToEnable) {
				ObjectToEnable.SetActive(true);
			}

			Destroy(gameObject);
		}
	}


}
