using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.Scripts.Utilities;

public class WeaponScript : MonoBehaviour {

	// TODO: bullet scale
	// IDEA: grow bullet the longer its in air

	public Transform firePoint;
	public GameObject bulletPrefab;
	//private float m_Cooldown = 0f;
	public float Cooldown = 0.8f;
	public float MinBulletInterval = 0.1f;
	public bool FullAuto = false;

	public int StartBatteryCount = 1;
	public List<Timer> AttackTimers;
	private Timer MinBulletIntervalTimer;

	//private PlayerMovement player;

	private void Start() {
		//player = GetComponentInParent<PlayerMovement>();
		AttackTimers = new List<Timer>()// {
			//new Timer(Cooldown),
			//new Timer(Cooldown),
			//new Timer(Cooldown),
		//}
		;
		int i = 0;
		while (i < StartBatteryCount) {
			AddCooldownTimer();
			i++;
		}

		MinBulletIntervalTimer = new Timer(MinBulletInterval);
		MinBulletIntervalTimer.Stop();

		foreach (var timer in AttackTimers) {
			timer.Stop();
		}
	}


	void Update() {

		foreach (var timer in AttackTimers) {
			timer.Update();
		}
		MinBulletIntervalTimer.Update();
		if (FullAuto) {
			if (Input.GetMouseButton(0) && !MinBulletIntervalTimer.IsRunning()) {
				TryShoot();
			}
		} else {
			if (Input.GetMouseButtonDown(0) && !MinBulletIntervalTimer.IsRunning()) {
				TryShoot();
			}
		}
	}

	private void TryShoot() {
		foreach (var timer in AttackTimers) {
			if (!timer.IsRunning()) {
				Shoot();
				timer.Restart(Cooldown);
				break;
			}
		}
	}

	public void AddCooldownTimer() {
		Timer attackTimer = new Timer(Cooldown);
		AttackTimers.Add(attackTimer);
		attackTimer.Stop();

		transform.parent.GetComponentInChildren<BatteryBackpackScript>().SetActiveBatteries(AttackTimers.Count-1);
	}

	void Shoot() {
		Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		firePoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		bullet.transform.parent = transform.parent.parent;
		MinBulletIntervalTimer.RestartWithDelta(MinBulletInterval);
	}
}
