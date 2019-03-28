using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.Scripts.Utilities;

public class ZombieAttackScript : MonoBehaviour {

	// TODO: move to zombie behaviour script? or control script in player?
	public int Damage = 35;
	public ZombieBehaviourScript ZombieScript;

	private bool attacking = false;

	private Timer attackTimer;
	private Timer colorTimer;
	public Color AttackColor = Color.green;

	private BoxCollider2D attackCollider;

	// Start is called before the first frame update
	void Start() {
		attackTimer = new Timer(1);
		colorTimer = new Timer(.2f);

		attackCollider = GetComponent<BoxCollider2D>();
	}

	// Update is called once per frame
	void Update() {
		if (attacking) {
			if (attackTimer.Update(Time.deltaTime)) {
				// attack

				Collider2D[] colliding = new Collider2D[10];
				attackCollider.OverlapCollider(new ContactFilter2D(), colliding);
				foreach (Collider2D item in colliding) {
					if (item == null || item.tag != "Enemy") {
						continue;
					}

					var enemy = item.GetComponent<EnemyScript>();
					if (enemy != null) {
						enemy.TakeDamage(Damage);
					}

				}

				attackTimer.Restart();
				transform.parent.GetComponent<SpriteRenderer>().color = AttackColor;
                GetComponentInParent<Animator>().SetTrigger("Attack");
                colorTimer.Restart();
			} 
		}

		if (colorTimer.Update(Time.deltaTime)) {
			transform.parent.GetComponent<SpriteRenderer>().color = Color.white;
		}
		attacking = false;
	}

	private void OnTriggerStay2D(Collider2D collision) {

		ZombieScript.AttackAreaTriggerStay(collision);

		if (collision.tag == "Enemy") {
			attacking = true;
		}

	}

	/*
	private void OnTriggerExit2D(Collider2D collision) {

		ZombieScript.AttackAreaTriggerExit(collision);

		if (collision.tag == "Enemy") {
			attacking = false;
		}

	}
	 */
}
