using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QueenHpBarScript : MonoBehaviour {

	public BossScript Queen;
	public BossScript King;
	//private bool kingIsDead = false;

	public GameObject HpBar;
	public GameObject InvulnText;
	public Color InvulnColor;
	private Color OriginalColor;

	void Start() {
		var sprite = HpBar.GetComponentInChildren<Image>();
		OriginalColor = sprite.color;
		sprite.color = InvulnColor;
	}

	void Update() {

		float HpPercentage = Queen.GetHpPercentage();

		if (King.dead) {
			InvulnText.SetActive(false);
			HpBar.GetComponentInChildren<Image>().color = OriginalColor;
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
