using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartWithLargeZombiesScript : MonoBehaviour {
	public List<GameObject> LargeZombies;

	void Start() {
		int largeZombies = Globals.StartLargeZombies;
		for (int i = 0; i < largeZombies; i++) {
			LargeZombies[i].SetActive(true);
		}
		Globals.StartLargeZombies = 0;
	}

}
