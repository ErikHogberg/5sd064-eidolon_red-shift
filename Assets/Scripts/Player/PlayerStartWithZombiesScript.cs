using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartWithZombiesScript : MonoBehaviour {

	public int StartZombieOverride = 0;
	public ZombieType type = ZombieType.Small;

	public List<GameObject> Zombies;

	void Start() {
		int zombieCount = Globals.StartSmallZombies;
		switch (type) {
			case ZombieType.Small:
				zombieCount = Globals.StartSmallZombies;
				Globals.StartSmallZombies = 0;
				break;
			case ZombieType.Large:
				zombieCount = Globals.StartLargeZombies;
				Globals.StartLargeZombies = 0;
				break;
		}
		if (StartZombieOverride > Globals.StartSmallZombies) {
			zombieCount = StartZombieOverride;
		}

		for (int i = 0; i < zombieCount; i++) {
			Zombies[i].SetActive(true);
			Zombies[i].transform.SetParent(transform.parent.parent.parent);
		}
		
	}

}
