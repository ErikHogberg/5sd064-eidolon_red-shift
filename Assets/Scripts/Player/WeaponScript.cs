using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.Scripts.Utilities;

public class WeaponScript : MonoBehaviour {

	public Transform firePoint;
	public GameObject bulletPrefab;
	//private float m_Cooldown = 0f;
	public float Cooldown = 0.1f;

	public List<Timer> AttackTimers;

	//private PlayerMovement player;

	private void Start() {
		//player = GetComponentInParent<PlayerMovement>();
		AttackTimers = new List<Timer> {
			new Timer(Cooldown),
			new Timer(Cooldown),
			new Timer(Cooldown),
		};

		foreach (var timer in AttackTimers) {
			timer.Stop();
		}
	}


	void Update() {

		foreach (var timer in AttackTimers) {
			timer.Update();
		}

		//if (m_Cooldown > 0f) {
		//	m_Cooldown -= Time.deltaTime;
		//}
		//if (Input.GetMouseButtonDown(0) && (m_Cooldown == 0f || m_Cooldown < 0f)) 
		//{
		//Shoot();
		//m_Cooldown = Cooldown;
		//}
		if (Input.GetMouseButtonDown(0)) {
			foreach (var timer in AttackTimers) {
				if (!timer.IsRunning()) {
					Shoot();
					timer.Restart(Cooldown);
					break;
				}
			}
		}
	}

	void Shoot() {
		Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		firePoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		bullet.transform.parent = transform.parent.parent;
	}
}
