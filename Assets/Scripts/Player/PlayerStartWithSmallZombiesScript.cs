using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartWithSmallZombiesScript : MonoBehaviour {

	public List<GameObject> SmallZombies;

	void Start() {
		int smallZombies = Globals.StartSmallZombies;
		for (int i = 0; i < smallZombies; i++) {
			SmallZombies[i].SetActive(true);
		}
		Globals.StartSmallZombies = 0;

	}
}
