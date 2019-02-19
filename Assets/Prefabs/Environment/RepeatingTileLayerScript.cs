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

	// Use this for initialization
	void Start() {
		SpriteRenderer tile = GetComponentInChildren<SpriteRenderer>();


		// create copies of tile if it doesn't already have a series of tiles.
		//if (Layer.GetComponentsInChildren<SpriteRenderer>().Length == 1) {

		tileWidth = tile.bounds.size.x;
		tileOffsetX = tile.transform.localPosition.x;

		float cameraWidth = Camera.main.orthographicSize * 2f * Camera.main.aspect;
		int i = 0;

		float limit = cameraWidth;
		if (flipOnRepeat) {
			limit *= 2;
			tileOffsetX += tileWidth / 2;
		}

		while (tileWidth * i < limit) {
			i++;
			SpriteRenderer newTile = Instantiate<SpriteRenderer>(tile);
			newTile.transform.parent = transform;
			newTile.transform.localScale = tile.transform.localScale;
			newTile.transform.position = tile.transform.position + new Vector3(tileWidth * i, 0, 0);

			if (flipOnRepeat && i%2 == 1) {
				newTile.flipX = true;
			}

			if (i > 20) {
				break;
			}
		}

	}

	// Update is called once per frame
	void FixedUpdate() {

		float tilingLength = tileWidth;

		// TODO: move to init
		if (flipOnRepeat) {
			tilingLength *= 2;
		} 

		//foreach (var tile in GetComponentsInChildren<SpriteRenderer>()) {

		//float tileWidth = tile.bounds.size.x;
		float cameraHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;
		float cameraWidth = cameraHalfWidth * 2.0f;

		//float tileRightX = tile.transform.position.x + tileWidth / 2;
		float tileRightX = transform.position.x + tilingLength / 2 + tileOffsetX;
		float cameraLeftX = -cameraHalfWidth;

		if (tileRightX < cameraLeftX) {
			//float displacementAmount = tileWidth * (Mathf.Floor(cameraWidth / tileWidth) + 2);
			//float displacementAmount = tileWidth;
			displacementAmount += tilingLength;
			//tile.transform.position += new Vector3(

			//transform.localPosition += new Vector3(
			//	displacementAmount,
			//	0, 0
			//);

		}

		// displacement, parallax speed
		Vector3 localPosition = transform.localPosition;
		localPosition.x = (float)(transform.parent.position.x * ParallaxSpeed) + displacementAmount;

		transform.localPosition = localPosition;

		//}
	}
}
