using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarScript : MonoBehaviour {

	public GameObject HpBar;
	public GameObject HpOverflowBar;

	void Start() {

	}

	void Update() {

		float HpPercentage = Globals.Player.GetHpPercentage();
		float OverflowPercentage = 0.0f;

		if (HpPercentage > 1.0) {
			OverflowPercentage = HpPercentage - 1.0f;
			HpPercentage = 1.0f;
		} else if (HpPercentage < 0.0f) {
			HpPercentage = 0.0f;
		}

		Vector3 hpScale = HpBar.transform.localScale;
		Vector3 overflowScale = HpBar.transform.localScale;

		hpScale.x = HpPercentage;
		overflowScale.x = OverflowPercentage;

		HpBar.transform.localScale = hpScale;
		HpOverflowBar.transform.localScale = overflowScale;

	}

}
