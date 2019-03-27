using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenHpBarScript : MonoBehaviour {

	public BossScript Queen;
	public BossScript King;
	private bool kingIsDead = false;

	public GameObject HpBar;
	public GameObject InvulnText;

	void Start() {

	}

	void Update() {

		float HpPercentage = Queen.GetHpPercentage();

		if (!kingIsDead) {
			if (King.GetHpPercentage() < 0.0f) {
				InvulnText.SetActive(false);
				kingIsDead = true;
			}
		}

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
