﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingTileHostScript : MonoBehaviour {



	// Use this for initialization
	void Start() {

		// prepare repeating tiles
		foreach (RepeatingTileLayerScript layer in GetComponentsInChildren<RepeatingTileLayerScript>()) {
			SpriteRenderer tile = layer.GetComponentInChildren<SpriteRenderer>();

			// create copies of tile if it doesn't already have a series of tiles.
			//if (Layer.GetComponentsInChildren<SpriteRenderer>().Length == 1) {

			float tileWidth = tile.bounds.size.x;

			// TODO: create enough tiles to fill screen width
			/*
			int i = 0;
			while (tileWidth * i < Camera.current.rect.width) {
				RepeatingTileScript newTile = Instantiate<RepeatingTileScript>(item);
				newTile.transform.parent = item.transform;
				newTile.transform.position += new Vector3(tileWidth*i,0,0);
				i++;
				if (i > 10) {
					break;
				}
			}
			// */

			//*
			SpriteRenderer newTile = Instantiate<SpriteRenderer>(tile);
			//newTile.transform.position.Set(0, 0, newTile.transform.position.z);
			newTile.transform.parent = layer.transform;
			newTile.transform.position += new Vector3(tileWidth, 0, 0);

			if (layer.flipOnRepeat) {
				newTile.flipX = true;
			}
			// */


			//}
		}
	}

	// Update is called once per frame
	void Update() {

		foreach (RepeatingTileLayerScript Layer in GetComponentsInChildren<RepeatingTileLayerScript>()) {
			foreach (var tile in Layer.GetComponentsInChildren<SpriteRenderer>()) {

				float tileWidth = tile.GetComponent<SpriteRenderer>().bounds.size.x;
				if (tile.transform.position.x < -tileWidth) {
					tile.transform.position += new Vector3(tileWidth * 2, 0, 0);
				}

			}
		}

	}
}
