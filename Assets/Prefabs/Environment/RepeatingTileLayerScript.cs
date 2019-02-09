using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingTileLayerScript : MonoBehaviour {

	public bool flipOnRepeat = false;

	// Use this for initialization
	void Start() {
		SpriteRenderer tile = GetComponentInChildren<SpriteRenderer>();

		// create copies of tile if it doesn't already have a series of tiles.
		//if (Layer.GetComponentsInChildren<SpriteRenderer>().Length == 1) {

		float tileWidth = tile.bounds.size.x;
		float cameraWidth = Camera.main.orthographicSize * 2f * Camera.main.aspect;
		//*
		int i = 0;
		while (tileWidth * i < cameraWidth) {
			i++;
			SpriteRenderer newTile = Instantiate<SpriteRenderer>(tile);
			newTile.transform.parent = transform;
			newTile.transform.position += new Vector3(tileWidth * i, 0, 0);

			if (flipOnRepeat) {
				newTile.flipX = true;
			}

			if (i > 10) {
				break;
			}
		}
		// */

	}

	// Update is called once per frame
	void Update() {
		foreach (var tile in GetComponentsInChildren<SpriteRenderer>()) {
			float tileWidth = tile.bounds.size.x;
			float cameraHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;
			float cameraWidth = cameraHalfWidth * 2.0f;

			if (tile.transform.position.x - tileWidth / 2 + cameraHalfWidth < -tileWidth) {
				tile.transform.position += new Vector3(
					tileWidth * (Mathf.Floor(cameraWidth / tileWidth) + 2),
					0, 0);
			}

		}
	}
}
