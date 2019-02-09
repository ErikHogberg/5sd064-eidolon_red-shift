using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryLayerGeneratorScript : MonoBehaviour {

	// Use this for initialization
	void Start() {
		// adds a collision boundary to each child object 
		foreach (var item in GetComponentsInChildren<SpriteRenderer>()) {
			item.gameObject.AddComponent<BoxCollider2D>();
		}
		
	}

}
