using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingHpBarScript : MonoBehaviour {

	public BossScript King;

	public GameObject HpBar;

	void Start() {

	}

	void Update() {

		float HpPercentage = King.GetHpPercentage();

		if (HpPercentage > 1.0) {
			HpPercentage = 1.0f;
		} else if (HpPercentage < 0.0f) {
			HpPercentage = 0.0f;
		}

		Vector3 hpScale = HpBar.transform.localScale;

		hpScale.x = HpPercentage;

		HpBar.transform.localScale = hpScale;

	}

}
