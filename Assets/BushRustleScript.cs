using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushRustleScript : MonoBehaviour {

	private ParticleSystem ps;
	//private BoxCollider2D col;

	void Start() {
		ps = GetComponent<ParticleSystem>();
		//col = GetComponent<BoxCollider2D>();
	}

	void Update() {

	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (!ps.isEmitting) {
			ps.Play();
		}
	}

}
