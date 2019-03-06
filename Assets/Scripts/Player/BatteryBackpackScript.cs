using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryBackpackScript : MonoBehaviour
{

	public GameObject Battery1;
	public GameObject Battery2;
	public GameObject Battery3;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
		if (Count > 0) {
			Battery1.SetActive(true);
		}
		if (Count > 1) {
			Battery2.SetActive(true);
		}
		if (Count > 2) {
			Battery3.SetActive(true);
		}
	}

}
