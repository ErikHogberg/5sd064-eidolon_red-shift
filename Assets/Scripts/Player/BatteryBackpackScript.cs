using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryBackpackScript : MonoBehaviour {

	public List<GameObject> Batteries;

	public void SetActiveBatteries(int Count) {

		for (int i = 0; i < Count; i++) {
			if (i >= Batteries.Count) {
				return;
			}

			if (Batteries[i] != null) {
				Batteries[i].SetActive(true);
			}

		}
		
	}

}
