using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonScripts : MonoBehaviour {

	void Start() {

	}

	void Update() {

	}

	public void StartLevel(string level) {
		SceneManager.LoadScene(level, LoadSceneMode.Single);
	}

	public void StartForestLevel() {
		StartLevel("Forest Level");
	}

	public void QuitGame() {
		Application.Quit();
	}

	public void RestartScene() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
	}

}
