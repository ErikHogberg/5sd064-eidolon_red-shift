using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneScript : MonoBehaviour
{
	public string NextScene;
 
	public void SwitchScene() {
		if (NextScene == "") {
			return;
		}
		//SceneManager.LoadScene(NextScene, LoadSceneMode.Single);
		Globals.FadePanel.StartLevelTransition(NextScene);
	}
}
