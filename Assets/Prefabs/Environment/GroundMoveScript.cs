using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMoveScript : MonoBehaviour {

	public GameObject player;

	public float speed = 5;

	//public float minX;
	public float maxX = 5;
	public float minY= 2;
	public float max = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.x > maxX) {
			transform.localPosition += new Vector3(-Time.deltaTime*speed, 0, 0);
		}
	}
}
