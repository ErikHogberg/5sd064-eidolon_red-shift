using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZombieState {
	Aggressive,
	Defensive,
	Passive,
	// knocked down?
}


public class ZombieBehaviourScript : MonoBehaviour {

	// IDEA: create container script for assigning player semi-automatically, similar to parallax and repeating tile layers
	public GameObject Player;

	public float MaxFollowDistance = 3.0f;
	public float FollowSpeed = 5;
	public float AggressiveSpeed = 1;

	// State of zombie, decides its behaviour. Uses accessor to trigger transition events between state changes
	public ZombieState InitialState = ZombieState.Defensive;
	private ZombieState state;
	public ZombieState State {
		get { return state; }
		set {

			switch (state) {
				case ZombieState.Aggressive:
					attacking = false;
					break;
				case ZombieState.Defensive:
					break;
				case ZombieState.Passive:
					break;

				default:
					break;
			}

			switch (value) {
				case ZombieState.Aggressive:
					break;
				case ZombieState.Defensive:
					break;
				case ZombieState.Passive:
					break;

				default:
					break;
			}

			state = value;
		}
	}

	private Rigidbody2D rb;

	private bool attacking = false;


	// Start is called before the first frame update
	void Start() {
		state = InitialState;
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate() {

		// Sets state to player state, skips if state is unchanged in order to avoid calling state accessor too often
		if (State != Player.GetComponent<ZombieControlScript>().HordeState) {
			State = Player.GetComponent<ZombieControlScript>().HordeState;
		}

		switch (State) {
			//switch (Player.GetComponent<ZombieControlScript>().HordeState) {
			case ZombieState.Aggressive:
				if (!attacking) {
					FindEnemy();
				}
				break;
			case ZombieState.Defensive:
				FollowPlayer();
				break;
			case ZombieState.Passive:
				break;
			default:
				break;
		}
	}

	/*
	private void OnTriggerStay2D(Collider2D collision) {
		switch (State) {
			case ZombieState.Aggressive:
				if (collision.tag == "Enemy") {
					// IDEA: choose an enemy, keep attacking until enemy is dead, out of range, or zombie changes state, then it may choose another target
					attacking = true;
					rb.velocity = Vector2.zero;
				}
				break;
			case ZombieState.Defensive:
				break;
			case ZombieState.Passive:
				break;
			default:
				break;
		}
	}
	 */
	
	public void AttackAreaTriggerStay(Collider2D collision) {
		switch (State) {
			case ZombieState.Aggressive:
				if (collision.tag == "Enemy") {
					// IDEA: choose an enemy, keep attacking until enemy is dead, out of range, or zombie changes state, then it may choose another target
					attacking = true;
					rb.velocity = Vector2.zero;
				}
				break;
			case ZombieState.Defensive:
				break;
			case ZombieState.Passive:
				break;
			default:
				break;
		}
	}

	public void AttackAreaTriggerExit(Collider2D collision) {
		switch (State) {
			case ZombieState.Aggressive:
				if (collision.tag == "Enemy") {
					attacking = false;
				}
				break;
			case ZombieState.Defensive:
				break;
			case ZombieState.Passive:
				break;
			default:
				break;
		}
	}

	// 
	private void FollowPlayer() {

		Vector3 delta = transform.position - Player.transform.position;
		if (delta.sqrMagnitude > MaxFollowDistance * MaxFollowDistance) {

			float angle = Mathf.Atan2(delta.y, delta.x);
			//Vector2.SignedAngle(transform.position, Player.transform.position);

			Vector2 direction = new Vector2(
				Mathf.Cos(angle),
				Mathf.Sin(angle)
				);

			//rb.AddForce(direction * FollowSpeed);
			rb.velocity = direction * -FollowSpeed * Time.deltaTime;

		} else {
			// TODO: reposition zombie ahead of player, then move with player
			//rb.velocity = Vector2.zero;
			rb.velocity = Player.GetComponent<Rigidbody2D>().velocity;
		}

	}

	private void FindEnemy() {
		rb.velocity = new Vector2(FollowSpeed * Time.deltaTime, 0);
		//Collider cl;
	}

}
