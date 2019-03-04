﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    Archer,
    Knight,
    Peasant,
}

public class EnemyScript : MonoBehaviour {

	public int health = 100;
	public GameObject Corpse;
    public float Speed = 0.05f;
    public Type EnemyType;
    public float movementCooldown = 1f;

    private float yMax = 2f;
    private float yMin = -2f;
    private float yTarget;

    private bool lookingRight = false;

    public int ScoreWorth = 10;

	private void Start()
	{
        this.enabled = false;
        movementCooldown = 0f;
		gameObject.GetComponentInChildren<EnemyWeaponScript>().enabled = false;
        yTarget = Random.Range(yMin, yMax);
    }

	void Update () {
		if(health < 0 || health == 0)
		{
			var corpse = Instantiate(Corpse, transform.position, transform.rotation);
			corpse.transform.parent = transform.parent;
			Destroy(gameObject);
			Assets.Scripts.Globals.Score += ScoreWorth;
		}

        switch(EnemyType)
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

        if (GameObject.FindWithTag("Player").transform.position.x < transform.position.x && lookingRight)
        {
            lookingRight = !lookingRight;
            Flip();
        }
        else if (GameObject.FindWithTag("Player").transform.position.x > transform.position.x && !lookingRight)
        {
            lookingRight = !lookingRight;
            Flip();
        }
    }

    private void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }

    private void RangeMove()
    { 
        Vector3 destination = new Vector3(transform.position.x, yTarget, transform.position.z);
        if(transform.position == destination)
        {
            yTarget = Random.Range(yMin, yMax);
            destination = new Vector3(transform.position.x, yTarget, transform.position.z);
            movementCooldown = 1f;
        }

        if(movementCooldown > 0)
        {
            movementCooldown -= Time.deltaTime;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, Speed);
        }
    }

    private void MeleeMove()
    {
        if (movementCooldown > 0)
        {
            movementCooldown -= Time.deltaTime;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Player").transform.position, Speed);
            GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
    }

    private void OnBecameVisible()
	{
		this.enabled = true;
		gameObject.GetComponentInChildren<EnemyWeaponScript>().enabled = true;
	}

	private void OnBecameInvisible()
	{
		this.enabled = false;
		gameObject.GetComponentInChildren<EnemyWeaponScript>().enabled = false;
	}
}
