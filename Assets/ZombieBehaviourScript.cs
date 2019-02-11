using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZombieState {
	Aggressive,
	Defensive,
	Passive,
	// knocked down?
}


public class ZombieBehaviourScript : MonoBehaviour
{

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
			switch (value) {
				case ZombieState.Aggressive:
					break;
				case ZombieState.Defensive:
					break;
				default:
					break;
			}

			state = value;
		}
	}

	private Rigidbody2D rb;


	// Start is called before the first frame update
	void Start()
	{
		state = InitialState;
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		switch (state) {
		//switch (Player.GetComponent<ZombieControlScript>().ZombieState)
        //{
            case ZombieState.Aggressive:
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

}
