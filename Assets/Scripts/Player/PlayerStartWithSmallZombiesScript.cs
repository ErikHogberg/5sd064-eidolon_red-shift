using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartWithSmallZombiesScript : MonoBehaviour {

	public List<GameObject> SmallZombies;

	void Start() {
		for (int i = 0; i < Globals.StartSmallZombies; i++) {
			SmallZombies[i].SetActive(true);
		}
	}
}
