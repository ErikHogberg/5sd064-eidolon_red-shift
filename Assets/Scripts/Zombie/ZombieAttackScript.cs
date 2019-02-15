using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.Scripts.Utilities;

public class ZombieAttackScript : MonoBehaviour {

	private bool attacking = false;

	private Timer attackTimer;
	private Timer colorTimer;

	// Start is called before the first frame update
	void Start() {
		attackTimer = new Timer(1);
		colorTimer = new Timer();
	}

	// Update is called once per frame
	void Update() {
		if (attacking) {
			if (attackTimer.Update(Time.deltaTime)) {
				attackTimer.Restart(1);
				transform.parent.GetComponent<SpriteRenderer>().color = Color.green;
				colorTimer.Restart(.2f);
			} else {
				//transform.parent.GetComponent<SpriteRenderer>().color = Color.white;
			}
		}

		if (colorTimer.Update(Time.deltaTime)) {
			transform.parent.GetComponent<SpriteRenderer>().color = Color.white;
		}
	}

	private void OnTriggerStay2D(Collider2D collision) {

		if (collision.tag == "Enemy") {
			// attacking set in stay instead of enter just in case zombie overlaps with 2 or more enemies
			attacking = true;
			//Debug.Log("Zombie in range");
		}

	}

	private void OnTriggerExit2D(Collider2D collision) {

		if (collision.tag == "Enemy") {
			attacking = false;
		}

	}
}
