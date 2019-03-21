using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	public float Speed = 25f;
	public int Damage = 20;
	private Rigidbody2D rb;

	bool destroyed = false;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = transform.right * Speed;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.CompareTag("Enemy")) {
			collider.GetComponent<EnemyScript>().TakeDamage(Damage);
			DestroyBullet();
		}
	}
	void OnBecameInvisible() {
		DestroyBullet();
	}

	private void DestroyBullet() {
		if (destroyed) {
			return;
		}
		destroyed = true;
		ParticleSystem particleSystem = GetComponentInChildren<ParticleSystem>();
		particleSystem.Stop();

		Vector3 particleScale = particleSystem.transform.localScale;
		Vector3 bulletScale = transform.localScale;

		particleScale.x /= bulletScale.x;
		particleScale.y /= bulletScale.y;

		particleSystem.transform.localScale = particleScale;
		particleSystem.transform.parent = transform.parent;

		Destroy(gameObject);
	}
}

