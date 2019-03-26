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
    public Animator animator;

    public float scaleMin = 0.2f;
    public float scaleMax = 0.3f;
    public float randomScale;

    private float yMax = 2f;
    private float yMin = -2f;
    private float yTarget;
    private GameObject camera;

    private bool lookingRight = false;
	private bool destroyed = false;

    public int ScoreWorth = 10;

	private Timer colorTimer;

	private void Start()
	{
		colorTimer = new Timer(.1f);
		this.enabled = false;
        movementCooldown = 0f;
		gameObject.GetComponentInChildren<EnemyWeaponScript>().enabled = false;
        camera = GameObject.Find("Main Camera");
        yTarget = Random.Range(yMin, yMax);
        randomScale = Random.Range(scaleMin, scaleMax);
        transform.localScale = new Vector3(randomScale, randomScale, randomScale);
    }

	void Update () {

		if (colorTimer.Update(Time.deltaTime)) {
			GetComponent<SpriteRenderer>().color = Color.white;
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

	public void TakeDamage(int damage) {

		if (destroyed) {
			return;
		}

		health -= damage;

		GetComponent<SpriteRenderer>().color = Color.red;
		colorTimer.Restart();

		if (health <= 0) {
			if (lookingRight) {
				Flip();
			}
			var corpse = Instantiate(Corpse, transform.position, transform.rotation);
			corpse.transform.parent = transform.parent;
			Destroy(gameObject);
			destroyed = true;
			Assets.Scripts.Globals.Score += ScoreWorth;
			camera.GetComponent<EnemyRespawn>().EnemyKilled(false);
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
            if(movementCooldown < 0.5f)
            {
                GetComponentInChildren<EnemyWeaponScript>().enabled = true;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, Speed * Time.deltaTime * (1.0f / 60.0f));
            GetComponentInChildren<EnemyWeaponScript>().enabled = false;
        }
    }

    private void MeleeMove()
    {
        if (movementCooldown > 0)
        {
            movementCooldown -= Time.deltaTime;
			if (animator != null) {
				animator.SetBool("isMoving", false);
			}
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, GameObject.FindWithTag("Player").transform.position, Speed*Time.deltaTime*(1.0f/60.0f));
			if (animator != null) {
				animator.SetBool("isMoving", true);
			}
			if (!colorTimer.IsRunning()) {
				GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
			}
        }
    }

    private void OnBecameVisible()
	{
        this.enabled = true;
		gameObject.GetComponentInChildren<EnemyWeaponScript>().enabled = true;
	}

	private void OnBecameInvisible()
	{
        if (gameObject.activeInHierarchy == true && gameObject.transform.position.x < camera.transform.position.x)
        {
            Destroy(gameObject);
            camera.GetComponent<EnemyRespawn>().EnemyKilled(true);
        }

        this.enabled = false;
        gameObject.GetComponentInChildren<EnemyWeaponScript>().enabled = false;
	}
}
