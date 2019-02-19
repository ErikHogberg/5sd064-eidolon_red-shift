using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingTileLayerScript : MonoBehaviour {

	public double ParallaxSpeed = 0;

	public bool flipOnRepeat = false;

	// initial offset (distance) of tile from layer (parent)
	private float tileOffsetX;
	private float displacementAmount = 0;

	private float tileWidth;
	private float tilingLength;

	float cameraHalfWidth;
	float cameraWidth;

	// Use this for initialization
	void Start() {

		SpriteRenderer tile = GetComponentInChildren<SpriteRenderer>();

		tileWidth = tile.bounds.size.x;
		tileOffsetX = tile.transform.localPosition.x;

		tilingLength = tileWidth;

		if (flipOnRepeat) {
			// increase tiling to 2 tiles if cloned tile is flipped
			tilingLength *= 2;
		}

		cameraHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;
		cameraWidth = cameraHalfWidth * 2.0f;

		float limit = cameraWidth;
		if (flipOnRepeat) {
			// double amount of tiles created
			limit *= 2;
			// move the center of the tile to the center of both tiles, when measuring distance from center of camera
			tileOffsetX += tileWidth / 2;
		}

		int i = 0;
		while (tileWidth * i < limit) {
			i++;

			SpriteRenderer newTile = Instantiate(tile);
			newTile.transform.parent = transform;
			newTile.transform.localScale = tile.transform.localScale;
			newTile.transform.position = tile.transform.position + new Vector3(tileWidth * i, 0, 0);

			if (flipOnRepeat && i % 2 == 1) {
				newTile.flipX = true;
			}

			if (i > 20) {
				break;
			}
		}

	}

	void FixedUpdate() {

		float tileRightX = transform.position.x + tilingLength / 2 + tileOffsetX;
		float cameraLeftX = -cameraHalfWidth;

		if (tileRightX < cameraLeftX) {
			displacementAmount += tilingLength;
		}

		// displacement, parallax speed
		Vector3 localPosition = transform.localPosition;
		// FIXME: slower backgrounds are lagging again, precision error?
		localPosition.x = (float) (transform.parent.position.x * ParallaxSpeed) + displacementAmount;

		transform.localPosition = localPosition;

	}
}
