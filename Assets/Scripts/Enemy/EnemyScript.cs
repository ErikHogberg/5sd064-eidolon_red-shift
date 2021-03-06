﻿using Assets.Scripts;
using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    Archer,
    Knight,
    Peasant,
    King,
    Queen,
}

public class EnemyScript : MonoBehaviour {

	public int health = 100;
	public GameObject Corpse;
    public float Speed = 0.05f;
    public Type EnemyType;
    public float movementCooldown = 1f;
    private Animator animator;

	public EnemyRespawn Respawn;

    public float scaleMin = 0.2f;
    public float scaleMax = 0.3f;
    public float randomScale;

    //private float yMax = 2f;
    //private float yMin = -2f;
    private float yTarget;
	private bool yTargetInit = false;
	//private GameObject camera;
    private bool lookingRight = false;
	//private bool dying = false;
	private bool destroyed = false;
    private float LastUpperBorderPosition;

    public int ScoreWorth = 10;

	private Timer colorTimer;

	private bool moveToPos = false;
	private Vector3 moveTarget;

    //Mick
    public AudioSource Dying;
    public ParticleSystem Damaged_FX;
    public ParticleSystem Magic_Damage;
    //public AudioSource Damage_Sound;
    //Mick

	private void Start()
	{
		colorTimer = new Timer(.1f);
		this.enabled = false;
        movementCooldown = 0f;
		gameObject.GetComponentInChildren<EnemyWeaponScript>().enabled = false;
        //camera = GameObject.Find("Main Camera");
		//yTarget = Random.Range(yMin, yMax);
		//yTarget = CalcRandomY();

		if (Respawn == null) {
			//Respawn = camera.GetComponent<EnemyRespawn>();
			Respawn = GameObject.Find("Main Camera").GetComponent<EnemyRespawn>();
		}


		randomScale = Random.Range(scaleMin, scaleMax);
        transform.localScale = new Vector3(randomScale, randomScale, randomScale);
        animator = GetComponent<Animator>();
        LastUpperBorderPosition = Globals.UpperBoundary.transform.position.y;
    }

	void Update () {

        if (LastUpperBorderPosition < Globals.UpperBoundary.transform.position.y)
        {
            yTarget = yTarget + (Globals.UpperBoundary.transform.position.y - LastUpperBorderPosition);
            LastUpperBorderPosition = Globals.UpperBoundary.transform.position.y;
        }
        else if (LastUpperBorderPosition > Globals.UpperBoundary.transform.position.y)
        {
            yTarget = yTarget - (LastUpperBorderPosition - Globals.UpperBoundary.transform.position.y);
            LastUpperBorderPosition = Globals.UpperBoundary.transform.position.y;
        }

        if (colorTimer.Update(Time.deltaTime)) {
			GetComponent<SpriteRenderer>().color = Color.white;
		}

		GameObject player = GameObject.FindWithTag("Player");
		if (player == null || destroyed) {
			return;
		}

		switch (EnemyType)
        {
            case Type.Archer:
                RangeMove();
                break;
            case Type.Knight:
                MeleeMove();
                break;
            case Type.Peasant:
                MeleeMove();
                break;
            default:
                break;
        }

        if (player.transform.position.x < transform.position.x && lookingRight)
        {
            lookingRight = !lookingRight;
            Flip();
        }
        else if (player.transform.position.x > transform.position.x && !lookingRight)
        {
            lookingRight = !lookingRight;
            Flip();
        }
    }

	public void TakeDamage(int damage) {

		if (destroyed) {
			return;
		}

		health -= damage;

		GetComponent<SpriteRenderer>().color = Color.red;
		colorTimer.Restart();

        //Mick
        if (Damaged_FX != null)
        {
            Damaged_FX.Play();
        }
        if (Magic_Damage != null)
        {
            Magic_Damage.Play();
        }
        //if (Damage_Sound != null)
        //{
        //Damage_Sound.Play();
        //}
        //Mick
		if (health <= 0) {
            gameObject.GetComponentInChildren<EnemyWeaponScript>().enabled = false;
            destroyed = true;
			GetComponentInChildren<EnemyWeaponScript>().gameObject.SetActive(false);
			animator.SetTrigger("Dead");
            //Mick
            if (Dying != null)
            {
            Dying.Play();
            }
            //Mick
            Invoke("Dead", 1);
		}
	}

    private void Dead()
    {
        var corpse = Instantiate(Corpse, transform.position, transform.rotation);
		corpse.GetComponent<CorpseScript>().LookingRight = lookingRight;
        corpse.transform.parent = transform.parent;
        Destroy(gameObject);
        Globals.Score += ScoreWorth;
		Respawn.EnemyKilled(false);
    }

	private void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }

    private void RangeMove()
    { 
        if(destroyed)
        {
            return;
        }

		if (moveToPos) {
			Vector3.MoveTowards(
				transform.position,
				moveTarget, Speed * Time.deltaTime * 60.0f
				);
		}

		if (!yTargetInit) {
			yTarget = CalcRandomY();
			yTargetInit = true;
		}
		Vector3 destination = new Vector3(transform.position.x, yTarget, transform.position.z);
        if (transform.position == destination)
        {
			//yTarget = Random.Range(yMin, yMax);
			yTarget = CalcRandomY();

			destination = new Vector3(transform.position.x, yTarget, transform.position.z);
            movementCooldown = 1f;
        }

        if(movementCooldown > 0)
        {
            animator.SetBool("isMoving", false);
            movementCooldown -= Time.deltaTime;
            if(movementCooldown < 0.5f)
            {
                GetComponentInChildren<EnemyWeaponScript>().enabled = true;
            }
        }
        else
        {
            animator.SetBool("isMoving", true);
            transform.position = Vector3.MoveTowards(transform.position, destination, Speed * Time.deltaTime * 60.0f);
            GetComponentInChildren<EnemyWeaponScript>().enabled = false;
        }
    }

	private float CalcRandomY() {
		return Random.Range(
				Globals.LowerBoundary.transform.position.y,// + Globals.LowerBoundary.size.y * 0.5f,
				Globals.UpperBoundary.transform.position.y// - Globals.UpperBoundary.size.y * 0.5f
			);
	}

    private void MeleeMove()
    {
        if(destroyed)
        {
            return;
        }
        if (movementCooldown > 0)
        {
            movementCooldown -= Time.deltaTime;
			if (animator != null) {
				animator.SetBool("isMoving", false);
			}
        }
        else
        {
            transform.position = Vector3.MoveTowards(
				transform.position, 
				GameObject.FindWithTag("Player").transform.position, Speed * Time.deltaTime * 60.0f
				);

			if (animator != null) {
				animator.SetBool("isMoving", true);
			}
			if (!colorTimer.IsRunning()) {
				GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
			}
        }
    }

	public void MoveTo(Vector3 position) {
		moveToPos = true;
		moveTarget = position;
		
	}

    private void OnBecameVisible()
	{
        this.enabled = true;
		gameObject.GetComponentInChildren<EnemyWeaponScript>().enabled = true;
	}

	private void OnBecameInvisible()
	{
        if (gameObject.activeInHierarchy == true && gameObject.transform.position.x < GameObject.Find("Main Camera").transform.position.x)
        {
            Destroy(gameObject);
            Respawn.EnemyKilled(true);
        }

		gameObject.SetActive(false);
		var weapon = GetComponentInChildren<EnemyWeaponScript>();
		if (weapon != null) {
			weapon.gameObject.SetActive(false);
		}
		
	}
}
