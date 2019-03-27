using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEnableTriggerScript : MonoBehaviour {

	public GameObject ObjectToEnable;

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "Player") {
			ObjectToEnable.SetActive(true);
			Destroy(gameObject);
		}
	}


}
