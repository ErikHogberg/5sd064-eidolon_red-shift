using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxHostScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		foreach (Transform tr in transform) {
			if (tr.tag == "Parallax Layer") {
				tr.GetComponent<GameObject>();
				//Debug.Log("fount layer " + tr.name);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
