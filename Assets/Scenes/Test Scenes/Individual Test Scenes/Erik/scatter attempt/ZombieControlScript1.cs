using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieControlScript1 : MonoBehaviour {

	public ZombieState HordeState = ZombieState.Defensive;
	public float ManualSpeed = 0.1f;

	private ZombieState preManualState;

	public float ScatterRadius;
	private Vector2 clickPos;
	private Vector2 dragPos;

	public float DragDistance {
		get { return (dragPos - clickPos).magnitude; }
	}

	public Vector2 DragDelta {
		get { return dragPos - clickPos; }
	}

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

		if (Input.GetAxis("Zombie State 1") > 0) {
			HordeState = ZombieState.Aggressive;
		}
		if (Input.GetAxis("Zombie State 2") > 0) {
			HordeState = ZombieState.Defensive;
		}
		if (Input.GetAxis("Zombie State 3") > 0) {
			HordeState = ZombieState.Passive;
		}

		// right click
		if (Input.GetMouseButtonDown(1)) {
			preManualState = HordeState;
			HordeState = ZombieState.Manual;
			clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		}
		if (Input.GetMouseButtonUp(1)) {
			HordeState = preManualState;
			if (DragDistance < 10.0f) {
				//HordeState 
			}
		}


		switch (HordeState) {
			case ZombieState.Aggressive:
				break;
			case ZombieState.Defensive:
				break;
			case ZombieState.Passive:
				break;
			case ZombieState.Manual:
				dragPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
				// TODO: draw line from clickPos to dragPos
				break;
			default:
				break;
		}


	}
}
