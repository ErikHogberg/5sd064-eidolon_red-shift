using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour {
	public int Health = 100;
	private int startHealth;
	public bool Invulnerable = false;
	public bool dead = false;

	public float Speed = 0.05f;

	public Type BossType;
	public EnemyWeaponScript Weapon;

	public BossScript King;
	public EnemyRespawn Respawn;
	public ScrollStopperScript Stopper;
    private Animator animator;

    public float movementCooldown = 1f;

	private float randomY;
	private float randomX;

	public GameObject Border;
	/*
	public Transform UpperGroundBorder;
	public Transform LowerGroundBorder;
	public Transform LeftBorder;
	public Transform RightBorder;
	 */

	private bool lookingRight = false;

	public int ScoreWorth = 1000;

	private Timer colorTimer;

	public ParticleSystem FireFront;
	public ParticleSystem FireBack;
	public ParticleSystem Smoke;

	private void Start() {
		colorTimer = new Timer(.1f);
		movementCooldown = 0f;
		//GetComponentInChildren<EnemyWeaponScript>().gameObject.SetActive(false);
		Weapon.gameObject.SetActive(false);
		RandomPosition();
		Border.transform.SetParent(transform.parent);
		startHealth = Health;

		if (BossType == Type.Queen) {
			Invulnerable = true;
			Weapon.gameObject.SetActive(true);

		}

        animator = GetComponent<Animator>();
    }

	void RandomPosition() {
		RectTransform border = Border.GetComponent<RectTransform>();

		//randomY = Random.Range(LowerGroundBorder.position.y, UpperGroundBorder.position.x);
		randomY = border.anchoredPosition.y + Random.Range(-border.rect.height*0.5f, border.rect.height * 0.5f);
		//randomX = Random.Range(LeftBorder.position.x, RightBorder.position.x);
		randomX = border.anchoredPosition.x + Random.Range(-border.rect.width * 0.5f, border.rect.width * 0.5f);
	}

	void Update() {

		if (dead) {
			return;
		}

		GameObject player = GameObject.FindWithTag("Player");
		if (player == null) {
			return;
		}

		if (colorTimer.Update(Time.deltaTime)) {
			GetComponent<SpriteRenderer>().color = Color.white;
		}

		switch (BossType) {
			case Type.King:
				RangeMove();
				break;
			case Type.Queen:
				if (King.dead) {
					Invulnerable = false;
				}
				MeleeMove();
				break;
			default:
				break;
		}

		if (player.transform.position.x < transform.position.x && lookingRight) {
			lookingRight = !lookingRight;
			Flip();
		} else if (player.transform.position.x > transform.position.x && !lookingRight) {
			lookingRight = !lookingRight;
			Flip();
		}
	}

	public void TakeDamage(int damage) {

		if (Invulnerable) {
			GetComponent<SpriteRenderer>().color = Color.cyan;
			colorTimer.Restart();
			return;
		}

		Health -= damage;

		GetComponent<SpriteRenderer>().color = Color.red;
		colorTimer.Restart();

		if (Health <= 0) {
			//if (lookingRight)
			//{
			//    Flip();
			//}
			//Destroy(gameObject);
			GetComponent<SpriteRenderer>().color = Color.gray;

			FireBack.gameObject.SetActive(true);
			FireFront.gameObject.SetActive(true);
			Smoke.gameObject.SetActive(true);

			if (BossType == Type.Queen) {
				Respawn.gameObject.SetActive(false);
				if (Stopper != null) {
					Destroy(Stopper.gameObject);
				}
			}

			Weapon.gameObject.SetActive(false);

			dead = true;
            animator.SetTrigger("Dead");

			Assets.Scripts.Globals.Score += ScoreWorth;
		}

	}

	private void Flip() {
		transform.Rotate(0f, 180f, 0f);
	}

	private void RangeMove() {
		Vector3 destination = new Vector3(randomX, randomY, transform.localPosition.z);
		if (transform.localPosition == destination) {
			RandomPosition();
			destination = new Vector3(randomX, randomY, transform.localPosition.z);
			movementCooldown = 1f;
		}

		if (movementCooldown > 0) {
            animator.SetBool("isMoving", false);
			movementCooldown -= Time.deltaTime;
			if (movementCooldown < 0.5f) {
				//GetComponentInChildren<EnemyWeaponScript>().gameObject.SetActive(true);
				Weapon.gameObject.SetActive(true);
			}
		} else {
            animator.SetBool("isMoving", true);
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, destination, Speed);
			//GetComponentInChildren<EnemyWeaponScript>().gameObject.SetActive(false);
			Weapon.gameObject.SetActive(false);
		}
	}

	private void MeleeMove() {
		if (movementCooldown > 0) {
			movementCooldown -= Time.deltaTime;
            if(animator)
            {
                animator.SetBool("isMoving", false);
            }
        } else {
			transform.localPosition = Vector3.MoveTowards(
				transform.localPosition,
				GameObject.FindWithTag("Player").transform.localPosition, Speed * Time.deltaTime * 60.0f
			);
			if (!colorTimer.IsRunning()) {
				GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
			}
            if(animator)
            {
                animator.SetBool("isMoving", true);
            }
        }
	}

	public float GetHpPercentage() {
		return (float) Health / startHealth;
	}

}
