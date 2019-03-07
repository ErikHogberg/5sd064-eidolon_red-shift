using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReparentParticleSystemOnDestroyScript : MonoBehaviour {
	private void OnDestroy() {
		GetComponentInChildren<ParticleSystem>().transform.parent = transform.parent;
	}
}
