﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.Scripts;
using Assets.Scripts.Utilities;
using Assets.Scripts.Pickups;

public class PlayerMovementScript : MonoBehaviour {
	private Rigidbody2D rb;
	private Vector3 mousePosition;

	public SpriteRenderer PlayerSprite;
    public GameObject DeadPlayer;

	public float Speed = 400;
	public float DodgeSpeed = 300;
	public float DodgeCooldownTime = .6f;
	public float DodgeDurationTime = .15f;

	private int startHealth;
	public int Health = 100;
	public bool HpRegen = false;
	public int HpRegenCap = 100;
	public float HpRegenRate = 2.0f; // amount restored per second
	private Timer hpRegenTimer;
    public Animator animator;

	private bool lookingRight = true;

	public Timer DodgeCooldown; // time until next dodge
	public Timer DodgeTimer; // time until dodge ends

	private Timer colorTimer;

	public BuffSystem Buffs;
    public bool destroyed = false;

    //mick
    public ParticleSystem Player_Damage;
    //mick

	void Start() {

		Globals.Player = this;

		startHealth = Health;

		rb = GetComponent<Rigidbody2D>();

		hpRegenTimer = new Timer(1.0f / HpRegenRate);

		DodgeCooldown = new Timer(DodgeCooldownTime);
		DodgeCooldown.Stop();
		DodgeTimer = new Timer(DodgeDurationTime);
		DodgeTimer.Stop();

		colorTimer = new Timer(.1f);

		Buffs = new BuffSystem();

        animator = GetComponentInChildren<Animator>();
	}

	private void Update() {

		if (colorTimer.Update()) {
			GetComponentInChildren<SpriteRenderer>().color = Color.white;
		}

		// Update buffs and disable expired buffs
		foreach (Buff expiredBuff in Buffs.Update()) {
			switch (expiredBuff.Type) {
				case BuffType.HpRegen:
					HpRegenRate -= expiredBuff.BuffStrength;
					UpdateRegen();
					break;
				case BuffType.ZombieHpRegen:
					break;
				case BuffType.ZombieSpeedUp:
					break;
				case BuffType.Invulnerability:
					break;
				case BuffType.NoWeaponCooldown:
					break;
				case BuffType.FullAutoWeapon:
					GetComponentInChildren<WeaponScript>().FullAuto = false;
					break;
				case BuffType.DamageIncrease:
					break;
				case BuffType.AoEWeapon:
					break;
				default:
					break;
			}

			string message = "";
			switch (expiredBuff.Type) {
				case BuffType.HpRegen:
					message += "Hp Regeneration";
					break;
				case BuffType.ZombieHpRegen:
					message += "Zombie Hp Regen.";
					break;
				case BuffType.ZombieSpeedUp:
					message += "Zombie Speed Up";
					break;
				case BuffType.Invulnerability:
					message += "Invulnerability";
					break;
				case BuffType.NoWeaponCooldown:
					break;
				case BuffType.FullAutoWeapon:
					message += "Full Auto";
					break;
				case BuffType.DamageIncrease:
					break;
				case BuffType.AoEWeapon:
					break;
				default:
					break;
			}
			message += " buff expired";
			Globals.NotificationWindow.Show(message);

		}

		if (HpRegen && Health < HpRegenCap) {
			if (hpRegenTimer.Update()) {
				//Health += 1;
				int overflows = hpRegenTimer.RestartWithDelta();
				for (int i = 0; i < overflows; i++) {
					Health += 1;
				}
			}
		}

		DodgeCooldown.Update();
		if (Input.GetKeyDown(KeyCode.LeftShift) && !DodgeCooldown.IsRunning() && !DodgeTimer.IsRunning()) {
            if(destroyed)
            {
                return;
            }
            DodgeTimer.Restart(DodgeDurationTime);
		}
	}

	void FixedUpdate() {
        if(destroyed)
        {
            rb.velocity = Vector3.zero;
            return;
        }
        float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector2 movement = new Vector2(moveHorizontal, moveVertical);

		if (DodgeTimer.IsRunning()) {
            animator.SetBool("isDodging", true);
            Vector2 direction = rb.velocity.normalized;
			//rb.velocity = direction * DodgeSpeed * .05f;
			if (DodgeTimer.Update()) {
				DodgeCooldown.Restart(DodgeCooldownTime);
			}
			//return; // NOTE: early return
            rb.velocity = movement * DodgeSpeed * Time.deltaTime;
		} else {
            animator.SetBool("isDodging", false);
            rb.velocity = movement * Speed * Time.deltaTime;
		}

		if (mousePosition.x < transform.position.x && lookingRight) {
			lookingRight = !lookingRight;
			Flip();
		} else if (mousePosition.x > transform.position.x && !lookingRight) {
			lookingRight = !lookingRight;
			Flip();
		}

        if(moveVertical != 0f || moveHorizontal != 0f)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

	void LateUpdate() {
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}

	public void TakeDamage(int damage) {

		// invulnerability frames
		if (DodgeTimer.IsRunning() || destroyed) {
			return;
		}

		GetComponentInChildren<SpriteRenderer>().color = Color.red;
		colorTimer.Restart();

		Health = Health - damage;

        //mick
        if (Player_Damage != null)
        {
        Player_Damage.Play();
        }
        //mick

		if (Health < 0 || Health == 0) {
            //Destroy(gameObject);
            destroyed = true;
			GetComponentInChildren<BatteryBackpackScript>().gameObject.SetActive(false);
            animator.SetTrigger("Dead");
            GetComponentInChildren<WeaponScript>().enabled = false;
            Invoke("Dying", 1);
		}
	}

    void Dying()
    {
        Globals.GameOver();
        gameObject.SetActive(false);
        Instantiate(DeadPlayer, transform.position, transform.rotation);
    }

    public void AddBuff(Buff buff) {
		Buffs.AddBuff(buff);

		switch (buff.Type) {
			case BuffType.HpRegen:
				HpRegenRate += buff.BuffStrength;
				UpdateRegen();
				break;
			case BuffType.ZombieHpRegen:
				break;
			case BuffType.ZombieSpeedUp:
				break;
			case BuffType.Invulnerability:
				DodgeTimer.Restart(buff.Timer.TimeLeft());
				break;
			case BuffType.NoWeaponCooldown:
				break;
			case BuffType.FullAutoWeapon:
				GetComponentInChildren<WeaponScript>().FullAuto = true;
				break;
			case BuffType.DamageIncrease:
				break;
			case BuffType.AoEWeapon:
				break;
			default:
				break;
		}

	}

	private void UpdateRegen() {
		hpRegenTimer.RestartWithDelta(1.0f / HpRegenRate);
	}

	void Flip() {
		//transform.Rotate(0f, 180f, 0f);
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	public float GetHpPercentage() {
		return (float)Health / (float)startHealth;
	}

}
