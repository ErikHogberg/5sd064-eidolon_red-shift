using Assets.Scripts;
using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZombieState {
	Aggressive,
	Defensive,
	Passive,
	Manual,
	Scatter,
	// knocked down?
}


public class ZombieBehaviourScript : MonoBehaviour {

	public int Health = 100;

	// IDEA: create container script for assigning player semi-automatically, similar to parallax and repeating tile layers
	private ZombieControlScript Player;

	public float MaxFollowDistance = 3.0f;
	public float FollowSpeed = 5;
	public float AggressiveSpeed = 1;
	private float ManualSpeed;

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
				case ZombieState.Manual:

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
				case ZombieState.Manual:
					break;

				default:
					break;
			}

			state = value;
		}
	}

	private Rigidbody2D rb;

	private bool attacking = false;

	private Timer colorTimer;


	// Start is called before the first frame update
	void Start() {
		//Player = Globals.Player.GetComponent<ZombieControlScript>();
		//ManualSpeed = Player.ManualSpeed;
		state = InitialState;
		rb = GetComponent<Rigidbody2D>();

		colorTimer = new Timer(.2f);

	}

	// Update is called once per frame
	void FixedUpdate() {

		if (colorTimer.Update(Time.deltaTime)) {
			GetComponent<SpriteRenderer>().color = Color.white;
		}

		if (Player == null) {
			Player = Globals.Player.GetComponent<ZombieControlScript>();
			ManualSpeed = Player.ManualSpeed;

		}

		// Sets state to player state, skips if state is unchanged in order to avoid calling state accessor too often
		if (State != Player.HordeState) {
			State = Player.HordeState;
		}

		switch (State) {
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
			case ZombieState.Manual:
				Vector2 speed = Player.DragDelta * ManualSpeed;
				speed.x += Player.GetComponent<Rigidbody2D>().velocity.x;
				if (speed.x > 0) {
					speed.x = Mathf.Min(speed.x, AggressiveSpeed * 0.01667f);
				} else {
					speed.x = Mathf.Max(speed.x, -AggressiveSpeed * 0.01667f);
				}
				if (speed.y > 0) {
					speed.y = Mathf.Min(speed.y, AggressiveSpeed * 0.01667f);
				} else {
					speed.y = Mathf.Max(speed.y, -AggressiveSpeed * 0.01667f);
				}
				rb.velocity = speed;
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
			case ZombieState.Manual:
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
			case ZombieState.Manual:
				break;
			default:
				break;
		}
	}

	public void TakeDamage(int damage) {
		Health = Health - damage;

		GetComponent<SpriteRenderer>().color = Color.red;
		colorTimer.Restart();

		if (Health < 0 || Health == 0) {
			Destroy(gameObject);
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
		rb.velocity = new Vector2(AggressiveSpeed * 0.01667f, 0);
		// TODO: target/lock on to nearby enemy when in range
	}

}
