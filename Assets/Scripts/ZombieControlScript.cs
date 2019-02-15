using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieControlScript : MonoBehaviour
{

	public ZombieState HordeState = ZombieState.Defensive;
	
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetAxis("Zombie State 1") > 0) {
			HordeState = ZombieState.Aggressive;
		}
		if (Input.GetAxis("Zombie State 2") > 0) {
			HordeState = ZombieState.Defensive;
		}
		if (Input.GetAxis("Zombie State 3") > 0) {
			HordeState = ZombieState.Passive;
		}


	}
}
