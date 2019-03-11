using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.Scripts;
using Assets.Scripts.Utilities;

public class RespawnScript : MonoBehaviour {
	private SpriteRenderer spr;

	public GameObject ZombieTypeToSpawn;

    //Mick's addition starts here
    public ParticleSystem ResEffect;
    //Mick's addition ends here

	//private float m_Cooldown = 0f;
	public float Cooldown = 0.1f;
	public float Duration = 0.1f;

	public Timer DurationTimer;
	public Timer CooldownTimer;


	void Start() {
		spr = GetComponent<SpriteRenderer>();
		spr.enabled = false;

		DurationTimer = new Timer(Duration);
		DurationTimer.Stop();

		CooldownTimer = new Timer(Cooldown);
		CooldownTimer.Stop();

        //Mick's addition starts here
        ResEffect = transform.Find("quickres").gameObject.GetComponent<ParticleSystem>();
        //Mick's addition ends here
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
		if (spr == null) {
			return;
		}
		if (spr.enabled && col.tag == "Corpse") {
			CorpseScript corpseScript = col.GetComponent<CorpseScript>();
			ZombieControlScript zombieControlScript = transform.parent.gameObject.GetComponent<ZombieControlScript>();

            //Mick's addition starts here
            ResEffect.Play();
            //Mick's addition ends here

            corpseScript.SpawnZombie(zombieControlScript);
		}
	}
}
