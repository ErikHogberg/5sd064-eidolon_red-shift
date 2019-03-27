using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public int health = 100;
    public float Speed = 0.05f;
    public Type BossType;
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

    public int ScoreWorth = 10;

    private Timer colorTimer;

    private void Start()
    {
        colorTimer = new Timer(.1f);
        movementCooldown = 0f;
        gameObject.GetComponentInChildren<EnemyWeaponScript>().enabled = false;
        RandomPosition();
		Border.transform.SetParent(transform.parent);
    }

    void RandomPosition()
    {
		Rect border = Border.GetComponent<RectTransform>().rect;

		//randomY = Random.Range(LowerGroundBorder.position.y, UpperGroundBorder.position.x);
		randomY = border.y + Random.Range(0, border.height);
		//randomX = Random.Range(LeftBorder.position.x, RightBorder.position.x);
		randomX = border.x + Random.Range(0, border.width);
	}
	void Update()
    {
		GameObject player = GameObject.FindWithTag("Player");
		if (player == null) {
			return;
		}


		if (colorTimer.Update(Time.deltaTime))
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }

        switch (BossType)
        {
            case Type.King:
                RangeMove();
                break;
            case Type.Queen:
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

    public void TakeDamage(int damage)
    {

        health -= damage;

        GetComponent<SpriteRenderer>().color = Color.red;
        colorTimer.Restart();

        if (health <= 0)
        {
            if (lookingRight)
            {
                Flip();
            }
            //Destroy(gameObject);
            Assets.Scripts.Globals.Score += ScoreWorth;
        }

    }

    private void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }

    private void RangeMove()
    {
        Vector3 destination = new Vector3(randomX, randomY, transform.position.z);
        if (transform.position == destination)
        {
            RandomPosition();
            destination = new Vector3(randomX, randomY, transform.position.z);
            movementCooldown = 1f;
        }

        if (movementCooldown > 0)
        {
            movementCooldown -= Time.deltaTime;
            if (movementCooldown < 0.5f)
            {
                GetComponentInChildren<EnemyWeaponScript>().enabled = true;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, Speed);
            GetComponentInChildren<EnemyWeaponScript>().enabled = false;
        }
    }

    private void MeleeMove()
    {
		if (movementCooldown > 0) {
			movementCooldown -= Time.deltaTime;
			//if (animator != null) {
			//	animator.SetBool("isMoving", false);
			//}
		} else {
			transform.position = Vector3.MoveTowards(
				transform.position,
				GameObject.FindWithTag("Player").transform.position, Speed * Time.deltaTime * 60.0f
			);

			//if (animator != null) {
			//	animator.SetBool("isMoving", true);
			//}
			if (!colorTimer.IsRunning()) {
				GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
			}
		}
	}
}
