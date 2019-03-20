using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemSelfDestructScript : MonoBehaviour
{
	//private ParticleSystem ps;

	public void Start() {
		//ps = GetComponent<ParticleSystem>();
		//ps.simulationSpace = ParticleSystemSimulationSpace.Custom;//main.simulationSpace = Globals.Ground.transform;
		//ps.main.customSimulationSpace.parent = Globals.Ground.transform;
	}

	public void Update() {
		/*
		if (ps) {
			if (!ps.IsAlive()) {
				Destroy(gameObject);
			}
		}
		// */
	}
}
