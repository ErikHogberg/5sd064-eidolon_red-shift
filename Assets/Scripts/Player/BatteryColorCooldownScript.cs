using Assets.Scripts;
using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryColorCooldownScript : MonoBehaviour {

	public Color ReadyColor;
	public Color ChargingColor;

	//private Sprite readySprite;
	//public Sprite ChargingSprite;

	public int CooldownIndex;


	private Timer cooldown;

	private SpriteRenderer spriteRenderer;

	void Start() {
		spriteRenderer = GetComponent<SpriteRenderer>();
		//readySprite = spriteRenderer.sprite;
	}

	void Update() {
		if (cooldown == null) {
			cooldown = Globals.Player.GetComponentInChildren<WeaponScript>().AttackTimers[CooldownIndex];
		}
		
		if (cooldown.IsRunning()) {
			spriteRenderer.color = ChargingColor;
			//spriteRenderer.sprite = ChargingSprite;
		} else {
			spriteRenderer.color = ReadyColor;
			//spriteRenderer.sprite = readySprite;
		}

	}

}
