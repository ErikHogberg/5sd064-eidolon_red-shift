using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.Scripts.Utilities;

public class WeaponScript : MonoBehaviour {

	// TODO: bullet scale
	// IDEA: grow bullet the longer its in air

	//Mick's edit start
	public AudioSource Bullet;
	//Mick's edit end

	public Transform firePoint;
	public GameObject bulletPrefab;
	//private float m_Cooldown = 0f;
	public float Cooldown = 0.8f;
	public float MinBulletInterval = 0.1f;
	public bool FullAuto = false;
	public float BulletSpread = 5.0f;
	public bool EnableSpreadShot = true;

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
			if (Input.GetMouseButton(0)) {
				TryShoot();
			}
		} else {
			if (Input.GetMouseButtonDown(0)) {
				TryShoot();
			}
		}
		if (EnableSpreadShot) {
			if (FullAuto) {
				if (Input.GetMouseButton(2)) {
					SpreadShot();
				}
			} else {
				if (Input.GetMouseButtonDown(2)) {
					SpreadShot();
				}
			}
		}
	}

	private void TryShoot() {
		if (MinBulletIntervalTimer.IsRunning()) {
			return;
		}
		foreach (var timer in AttackTimers) {
			if (!timer.IsRunning()) {
				Shoot();
				timer.Restart(Cooldown);
				break;
			}
		}
	}

	private void SpreadShot() {
		if (MinBulletIntervalTimer.IsRunning()) {
			return;
		}

		int firedShots = 0;
		foreach (var timer in AttackTimers) {
			if (!timer.IsRunning()) {
				int flip = 1;
				if (firedShots % 2 == 1) {
					flip = -1;
				}
				int spreadMultiplier = firedShots / 2 + firedShots % 2;

				Shoot(spreadMultiplier * BulletSpread * flip);
				firedShots++;
				timer.Restart(Cooldown);

				//Mick's edit start
				Bullet.Play();
				//Mick's edit end
			}
		}
	}

	public void AddCooldownTimer() {
		Timer attackTimer = new Timer(Cooldown);
		AttackTimers.Add(attackTimer);
		attackTimer.Stop();

		transform.parent.GetComponentInChildren<BatteryBackpackScript>().SetActiveBatteries(AttackTimers.Count - 1);
	}

	void Shoot() {
		Shoot(0.0f);

		//Mick's edit start
		Bullet.Play();
		//Mick's edit end
	}

	void Shoot(float offsetAngle) {
		Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + offsetAngle;
		firePoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		//bullet.transform.parent = transform.parent.parent.parent;
		bullet.transform.parent = Assets.Scripts.Globals.Ground.transform;

		MinBulletIntervalTimer.RestartWithDelta(MinBulletInterval);
	}
}
