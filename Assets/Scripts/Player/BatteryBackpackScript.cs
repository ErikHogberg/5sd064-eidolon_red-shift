using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryBackpackScript : MonoBehaviour {

	public GameObject Battery1;
	public GameObject Battery2;
	public GameObject Battery3;
	public GameObject Battery4;
	public GameObject Battery5;
	public GameObject Battery6;
	//public List<GameObject> Batteries;

	void Start() {

	}

	void Update() {

	}

	/*
	private int CountBatteries() {
		int batteries = 1; // always start with one battery thats not a separate sprite
		foreach (GameObject child in GetComponentsInChildren<GameObject>()) {
			if (child.tag == "Battery") {
				batteries++;
			}
		}

		return batteries;
	}
	 */

	/*
	public void AddBattery() {
		int numberOfBatteries = CountBatteries();
		if (numberOfBatteries == 1) {
			GetComponentInChildren<GameObject>().SetActive(true);
		}
	}
	 */

	public void SetActiveBatteries(int Count) {
		if (Count > 0 && Battery1 != null) {
			Battery1.SetActive(true);
		}
		if (Count > 1 && Battery2 != null) {
			Battery2.SetActive(true);
		}
		if (Count > 2 && Battery3 != null) {
			Battery3.SetActive(true);
		}
		if (Count > 3 && Battery4 != null) {
			Battery4.SetActive(true);
		}
		if (Count > 4 && Battery5 != null) {
			Battery5.SetActive(true);
		}
		if (Count > 5 && Battery6 != null) {
			Battery6.SetActive(true);
		}

	}

}
