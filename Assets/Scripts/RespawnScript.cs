using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.Scripts;
using Assets.Scripts.Utilities;

public class RespawnScript : MonoBehaviour {
	private SpriteRenderer spr;

	public GameObject ZombieTypeToSpawn;

	//private float m_Cooldown = 0f;
	public float Cooldown = 0.1f;
	public float Duration = 0.1f;

	public Timer DurationTimer;
	public Timer CooldownTimer;


	void Start() {
		spr = GetComponent<SpriteRenderer>();

		DurationTimer = new Timer(Duration);
		DurationTimer.Stop();

		CooldownTimer = new Timer(Cooldown);
		CooldownTimer.Stop();

	}

	void Update() {

		/*
		if (m_Cooldown > 0f)
		{
			m_Cooldown -= Time.deltaTime;
		} else
		{
			spr.enabled = false;
		}
		 */

		CooldownTimer.Update();

		if (DurationTimer.Update()) {
			spr.enabled = false;
			CooldownTimer.Restart(Cooldown);
		}


		//if (Input.GetKeyDown(KeyCode.Space) && (m_Cooldown == 0f || m_Cooldown < 0f)) {
		if (Input.GetKeyDown(KeyCode.Space) && !CooldownTimer.IsRunning() &&!DurationTimer.IsRunning()) {
			spr.enabled = true;
			//m_Cooldown = Cooldown;
			DurationTimer.Restart(Duration);
		}
	}

	private void OnTriggerStay2D(Collider2D col) {
		if (spr.enabled && col.tag == "Corpse") {
			col.GetComponent<CorpseScript>().SpawnZombie(transform.parent.gameObject.GetComponent<ZombieControlScript>(), ZombieTypeToSpawn);
		}
	}
}
