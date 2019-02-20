using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseScript : MonoBehaviour {
	public GameObject Zombie;

	public void SpawnZombie(ZombieControlScript player, GameObject ZombieTypeToSpawn) {
		var zombie = Instantiate(ZombieTypeToSpawn, transform.position, transform.rotation);
		zombie.transform.parent = transform.parent;
		zombie.GetComponent<ZombieBehaviourScript>().Player = player;
		Destroy(gameObject);
	}
}
