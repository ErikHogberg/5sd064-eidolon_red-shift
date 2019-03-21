using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransitionTriggerScript : MonoBehaviour
{
	public string TargetLevel;

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "Player") {
			//SceneManager.LoadScene(TargetLevel, LoadSceneMode.Single);
			Globals.FadePanel.StartLevelTransition(TargetLevel);
		}
	}
}
