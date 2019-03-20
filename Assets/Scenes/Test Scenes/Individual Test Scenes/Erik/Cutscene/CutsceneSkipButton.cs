using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneSkipButton : MonoBehaviour {

	void Start() {
		GetComponent<Button>().onClick.AddListener(transform.parent.parent.GetComponentInChildren<CutsceneScript>().SwitchScene);
	}

}
