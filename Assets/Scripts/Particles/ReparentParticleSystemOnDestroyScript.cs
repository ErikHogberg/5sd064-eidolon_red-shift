using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReparentParticleSystemOnDestroyScript : MonoBehaviour {
	private void OnDestroy() {
		var particleSystem = GetComponentInChildren<ParticleSystem>();
		particleSystem.Stop();
		GetComponentInChildren<ParticleSystem>().transform.parent = transform.parent;
	}
}
