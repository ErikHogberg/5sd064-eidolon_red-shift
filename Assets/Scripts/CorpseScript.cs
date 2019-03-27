using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseScript : MonoBehaviour {
	public GameObject Zombie;

	public bool LookingRight = false;

	public void SpawnZombie(ZombieControlScript player) {
		if (LookingRight) {
			transform.Rotate(0f, 180f, 0f);
		}
		var zombie = Instantiate(Zombie, transform.position, transform.rotation);
		zombie.transform.parent = transform.parent;
		Destroy(gameObject);
	}

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
