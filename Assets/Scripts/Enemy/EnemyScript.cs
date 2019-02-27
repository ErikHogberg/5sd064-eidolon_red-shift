using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public int health = 100;
	public GameObject Corpse;
    public float Speed = 0.01f;

    private float yMax = 2f;
    private float yMin = -2f;
    private float yTarget;
    private bool arrived = false;

	public int ScoreWorth = 10;

	private void Start()
	{
        this.enabled = false;
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

        AIMove();
    }

    private void AIMove()
    {
        Vector3 destination = new Vector3(transform.position.x, yTarget, transform.position.z);
        if(transform.position == destination)
        {
            yTarget = Random.Range(yMin, yMax);
            destination = new Vector3(transform.position.x, yTarget, transform.position.z);
        }
        transform.position = Vector3.MoveTowards(transform.position, destination, Speed);
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
