using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartWithLargeZombiesScript : MonoBehaviour {
	public List<GameObject> LargeZombies;

	void Start() {
		for (int i = 0; i < Globals.StartLargeZombies; i++) {
			LargeZombies[i].SetActive(true);
		}
	}

}
